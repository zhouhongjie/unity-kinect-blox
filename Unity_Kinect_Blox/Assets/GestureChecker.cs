using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GestureChecker : MonoBehaviour {
	// can be set over unity
	public SkeletonWrapper sw;
	public int pauseFramesIfNotHit = 5;
	public int pauseFramesIfHit = 10;
	public enum Gesture {Swipe, Push};
	public Gesture SelectedGesture = Gesture.Push;

	private GestureControler gc = null;
	private int userId = 0; // just one player game
	private int trackingId = 0;

	private void addSwipeGestures(){
		// Left Hand
		IRelativeGestureSegment[] swipeGestureLeftSegments = new IRelativeGestureSegment[2];
		swipeGestureLeftSegments [0] = new SwipeLeftSegment1();
		swipeGestureLeftSegments [1] = new SwipeLeftSegment2();
		swipeGestureLeftSegments [2] = new SwipeLeftSegment3();
		gc.AddGesture (GestureType.LeftSwipe, swipeGestureLeftSegments);
		// Right Hand
		IRelativeGestureSegment[] swipeGestureRightSegments = new IRelativeGestureSegment[2];
		swipeGestureRightSegments[0] = new SwipeRightSegment1();
		swipeGestureRightSegments[1] = new SwipeRightSegment2();
		swipeGestureRightSegments[2] = new SwipeRightSegment3();
		gc.AddGesture (GestureType.RightSwipe, swipeGestureRightSegments);
	}

	private void addPushGestures(){
		// Right Hand
		IRelativeGestureSegment[] pushRightSegments = new IRelativeGestureSegment[2];
		pushRightSegments [0] = new PushRightSegment1();
		pushRightSegments [1] = new PushRightSegment2();
		gc.AddGesture (GestureType.PushRight, pushRightSegments);
		// Left Hand
		IRelativeGestureSegment[] pushLeftSegments = new IRelativeGestureSegment[2];
		pushLeftSegments [0] = new PushLeftSegment1();
		pushLeftSegments [1] = new PushLeftSegment2();
		gc.AddGesture (GestureType.PushRight, pushLeftSegments);
	}

	// Use this for initialization
	void Start () {
		// Creating gesture
		gc = new GestureControler ();

		if (SelectedGesture.Equals(Gesture.Swipe)) {
			addSwipeGestures ();
			// register event callback
			gc.GestureRecognised += SwipeDetected;
		} else if (SelectedGesture.Equals(Gesture.Push)) {
			addPushGestures ();
			// register event callback
			gc.GestureRecognised += PushDetected;
		}

	}

	private void PushDetected(object sender, SwipeGestureEventArgs args){
		Vector3 ShotFrom = new Vector3();
		
		if (args.GestureType.Equals (GestureType.PushRight)) {
			ShotFrom = args.rightHandPos;
		} else if (args.GestureType.Equals (GestureType.PushLeft)) {
			ShotFrom = args.leftHandPos;
		}
		
		// TODO: make the shoot
		Debug.Log("Shooting at " + ShotFrom.x + ":" + ShotFrom.y);
	}

	private void SwipeDetected(object sender, SwipeGestureEventArgs args){
		Vector3 ShotFrom = new Vector3();

		if (args.GestureType.Equals (GestureType.LeftSwipe)) {
			ShotFrom = args.leftHandPos;
		} else if (args.GestureType.Equals (GestureType.RightSwipe)) {
			ShotFrom = args.rightHandPos;
		}

		// TODO: make the shoot
		Debug.Log("Shooting at " + ShotFrom.x + ":" + ShotFrom.y);
	}

	
	// Update is called once per frame
	void Update () {
		GestureUpdatePackage gup = new GestureUpdatePackage(sw, userId, trackingId++);
		gc.UpdateAllGestures(gup);
	}
}
