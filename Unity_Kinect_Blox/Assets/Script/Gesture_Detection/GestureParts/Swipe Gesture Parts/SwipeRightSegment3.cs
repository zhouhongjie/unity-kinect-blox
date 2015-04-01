namespace AssemblyCSharp
{
	using Kinect;

    /// <summary>
    /// The third part of the swipe right gesture
    /// </summary>
    public class SwipeRightSegment3 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
            // //left hand in front of left Shoulder
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft].z && 
			    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
			{
				// Debug.Log("GesturePart 2 - left hand in front of left Shoulder - PASS");
                // //left hand below shoulder height but above hip height
				if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y && 
				    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
				{
					// Debug.Log("GesturePart 2 - left hand below shoulder height but above hip height - PASS");
                    // //left hand left of left Shoulder
					if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x)
                    {
						// Debug.Log("GesturePart 2 - left hand left of left Shoulder - PASS");
                        return GesturePartResult.Suceed;
                    }

					// Debug.Log("GesturePart 2 - left hand left of left Shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

				// Debug.Log("GesturePart 2 - left hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

			// Debug.Log("GesturePart 2 - left hand in front of left Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
}
