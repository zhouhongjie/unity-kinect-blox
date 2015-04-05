namespace AssemblyCSharp
{
    using System;
    using Kinect;
	using UnityEngine;

    /// <summary>
    /// A single gesture
    /// </summary>
    public class Gesture
    {
		/// <summary>
		/// Number of pause Frames when matching segment
		/// </summary>
		public int pauseFramesBeetweenHits = 10;
		/// <summary>
		/// Number of pause Frames when not matching segment
		/// </summary>
		public int pauseFramesBeetweenNonHits = 5;
        
        private IRelativeGestureSegment[] gestureParts;
        private int currentGesturePart = 0;
		private int pausedFrameCount = 10;
        private int frameCount = 0;
        private bool paused = false;
        private GestureType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gesture"/> class.
        /// </summary>
        /// <param name="type">The type of gesture.</param>
        /// <param name="gestureParts">The gesture parts.</param>
        public Gesture(GestureType type, IRelativeGestureSegment[] gestureParts)
        {
            this.gestureParts = gestureParts;
            this.type = type;
        }

        /// <summary>
        /// Occurs when [gesture recognised].
        /// </summary>
        public event EventHandler<SwipeGestureEventArgs> GestureRecognised;

        /// <summary>
        /// Updates the gesture.
        /// </summary>
        /// <param name="data">The skeleton data.</param>
		public void UpdateGesture(GestureUpdatePackage data)
        {
			// check if time for this segment is over
            if (this.paused)
            {
                if (this.frameCount == this.pausedFrameCount)
                {
                    this.paused = false;
                }

                this.frameCount++;
            }

            GesturePartResult result = this.gestureParts[this.currentGesturePart].CheckGesture(data.sw);
            if (result == GesturePartResult.Suceed)
            {
                if (this.currentGesturePart + 1 < this.gestureParts.Length)
                {
                    this.currentGesturePart++;
                    this.frameCount = 0;
					this.pausedFrameCount = pauseFramesBeetweenHits;
                    this.paused = true;
                }
                else
                {
                    if (this.GestureRecognised != null)
                    {
						Vector3 handRightPos = data.sw.bonePos[0, (int) Kinect.NuiSkeletonPositionIndex.HandRight];
						Vector3 handLeftPos = data.sw.bonePos[0, (int) Kinect.NuiSkeletonPositionIndex.HandLeft];
						this.GestureRecognised(this, new SwipeGestureEventArgs(this.type, data.trackingId, data.userId, handLeftPos, handRightPos));
                        this.Reset();
                    }
                }
            }
            else if (result == GesturePartResult.Fail || this.frameCount == 50)
            {
                this.currentGesturePart = 0;
                this.frameCount = 0;
				this.pausedFrameCount = pauseFramesBeetweenNonHits;
                this.paused = true;
            }
            else
            {
                this.frameCount++;
				this.pausedFrameCount = pauseFramesBeetweenNonHits;
                this.paused = true;
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            this.currentGesturePart = 0;
            this.frameCount = 0;
			this.pausedFrameCount = pauseFramesBeetweenNonHits;
            this.paused = true;
        }
    }
}
