using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;

using Windows.UI;

namespace HDF
{
    
    class Fang : IDrawable, ICollidable,IDestroyable
    {
        private int x;
        private int y;
        public int width;
        public int height;

        private int xVelocity;
        private int yVelocity;

        public Color color;

        public Fang(int x1,int y1, Color color1,int height1,int width1,int xVelocity,int yVelocity)
        {
            x = x1;
            y = y1;
            color = color1;
            height = height1;
            width = width1;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
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
            canvas.DrawRectangle(x, y, width,height , color);
        }

        public void update()
        {
            x = x + xVelocity;
            y = y + yVelocity;
        }
    }
}
