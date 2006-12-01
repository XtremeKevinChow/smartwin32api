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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using ArgumentNullException= ZO.SmartCore.Core.ArgumentNullException;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Represent a Handle to a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowHandle : IWin32Window
    {

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHandle"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public WindowHandle(int value)
        {
            this._Handle = new IntPtr(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHandle"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public WindowHandle(IntPtr value)
        {
            this._Handle = value;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHandle"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public WindowHandle(IWin32Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException("window");
            }
            this._Handle = window.Handle;
        }
        #endregion

        #region Destructor

        #endregion

        #region Fields

        private IntPtr _Handle;

        /// <summary>
        /// Empty WindowHandle
        /// </summary>
        private static readonly WindowHandle _Empty = new WindowHandle(IntPtr.Zero);

        #endregion

        #region Events

        #endregion

        #region Operators

        /// <summary>
        /// Operator ==s the specified a HWND1.
        /// </summary>
        /// <param name="handle1">A HWND1.</param>
        /// <param name="handle2">A HWND2.</param>
        /// <returns></returns>
        public static bool operator ==(WindowHandle handle1, WindowHandle handle2)
        {
            //if (handle1 != WindowHandle.Empty)
            //{
            //    return handle1.Equals(handle2);
            //}
            //return (handle2 == WindowHandle.Empty);

            return handle1.Equals(handle2);
        }


        /// <summary>
        /// Operator ==s the specified a WindowHandle.
        /// </summary>
        /// <param name="handle">A WindowHandle.</param>
        /// <param name="ptr">A int PTR.</param>
        /// <returns></returns>
        public static bool operator ==(WindowHandle handle, IntPtr ptr)
        {
            //if (handle != WindowHandle.Empty)
            //{
            //    return handle.Equals(ptr);
            //}
            //return (ptr == IntPtr.Zero);

            return handle.Equals(ptr);
        }


        /// <summary>
        /// Operator ==s the specified a int PTR.
        /// </summary>
        /// <param name="ptr">A int PTR.</param>
        /// <param name="handle">A WindowHandle.</param>
        /// <returns></returns>
        public static bool operator ==(IntPtr ptr, WindowHandle handle)
        {
            if (ptr != IntPtr.Zero)
            {
                return handle.Equals(ptr);
            }
            return (handle == Empty);

        }


        /// <summary>
        /// Implicit operators the specified a WindowHandle.
        /// </summary>
        /// <param name="handle">A WindowHandle.</param>
        /// <returns></returns>
        public static implicit operator IntPtr(WindowHandle handle)
        {
            return handle.Handle;
        }


        /// <summary>
        /// Implicit operators the specified a int PTR.
        /// </summary>
        /// <param name="ptr">A int PTR.</param>
        /// <returns></returns>
        public static implicit operator WindowHandle(IntPtr ptr)
        {
            return new WindowHandle(ptr);
        }

        /// <summary>
        /// Operator !=s the specified a HWND1.
        /// </summary>
        /// <param name="handle1">A HWND1.</param>
        /// <param name="handle2">A HWND2.</param>
        /// <returns></returns>
        public static bool operator !=(WindowHandle handle1, WindowHandle handle2)
        {
            return !(handle1.Equals(handle2));
        }


        /// <summary>
        /// Operator !=s the specified a WindowHandle.
        /// </summary>
        /// <param name="handle">A WindowHandle.</param>
        /// <param name="ptr">A int PTR.</param>
        /// <returns></returns>
        public static bool operator !=(WindowHandle handle, IntPtr ptr)
        {
            return !(handle.Equals(ptr));
        }


        /// <summary>
        /// Operator !=s the specified a int PTR.
        /// </summary>
        /// <param name="ptr">A int PTR.</param>
        /// <param name="handle">A WindowHandle.</param>
        /// <returns></returns>
        public static bool operator !=(IntPtr ptr, WindowHandle handle)
        {
            return !(ptr == handle);
        }


   






        #endregion

        #region Properties

        /// <summary>
        /// Gets the empty WindowHandle.
        /// </summary>
        /// <value>The empty WindowHandle.</value>
        public static WindowHandle Empty
        {
            get { return _Empty; }
        }


        /// <summary>
        /// Gets a handle to the specified window's parent or owner.
        /// </summary>
        public WindowHandle ParentHandle
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {

                return UnsafeNativeMethods.GetParent(this);
            }

        }
        #endregion

        #region Methods

   

        /// <summary>
        /// Equalses the specified WindowHandle.
        /// </summary>
        /// <param name="hwnd">The WindowHandle.</param>
        /// <returns></returns>
        public bool Equals(WindowHandle hwnd)
        {
                return this.Equals(hwnd.Handle);
        }

        /// <summary>
        /// Equalses the specified PTR.
        /// </summary>
        /// <param name="ptr">The PTR.</param>
        /// <returns></returns>
        public bool Equals(IntPtr ptr)
        {
            return (this.Handle == ptr);
        }


        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is WindowHandle)
                {
                    return this.Equals((WindowHandle)obj);
                }


                if (!(obj is IntPtr))
                {
                    return false;
                }
                return this.Equals((IntPtr)obj);
            }
            return false;
        }

        /// <summary>
        /// Equalses the specified window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns></returns>
        public bool Equals(IWin32Window window)
        {
            if (window != null)
                return this.Equals(window.Handle);

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this._Handle.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            int num1 = this._Handle.ToInt32();
            return ("{Handle=0x" + num1.ToString("X8", CultureInfo.CurrentCulture) + "}");
        }


        /// <summary>
        /// Gets the window associated with this handle.
        /// </summary>
        public Window Window
        {
            get
            {
                return new Window(this);
            }
        }


        #endregion

        #region IWin32Window Members

        /// <summary>
        /// Gets the handle to the window represented by the implementer.
        /// </summary>
        /// <value></value>
        /// <returns>A handle to the window represented by the implementer.</returns>
        public IntPtr Handle
        {
            get { return _Handle; }
        }

        #endregion
    }
}
