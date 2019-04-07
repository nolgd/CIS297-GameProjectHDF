﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace HDF
{
    class Barrier : IDrawable, ICollidable
    {
        public RotateTransform Rotate;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public bool rotateClockwise = false;

        Barrier()
        {
            X = 500;
            Y = 200;
            Width = 5;
            Height = 2;
            Color =  Colors.Black;

            Rotate.CenterX = 500;
            Rotate.CenterY = 500;
            Rotate.Angle = 0;
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
            canvas.DrawRectangle(X, Y, Width, Height, Color, 3);
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
                Rotate.Angle += 1;
            }
            else if (!rotateClockwise)
            {
                Rotate.Angle -= 1;
            }
        
        }

    }
}
