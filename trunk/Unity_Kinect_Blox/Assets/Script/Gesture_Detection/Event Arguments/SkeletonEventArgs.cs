namespace AssemblyCSharp
{
    #region using...

    using System;
    using Kinect;

    #endregion

    /// <summary>
    /// The skeleton event args
    /// </summary>
    public class SkeletonEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkeletonEventArgs"/> class.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        public SkeletonEventArgs(Kinect.NuiSkeletonData skeleton)
        {
            this.Skeleton = skeleton;
        }

        /// <summary>
        /// Gets or sets the skeleton.
        /// </summary>
        /// <value>
        /// The skeleton.
        /// </value>
		public Kinect.NuiSkeletonData Skeleton
        { 
            get; 
            set; 
        }
    }
}
