namespace StageKit
{
    /// <summary>
    /// Represents the speed of the strobe light.
    /// </summary>
    public enum StrobeSpeed : short
    {
        /// <summary>
        /// Represents the slowest speed of the strobe light.
        /// </summary>
        Slow = 0x300,
        /// <summary>
        /// Represents the medium speed of the strobe light.
        /// </summary>
        Medium = 0x400,
        /// <summary>
        /// Represents the fast speed of the strobe light.
        /// </summary>
        Faster = 0x500,
        /// <summary>
        /// Represents the fastest speed of the strobe light.
        /// </summary>
        Fastest = 0x600,
    }
}
