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
using System.Security.Permissions;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Provides Application Hooking
    /// </summary>
    public class WindowHook : BaseHook
    {

        #region Constructors
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHook"/> class.
        /// </summary>
        public WindowHook()
            : base(HookType.Window)
        {

        }
   
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHook"/> class.
        /// </summary>
        /// <param name="install">if set to <c>true</c> [install].</param>
        public WindowHook(bool install)
            : base(HookType.Window, install)
        {
        }


        #endregion

        #region Destructor

        #endregion

        #region Fields

        #endregion

        #region Events
        /// <summary>
        /// Occurs When the system is about to activate a window.
        /// </summary>
        public event EventHandler<WindowActivatingEventArgs> Activating;
        #endregion

 
        

        #region Operators

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Called when [hook].
        /// </summary>
        /// <param name="code">an integer that indicates the action the hook is going to take.</param>
        /// <param name="wparam">Additional information about the message.</param>
        /// <param name="lparam">Additional information about the message.</param>
        /// <returns>
        /// A zero value if the procedure processes the message; a nonzero value if the procedure ignores the message.
        /// </returns>
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        protected override IntPtr OnHook(int code, IntPtr wparam, IntPtr lparam)
        {
            switch (code)
            {
                case (int)WindowHookCode.Activate:
                    WindowActivatingEventArgs args = new WindowActivatingEventArgs(new Window(wparam));

                    this.OnActivating(args);

                    if (args.Cancel)
                    {
                        return new IntPtr(1);
                    }

                    return IntPtr.Zero;

                default:
                    return base.OnHook(code, wparam, lparam);
            }
        }

        #region OnActivating
        /// <summary>
        /// Raises the <see cref="Activating"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:SmartCore.Interop.Windows.WindowActivatingEventArgs"/> instance containing the event data.</param>
        protected virtual void OnActivating(WindowActivatingEventArgs e)
        {
            if (Activating != null)
                Activating(this, e);
        }
        #endregion
        #endregion
     
    }
}
