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
    /// Installs a hook procedure that will be called when the application's foreground 
    /// thread is about to become idle
    /// </summary>
    public class ForegroundIdle : BaseHook
    {

        #region Constructors
              /// <summary>
        /// Initializes a new instance of the <see cref="ForegroundIdle"/> class.
        /// </summary>
        public ForegroundIdle()
            : base(HookType.ForegroundIdle)
        {
            base.SystemHook = true;
        }
   
        /// <summary>
        /// Initializes a new instance of the <see cref="ForegroundIdle"/> class.
        /// </summary>
        /// <param name="install">if set to <c>true</c> [install].</param>
        public ForegroundIdle(bool install)
            : base(HookType.ForegroundIdle, install)
        {
        }
        #endregion

        #region Destructor

        #endregion

        #region Fields

        #endregion

        #region Events
        /// <summary>
        /// Occurs whenforeground thread is about to become idle. 
        /// </summary>
        public event EventHandler Idle;
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
            if (code >= (int)HookCode.Action)
            {
                this.OnIdle(EventArgs.Empty);
            }
            
            return base.OnHook(code, wparam, lparam);
        }


        #region OnIdle

        /// <summary>
        /// Raises the <see cref="Idle"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnIdle(EventArgs e)
        {
            if (Idle != null)
                Idle(this, e);
        }
        #endregion

        #endregion
    }
}
