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
    /// Specifies the style of the window being created. 
    /// This parameter can be a combination of the following window styles
    /// </summary>
    [Flags]
    public enum WindowStyles
    {
        /// <summary>
        /// Creates a window that has a thin-line border.
        /// </summary>
        Border = 0x800000,

        /// <summary>
        /// Creates a window that has a title bar (includes the WS_BORDER style).
        /// </summary>
        Caption = 0xc00000,


        /// <summary>
        /// Creates a child window. A window with this style cannot have a menu bar. 
        /// This style cannot be used with the WS_POPUP style.
        /// </summary>
        Child = 0x40000000,

        /// <summary>
        /// Same as Child
        /// </summary>
        Children = Child,

        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the 
        /// parent window. This style is used when creating the parent window.
        /// </summary>
        ClipChildren = 0x2000000,


        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular 
        /// child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips 
        /// all other overlapping child windows out of the region of the child window t
        /// o be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap,
        /// it is possible, when drawing within the client area of a child window, to draw
        /// within the client area of a neighboring child window.
        /// </summary>
        ClipSiblings = 0x4000000,


        /// <summary>
        /// Creates a window that is initially disabled. A disabled window cannot 
        /// receive input from the user. To change this after a window has been created,
        /// use EnableWindow. 
        /// </summary>
        Disabled = 0x8000000,


        /// <summary>
        /// Creates a window that has a border of a style typically used with dialog boxes. 
        /// A window with this style cannot have a title bar.
        /// </summary>
        DialogFrame = 0x400000,

        /// <summary>
        /// Specifies the first control of a group of controls. The 
        /// group consists of this first control and all controls defined after it,
        /// up to the next control with the WS_GROUP style. The first control in 
        /// each group usually has the WS_TABSTOP style so that the user can move 
        /// from group to group. The user can subsequently change the keyboard focus
        /// from one control in the group to the next control in the group by using 
        /// the direction keys.
        /// You can turn this style on and off to change dialog box navigation. 
        /// To change this style after a window has been created, use <b>SetWindowLong</b>.
        /// </summary>
        Group = 0x20000,

        /// <summary>
        /// Creates a window that has a horizontal scroll bar.
        /// </summary>
        HorizontalScrollBar = 0x100000,

        /// <summary>
        /// Creates a window that is initially minimized. Same as the WS_MINIMIZE style.
        /// </summary>
        Iconic = 0x20000000,

        /// <summary>
        /// Creates a window that is initially maximized.
        /// </summary>
        Maximize = 0x1000000,

        /// <summary>
        /// Creates a window that has a maximize button. Cannot be combined with the 
        /// WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified. 
        /// </summary>
        MaximizeBox = 0x10000,

        /// <summary>
        /// Creates a window that is initially minimized. Same as the WS_ICONIC style.
        /// </summary>
        Minimize = 0x20000000,

        /// <summary>
        /// Creates a window that has a minimize button. Cannot be combined with the 
        /// WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified. 
        /// </summary>
        MinimizeBox = 0x20000,

        /// <summary>
        /// Creates an overlapped window. An overlapped window has a title bar and a border.
        /// Same as the WS_TILED style.
        /// </summary>
        Overlapped = 0,

        /// <summary>
        /// Creates an overlapped window with the WS_OVERLAPPED, WS_CAPTION, WS_SYSMENU, 
        /// WS_THICKFRAME, WS_MINIMIZEBOX, and WS_MAXIMIZEBOX styles. Same as the WS_TILEDWINDOW style. 
        /// </summary>
        OverlappedWindow = 0xcf0000,

        /// <summary>
        /// Creates a pop-up window. This style cannot be used with the WS_CHILD style.
        /// </summary>
        Popup = -2147483648,

        /// <summary>
        /// Creates a pop-up window with WS_BORDER, WS_POPUP, and WS_SYSMENU styles. The 
        /// WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.
        /// </summary>
        PopupWindow = -2138570752,

        /// <summary>
        /// Creates a window that has a sizing border. Same as the WS_THICKFRAME style.
        /// </summary>
        Resizable = 0x40000,

        /// <summary>
        /// Creates a window that has a window menu on its title bar. 
        /// The WS_CAPTION style must also be specified.
        /// </summary>
        SystemMenu = 0x80000,

        /// <summary>
        /// Specifies a control that can receive the keyboard focus when the user 
        /// presses the TAB key. Pressing the TAB key changes the keyboard focus 
        /// to the next control with the WS_TABSTOP style. 
        /// You can turn this style on and off to change dialog box navigation.
        /// To change this style after a window has been created, use SetWindowLong.
        /// </summary>
        TabStop = 0x10000,

        /// <summary>
        /// Creates a window that has a sizing border. Same as the WS_SIZEBOX style.
        /// </summary>
        ThickFrame = 0x40000,

        /// <summary>
        /// Creates an overlapped window. An overlapped window has a title bar and a border. 
        /// Same as the WS_OVERLAPPED style. 
        /// </summary>
        Tiled = Overlapped,

        /// <summary>
        /// Creates an overlapped window with the WS_OVERLAPPED, WS_CAPTION, WS_SYSMENU,
        /// WS_THICKFRAME, WS_MINIMIZEBOX, and WS_MAXIMIZEBOX styles. Same as 
        /// the WS_OVERLAPPEDWINDOW style. 
        /// </summary>
        TiledWindow = OverlappedWindow | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox,

        /// <summary>
        /// Creates a window that is initially visible.
        /// </summary>
        Visible = 0x10000000,

        /// <summary>
        /// Creates a window that has a vertical scroll bar.
        /// </summary>
        VerticalScrollBar = 0x200000

    }
}
