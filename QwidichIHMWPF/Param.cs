using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwidichIHMWPF
{
    [SerializableAttribute]
    public class Param
    {
        public double Height
        {
            get
            {
                return mHeight;
            }
            set
            {
                mHeight = value;
            }
        }
        private double mHeight;

        public double Width
        {
            get
            {
                return mWidth;
            }
            set
            {
                mWidth = value;
            }
        }
        private double mWidth;

        public double XPos
        {
            get
            {
                return mXPos;
            }
            set
            {
                mXPos = value;
            }
        }
        private double mXPos;

        public double YPos
        {
            get
            {
                return mYPos;
            }
            set
            {
                mYPos = value;
            }
        }
        private double mYPos;

    }
}
