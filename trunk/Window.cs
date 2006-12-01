#region Copyright(c) 2006 ZO, All right reserved.
// -----------------------------------------------------------------------------
// Copyright(c) 2006 ZO, All right reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//   1.  Redistribution of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//   2.  Redistribution in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//   3.  The name of the author may not be used to endorse or promote products
//       derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
// EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// -----------------------------------------------------------------------------
#endregion


#region Using directives

using System;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using ZO.SmartCore.Core;
using ArgumentNullException= ZO.SmartCore.Core.ArgumentNullException;
using System.Text;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Represent a Window
    /// </summary>
    public class Window : DisposableObject
    {

        #region Constructors
             /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Window(int value)
        {
            this._Handle = new WindowHandle(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public Window(WindowHandle handle)
        {
            this._Handle = handle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Window(IntPtr value)
        {
            this._Handle = new WindowHandle(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public Window(IWin32Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            this._Handle = new WindowHandle(window);
        }
        #endregion

        #region Destructor

        #endregion

        #region Fields
        private WindowHandle _Handle;

    
        #endregion

        #region Events

        #endregion

        #region Operators

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public WindowHandle Handle
        {
            get { return _Handle; }
        }


        /// <summary>
        /// Gets or sets the instance handle of calling process.
        /// </summary>
        public static InstanceHandle HINSTANCE
        {
            get { return UnsafeNativeMethods.GetModuleHandle(null); }
        }


        /// <summary>
        /// Gets the name of the current process.
        /// </summary>
        /// <value>The name of the current process.</value>
        public static string ProcessName
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                StringBuilder sb = new StringBuilder(0x400);
                int num = UnsafeNativeMethods.GetModuleFileName(HINSTANCE, sb, sb.Capacity);
                return sb.ToString();
            }
        }


        /// <summary>
        /// Get the dimensions of the bounding rectangle of the window.
        /// </summary>
        public Rectangle WindowRect
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                RECT rect = UnsafeNativeMethods.GetWindowRect(this.Handle);

                return rect.ToRectangle();
            }
        }

        /// <summary>
        /// Gets the name of the class to which the specified window belongs.
        /// </summary>
        /// <value>The name of the class.</value>
        public String ClassName
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return UnsafeNativeMethods.GetClassName(this.Handle);
            }
        }

        /// <summary>
        /// Gets window's parent or owner.
        /// </summary>
        public Window Parent
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return new Window(UnsafeNativeMethods.GetParent(this.Handle));
            }

        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Window"/> is exists.
        /// </summary>
        /// <value><c>true</c> if exists; otherwise, <c>false</c>.</value>
        public bool Exists
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return UnsafeNativeMethods.IsWindow(this.Handle);
            }
        }



        /// <summary>
        /// Determines whether specified window is a messagebox.
        /// </summary>
        /// <returns>
        /// 	<see langword="true"/> if [is message box] [the specified handle]; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsMessageBox
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                if (this.ClassName == "#32770")
                {


                    if ((UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Abort) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Cancel) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Continue) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Ignore) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.NO) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.OK) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Retry) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.TryAgain) != WindowHandle.Empty) ||
                        (UnsafeNativeMethods.GetDlgItem(this.Handle, MessageBoxItem.Yes) != WindowHandle.Empty))
                    {
                        if (UnsafeNativeMethods.FindWindow(this.Handle, "COMBOBOX") != WindowHandle.Empty ||
                    UnsafeNativeMethods.FindWindow(this.Handle, "EDIT") != WindowHandle.Empty)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }


                    }
                }

                return false;
            }

        }

        /// <summary>
        /// Gets the thread ID of the calling thread.
        /// </summary>
        public static long ThreadID
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return SafeNativeMethods.GetCurrentThreadID();
            }
        }


        /// <summary>
        /// Gets the process ID of the calling process.
        /// </summary>
        public static long ProcessID
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                return SafeNativeMethods.GetCurrentProcessID();
            }
        }
        #endregion

        #region Methods
      
    


        /// <summary>
        /// Move the control with the specified size and location.
        /// </summary>
        /// <param name="left">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control.</param>
        /// <param name="top">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control.</param>
        /// <param name="width">The <see cref="P:System.Drawing.Size.Width"></see> of the control.</param>
        /// <param name="height">The <see cref="P:System.Drawing.Size.Height"></see> of the control.</param>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public bool Move(int left, int top, int width, int height)
        {
            return UnsafeNativeMethods.MoveWindow(this.Handle, left, top, width, height, true);
        }




        /// <summary>
        /// Move the control with the specified size and location.
        /// </summary>
        /// <param name="window">window to move.</param>
        /// <summary>Updates the bounds of the control with the specified size and location.</summary>
        /// <param name="top">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
        /// <param name="width">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
        /// <param name="height">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
        /// <param name="left">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public static void Move(IWin32Window window, int left, int top, int width, int height)
        {
            UnsafeNativeMethods.MoveWindow(window, left, top, width, height, true);
        }

        #endregion
    }
}
