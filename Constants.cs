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
	/// Internal Constants used By Library
	/// </summary>
	internal static class Constants
	{

		#region Constructors

		#endregion

		#region Destructor

		#endregion

		#region Fields
		/// <summary>
		/// module that contains common GUI components used by Windows 
		/// </summary>
		public const string Comctl32 = "comctl32.dll";

		/// <summary>
		/// The Kernel32.dll file handles memory management, input/output operations, and interrupts. 
		/// When you start Windows, Kernel32.dll is loaded into a protected memory space so that other 
		/// programs do not take over that memory space. 
		/// </summary>
		public const string Kernel32 = "kernel32.dll";

		/// <summary>
		/// Provides Windows XP Visual Style Support
		/// </summary>
		public const string UxTheme = "uxtheme.dll";

		/// <summary>
		/// contains Windows API functions related to the Windows user interface 
		/// (Window handling, basic UI functions, and so forth).
		/// </summary>
		public const string User32 = "user32.dll";

        /// <summary>
        /// contains Windows API functions related to Drawing
        /// </summary>
        public const string GDI32 = "gdi32.dll";


        public const string Hooks = "SmartCore.Interop.Windows.Hooks.dll";
		#endregion

		#region Events

		#endregion

		#region Operators

		#endregion

		#region Properties

		#endregion

		#region Methods

		#endregion
	}
}
