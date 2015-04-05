namespace AssemblyCSharp
{
    using Kinect;
	//using UnityEngine; // just for debug
	
    public class PushLeftSegment1 : IRelativeGestureSegment
    {
		private const double NEAR_DEF = 0.2;

		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
			// Right hand shoulder (depth)
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft].z + NEAR_DEF)
			{
					return GesturePartResult.Suceed;
			}
			return GesturePartResult.Fail;
        }
    }
}