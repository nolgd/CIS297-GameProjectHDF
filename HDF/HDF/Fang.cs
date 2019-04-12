using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

using Windows.UI;
using System.Drawing;
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
            //throw new NotImplementedException();
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
            int x = random.Next(700);
            int y = random.Next(700);
            int xvel = random.Next(10)+1;
            int yvel = random.Next(10)+1;
            Fang fang= new Fang(x,y,color,60,60,xvel,yvel,bar); //=// new Block(x, y, color, 60, 60);

            return fang;
        }
    }

}
