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

using System.ComponentModel;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Provides Data For Window Activating Event.
    /// </summary>
    public class WindowActivatingEventArgs : CancelEventArgs
    {

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowActivatingEventArgs"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public WindowActivatingEventArgs(Window window)
        {
            this.Window = window;
        }

        #endregion

        #region Destructor

        #endregion

        #region Fields

        #endregion

        #region Events

        #endregion

        #region Operators

        #endregion

    
        #region Properties

        private Window _Window;


        /// <summary>
        /// Gets the window going to activate.
        /// </summary>
        /// <value>The window.</value>
        public Window Window
        {
            get
            {
                return _Window;
            }
            internal set
            {
                _Window = value;
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
