using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

using Windows.UI;
using System.Drawing;
using Microsoft.Graphics;
using Windows.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Numerics;
using Windows.Foundation;

namespace HDF
{
    
    public class Fang : IUpdateable
    {

        Barrier barrier;
        private int x;
        private int y;
        public int width;
        public int height;

        private int xVelocity;
        private int yVelocity;
        public Rectangle rect { get; set; }

        public Windows.UI.Color color;

        public Fang(int x1,int y1, Windows.UI.Color color1,int height1,int width1,int xVelocity,int yVelocity,Barrier bar)
        {
            x = x1;
            y = y1;
            color = color1;
            height = height1;
            width = width1;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
            barrier = bar;
        }
        
        

        public bool update()
        {
            x = x + xVelocity;
            y = y + yVelocity;
            rect = new Rectangle(x, y, width, height);
            if (barrier.Collides(rect))
            {
                return false;
            }
            return true;
        }

        public bool Collides(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawRectangle(x, y, width, height, color, 4);
            canvas.DrawText("RAZOR.PNG", x + 2, y + 2, color);

            //BitmapImage image = new BitmapImage(new Uri(@"UpscaledRazor.png"));
            //CanvasBitmap imag = new CanvasBitmap();

            //Image mig = Image.FromFile("UpscaledRazor.png");
            //ICanvasImage fuck = ;
            //const image = new Image();

            //canvas.
            ////throw new NotImplementedException();
        }

        public bool Collides(Rectangle rect)
        {
            throw new NotImplementedException();
        }
    }

    public class FangGenerator
    {
        Random random;

        public static Fang GenerateFang(Windows.UI.Color color,Barrier bar)
        {
            Random random = new Random();

            int location = random.Next(8);
            Fang fang;
            if (location == 0)//clockwise around
            {
                int x = random.Next(0);
                int y = random.Next(0);
                int xvel = random.Next(10) + 1;
                int yvel = random.Next(6) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else if(location == 1)
            {

                int x = 900;
                x+=random.Next(120);
                int y = 0;
                int xvel = -2; 
                xvel += random.Next(4) + 1;
                int yvel = random.Next(10) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else if (location == 2)
            {
                int x = 1860;
                x += random.Next(120);
                int y = -50;
                y += random.Next(100);
                int xvel = -15;
                xvel += random.Next(10) + 1;
                int yvel = -10;
                yvel += random.Next(10) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else if (location == 3)
            {
                int x = 1920;
                int y = 480;
                y += random.Next(120);
                int xvel = -10;
                xvel += random.Next(3) + 1;
                int yvel = -1;
                yvel += random.Next(2) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else if (location == 4)//bottom right
            {
                int x = 1860;
                x += random.Next(120);
                int y = 1030;
                y += random.Next(100);
                int xvel = -15;
                xvel += random.Next(10) + 1;
                int yvel = -10;
                yvel += random.Next(5) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else if (location == 5)//bottom
            {
                //int x = 900;
                //x += random.Next(120);
                //int y = 1080;
                //int xvel = -2;
                //xvel += random.Next(4) + 1;
                //int yvel = -13; 
                //yvel+=random.Next(10) + 1;
                //fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
                fang = new Fang(6000, 6000, color, 0, 0, 0, 0, bar);
            }
            else if (location == 6)//bottom left
            {
                int x = -60;
                x += random.Next(120);
                int y = 1030;
                y += random.Next(100);
                int xvel = 0;
                xvel += random.Next(10) + 1;
                int yvel = 0;
                yvel += random.Next(6) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
            else //left middle
            {
                int x = 0;
                int y = 480;
                y += random.Next(120);
                int xvel = 0;
                xvel += random.Next(10) + 1;
                int yvel = -1;
                yvel += random.Next(2) + 1;
                fang = new Fang(x, y, color, 60, 60, xvel, yvel, bar);
            }
             //=// new Block(x, y, color, 60, 60);

            return fang;
        }
    }

    public class WackyImage : ICanvasImage
    {



        public Rect GetBounds(ICanvasResourceCreator resourceCreator)
        {
            throw new NotImplementedException();
        }

        public Rect GetBounds(ICanvasResourceCreator resourceCreator, Matrix3x2 transform)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
