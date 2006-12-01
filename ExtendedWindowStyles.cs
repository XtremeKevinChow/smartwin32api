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

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// Specifies the extended window style of the window being created
    /// </summary>
    [Flags]
    public enum ExtendedWindowStyles
    {
        /// <summary>
        /// Specifies that a window created with this style accepts drag-drop files.
        /// </summary>
        AcceptFiles = 0x10,

        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible. 
        /// </summary>
        AppWindow = 0x40000,

        /// <summary>
        /// Specifies that a window has a border with a sunken edge.
        /// </summary>
        ClientEdge = 0x200,


        /// <summary>
        /// Windows XP: Paints all descendants of a window in bottom-to-top painting order using double-buffering.
        /// For more information, see Remarks. This cannot be used if the window has a class style of 
        /// either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        Composite = 0x2000000,

        /// <summary>
        /// Includes a question mark in the title bar of the window.
        /// </summary>
        ContextHelp = 0x400,

        /// <summary>
        /// The window itself contains child windows that should take part in dialog box navigation. 
        /// If this style is specified, the dialog manager recurses into children of this window when 
        /// performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        ControlParent = 0x10000,

        /// <summary>
        /// Creates a window that has a double border; the window can, optionally, be created with 
        /// a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
        /// </summary>
        DialogModalFrame = 1,

        /// <summary>
        /// Windows 2000/XP: Creates a layered window. Note that this cannot be used for child windows.
        /// Also, this cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        Layered = 0x80000,

        /// <summary>
        /// Arabic and Hebrew versions of Windows 98/Me, Windows 2000/XP: Creates a window whose 
        /// horizontal origin is on the right edge. Increasing horizontal values advance to the left. 
        /// </summary>
        RTLLayout = 0x400000,

        /// <summary>
        /// Creates a window that has generic left-aligned properties. This is the default.
        /// </summary>
        LeftAlign = 0,

        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading 
        /// order alignment, the vertical scroll bar (if present) is to the left of the client area. 
        /// For other languages, the style is ignored.
        /// </summary>
        LeftScrollBar = 0x4000,

        /// <summary>
        /// The window text is displayed using left-to-right reading-order properties. This is the default.
        /// </summary>
        LTRReading = 0,

        /// <summary>
        /// Creates a multiple-document interface (MDI) child window.
        /// </summary>
        MDIChild = 0x40,

        /// <summary>
        /// Windows 2000/XP: A top-level window created with this style does not become the 
        /// foreground window when the user clicks it. The system does not bring this window to the 
        /// foreground when the user minimizes or closes the foreground window. 
        /// To activate the window, use the SetActiveWindow or SetForegroundWindow function.
        /// The window does not appear on the taskbar by default. To force the window to appear on 
        /// the taskbar, use the WS_EX_APPWINDOW style.
        /// </summary>
        NoActivate = 0x8000000,

        /// <summary>
        /// Windows 2000/XP: A window created with this style does not pass its window layout to its child windows.
        /// </summary>
        NotInheritLayout = 0x100000,

        /// <summary>
        /// Specifies that a child window created with this style does not send the WM_PARENTNOTIFY 
        /// message to its parent window when it is created or destroyed.
        /// </summary>
        NoParentNotify = 4,

        /// <summary>
        /// Combines the WS_EX_CLIENTEDGE and WS_EX_WINDOWEDGE styles.
        /// </summary>
        OverlappedWindow = 0x300,

        /// <summary>
        /// Combines the WS_EX_WINDOWEDGE, WS_EX_TOOLWINDOW, and WS_EX_TOPMOST styles.
        /// </summary>
        PaletteWindow = WindowEdge | Topmost | ToolWindow,

        /// <summary>
        /// The window has generic "right-aligned" properties. This depends on the window class. 
        /// This style has an effect only if the shell language is Hebrew, Arabic, or another 
        /// language that supports reading-order alignment; otherwise, the style is ignored.
        /// Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the
        /// SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the 
        /// same effect as using BS_RIGHT and BS_RIGHTBUTTON styles. 
        /// </summary>
        RightAlign = 0x1000,

        /// <summary>
        /// Vertical scroll bar (if present) is to the right of the client area. This is the default.
        /// </summary>
        RightScrollBar = 0,

        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment,
        /// the window text is displayed using right-to-left reading-order properties. For other languages,
        /// the style is ignored.
        /// </summary>
        RTLReading = 0x2000,

        /// <summary>
        /// Creates a window with a three-dimensional border style intended to be used for items 
        /// that do not accept user input.
        /// </summary>
        StaticEdge = 0x20000,

        /// <summary>
        /// Creates a tool window; that is, a window intended to be used as a floating toolbar.
        /// A tool window has a title bar that is shorter than a normal title bar, and the window
        /// title is drawn using a smaller font. A tool window does not appear in the taskbar or in 
        /// the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, 
        /// its icon is not displayed on the title bar. However, you can display the system menu by 
        /// right-clicking or by typing ALT+SPACE. 
        /// </summary>
        ToolWindow = 0x80,

        /// <summary>
        /// Specifies that a window created with this style should be placed above all 
        /// non-topmost windows and should stay above them, even when the window is deactivated. 
        /// To add or remove this style, use the SetWindowPos function.
        /// </summary>
        Topmost = 8,

        /// <summary>
        /// Specifies that a window created with this style should not be painted until siblings
        /// beneath the window (that were created by the same thread) have been painted. 
        /// The window appears transparent because the bits of underlying sibling windows
        /// have already been painted.
        /// To achieve transparency without these restrictions, use the SetWindowRgn function.
        /// </summary>
        Transparent = 0x20,

        /// <summary>
        /// Specifies that a window has a border with a raised edge.
        /// </summary>
        WindowEdge = 0x100

    }
}
