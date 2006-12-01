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
    /// a code that the hook procedure uses to determine how to process the message.
    /// </summary>
    internal enum WindowHookCode
    {
        /// <summary>
        /// A window is about to be moved or sized.
        /// </summary>
        MoveOrResize = 0,

        /// <summary>
        /// A window is about to be minimized or maximized.
        /// </summary>
        MinimizeOrMaximize = 1,

        /// <summary>
        /// The system has retrieved a WM_QUEUESYNC message from the system message queue.
        /// </summary>
        QueueSync = 2,

        /// <summary>
        /// A window is about to be created. 
        /// </summary>
        CreateWindow = 3,

        /// <summary>
        /// A window is about to be destroyed.
        /// </summary>
        DestroyWindow = 4,

        /// <summary>
        /// The system is about to activate a window.
        /// </summary>
        Activate = 5,

        /// <summary>
        /// The system has removed a mouse message from the system message queue.
        /// Upon receiving this hook code, a CBT application must install a 
        /// WH_JOURNALPLAYBACK hook procedure in response to the mouse message.
        /// </summary>
        ClickSkipped = 6,

        /// <summary>
        /// The system has removed a keyboard message from the system message queue. 
        /// Upon receiving this hook code, a CBT application must install a WH_JOURNALPLAYBACK
        /// hook procedure in response to the keyboard message.
        /// </summary>
        KeySkipped = 7,

        /// <summary>
        /// A system command is about to be carried out. 
        /// This allows a CBT application to prevent task switching by means of hot keys.
        /// </summary>
        SystemCommand = 8,

        /// <summary>
        /// A window is about to receive the keyboard focus.
        /// </summary>
        Focus = 9
    }
}
