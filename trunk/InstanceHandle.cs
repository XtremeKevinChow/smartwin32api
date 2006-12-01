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
    /// Represents a Handle to an instance. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InstanceHandle
    {

        #region Constructors
        
		/// <summary>
		/// Initializes a new instance of the <see cref="InstanceHandle"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public InstanceHandle(int value)
		{
			this._Instance = new IntPtr(value);
		}


	
		/// <summary>
		/// Initializes a new instance of the <see cref="InstanceHandle"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public InstanceHandle(IntPtr value)
		{
			this._Instance = value;
		}
        #endregion

        #region Destructor

        #endregion

        #region Fields
        private IntPtr _Instance;

        #endregion

        #region Events

        #endregion

   		#region Operators

		/// <summary>
		/// Operator ==s the specified hinstance1.
		/// </summary>
		/// <param name="hinstance1">The hinstance1.</param>
		/// <param name="hinstance2">The hinstance2.</param>
		/// <returns></returns>
		public static bool operator == (InstanceHandle hinstance1, InstanceHandle hinstance2)
		{
			if (!hinstance1.IsEmpty)
			{
				return hinstance1.Equals(hinstance2);
			}
			return (hinstance2.IsEmpty);
		}


		/// <summary>
		/// Operator ==s the specified instance.
		/// </summary>
		/// <param name="instance">The instance.</param>
        /// <param name="instance2">The PTR instance.</param>
		/// <returns></returns>
        public static bool operator ==(InstanceHandle instance, IntPtr instance2)
		{
			if (!instance.IsEmpty)
			{
                return instance.Equals(instance2);
			}
            return (instance2 == IntPtr.Zero);
		}


		/// <summary>
		/// Operator ==s the specified PTR instance.
		/// </summary>
        /// <param name="instance1">The PTR instance.</param>
		/// <param name="instance2">The instance.</param>
		/// <returns></returns>
        public static bool operator ==(IntPtr instance1, InstanceHandle instance2)
		{
            if (instance1 != IntPtr.Zero)
			{
                return instance2.Equals(instance1);
			}
            return (instance2.IsEmpty);
		}


		/// <summary>
		/// Implicit operators the specified instance.
		/// </summary>
		/// <param name="instance">The instance.</param>
		/// <returns></returns>
		public static implicit operator IntPtr(InstanceHandle instance)
		{
			return instance.Handle;
		}


		/// <summary>
		/// Implicit operators the specified PTR instance.
		/// </summary>
        /// <param name="instance">The PTR instance.</param>
		/// <returns></returns>
        public static implicit operator InstanceHandle(IntPtr instance)
		{
            return new InstanceHandle(instance);
		}



		/// <summary>
		/// Operator !=s the specified hinstance1.
		/// </summary>
		/// <param name="hinstance1">The hinstance1.</param>
		/// <param name="hinstance2">The hinstance2.</param>
		/// <returns></returns>
		public static bool operator !=(InstanceHandle hinstance1, InstanceHandle hinstance2)
		{
			return !(hinstance1 == hinstance2);
		}


		/// <summary>
		/// Operator !=s the specified instance.
		/// </summary>
		/// <param name="instance1">The instance.</param>
        /// <param name="instance2">The PTR instance.</param>
		/// <returns></returns>
        public static bool operator !=(InstanceHandle instance1, IntPtr instance2)
		{
            return !(instance1 == instance2);
		}


		/// <summary>
		/// Operator !=s the specified PTR instance.
		/// </summary>
        /// <param name="instance1">The PTR instance.</param>
		/// <param name="instance2">The instance.</param>
		/// <returns></returns>
        public static bool operator !=(IntPtr instance1, InstanceHandle instance2)
		{
            return !(instance1 == instance2);
		}

 


		#endregion

		#region Properties

		/// <summary>
		/// Represents the empty instance. This field is read-only. 
		/// </summary>
		public static readonly InstanceHandle Empty = new InstanceHandle(0);



		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public IntPtr Handle
		{
			get
			{
				return this._Instance;
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
				return (this._Instance == IntPtr.Zero);
			}
		}
 

		#endregion

		#region Methods

		/// <summary>
		/// Equalses the specified instance.
		/// </summary>
		/// <param name="instance">The instance.</param>
		/// <returns></returns>
		public bool Equals(InstanceHandle instance)
		{
			if (this._Instance.Equals(instance._Instance))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Equalses the specified PTR instance.
		/// </summary>
        /// <param name="instance">The PTR instance.</param>
		/// <returns></returns>
        public bool Equals(IntPtr instance)
		{
            if (this._Instance.Equals(instance))
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
				if (obj is InstanceHandle)
				{
					return this.Equals((InstanceHandle)obj);
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
			return this._Instance.GetHashCode();
		}


		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> containing a fully qualified type name.
		/// </returns>
		public override string ToString()
		{
			int num1 = this._Instance.ToInt32();
			return ("{Handle=0x" + num1.ToString("X8", CultureInfo.CurrentCulture) + "}");
		}

 


		#endregion
    }
}
