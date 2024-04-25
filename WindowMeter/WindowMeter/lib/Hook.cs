using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;

namespace WindowMeter
{
    public delegate void MyCallback(string message);

    public class Hook
    {
        // Import the necessary functions from the user32.dll library
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // Define the delegate for the keyboard hook procedure
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Define constants for hook types and key codes
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int VK_SNAPSHOT = 0x2C;

        private static LowLevelKeyboardProc _keyboardProc;
        private static IntPtr _hookId = IntPtr.Zero;

        public static MyCallback callback = null;

        public static void Register(MyCallback callback)
        {
            // Set up the keyboard hook
            _keyboardProc = HookCallback;
            _hookId = SetHook(_keyboardProc);

            Hook.callback = callback;
        }

        public static void UnRegister()
        {
            UnhookWindowsHookEx(_hookId);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            IntPtr hInstance = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, hInstance, 0);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == VK_SNAPSHOT)
                {
                    // Handle the Print Screen button press
                    Console.WriteLine("Print Screen button pressed!");

                    if (Hook.callback != null) {
                        Hook.callback("test");
                    }
                }
            }

            // Call the next hook in the hook chain
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
    }
}
