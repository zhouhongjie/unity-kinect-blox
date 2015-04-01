namespace AssemblyCSharp
{
    using Kinect;
	//using UnityEngine; // just for debug

    /// <summary>
    /// The first part of the swipe left gesture
    /// </summary>
    public class SwipeLeftSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
			//Right hand in front of right shoulder 
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].z && 
			    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
            {
				// Debug.Log("GesturePart 0 - Right hand in front of right shoudler - PASS");
                // //right hand below shoulder height but above hip height
				if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y && 
				    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
                {
					// Debug.Log("GesturePart 0 - right hand below shoulder height but above hip height - PASS");
                    // //right hand right of right shoulder
					if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x)
                    {
						// Debug.Log("GesturePart 0 - right hand right of right shoulder - PASS");
                        return GesturePartResult.Suceed;    
                    }

					// Debug.Log("GesturePart 0 - right hand right of right shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }
				// Debug.Log("GesturePart 0 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

			// Debug.Log("GesturePart 0 - Right hand in front of right shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
}