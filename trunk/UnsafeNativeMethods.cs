using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace ZO.SmartCore.Interop.Windows
{
    [SuppressUnmanagedCodeSecurity, HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    internal static class UnsafeNativeMethods
    {
        /// <summary>
        /// passes the hook information to the next hook procedure in the current hook chain.
        /// </summary>
        /// <param name="hook">Ignored</param>
        /// <param name="code">The code.</param>
        /// <param name="wParam">Specifies the wParam value passed to the current hook procedure.</param>
        /// <param name="lParam">Specifies the lParam value passed to the current hook procedure.</param>
        /// <returns>This value is returned by the next hook procedure in the chain. The current hook 
        /// procedure must also return this value. The meaning of the return value depends on the hook type.</returns>
        [DllImport(Constants.User32, CharSet = CharSet.Auto, EntryPoint = "CallNextHookEx", ExactSpelling = true)]
        public static extern IntPtr CallNextHook(HookHandle hook, int code, IntPtr wParam, IntPtr lParam);


        ///// <summary>
        ///// passes the hook information to the next hook procedure in the current hook chain.
        ///// </summary>
        ///// <param name="hook">Ignored</param>
        ///// <param name="code">The code.</param>
        ///// <param name="wParam">Specifies the wParam value passed to the current hook procedure.</param>
        ///// <param name="lParam">Specifies the lParam value passed to the current hook procedure.</param>
        ///// <returns>This value is returned by the next hook procedure in the chain. The current hook 
        ///// procedure must also return this value. The meaning of the return value depends on the hook type.</returns>
        //[DllImport(Constants.Hooks, CharSet = CharSet.Auto, EntryPoint = "CallHook", ExactSpelling = true, CallingConvention=CallingConvention.StdCall)]
        //public static extern IntPtr CallHook(HookHandle hook, int code, IntPtr wParam, IntPtr lParam);


        ///// <summary>
        ///// removes a hook procedure installed in a hook chain by the SetWindowsHookEx function. 
        ///// </summary>
        ///// <param name="hook">Handle to the hook to be removed.</param>
        ///// <returns>If the function succeeds, the return value is nonzero.
        ///// If the function fails, the return value is zero.</returns>
        //[return: MarshalAs(UnmanagedType.Bool)]
        //[DllImport(Constants.Hooks, CharSet = CharSet.Auto, EntryPoint = "UninstallHook", SetLastError = true, CallingConvention=CallingConvention.StdCall)]
        //public static extern bool UninstallHook(HookHandle hook);

        /// <summary>
        /// removes a hook procedure installed in a hook chain by the SetWindowsHookEx function. 
        /// </summary>
        /// <param name="hook">Handle to the hook to be removed.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32, CharSet = CharSet.Auto, EntryPoint = "UnhookWindowsHookEx", SetLastError = true)]
        public static extern bool UnhookWindowsHook(HookHandle hook);


        /// <summary>
        /// installs an application-defined hook procedure into a hook chain.
        /// </summary>
        /// <param name="hookType">Specifies the type of hook procedure to be installed.</param>
        /// <param name="proc">Pointer to the hook procedure. If the <paramref name="threadID"/> 
        /// parameter is zero or specifies the identifier of a thread created by a different process,
        /// the <paramref name="proc"/> parameter must point to a hook procedure in a dynamic-link library (DLL). 
        /// Otherwise, <paramref name="proc"/> can point to a hook procedure in the code associated with 
        /// the current process. </param>
        /// <param name="hMod">Handle to the DLL containing the hook procedure pointed to by the <paramref name="proc"/> parameter.
        /// The hMod parameter must be set to NULL if the <paramref name="threadID"/> parameter specifies a thread created by
        /// the current process and if the hook procedure is within the code associated with the current process.</param>
        /// <param name="threadID">Specifies the identifier of the thread with which the hook procedure is to be 
        /// associated. If this parameter is zero, the hook procedure is associated with all existing 
        /// threads running in the same desktop as the calling thread..</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure. 
        /// If the function fails, the return value is NULL.</returns>
        [DllImport(Constants.User32, EntryPoint = "SetWindowsHookEx", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern HookHandle SetWindowsHook(HookType hookType, HookProc proc, InstanceHandle hMod, uint threadID);


        ///// <summary>
        ///// installs an application-defined hook procedure into a hook chain.
        ///// </summary>
        ///// <param name="hookType">Specifies the type of hook procedure to be installed.</param>
        ///// <param name="proc">Pointer to the hook procedure. If the <paramref name="threadID"/> 
        ///// parameter is zero or specifies the identifier of a thread created by a different process,
        ///// the <paramref name="proc"/> parameter must point to a hook procedure in a dynamic-link library (DLL). 
        ///// Otherwise, <paramref name="proc"/> can point to a hook procedure in the code associated with 
        ///// the current process. </param>
        ///// <param name="threadID">Specifies the identifier of the thread with which the hook procedure is to be 
        ///// associated. If this parameter is zero, the hook procedure is associated with all existing 
        ///// threads running in the same desktop as the calling thread..</param>
        ///// <returns>If the function succeeds, the return value is the handle to the hook procedure. 
        ///// If the function fails, the return value is NULL.</returns>
        //[DllImport(Constants.Hooks, EntryPoint = "InstallHook", SetLastError = true, CharSet = CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
        //public static extern HookHandle InstallHook(HookType hookType, HookProc proc, uint threadID);


        /// <summary>
        /// retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd">Handle to the window whose parent window handle is to be retrieved. </param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. 
        /// If the window is a top-level window, the return value is a handle to the owner window. If the window is a top-level unowned window or if the function fails, the return value is NULL. </returns>
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern WindowHandle GetParent(WindowHandle hWnd);


        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="handle">A handle.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32)]
        private static extern bool ClientToScreen(WindowHandle handle, ref POINT point);

        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="handle">A handle.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        public static POINT ClientToScreen(WindowHandle handle, POINT point)
        {
            POINT point1 = point;
            if (!ClientToScreen(handle, ref point1))
            {
                throw new Win32Exception();
            }
            return point1;
        }


        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="window">A window.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        public static POINT ClientToScreen(IWin32Window window, POINT point)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            POINT point1 = point;
            if (!ClientToScreen(new WindowHandle(window), ref point1))
            {
                throw new Win32Exception();
            }
            return point1;
        }

        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="handle">A handle.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32)]
        private static extern bool ScreenToClient(WindowHandle handle, ref POINT point);

        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="handle">A handle.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        public static POINT ScreenToClient(WindowHandle handle, POINT point)
        {
            POINT point1 = point;
            if (!ScreenToClient(handle, ref point1))
            {
                throw new Win32Exception();
            }
            return point1;
        }


        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="window">A window.</param>
        /// <param name="point">A point.</param>
        /// <returns></returns>
        public static POINT ScreenToClient(IWin32Window window, POINT point)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            POINT point1 = point;
            if (!ScreenToClient(new WindowHandle(window), ref point1))
            {
                throw new Win32Exception();
            }
            return point1;
        }


        /// <summary>
        /// calculates the intersection of two source rectangles and places 
        /// the coordinates of the intersection rectangle into the destination rectangle.
        /// </summary>
        /// <param name="destination">Pointer to the RECT structure that is to receive the intersection of the rectangles .</param>
        /// <param name="source1">Pointer to the RECT structure that contains the first source rectangle. .</param>
        /// <param name="source2">Pointer to the RECT structure that contains the second source rectangle. .</param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32)]
        public static extern bool IntersectRect([Out] IntPtr destination, [In] IntPtr source1, [In] IntPtr source2);


        /// <summary>
        /// Intersects the rect.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static RECT IntersectRect(RECT rect1, RECT rect2)
        {
            RECT rect3;
            int num1 = RECT.GetSize();
            IntPtr ptr1 = Marshal.AllocHGlobal(num1);
            IntPtr ptr2 = Marshal.AllocHGlobal(num1);
            IntPtr ptr3 = Marshal.AllocHGlobal(num1);
            try
            {
                Marshal.StructureToPtr(rect1, ptr2, false);
                Marshal.StructureToPtr(rect2, ptr3, false);
                if (!IntersectRect(ptr1, ptr2, ptr3))
                {
                    throw new Win32Exception();
                }
                rect3 = (RECT)Marshal.PtrToStructure(ptr1, typeof(RECT));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr1);
                Marshal.FreeHGlobal(ptr2);
                Marshal.FreeHGlobal(ptr3);
            }
            return rect3;
        }

        /// <summary>
        ///  returns a handle to the desktop window. The desktop window covers the entire screen.
        ///  The desktop window is the area on top of which other windows are painted. 
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern WindowHandle GetDesktopWindow();


        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="handle">A handle.</param>
        /// <returns></returns>
        public static RECT GetWindowRect(WindowHandle handle)
        {
            RECT rect1 = RECT.Empty;
            if (!GetWindowRect(handle, ref rect1))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return rect1;
        }

        /// <summary>
        /// retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the
        /// upper-left corner of the screen.
        /// </summary>
        /// <param name="window">window for which dimension is returned.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        public static RECT GetWindowRect(IWin32Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            RECT rect1 = RECT.Empty;
            if (!GetWindowRect(new WindowHandle(window), ref rect1))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return rect1;
        }


        /// <summary>
        /// retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the
        /// upper-left corner of the screen.
        /// </summary>
        /// <param name="handle">Handle to the window.</param>
        /// <param name="rect">Pointer to a structure that receives the screen coordinates of the
        /// upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern bool GetWindowRect(WindowHandle handle, [In, Out] ref RECT rect);


        /// <summary>
        /// retrieves a handle to a window whose class name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, string className)
        {
            return FindWindow(parent.Handle, IntPtr.Zero, className, null);
        }

        /// <summary>
        /// retrieves a handle to a window whose class name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(WindowHandle parent, IWin32Window childAfter, string className)
        {
            return FindWindow(parent, childAfter.Handle, className, null);
        }


        /// <summary>
        /// retrieves a handle to a window whose class name match the specified string.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, WindowHandle childAfter, string className)
        {
            return FindWindow(parent.Handle, childAfter, className, null);
        }


        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <param name="windowName">specifies the window name (the window title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, string className, string windowName)
        {
            return FindWindow(parent.Handle, IntPtr.Zero, className, windowName);
        }

        /// <summary>
        /// retrieves a handle to a window whose class name match the specified string.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, IWin32Window childAfter, string className)
        {
            return FindWindow(parent.Handle, childAfter.Handle, className, null);
        }

        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <param name="windowName">specifies the window name (the window title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(WindowHandle parent, IWin32Window childAfter, string className, string windowName)
        {
            return FindWindow(parent, childAfter.Handle, className, windowName);
        }

        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <param name="windowName">specifies the window name (the window title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(WindowHandle parent, WindowHandle childAfter, string className, string windowName)
        {
            IntPtr ptr1 = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            if (!String.IsNullOrEmpty(className))
            {
                ptr1 = Marshal.StringToHGlobalAuto(className);
            }
            while (true)
            {
                if (!String.IsNullOrEmpty(windowName))
                {
                    ptr2 = Marshal.StringToHGlobalAuto(windowName);
                }
                try
                {
                    return FindWindow(parent, childAfter, ptr1, ptr2);
                }
                finally
                {
                    if (ptr1 != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(ptr1);
                    }
                    if (ptr2 != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(ptr2);
                    }
                }
            }
        }



        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">Handle to the parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">Handle to a child window. The search begins with the next child
        /// window in the Z order. The child window must be a direct child window of hwndParent, 
        /// not just a descendant window.</param>
        /// <param name="className">Pointer to a null-terminated string that specifies the class name or a class atom.</param>
        /// <param name="windowName">Pointer to a null-terminated string that specifies the window name (the window's title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(Constants.User32, EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindow(IntPtr parent, IntPtr childAfter,
            IntPtr className, IntPtr windowName);



        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <param name="windowName">specifies the window name (the window title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, WindowHandle childAfter, string className, string windowName)
        {
            return FindWindow(parent.Handle, childAfter, className, windowName);
        }


        /// <summary>
        /// retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parent">parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">The child after.</param>
        /// <param name="className">specifies the class name or a class atom.</param>
        /// <param name="windowName">specifies the window name (the window title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has 
        /// the specified class and window names.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static WindowHandle FindWindow(IWin32Window parent, IWin32Window childAfter, string className, string windowName)
        {
            return FindWindow(parent.Handle, childAfter.Handle, className, windowName);
        }



        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="uCmd">The u CMD.</param>
        /// <returns></returns>
        [DllImport(Constants.User32)]
        public static extern IntPtr GetWindow(IntPtr hWnd, WindowRelationship uCmd);

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="relationship">The relationship.</param>
        /// <returns></returns>
        public static WindowHandle GetWindow(IWin32Window window, WindowRelationship relationship)
        {
            return GetWindow(window.Handle, relationship);
        }

        /// <summary>
        /// Returns the DC for the entire window, including including title bar, menus, and scroll bars.
        /// </summary>
        [DllImport(Constants.User32)]
        public static extern IntPtr GetWindowDC(WindowHandle window);


        /// <summary>
        /// changes the position and dimensions of the specified window.
        /// For a top-level window, the position and dimensions are relative to the 
        /// upper-left corner of the screen. For a child window, they are 
        /// relative to the upper-left corner of the parent window's client area. 
        /// </summary>
        /// <param name="handle">Handle to the window. </param>
        /// <param name="x">Specifies the new position of the left side of the window.</param>
        /// <param name="y">Specifies the new position of the top of the window. </param>
        /// <param name="width">Specifies the new width of the window. </param>
        /// <param name="height">Specifies the new height of the window. </param>
        /// <param name="repaint">Specifies whether the window is to be repainted.
        /// If this parameter is TRUE, the window receives a message. If the parameter is FALSE,
        /// no repainting of any kind occurs. This applies to the client area, the nonclient
        /// area (including the title bar and scroll bars), and any part of the parent 
        /// window uncovered as a result of moving a child window. </param>
        /// <returns>If the function succeeds, the return value is <see langword="true" />
        /// If the function fails, the return value is <see langword="false" />. </returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern bool MoveWindow(WindowHandle handle, int x, int y, int width, int height,
            [MarshalAs(UnmanagedType.Bool)] bool repaint);


        /// <summary>
        /// changes the position and dimensions of the specified window.
        /// For a top-level window, the position and dimensions are relative to the 
        /// upper-left corner of the screen. For a child window, they are 
        /// relative to the upper-left corner of the parent window's client area. 
        /// </summary>
        /// <param name="window">window to move.</param>
        /// <param name="x">Specifies the new position of the left side of the window.</param>
        /// <param name="y">Specifies the new position of the top of the window. </param>
        /// <param name="width">Specifies the new width of the window. </param>
        /// <param name="height">Specifies the new height of the window. </param>
        /// <param name="repaint">Specifies whether the window is to be repainted.
        /// If this parameter is TRUE, the window receives a message. If the parameter is FALSE,
        /// no repainting of any kind occurs. This applies to the client area, the nonclient
        /// area (including the title bar and scroll bars), and any part of the parent 
        /// window uncovered as a result of moving a child window. </param>
        /// <returns>If the function succeeds, the return value is <see langword="true" />
        /// If the function fails, the return value is <see langword="false" />. </returns>
        public static void MoveWindow(IWin32Window window, int x, int y, int width, int height,
            [MarshalAs(UnmanagedType.Bool)] bool repaint)
        {
            if (!MoveWindow(new WindowHandle(window), x, y, width, height, repaint))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }


        /// <summary>
        /// retrieves the name of the class to which the specified window belongs. 
        /// </summary>
        /// <param name="hWnd">Handle to the window and, indirectly, the class to which the window belongs. </param>
        /// <param name="className">Pointer to the buffer that is to receive the class name string. </param>
        /// <param name="maxCount">Specifies the length, of the buffer pointed to by the lpClassName parameter</param>
        /// <returns>the return value is the number of char copied to the specified buffer.</returns>
        [DllImport(Constants.User32)]
        public static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder className, int maxCount);

        /// <summary>
        /// retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="window">The window for which class name is returned.</param>
        /// <returns>class name of specified window</returns>
        public static string GetClassName(IWin32Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            StringBuilder builder1 = new StringBuilder(0x100);
            int num1 = GetClassName(window.Handle, builder1, 0x100);
            return builder1.ToString(0, num1);
        }

        /// <summary>
        /// retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>class name of specified window</returns>
        public static string GetClassName(WindowHandle handle)
        {
            StringBuilder builder1 = new StringBuilder(0x100);
            int num1 = GetClassName(handle, builder1, 0x100);
            return builder1.ToString(0, num1);
        }

        /// <summary>
        /// retrieves the handle to a control in the specified dialog box.
        /// </summary>
        /// <param name="hWnd">Handle to the dialog box that contains the control.</param>
        /// <param name="dlgItem">Specifies the identifier of the control to be retrieved.</param>
        /// <returns>The window handle of the specified control indicates success. NULL indicates
        /// failure due to an invalid dialog box handle or a nonexistent control.</returns>
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern WindowHandle GetDlgItem(WindowHandle hWnd, int dlgItem);

        /// <summary>
        /// retrieves the handle to a control in the specified dialog box.
        /// </summary>
        /// <param name="hWnd">Handle to the dialog box that contains the control.</param>
        /// <param name="dlgItem">Specifies the identifier of the control to be retrieved.</param>
        /// <returns>The window handle of the specified control indicates success. NULL indicates
        /// failure due to an invalid dialog box handle or a nonexistent control.</returns>
        public static WindowHandle GetDlgItem(WindowHandle hWnd, MessageBoxItem dlgItem)
        {
            return GetDlgItem(hWnd, (int)dlgItem);
        }

        /// <summary>
        /// determines whether the specified window handle identifies an existing window. 
        /// </summary>
        /// <param name="hWnd"> Handle to the window to test.</param>
        /// <returns>If the window handle identifies an existing window, the return value is true.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(Constants.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// determines whether the specified window handle identifies an existing window. 
        /// </summary>
        /// <param name="hWnd"> Handle to the window to test.</param>
        /// <returns>If the window handle identifies an existing window, the return value is true.</returns>
        public static bool IsWindow(WindowHandle hWnd)
        {
            if (hWnd == WindowHandle.Empty)
            {
                return false;
            }
            return IsWindow(hWnd.Handle);
        }

        /// <summary>
        /// retrieves a module handle for the specified module if the file has been mapped 
        /// into the address space of the calling process.
        /// </summary>
        /// <param name="moduleName">Pointer to a null-terminated string that contains the name of the module (either a .dll or .exe file).</param>
        /// <returns>If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).</returns>
        [DllImport(Constants.Kernel32, CharSet = CharSet.Auto, SetLastError=true)]
        public static extern ModuleHandle GetModuleHandle([MarshalAs(UnmanagedType.LPTStr)] string moduleName);

        /// <summary>
        /// Retrieves the fully-qualified path for the file that contains the specified module. 
        /// The module must have been loaded by the current process.
        /// </summary>
        /// <param name="module">Handle to the loaded module whose path is being requested.</param>
        /// <param name="fileName">Pointer to a buffer that receives the fully-qualified path of the module.</param>
        /// <param name="length">The length of the fileName buffer.</param>
        /// <returns></returns>
        [DllImport(Constants.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetModuleFileName([In] ModuleHandle module, [Out] StringBuilder fileName, [In, MarshalAs(UnmanagedType.U4)] int length);

    }
}
