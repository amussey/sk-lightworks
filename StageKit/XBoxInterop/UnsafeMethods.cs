#if !XBOX
using System.Runtime.InteropServices;

namespace Microsoft.XBox
{
    internal static class UnsafeMethods
    {
        [DllImport("xinput1_3.dll", EntryPoint = "XInputSetState")]
        public static extern ErrorCodes SetState(PlayerIndex playerIndex, ref XINPUT_VIBRATION pVibration);
    }
}
#endif