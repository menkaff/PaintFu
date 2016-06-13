using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    class ControlResize
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        public  void Init(Control resizer, Control controlToResize, Direction direction, Cursor cursor)
        {
            bool dragging = false;
            Point dragStart = Point.Empty;
            int maxBound;
            int minBound;

            resizer.MouseHover += delegate(object sender, EventArgs e)
            {
                resizer.Cursor = cursor;
            };

            resizer.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                dragging = true;
                dragStart = new Point(e.X, e.Y);
                resizer.Capture = true;
            };

            resizer.MouseUp += delegate(object sender, MouseEventArgs e)
            {
                dragging = false;
                resizer.Capture = false;
            };

            resizer.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (dragging)
                {
                    if (direction == Direction.Horizontal)
                    {
                        minBound = resizer.Height;
                        maxBound = controlToResize.Parent.Height - controlToResize.Top - 20;
                        controlToResize.Height = Math.Min(maxBound, Math.Max(minBound, controlToResize.Height + (e.Y - dragStart.Y)));
                    }
                    if (direction == Direction.Vertical)
                    {
                        minBound = resizer.Width;
                        maxBound = controlToResize.Parent.Width - controlToResize.Left - 20;
                        controlToResize.Width = Math.Min(maxBound, Math.Max(minBound, controlToResize.Width + (e.X - dragStart.X)));
                    }
                }
            };
        }
    }


}
