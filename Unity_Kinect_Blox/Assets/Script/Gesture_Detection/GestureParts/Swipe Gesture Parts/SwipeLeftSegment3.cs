﻿namespace AssemblyCSharp
{
    using Kinect;
	using UnityEngine; // just for debug
	
    public class SwipeLeftSegment3 : IRelativeGestureSegment
    {
		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
            // //Right hand in front of right Shoulder
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].z && 
			    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
            {
				// Debug.Log("GesturePart 2 - Right hand in front of right shoulder - PASS");
                // //right hand below shoulder height but above hip height
				if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y && 
				    skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
                {
					// Debug.Log("GesturePart 2 - right hand below shoulder height but above hip height - PASS");
                    // //right hand left of left Shoulder
					if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft].x)
                    {
                        Debug.Log("GesturePart 2 - right hand left of left Shoulder - PASS");
                        return GesturePartResult.Suceed;
                    }

					Debug.Log("GesturePart 2 - right hand left of right Shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

				// Debug.Log("GesturePart 2 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

			// Debug.Log("GesturePart 2 - Right hand in front of right Shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
}