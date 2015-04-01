using System;
namespace AssemblyCSharp
{
	public class GestureUpdatePackage
	{
		public SkeletonWrapper sw { get; set; }
		public int userId { get; set; }
		public int trackingId { get; set; }

		public GestureUpdatePackage (SkeletonWrapper sw, int userId, int trackingId)
		{
			this.sw = sw;
			this.userId = userId;
			this.trackingId = trackingId;
		}
	}
}

