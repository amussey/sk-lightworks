#if !XBOX
using System;
using System.Diagnostics;

namespace Microsoft.XBox
{
    internal static class GamePad
    {
        private static bool[] _disconnected;
        private static long[] _lastReadTime;

        static GamePad()
        {
            _disconnected = new bool[4];
            _lastReadTime = new long[4];
        }

        public static bool SetVibration(PlayerIndex playerIndex, short leftMotor, short rightMotor)
        {
            XINPUT_VIBRATION xinput_vibration;
            xinput_vibration.LeftMotorSpeed = leftMotor;
            xinput_vibration.RightMotorSpeed = rightMotor;
            ErrorCodes success = ErrorCodes.Success;
            if (ThrottleDisconnectedRetries(playerIndex))
            {
                success = ErrorCodes.NotConnected;
            }
            else
            {
                success = UnsafeMethods.SetState(playerIndex, ref xinput_vibration);
                ResetThrottleState(playerIndex, success);
            }
            if (success == ErrorCodes.Success)
            {
                return true;
            }
            if (((success != ErrorCodes.Success) && (success != ErrorCodes.NotConnected)) && (success != ErrorCodes.Busy))
            {
                throw new InvalidOperationException("Invalid Controller");
            }
            return false;
        }
        private static void ResetThrottleState(PlayerIndex playerIndex, ErrorCodes result)
        {
            if ((playerIndex >= PlayerIndex.One) && (playerIndex <= PlayerIndex.Four))
            {
                if (result == ErrorCodes.NotConnected)
                {
                    _disconnected[(int)playerIndex] = true;
                    _lastReadTime[(int)playerIndex] = Stopwatch.GetTimestamp();
                }
                else
                {
                    _disconnected[(int)playerIndex] = false;
                }
            }
        }
        private static bool ThrottleDisconnectedRetries(PlayerIndex playerIndex)
        {
            if (((playerIndex >= PlayerIndex.One) && (playerIndex <= PlayerIndex.Four)) && _disconnected[(int)playerIndex])
            {
                long timestamp = Stopwatch.GetTimestamp();
                for (int i = 0; i < 4; i++)
                {
                    if (_disconnected[i])
                    {
                        long num3 = timestamp - _lastReadTime[i];
                        long frequency = Stopwatch.Frequency;
                        if (i != (int)playerIndex)
                        {
                            frequency /= 4L;
                        }
                        if ((num3 >= 0L) && (num3 <= frequency))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
#endif