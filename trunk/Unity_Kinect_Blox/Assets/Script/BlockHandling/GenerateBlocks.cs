﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace AssemblyCSharp
{
	public class GenerateBlocks : MonoBehaviour {

		// Container for a sample
		class AudioSample{
			public double SampleNumber { set; get; }
			public double Intensity { set; get; }
		}

		public enum Difficulty { EASY, MEDIUM, HARD};
		public static int CurrentScore { get; set;}
		public string pathToCsv = "";
		public Difficulty actualDifficulty = Difficulty.EASY;

		// Mapping CSV to Audiosample Object
		private const int NUMBER_OF_VALUES_PER_LINE = 2;
		private const int POSITION_OF_SAMPLENUMBER = 1;
		private const int POSITION_OF_INTENTSITY = 2;
		// module global list containing samples	
		private List<AudioSample> samples = null;
		private const int SAMPLES_PER_SECOND = 43;
		private int currentPositionSamples = 0;

		//Properties for color, position
		private Color[] colors = {Color.red, Color.blue, Color.yellow, Color.green, Color.magenta, Color.cyan};
		private System.Random random = new System.Random();
		private const float X_COORDINATE = 64f;
		private const float Y_COORDINATE = 22.5f;
		private const float Z_COORDINATE = -7f;
		private const int TUNNEL_WIDTH = 13;
		private const int TUNNEL_HEIGHT = 10;
		private const float TUNNEL_LENGTH = -40f;
		private const float POSTION_OF_DESTROY = -33f;
		private Vector3[] rotatings = {new Vector3(1,0,0), new Vector3(0,1,0), new Vector3(0,0,1)};
		private float speed = 2f;

		private static List<GameObject> cubes = new List<GameObject>();

		// Hud with score
		void OnGUI()
		{
			GUI.Box(new Rect(20, 20, 100, 20), "Score : " + CurrentScore);
		}

		// Use this for initialization
		void Start () {
			string content = ReadCSV (pathToCsv);
			samples = extractSamples (content); 

			InvokeRepeating("generateBlocksForSample", 0, (float) 1.0);
			InvokeRepeating("moveBlocks", 0, (float) 0.1);
		}
		
		// Update is called once per frame
		void Update () {
			// do nothing
		}

		public static void DeleteCubeFromList(GameObject cube){
			cubes.Remove(cube);
			Destroy (cube);
		}

		List<AudioSample> extractSamples(string csvContent)
		{
			List<AudioSample> samples = new List<AudioSample> ();
			var values = csvContent.Split (',');
			
			for (int line = 0; line < (values.Length / NUMBER_OF_VALUES_PER_LINE); line++) {
				AudioSample sample = new AudioSample();
				sample.SampleNumber = Convert.ToDouble(values[(line * POSITION_OF_SAMPLENUMBER*2)]);
				sample.Intensity = Convert.ToDouble(values[(line * POSITION_OF_INTENTSITY)+1]);
				samples.Add(sample);
			}
			return samples;
		}
		
		string ReadCSV(string path){
			FileInfo csvInputFile = new FileInfo (path);
			StreamReader reader = csvInputFile.OpenText();
			string csvContent="";
			string line;
			
			do
			{
				line = reader.ReadLine();
				if(line != null)
					csvContent += line+",";
			} while (line != null);    
			
			return csvContent;
		}

		void moveBlocks(){
			GameObject[] toDelete = new GameObject[cubes.Count];
			int rotating = 0;

			foreach (GameObject c in cubes) {
				Vector3 target = new Vector3 (TUNNEL_LENGTH, c.transform.position.y, c.transform.position.z);
				c.transform.position = Vector3.Lerp (c.transform.position, target, Time.deltaTime * speed);
				c.transform.Rotate(rotatings[(rotating++) % rotatings.Length]);

				if (c.transform.position.x <= POSTION_OF_DESTROY) {
					CurrentScore--;
					toDelete[cubes.IndexOf(c)] =c;
				}
			}
			
			for (int i =0; i<toDelete.Length; i++) {
				GameObject c = toDelete[i];
				if(c != null){
					cubes.Remove(c);
					toDelete[i] = null;
					Destroy(c);
				}
			}
		}


		
		// Generate Blocks according to samples in global list
		void generateBlocksForSample(){
			List<AudioSample> samplesOfSecond = samples.GetRange (currentPositionSamples, SAMPLES_PER_SECOND);
			double averageIntesity;
			double additiveIntensity = 0;
			
			foreach (AudioSample sample in samplesOfSecond) {
				additiveIntensity += sample.Intensity;
			}
			
			averageIntesity = additiveIntensity / samplesOfSecond.Capacity;

			currentPositionSamples += SAMPLES_PER_SECOND;
			if (currentPositionSamples + SAMPLES_PER_SECOND >= samples.Count)
				currentPositionSamples = 0;

			var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			var v = new Vector3 ();
			v.Set (X_COORDINATE,(float)(Y_COORDINATE+random.Next(TUNNEL_HEIGHT)), (float)(Z_COORDINATE+random.Next(TUNNEL_WIDTH)));
			cube.transform.position = v;
			cube.GetComponent<Renderer> ().material.color = colors[random.Next(colors.Length)];
			v.Set(1,1,1);
			cube.transform.localScale = v;

			cube.AddComponent<Rigidbody> ();
			cube.GetComponent<Rigidbody> ().useGravity = false;
			cube.name = "Blox";

			cubes.Add (cube);
			// Set Current Speed of all Blocks according to current Intensity
			if (averageIntesity > 0 && averageIntesity < 100) {
				speed = 2f;
			} else if (averageIntesity >= 100 && averageIntesity < 500) {
				speed = 4f;
			} else if (averageIntesity >= 500) {
				speed = 7f;
			}

			float multiplier = 1;
			switch (actualDifficulty) {
			case Difficulty.EASY:
				multiplier = 0.5f;
				break;
			case Difficulty.MEDIUM:
				multiplier = 1;
				break;
			case Difficulty.HARD:
				multiplier = 1.5f;
				break;
			}
			speed *= multiplier;
		}
}
}