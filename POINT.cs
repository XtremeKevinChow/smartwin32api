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
using System.Windows.Forms;
using ZO.SmartCore.Helpers;
using ZO.SmartCore.Interop.Windows.Properties;

#endregion

namespace ZO.SmartCore.Interop.Windows
{
    /// <summary>
    /// structure defines the x- and y- coordinates of a point. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public POINT(Point point)
        {
            this._X = point.X;
            this._Y = point.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public POINT(PointF point)
        {
            this._X = (int)point.X;
            this._Y = (int)point.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public POINT(int x, int y)
        {
            this._X = x;
            this._Y = y;
        }

 


        #endregion

        #region Destructor

        #endregion

        #region Fields
        private int _X;
        private int _Y;

        #endregion

        #region Events

        #endregion

        #region Operators

        /// <summary>
        /// Operator ==s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator ==(POINT point1, POINT point2)
        {
            if (point1 != Empty)
            {
                return point1.Equals(point2);
            }
            return (point2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator ==(POINT point1, Point point2)
        {
            if (point1 != Empty)
            {
                return point1.Equals(point2);
            }
            return (point2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator ==(Point point1, POINT point2)
        {
            if (point1 != Empty)
            {
                return point2.Equals(point1);
            }
            return (point2 == Empty);
        }


        /// <summary>
        /// Implicit operators the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static implicit operator Point(POINT point)
        {
            return point.ToPoint();
        }


        /// <summary>
        /// Implicit operators the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static implicit operator POINT(Point point)
        {
            return new POINT(point);
        }


        /// <summary>
        /// Operator !=s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator !=(POINT point1, POINT point2)
        {
            return !(point1 == point2);
        }


        /// <summary>
        /// Operator !=s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator !=(POINT point1, Point point2)
        {
            return !(point1 == point2);
        }


        /// <summary>
        /// Operator !=s the specified a point1.
        /// </summary>
        /// <param name="point1">A point1.</param>
        /// <param name="point2">A point2.</param>
        /// <returns></returns>
        public static bool operator !=(Point point1, POINT point2)
        {
            return !(point1 == point2);
        }





 

 



        #endregion

        #region Properties

        /// <summary>
        /// Get an empty Point
        /// </summary>
        public static readonly POINT Empty = new POINT(0, 0);


        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        public int X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        public int Y
        {
            get
            {
                return this._Y;
            }
            set
            {
                this._Y = value;
            }
        }
 



        #endregion

        #region Methods

        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="clientHandle">A client handle.</param>
        /// <returns></returns>
        public POINT ClientToScreen(WindowHandle clientHandle)
        {
            return UnsafeNativeMethods.ClientToScreen(clientHandle, this);
        }


        /// <summary>
        /// Clients to screen.
        /// </summary>
        /// <param name="clientHandle">A client handle.</param>
        /// <returns></returns>
        public POINT ClientToScreen(IWin32Window clientHandle)
        {
            return UnsafeNativeMethods.ClientToScreen(clientHandle, this);
        }


        /// <summary>
        /// Equalses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public bool Equals(Point point)
        {
            if (this._X.Equals((object)point.X) && this._Y.Equals((object)point.Y))
            {
                return true;
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
                if (obj is POINT)
                {
                    return this.Equals((POINT)obj);
                }
                if (!(obj is Point))
                {
                    return false;
                }
                return this.Equals((Point)obj);
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
            return (this._X ^ this._Y);
        }


        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="clientHandle">A client handle.</param>
        /// <returns></returns>
        public POINT ScreenToClient(WindowHandle clientHandle)
        {
            return UnsafeNativeMethods.ScreenToClient(clientHandle, this);
        }


        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="clientHandle">A client handle.</param>
        /// <returns></returns>
        public POINT ScreenToClient(IWin32Window clientHandle)
        {
            return UnsafeNativeMethods.ScreenToClient(clientHandle, this);
        }


        /// <summary>
        /// Toes the point.
        /// </summary>
        /// <returns></returns>
        public Point ToPoint()
        {
            return new Point(this._X, this._Y);
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return ("{" + StringHelper.Format(Resources.POINTXY, this._X, this._Y) + "}");
        }

 



        #endregion
    }
}
