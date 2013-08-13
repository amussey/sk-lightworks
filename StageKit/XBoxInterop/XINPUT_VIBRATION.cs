#if !XBOX
using System.Runtime.InteropServices;

namespace Microsoft.XBox
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XINPUT_VIBRATION
    {
        public short LeftMotorSpeed;
        public short RightMotorSpeed;
    }
}
#endif