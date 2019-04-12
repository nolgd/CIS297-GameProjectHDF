
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input;
using Windows.UI;
using System.Drawing;


namespace HDF
{
    
        public interface IDrawable
        {
            void Draw(CanvasDrawingSession canvas);
        }

        public interface ICollidable:IDrawable
        {
            bool Collides(Rectangle rect);
        }
        
        public interface IUpdateable :ICollidable
    {
        bool update();
    }
        public interface IDestroyable : ICollidable
        { }
    
}
