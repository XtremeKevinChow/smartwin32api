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
    /// specifies the width and height of a rectangle. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SIZE
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SIZE"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SIZE(Size size)
        {
            this._Width = size.Width;
            this._Height = size.Height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SIZE"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SIZE(SizeF size)
        {
            this._Width = (int)size.Width;
            this._Height = (int)size.Height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SIZE"/> class.
        /// </summary>
        /// <param name="aWidth">A width.</param>
        /// <param name="aHeight">A height.</param>
        public SIZE(int aWidth, int aHeight)
        {
            this._Width = aWidth;
            this._Height = aHeight;
        }

 



        #endregion

        #region Destructor

        #endregion

        #region Fields
        private int _Width;
        private int _Height;

        #endregion

        #region Events

        #endregion

        #region Operators

        /// <summary>
        /// Operator ==s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator ==(SIZE size1, SIZE size2)
        {
            if (size1 != Empty)
            {
                return size1.Equals(size2);
            }
            return (size2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator ==(SIZE size1, Size size2)
        {
            if (size1 != Empty)
            {
                return size1.Equals(size2);
            }
            return (size2 == Empty);
        }


        /// <summary>
        /// Operator ==s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator ==(Size size1, SIZE size2)
        {
            if (size1 != Empty)
            {
                return size2.Equals(size1);
            }
            return (size2 == Empty);
        }


        /// <summary>
        /// Implicit operators the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator Size(SIZE size)
        {
            return size.ToSize();
        }


        /// <summary>
        /// Implicit operators the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static implicit operator SIZE(Size size)
        {
            return new SIZE(size);
        }


        /// <summary>
        /// Operator !=s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator !=(SIZE size1, SIZE size2)
        {
            return !(size1 == size2);
        }


        /// <summary>
        /// Operator !=s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator !=(SIZE size1, Size size2)
        {
            return !(size1 == size2);
        }


        /// <summary>
        /// Operator !=s the specified a size1.
        /// </summary>
        /// <param name="size1">A size1.</param>
        /// <param name="size2">A size2.</param>
        /// <returns></returns>
        public static bool operator !=(Size size1, SIZE size2)
        {
            return !(size1 == size2);
        }


     
 


        #endregion

        #region Properties

        /// <summary>
        /// Empty Size
        /// </summary>
        public static readonly SIZE Empty = new SIZE(0, 0);


        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
            }
        }
 

        #endregion

        #region Methods

        /// <summary>
        /// Equalses the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Equals(SIZE size)
        {
            if (this._Width.Equals((object)size._Width) && this._Height.Equals((object)size._Height))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Equalses the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Equals(Size size)
        {
            if (this._Width.Equals((object)size.Width) && this._Height.Equals((object)size.Height))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is SIZE)
                {
                    return this.Equals((SIZE)obj);
                }
                if (!(obj is Size))
                {
                    return false;
                }
                return this.Equals((Size)obj);
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
            return (this._Width ^ this._Height);
        }



        /// <summary>
        /// Toes the size.
        /// </summary>
        /// <returns></returns>
        public Size ToSize()
        {
            return new Size(this._Width, this._Height);
        }


        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return ("{" + StringHelper.Format(Resources.SIZEWH, this._Width, this._Height) + "}");
        }



        #endregion
    }
}
