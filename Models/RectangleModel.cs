using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RectangleModel
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Point TopCoordinate
        {
            get
            {
                return new Point { X = this.Left, Y = this.Top };
            }

        }
        public Point RightBottomCoordinate
        {
            get
            {
                return new Point { X = this.Left + this.Width, Y = this.Top + this.Height };
            }

        }

    }
}
