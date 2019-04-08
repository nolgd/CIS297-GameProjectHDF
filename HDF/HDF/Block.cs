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
    public class Block : IDrawable, ICollidable,IDestroyable,IUpdateable
    {
        private int x;
        private int y;
        public int width;
        public int height;

       
        public Windows.UI.Color color;

        public Block(int x1, int y1, Windows.UI.Color color1, int height1, int width1)
        {
            x = x1;
            y = y1;
            color = color1;
            height = height1;
            width = width1;
        }

        

        public void Draw(CanvasDrawingSession canvas)
        {
            canvas.DrawRectangle(x, y, width, height, color);
        }

        public bool update()
        {


            return true;
        }

        public bool Collides(Rectangle rect)
        {
            throw new NotImplementedException();
        }
    }

    public class BlockGenerator
    {
        Random random;

        public static Block GenerateBlock(Windows.UI.Color color)
        {
            Random random = new Random();
            int x =random.Next(700);
            int y = random.Next(700);

            Block block=new Block(x,y,color,60,60);

            return block;
        }
    }
}
