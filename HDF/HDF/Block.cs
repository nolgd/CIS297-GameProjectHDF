using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Windows.UI;
namespace HDF
{
    class Block : IDrawable, ICollidable,IDestroyable
    {
        private int x;
        private int y;
        public int width;
        public int height;

       
        public Color color;

        public Block(int x1, int y1, Color color1, int height1, int width1)
        {
            x = x1;
            y = y1;
            color = color1;
            height = height1;
            width = width1;
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
            canvas.DrawRectangle(x, y, width, height, color);
        }

        public void update()
        {
            
        }
    }
}
