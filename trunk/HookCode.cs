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
    /// Specifies how to process the message.
    /// </summary>
    internal enum HookCode
    {
        /// <summary>
        /// hook code when an event is being removed from the system queue.
        /// </summary>
        Action = 0,

        /// <summary>
        /// hook code when windows accesses a thread's input queue. 
        /// In most cases, Windows makes this call many times for the same message.
        /// </summary>
        GetNext = 1,


        /// <summary>
        /// this hook code when there is a event that is not being removed because an
        /// application is calling PeekMessage with the PM_NOREMOVE option. 
        /// </summary>
        Remove = 3,

        /// <summary>
        /// hook code when windows has completed processing a message it received 
        /// </summary>
        Skip = 2,

        /// <summary>
        /// A system-modal dialog box has been destroyed. The hook procedure must resume recording.
        /// </summary>
        SysModalOff = 5,


        /// <summary>
        /// A system-modal dialog box is being displayed. Until the dialog box is destroyed,
        /// the hook procedure must stop recording.
        /// </summary>
        SysModalOn = 4
    }

}
