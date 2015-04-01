namespace AssemblyCSharp
{
    using System;
	using UnityEngine;
	using Kinect;

    /// <summary>
    /// The swipe gesture event arguments
    /// </summary>
    public class SwipeGestureEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GestureEventArgs"/> class.
        /// </summary>
        /// <param name="type">The gesture type.</param>
        /// <param name="trackingID">The tracking ID.</param>
        /// <param name="userID">The user ID.</param>
		/// <param name="y">leftHandPos - coordinate in last segment of left hand</param>
		/// <param name="z">rightHandPos - coordinate in last segment of right hand</param>
		public SwipeGestureEventArgs(GestureType type, int trackingID, int userID, Vector3 leftHandPos, Vector3 rightHandPos)
        {
            this.TrackingID = trackingID;
            this.UserID = userID;
            this.GestureType = type;
			this.leftHandPos = leftHandPos;
			this.rightHandPos = rightHandPos;
        }

		/// <summary>
		/// Gets or sets leftHandPos
		/// </summary>
		/// <value>
		/// The leftHandPos 
		/// </value>
		public Vector3 leftHandPos
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets leftHandPos
		/// </summary>
		/// <value>
		/// The leftHandPos 
		/// </value>
		public Vector3 rightHandPos
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the type of the gesture.
        /// </summary>
        /// <value>
        /// The type of the gesture.
        /// </value>
        public GestureType GestureType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tracking ID.
        /// </summary>
        /// <value>
        /// The tracking ID.
        /// </value>
        public int TrackingID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>
        /// The user ID.
        /// </value>
        public int UserID
        {
            get;
            set;
        }
    }
}
