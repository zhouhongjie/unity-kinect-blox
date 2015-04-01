namespace AssemblyCSharp
{
    /// <summary>
    /// the gesture part result
    /// </summary>
    public enum GesturePartResult 
    {
        /// <summary>
        /// Gesture part fail
        /// </summary>
        Fail,

        /// <summary>
        /// Gesture part suceed
        /// </summary>
        Suceed,

        /// <summary>
        /// Gesture part result undetermined
        /// </summary>
        Pausing 
    }

    /// <summary>
    /// The gesture type
    /// </summary>
    public enum GestureType 
    {
        /// <summary>
        /// Swiped left
        /// </summary>
        LeftSwipe,

        /// <summary>
        /// swiped right
        /// </summary>
        RightSwipe 
    }
}
