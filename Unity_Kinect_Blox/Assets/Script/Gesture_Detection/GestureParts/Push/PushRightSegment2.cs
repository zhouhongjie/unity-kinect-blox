namespace AssemblyCSharp
{
	using Kinect;
	using UnityEngine; // just for debug
	
	public class PushRightSegment2 : IRelativeGestureSegment
	{
		private const double NEAR_DEF = 0.45;
		
		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
		{
			//float pfote = skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z;
			//float schulter = skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].z;
			//Debug.Log("Failin so hard: Hand: " + pfote + " shoulder: " + schulter);
			// Right hand in front of hip (depth)
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z > skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].z + NEAR_DEF)
			{
				return GesturePartResult.Suceed;
			}

			// will set to fail after hundret tries
			return GesturePartResult.Pausing;
		}
	}
}