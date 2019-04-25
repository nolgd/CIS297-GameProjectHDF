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

    public class Barrier : IDrawable,IUpdateable
    {
        public struct rectD
        {
            public float x;
            public float y;
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
        public bool rotateAtAllCounter;
        public bool rotateAtAllClocker;
        private int speed;
        private int length;
        List<rectD> circle;
        private int startDraw;

        public Barrier()
        {
            circle = new List<rectD>();
            rotate = new RotateTransform();
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();
            bool f = rect1.IntersectsWith(rect2);
            rotateAtAllCounter = false;
            rotateAtAllClocker = false;
            X = 500;
            Y = 200;
            Width = 5;
            Height = 2;
            Color =  Colors.Red;
            rotateClockwise = false;
            rotate.CenterX = 500;
            rotate.CenterY = 500;
            rotate.Angle = 0;
            length = 105;
            speed = 7;
            startDraw = 0;
            for(float i = 0; i < 2*Math.PI; i=i+0.015f)
            {
                rectD temp1 = new rectD();
                temp1.x = (float)(940 + 280 * System.Math.Cos(i));
                temp1.y = (float)(530 + 280 * System.Math.Sin(i));
                temp1.width = 2;
                temp1.height = 2;
                circle.Add(temp1);
            }
        }


        public void Draw(CanvasDrawingSession canvas)
        {
            
            int sos = startDraw;
            int count = 0;
            while (count < length)
            {
                if (sos + count >= 419)
                {
                    sos = 0 - count;
                }
                rectD temp1 = circle[sos + count];
                canvas.DrawRectangle((float)temp1.x,(float)temp1.y,temp1.width,temp1.height,Color,3);
                count = count +1;
            }
            //canvas.DrawRectangle(X, Y, Width, Height, Color, 3);
            //canvas.DrawRectangle(rect);
        }

        public bool update()
        {
            /*
             * if keyinput == (keyleft || controllerleft)
             *  rotate counterclockwise
             * if keyinput == (keyright || controllerright)
             *  rotate clockwise
             *  */
            if (rotateAtAllCounter||rotateAtAllClocker)
            {
                if (rotateClockwise)
                {
                    startDraw += speed;
                    if (startDraw > 418)
                        startDraw = 0;
                }
                else if (!rotateClockwise)
                {
                    startDraw -= speed;
                    if (startDraw < 0)
                        startDraw = 418;
                }
            }
            return true;
        }

        public bool Collides(Rectangle rectObject)
        {
            int sos = startDraw;
            int count = 0;
            while (count < length)
            {
                if (sos + count >= 419)
                {
                    sos = 0 - count;
                }
                rectD temp1 = circle[sos + count];
                Rectangle tempObject = new Rectangle((int)temp1.x,(int)temp1.y,temp1.width,temp1.height);
                if (tempObject.IntersectsWith(rectObject))
                {
                    return true;
                }
                count = count + 2;
            }
            return false;
        }
    }
}
