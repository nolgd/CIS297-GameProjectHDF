
using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Gaming.Input;
using Windows.UI;

namespace HDF
{
    class Game
    {
        public static int LEFT_EDGE = 10;
        public static int TOP_EDGE = 10;
        public static int RIGHT_EDGE = 790;
        public static int BOTTOM_EDGE = 450;

        private Random random;

        private Razor razor;
        private Hair hair;
        private List<IDrawable> drawables;

        private Gamepad controller;

        public Game()
        {
            razor = new Razor(15, 15, Colors.White, 50, 50,2,2);
            hair = new Hair(150, 200, Colors.Brown, 60, 60);
            drawables = new List<IDrawable>();
            drawables.Add(razor);
            drawables.Add(hair);

        }

        public bool update()
        {
            razor.update();
            hair.update();
            
            return true;
        }

        public void DrawGame(CanvasDrawingSession canvas)
        {
            foreach (var drawable in drawables)
            {
                drawable.Draw(canvas);
            }
        }


    }
}
