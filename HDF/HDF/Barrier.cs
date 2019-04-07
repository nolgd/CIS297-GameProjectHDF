using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Windows.UI;
using Windows.UI.Xaml.Media;
using System.Drawing;

namespace HDF
{

    class Barrier : IDrawable, ICollidable
    {
        public struct rectD
        {
            public double x;
            public double y;
            public int width;
            public int height;
        };
        public RotateTransform rotate;
        
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Windows.UI.Color Color { get; set; }
        public bool rotateClockwise { get; set; }
        public Rectangle rect { get; set; }
        public Graphics g { get; set; }
        private int startDraw;
        private List<rectD> circle;
        public Barrier()
        {
            startDraw = 330;
            circle = new List<rectD>();
            rotate = new RotateTransform();
            X = 500;
            Y = 200;
            Width = 5;
            Height = 2;
            Color =  Colors.Black;
            rotateClockwise = false;
            rotate.CenterX = 500;
            rotate.CenterY = 500;
            rotate.Angle = 0;
            rect = new Rectangle(500, 500, 20, 20);

            for(int i = 0; i < 360; i++)
            {
                rectD temp1 = new rectD();
                temp1.x = (500 + 300 * System.Math.Cos(i));
                temp1.y = (500 + 300 * System.Math.Sin(i));
                temp1.width = 1;
                temp1.height = 1;
                circle.Add(temp1);
            }
        }

        public bool CollidesLeftEdge(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool CollidesTopEdge(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool ColllidesRightEdge(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool CoolidesBottomEdge(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            
            int sos = startDraw;
            int count = 0;
            while (count < 20)
            {
                if (sos + count >= 360)
                {
                    sos = 0 - count;
                }
                rectD temp1 = circle[sos + count];
                canvas.DrawRectangle((float)temp1.x,(float)temp1.y,temp1.width,temp1.height,Color,1);
                count++;
            }
            //canvas.DrawRectangle(X, Y, Width, Height, Color, 3);
            //canvas.DrawRectangle(rect);
        }

        public void Update()
        {
            /*
             * if keyinput == (keyleft || controllerleft)
             *  rotate counterclockwise
             * if keyinput == (keyright || controllerright)
             *  rotate clockwise
             *  */

            if (rotateClockwise)
            {
               startDraw += 1;
                if (startDraw > 359)
                    startDraw = 0;
            }
            else if (!rotateClockwise)
            {
                startDraw -= 1;
                if (startDraw < 0)
                    startDraw = 359;
            }
        
        }

    }
}
