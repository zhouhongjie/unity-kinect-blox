using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

public class NewBehaviourScript : MonoBehaviour {
	// Container for a sample
	class AudioSample{
		public int SampleNumber { set; get; }
		public int Intensity { set; get; }
		public int Beats { set; get; }
	}

	public string pathToCsv = "";

	// Mapping CSV to Audiosample Object
	private const int NUMBER_OF_VALUES_PER_LINE = 3;
	private const int POSITION_OF_SAMPLENUMBER = 1;
	private const int POSITION_OF_INTENTSITY = 2;
	private const int POSITION_OF_BEATS = 3;
	// module global list containing samples	
	private List<AudioSample> samples = null;
	private const int SAMPLES_PER_SECOND = 1000;
	private int currentPositionSamples = 0;

	// Use this for initialization
	void Start () {
		string content = ReadCSV (pathToCsv);
		samples = extractSamples (content); 

		InvokeRepeating("generateBlocksForSample", 0, (float) 1.0);
	}

	// Update is called once per frame
	void Update () {
		// do nothing
	}

	List<AudioSample> extractSamples(string csvContent)
	{
		List<AudioSample> samples = new List<AudioSample> ();
		var values = csvContent.Split (';');

		for (int line = 0; line <= (values.Length / NUMBER_OF_VALUES_PER_LINE); line++) {
			AudioSample sample = new AudioSample();
			sample.SampleNumber = Convert.ToInt32(values[(line * POSITION_OF_SAMPLENUMBER)]);
			sample.Intensity = Convert.ToInt32(values[(line * POSITION_OF_INTENTSITY)]);
			sample.Beats = Convert.ToInt32(values[(line * POSITION_OF_BEATS)]);
			samples.Add(sample);
		}
		return samples;
	}

	string ReadCSV(string path){
		FileInfo csvInputFile = new FileInfo (path);
		StreamReader reader = csvInputFile.OpenText();
		string csvContent;
		
		do
		{
			csvContent = reader.ReadLine();
		} while (csvContent != null);    

		return csvContent;
	}

	// Generate Blocks according to samples in global list
	void generateBlocksForSample(){
		List<AudioSample> samplesOfSecond = samples.GetRange (currentPositionSamples, SAMPLES_PER_SECOND);
		int averageIntesity;
		int additiveIntensity = 0;
		int averageBeatsInSecond;
		int additiveBeats = 0;

		foreach (AudioSample sample in samplesOfSecond) {
			additiveIntensity += sample.Intensity;
			additiveBeats += sample.Beats;
		}

		averageIntesity = additiveIntensity / samplesOfSecond.Capacity;
		averageBeatsInSecond = additiveBeats / samplesOfSecond.Capacity;

		// Todo: Make Blox - Cubes with setter
		/*
		 * 			Blox c = new Blox();
		 * 			c.setStartPosition(x, y);
		 * 			c.setColor(BLUE);
		 * 			c.setSpeed();
		 * 
		 * 			add to BlocksLive -> Composition
		 */
		BlocksLive allBlocks = new BlocksLive();

		// Create Blocks according to Beats in second
		if (averageBeatsInSecond > 0 && averageBeatsInSecond < 10) {
			// TODO: create f.e. 3 Blocks and add it to parent (Block Container)
			// give them random Color
		}else if (averageBeatsInSecond >= 10 && averageBeatsInSecond < 100){
			// TODO: create f.e. 4 Blocks nd add it to parent (Block Container)
			// give them random Color
		}

		// Set Current Speed of all Blocks according to current Intensity
		if (averageIntesity > 0 && averageIntesity < 10) {
			allBlocks.currentSpeed = 1;
		}else if (averageIntesity >= 10 && averageIntesity < 100){
			allBlocks.currentSpeed = 2;
		}

		currentPositionSamples += samplesOfSecond.Capacity;
	}
}
