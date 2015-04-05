using System;
using System.Collections.Generic;
using Kinect;

namespace AssemblyCSharp
{
	/// <summary>
	/// The gesture controler
	/// </summary>
	public class GestureControler
	{
		/// <summary>
		/// Number of pause Frames when matching segment
		/// </summary>
		public int pauseFramesBeetweenHits = 10;
		/// <summary>
		/// Number of pause Frames when not matching segment
		/// </summary>
		public int pauseFramesBeetweenNonHits = 5;
		/// <summary>
		/// The list of all gestures we are currently looking for
		/// </summary>
		private List<Gesture> gestures = new List<Gesture>();
		
		/// <summary>
		/// Initializes a new instance of the <see cref="GestureControler"/> class.
		/// </summary>
		public GestureControler()
		{
		}
		
		/// <summary>
		/// Occurs when [gesture recognised].
		/// </summary>
		public event EventHandler<SwipeGestureEventArgs> GestureRecognised;
		
		/// <summary>
		/// Updates all gestures.
		/// </summary>
		/// <param name="data">The skeleton data.</param>
		public void UpdateAllGestures(GestureUpdatePackage data)
		{
			foreach (Gesture gesture in this.gestures)
			{
				gesture.UpdateGesture(data);
			}
		}
		
		/// <summary>
		/// Adds the gesture.
		/// </summary>
		/// <param name="type">The gesture type.</param>
		/// <param name="gestureDefinition">The gesture definition.</param>
		public void AddGesture(GestureType type, IRelativeGestureSegment[] gestureDefinition)
		{
			Gesture gesture = new Gesture(type, gestureDefinition);
			gesture.pauseFramesBeetweenHits = pauseFramesBeetweenHits;
			gesture.pauseFramesBeetweenNonHits = pauseFramesBeetweenNonHits;
			gesture.GestureRecognised += new EventHandler<SwipeGestureEventArgs>(this.Gesture_GestureRecognised);
			this.gestures.Add(gesture);
		}
		
		/// <summary>
		/// Handles the GestureRecognised event of the g control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="KinectSkeltonTracker.GestureEventArgs"/> instance containing the event data.</param>
		private void Gesture_GestureRecognised(object sender, SwipeGestureEventArgs e)
		{
			if (this.GestureRecognised != null)
			{
				this.GestureRecognised(this, e);
			}
			
			foreach (Gesture g in this.gestures)
			{
				g.Reset();
			}
		}
	}
}

