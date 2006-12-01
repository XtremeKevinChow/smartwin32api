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

using System.Drawing;
using System.Runtime.InteropServices;
using ZO.SmartCore.Helpers;
using ZO.SmartCore.Interop.Windows.Properties;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// defines the coordinates of the upper-left and lower-right corners of a rectangle. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public RECT(Rectangle rectangle)
        {
            this._Left = rectangle.Left;
            this._Top = rectangle.Top;
            this._Right = rectangle.Right;
            this._Bottom = rectangle.Bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        public RECT(RectangleF rectangle)
        {
            this._Left = (int)rectangle.Left;
            this._Top = (int)rectangle.Top;
            this._Right = (int)rectangle.Right;
            this._Bottom = (int)rectangle.Bottom;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> class.
        /// </summary>
        /// <param name="location">A location.</param>
        /// <param name="size">A size.</param>
        public RECT(POINT location, SIZE size)
        {
            this._Left = location.X;
            this._Top = location.Y;
            this._Right = this._Left + size.Width;
            this._Bottom = this._Top + size.Height;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> class.
        /// </summary>
        /// <param name="left">A left.</param>
        /// <param name="top">A top.</param>
        /// <param name="right">A right.</param>
        /// <param name="bottom">A bottom.</param>
        public RECT(int left, int top, int right, int bottom)
        {
            this._Left = left;
            this._Top = top;
            this._Right = right;
            this._Bottom = bottom;
        }

 


        #endregion

        #region Destructor

        #endregion

        #region Fields
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;

        #endregion

        #region Events

        #endregion

        #region Operators
        /// <summary>
        /// Operator ==s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator ==(RECT rect1, RECT rect2)
        {
            if (rect1 != Empty)
            {
                return rect1.Equals(rect2);
            }
            return (rect2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator ==(RECT rect1, Rectangle rect2)
        {
            if (rect1 != Empty)
            {
                return rect1.Equals(rect2);
            }
            return (rect2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator ==(Rectangle rect1, RECT rect2)
        {
            if (rect1 != Empty)
            {
                return rect2.Equals(rect1);
            }
            return (rect2 == Empty);
        }


        /// <summary>
        /// Implicit operators the specified a rect.
        /// </summary>
        /// <param name="rect">A rect.</param>
        /// <returns></returns>
        public static implicit operator Rectangle(RECT rect)
        {
            return rect.ToRectangle();
        }


        /// <summary>
        /// Implicit operators the specified rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        public static implicit operator RECT(Rectangle rectangle)
        {
            return new RECT(rectangle);
        }


        /// <summary>
        /// Operator !=s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator !=(RECT rect1, RECT rect2)
        {
            return !(rect1 == rect2);
        }


        /// <summary>
        /// Operator !=s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator !=(RECT rect1, Rectangle rect2)
        {
            return !(rect1 == rect2);
        }


        /// <summary>
        /// Operator !=s the specified rect1.
        /// </summary>
        /// <param name="rect1">The rect1.</param>
        /// <param name="rect2">The rect2.</param>
        /// <returns></returns>
        public static bool operator !=(Rectangle rect1, RECT rect2)
        {
            return !(rect1 == rect2);
        }

 

        #endregion

        #region Properties
        /// <summary>
        /// Get an empty rect
        /// </summary>
        public static readonly RECT Empty = new RECT(0, 0, 0, 0);


        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        public int Bottom
        {
            get
            {
                return this._Bottom;
            }
            set
            {
                this._Bottom = value;
            }
        }

        /// <summary>
        /// Gets the bottom right.
        /// </summary>
        /// <value>The bottom right.</value>
        public POINT BottomRight
        {
            get
            {
                return new POINT(this._Right, this._Bottom);
            }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return (this._Bottom - this._Top);
            }
        }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        public int Left
        {
            get
            {
                return this._Left;
            }
            set
            {
                this._Left = value;
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        public POINT Location
        {
            get
            {
                return new POINT(this._Left, this._Top);
            }
        }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>The right.</value>
        public int Right
        {
            get
            {
                return this._Right;
            }
            set
            {
                this._Right = value;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public SIZE Size
        {
            get
            {
                return new SIZE(this._Right - this._Left, this._Bottom - this._Top);
            }
        }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        public int Top
        {
            get
            {
                return this._Top;
            }
            set
            {
                this._Top = value;
            }
        }

        /// <summary>
        /// Gets the top left.
        /// </summary>
        /// <value>The top left.</value>
        public POINT TopLeft
        {
            get
            {
                return new POINT(this._Left, this._Top);
            }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return (this._Right - this._Left);
            }
        }
 

        #endregion

        #region Methods


        /// <summary>
        /// Equalses the specified a rect.
        /// </summary>
        /// <param name="rect">A rect.</param>
        /// <returns></returns>
        public bool Equals(RECT rect)
        {
            if (this._Left.Equals((object)rect._Left))
            {
                if (this._Top.Equals((object)rect._Top))
                {
                    if (this._Right.Equals((object)rect._Right))
                    {
                        if (this._Bottom.Equals((object)rect._Bottom))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }


        /// <summary>
        /// Equalses the specified a rectangle.
        /// </summary>
        /// <param name="rectangle">A rectangle.</param>
        /// <returns></returns>
        public bool Equals(Rectangle rectangle)
        {
            if (this._Left.Equals((object)rectangle.Left))
            {
                if (this._Top.Equals((object)rectangle.Top))
                {
                    if (this._Right.Equals((object)rectangle.Right))
                    {
                        if (this._Bottom.Equals((object)rectangle.Bottom))
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Equalses the specified a obj.
        /// </summary>
        /// <param name="obj">A obj.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is RECT)
                {
                    return this.Equals((RECT)obj);
                }
                if (!(obj is Rectangle))
                {
                    return false;
                }
                return this.Equals((Rectangle)obj);
            }
            return false;
        }


        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return (((this._Left ^ ((this._Top << 13) | (this._Top >> 0x13))) ^ ((this.Width << 0x1a) | (this.Width >> 6))) ^ ((this.Height << 7) | (this.Height >> 0x19)));
        }


        /// <summary>
        /// Returns the size of this structure, in bytes.
        /// </summary>
        public static int GetSize()
        {
            return Marshal.SizeOf(typeof(RECT));
        }


        /// <summary>
        /// Inflates the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        public void Inflate(SIZE size)
        {
            this.Inflate(size.Width, size.Height);
        }


        /// <summary>
        /// Inflates the specified a width.
        /// </summary>
        /// <param name="width">A width.</param>
        /// <param name="height">A height.</param>
        public void Inflate(int width, int height)
        {
            this._Left -= width;
            this._Top -= height;
            this._Right += width;
            this._Bottom += height;
        }


        /// <summary>
        /// Inflates the specified left.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="right">The right.</param>
        public void Inflate(int left, int top, int bottom, int right)
        {
            this._Left += left;
            this._Top += top;
            this._Bottom += bottom;
            this._Right += right;
        }


        /// <summary>
        /// Returns the intersection of two RECT structures.
        /// </summary>
        public static RECT Intersect(RECT rect1, RECT rect2)
        {
            return UnsafeNativeMethods.IntersectRect(rect1, rect2);
        }


        /// <summary>
        /// Get a rectangle representation.
        /// </summary>
        /// <returns></returns>
        public Rectangle ToRectangle()
        {
            return new Rectangle(this._Left, this._Top, this.Width, this.Height);
        }


        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return ("{" + StringHelper.Format(Resources.RECTLTRB, new object[] { this._Left, this._Top, this._Right, this._Bottom }) + "}");
        }

 


        #endregion
    }
}
