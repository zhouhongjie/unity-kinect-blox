using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GestureChecker : MonoBehaviour {
	// can be set over unity
	public SkeletonWrapper sw;

	private GestureControler gc = null;
	private int userId = 0; // just one player game
	private int trackingId = 0;

	// Use this for initialization
	void Start () {
		// Creating gesture
		gc = new GestureControler ();

		// Left Hand
		IRelativeGestureSegment[] swipeGestureLeftSegments = new IRelativeGestureSegment[3];
		swipeGestureLeftSegments[0] = new SwipeLeftSegment1();
		swipeGestureLeftSegments[1] = new SwipeLeftSegment2();
		swipeGestureLeftSegments[2] = new SwipeLeftSegment3();
		gc.AddGesture (GestureType.LeftSwipe, swipeGestureLeftSegments);
		// Right Hand
		IRelativeGestureSegment[] swipeGestureRightSegments = new IRelativeGestureSegment[3];
		swipeGestureRightSegments[0] = new SwipeLeftSegment1();
		swipeGestureRightSegments[1] = new SwipeLeftSegment2();
		swipeGestureRightSegments[2] = new SwipeLeftSegment3();
		gc.AddGesture (GestureType.RightSwipe, swipeGestureRightSegments);
		// register event callback
		gc.GestureRecognised += SwipeDetected;
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
		GestureUpdatePackage gup = new GestureUpdatePackage(sw, userId, trackingId);
		gc.UpdateAllGestures(gup);
	}
}
