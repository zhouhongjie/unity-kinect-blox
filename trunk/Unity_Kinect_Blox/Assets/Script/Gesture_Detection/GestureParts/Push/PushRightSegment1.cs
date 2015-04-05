namespace AssemblyCSharp
{
    using Kinect;
	using UnityEngine; // just for debug
	
    public class PushRightSegment1 : IRelativeGestureSegment
    {
		private const double NEAR_DEF = 0.2;

		public GesturePartResult CheckGesture(SkeletonWrapper skeleton)
        {
			// Right hand shoulder (depth)
			if (skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z < skeleton.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].z + NEAR_DEF)
			{
					return GesturePartResult.Suceed;
			}
			return GesturePartResult.Fail;
        }
    }
}