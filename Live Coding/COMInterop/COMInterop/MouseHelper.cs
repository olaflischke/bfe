using System.Runtime.InteropServices;

namespace COMInterop
{
    public class MouseHelper
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SwapMouseButton([param: MarshalAs(UnmanagedType.Bool)] bool fSwap);

        public void MakeRightButtonPrimary()
        {
            SwapMouseButton(true);
        }

        public void MakeLeftButtonPrimary()
        {
            SwapMouseButton(false);
        }
    }
}