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

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Represent a Handle to a hook. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HookHandle
    {

        #region Constructors

        		/// <summary>
		/// Initializes a new instance of the <see cref="HookHandle"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public HookHandle(int value)
		{
			this._Hook = new IntPtr(value);
		}


		/// <summary>
        /// Initializes a new instance of the <see cref="HookHandle"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
        public HookHandle(IntPtr value)
		{
			this._Hook = value;
		}
        #endregion

        #region Destructor

        #endregion

        #region Fields
        private IntPtr _Hook;

        #endregion

        #region Events

        #endregion

        #region Operators

        /// <summary>
        /// Operator ==s the specified hook1.
        /// </summary>
        /// <param name="hook1">The hook1.</param>
        /// <param name="hook2">The hook2.</param>
        /// <returns></returns>
        public static bool operator ==(HookHandle hook1, HookHandle hook2)
        {
            if (!hook1.IsEmpty)
            {
                return hook1.Equals(hook2);
            }
            return (hook2.IsEmpty);
        }


        /// <summary>
        /// Operator ==s the specified hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <returns></returns>
        public static bool operator ==(HookHandle hook, IntPtr ptrHook)
        {
            if (!hook.IsEmpty)
            {
                return hook.Equals(ptrHook);
            }
            return (ptrHook == IntPtr.Zero);
        }


        /// <summary>
        /// Operator ==s the specified PTR hook.
        /// </summary>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <param name="hook">The hook.</param>
        /// <returns></returns>
        public static bool operator ==(IntPtr ptrHook, HookHandle hook)
        {
            if (ptrHook != IntPtr.Zero)
            {
                return hook.Equals(ptrHook);
            }
            return (hook.IsEmpty);
        }


        /// <summary>
        /// Implicit operators the specified hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <returns></returns>
        public static implicit operator IntPtr(HookHandle hook)
        {
            return hook.Handle;
        }


        /// <summary>
        /// Implicit operators the specified PTR hook.
        /// </summary>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <returns></returns>
        public static implicit operator HookHandle(IntPtr ptrHook)
        {
            return new HookHandle(ptrHook);
        }


        /// <summary>
        /// Operator !=s the specified hook1.
        /// </summary>
        /// <param name="hook1">The hook1.</param>
        /// <param name="hook2">The hook2.</param>
        /// <returns></returns>
        public static bool operator !=(HookHandle hook1, HookHandle hook2)
        {
            return !(hook1 == hook2);
        }


        /// <summary>
        /// Operator !=s the specified hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <returns></returns>
        public static bool operator !=(HookHandle hook, IntPtr ptrHook)
        {
            return !(hook == ptrHook);
        }


        /// <summary>
        /// Operator !=s the specified PTR hook.
        /// </summary>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <param name="hook">The hook.</param>
        /// <returns></returns>
        public static bool operator !=(IntPtr ptrHook, HookHandle hook)
        {
            return !(ptrHook == hook);
        }




        #endregion

        #region Properties
        /// <summary>
        /// Represents the empty Hook. This field is read-only. 
        /// </summary>
        public static readonly HookHandle Empty = new HookHandle(0);



        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public IntPtr Handle
        {
            get
            {
                return this._Hook;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get
            {
                return (this._Hook == IntPtr.Zero);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Equalses the specified hook.
        /// </summary>
        /// <param name="hook">The hook.</param>
        /// <returns></returns>
        public bool Equals(HookHandle hook)
        {
            if (this._Hook.Equals(hook._Hook))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Equalses the specified PTR hook.
        /// </summary>
        /// <param name="ptrHook">The PTR hook.</param>
        /// <returns></returns>
        public bool Equals(IntPtr ptrHook)
        {
            if (this._Hook.Equals(ptrHook))
            {
                return true;
            }
            return false;
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
                if (obj is HookHandle)
                {
                    return this.Equals((HookHandle)obj);
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
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this._Hook.GetHashCode();
        }


        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            int num1 = this._Hook.ToInt32();
            return ("{Handle=0x" + num1.ToString("X8", CultureInfo.CurrentCulture) + "}");
        }
        #endregion
    }
}
