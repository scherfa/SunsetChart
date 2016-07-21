using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SunsetChart.MSChartExtension
{
    static class WindowMessagesNativeMethods
    {
        #region [ Suspend / Resume Drawing ]
        [DllImport("user32.dll")]
        private static extern long SendMessage(IntPtr hWnd, int wMsg, [MarshalAs(UnmanagedType.Bool)] bool wParam, int lParam);

        private const int WM_SETREDRAW = 11;
        public static void SuspendDrawing(Control parent) { SendMessage(parent.Handle, WM_SETREDRAW, false, 0); }
        public static void ResumeDrawing(Control parent) { SendMessage(parent.Handle, WM_SETREDRAW, true, 0); parent.Refresh(); }
        #endregion

    }
}
