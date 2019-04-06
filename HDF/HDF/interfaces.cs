
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input;
using Windows.UI;

namespace HDF
{
    
        public interface IDrawable
        {
            void Draw(CanvasDrawingSession canvas);
        }

        public interface ICollidable
        {
            bool CollidesLeftEdge(int x, int y);
            bool ColllidesRightEdge(int x, int y);
            bool CollidesTopEdge(int x, int y);
            bool CoolidesBottomEdge(int x, int y);
        }

        public interface IDestroyable : ICollidable
        { }
    
}
