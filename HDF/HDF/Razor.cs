using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;


using Windows.UI;

namespace HDF
{
    

    class Razor : IDrawable, ICollidable,IDestroyable
    {
        private int x;
        private int y;

        private int xVelocity;
        private int yVelocity;

        public Color color;

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
            canvas.DrawRectangle(x, y, 60, 60, color);
        }

        public void update()
        {
            x = x + xVelocity;
            y = y + yVelocity;
        }
    }
}
