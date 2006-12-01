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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Represents a Base Window Hook
    /// </summary>
    public abstract class BaseHook : SafeHandle
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHook"/> class.
        /// </summary>
        /// <param name="hookType">Type of the hook.</param>
        internal BaseHook(HookType hookType)
            : base(IntPtr.Zero, true)
        {
            this._HookType = hookType;
            this._HookProc = new HookProc(this.InternalHook);

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHook"/> class.
        /// </summary>
        /// <param name="hookType">Type of the hook.</param>
        /// <param name="install">if set to <c>true</c> [install].</param>
        internal BaseHook(HookType hookType, bool install)
            : this(hookType)
        {
            if (install)
            {
                this.Install();
            }
        }

        #endregion

        #region Destructor

        #endregion

        #region Fields
        private HookHandle _Handle = HookHandle.Empty;
        private HookType _HookType;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        private HookProc _HookProc;
        private bool _SystemHook;

        #endregion

        #region Events

        #endregion

        #region Operators

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value this hook is a system hook.
        /// </summary>
        /// <value><c>true</c> if [system hook]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool SystemHook
        {
            get
            {
                return _SystemHook;
            }
            set
            {
                _SystemHook = value;

            }
        }




        /// <summary>
        /// Gets the type of the hook.
        /// </summary>
        /// <value>The type of the hook.</value>
        internal HookType HookType
        {
            get
            {
                return this._HookType;
            }
        }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public HookHandle HookHandle
        {
            get
            {
                return this._Handle;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this Hook is installed.
        /// </summary>
        /// <value><c>true</c> if installed; otherwise, <c>false</c>.</value>
        public bool Installed
        {
            get
            {
                return !this._Handle.IsEmpty;
            }
        }


        #endregion

        #region Methods
     
        /// <summary>
        /// Called when [hook].
        /// </summary>
        /// <param name="code">an integer that indicates the action the hook is going to take.</param>
        /// <param name="wparam">Additional information about the message.</param>
        /// <param name="lparam">Additional information about the message.</param>
        /// <returns>A zero value if the procedure processes the message; a nonzero value if the procedure ignores the message. </returns>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        protected virtual IntPtr OnHook(int code, IntPtr wparam, IntPtr lparam)
        {
            return UnsafeNativeMethods.CallNextHook(this.HookHandle, code, wparam, lparam);
        }

        /// <summary>
        /// Called when [hook].
        /// </summary>
        /// <param name="code">an integer that indicates the action the hook is going to take.</param>
        /// <param name="wparam">Additional information about the message.</param>
        /// <param name="lparam">Additional information about the message.</param>
        /// <returns>A zero value if the procedure processes the message; a nonzero value if the procedure ignores the message. </returns>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private IntPtr InternalHook(int code, IntPtr wparam, IntPtr lparam)
        {
            return OnHook(code, wparam, lparam);
        }
        
        /// <summary>
        /// Uninstalls this hook.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public void Uninstall()
        {
            lock (this)
            {

                if (!this.HookHandle.IsEmpty)
                {
                    while (true)
                    {

                        if (!UnsafeNativeMethods.UnhookWindowsHook(this.HookHandle))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }

                        _Handle = HookHandle.Empty;
                        this._HookProc = null;

                        return;
                    }
                }
            }

        }


        /// <summary>
        /// Installs the hook.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public void Install()
        {
            if (!this.HookHandle.IsEmpty)
            {
                this.Uninstall();
            }
            while (true)
            {
                lock (this)
                {
                    this._Handle = UnsafeNativeMethods.SetWindowsHook(this.HookType, this._HookProc,
                     InstanceHandle.Empty, (uint)Window.ThreadID);
                    if (this.HookHandle.IsEmpty)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    return;
                }
            }
        }










        #endregion

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the handle value is invalid.
        /// </summary>
        /// <value></value>
        /// <returns>true if the handle is valid; otherwise, false.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public override bool IsInvalid
        {
            get { return this.HookHandle == HookHandle.Empty; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a ReleaseHandleFailed Managed Debugging Assistant.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            if (this.Installed)
            {
                this.Uninstall();
            }
            return true;
        }
    }
}
