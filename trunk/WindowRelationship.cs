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



#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Specifies the relationship between the specified window and the window whose handle is to be retrieved
    /// </summary>
    public enum WindowRelationship
    {
        /// <summary>
        /// The retrieved handle identifies the window of the same type that 
        /// is highest in the Z order. If the specified window is a topmost window, 
        /// the handle identifies the topmost window that is highest in the Z order. 
        /// If the specified window is a top-level window, the handle identifies the 
        /// top-level window that is highest in the Z order. If the specified window
        /// is a child window, the handle identifies the sibling window that is highest in the Z order.
        /// </summary>
        First,

        /// <summary>
        /// The retrieved handle identifies the window of the same type that is 
        /// lowest in the Z order. If the specified window is a topmost window, the 
        /// handle identifies the topmost window that is lowest in the Z order.
        /// If the specified window is a top-level window, the handle identifies the 
        /// top-level window that is lowest in the Z order. If the specified window is 
        /// a child window, the handle identifies the sibling window that is lowest in the Z order.
        /// </summary>
        Last,

        /// <summary>
        /// The retrieved handle identifies the window below the specified window in the Z order.
        /// If the specified window is a topmost window, the handle identifies the topmost window
        /// below the specified window. If the specified window is a top-level window, 
        /// the handle identifies the top-level window below the specified window. If the 
        /// specified window is a child window, the handle identifies the sibling window
        /// below the specified window.
        /// </summary>
        Next,

        /// <summary>
        /// The retrieved handle identifies the window above the specified window in the Z order.
        /// If the specified window is a topmost window, the handle identifies the topmost
        /// window above the specified window. If the specified window is a top-level window,
        /// the handle identifies the top-level window above the specified window. If 
        /// the specified window is a child window, the handle identifies the sibling window 
        /// above the specified window.
        /// </summary>
        Previous,

        /// <summary>
        /// The retrieved handle identifies the specified window's owner window, if any. 
        /// </summary>
        Owner,

        /// <summary>
        /// The retrieved handle identifies the child window at the top of the Z order,
        /// if the specified window is a parent window; otherwise, the retrieved handle is NULL.
        /// The function examines only child windows of the specified window. It 
        /// does not examine descendant windows.
        /// </summary>
        Child,

        /// <summary>
        /// Windows 2000/XP: The retrieved handle identifies the enabled popup window owned 
        /// by the specified window (the search uses the first such window found using GW_HWNDNEXT);
        /// otherwise, if there are no enabled popup windows, the retrieved handle 
        /// is that of the specified window. 
        /// </summary>
        Popup
    }
 

}
