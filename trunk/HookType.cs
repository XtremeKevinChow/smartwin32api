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
	/// Specifies the type of hook procedure.
	/// </summary>
	internal enum HookType
	{
		/// <summary>
		/// Installs a hook procedure that monitors messages before the system sends them to 
		/// the destination window procedure.
		/// </summary>
		BeforeWindowProcedure = 4,

		/// <summary>
		/// Installs a hook procedure that monitors messages after they have been processed 
		/// by the destination window procedure.
		/// </summary>
        AfterWindowProcedure = 12,


		/// <summary>
		/// Installs a hook procedure that receives notifications useful to a 
		/// computer-based training (CBT) application.
		/// </summary>
		Window = 5,

		/// <summary>
		/// Installs a hook procedure useful for debugging other hook procedures.
		/// </summary>
		Debug = 9,

		/// <summary>
		/// Installs a hook procedure that will be called when the application's foreground thread is 
		/// about to become idle. This hook is useful for performing low priority tasks during idle time. 
		/// </summary>
        ForegroundIdle = 11,

		/// <summary>
		/// Installs a hook procedure that monitors messages posted to a message queue.
		/// </summary>
        MessageQueue = 3,

		/// <summary>
		/// A nonstandard hardware message hook called whenever the application calls the GetMessage() or 
		/// PeekMessage() function and there is a hardware event (other than a mouse or keyboard event) to process.
		/// </summary>
		Hardware = 8,


		/// <summary>
		/// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure. 
		/// </summary>
        JournalPlayback = 1,


		/// <summary>
		/// Installs a hook procedure that records input messages posted to the system message queue. 
		/// This hook is useful for recording macros. 
		/// </summary>
		JournalRecord = 0,


		/// <summary>
		/// Installs a hook procedure that monitors keystroke messages.
		/// </summary>
		Keyboard = 2,


		/// <summary>
		/// Windows NT/2000/XP: Installs a hook procedure that monitors low-level keyboard input events. 
		/// </summary>
		LowLevelKeyboard = 13,


		/// <summary>
		/// Installs a hook procedure that monitors mouse messages.
		/// </summary>
		Mouse = 7,


		/// <summary>
		/// Windows NT/2000/XP: Installs a hook procedure that monitors low-level mouse input events.
		/// </summary>
		LowLevelMouse = 14,


		/// <summary>
        /// Intercepts sent messages produced by menus, dialog boxes, message boxes, and scroll bars
		/// </summary>
		Message = -1,


		/// <summary>
        /// Intercepts messages that notify an application of actions occurring to it 
        /// either through user intervention or through a change in the system's state
		/// </summary>
		Shell = 10,


		/// <summary>
        /// Intercepts sent messages produced by menus, dialog boxes, message boxes,
        /// and scroll bars on a system-wide basis
		/// </summary>
        SystemMessage = 6
	}
 

}
