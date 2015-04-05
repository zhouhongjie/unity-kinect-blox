namespace AssemblyCSharp
{
	using Kinect;

    public class SwipeRightSegment2 : IRelativeGestureSegment
    {
		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
            // //left hand in front of left Shoulder
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft].z && 
			    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
			{
				// Debug.Log("GesturePart 1 - left hand in front of left Shoulder - PASS");
                // /left hand below shoulder height but above hip height
				if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y && 
				    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
				{
					// Debug.Log("GesturePart 1 - left hand below shoulder height but above hip height - PASS");
                    // //left hand left of left Shoulder
					if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x && 
					    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].x > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft].x)
					{
						// Debug.Log("GesturePart 1 - left hand left of left Shoulder - PASS");
                        return GesturePartResult.Suceed;
                    }

					// Debug.Log("GesturePart 1 - left hand left of left Shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

				// Debug.Log("GesturePart 1 - left hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

			// Debug.Log("GesturePart 1 - left hand in front of left Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
}