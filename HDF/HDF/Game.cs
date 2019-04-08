﻿
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
        
        private Fang razor;
        private Block hair;
        public Barrier barrier { get; set; }
        private List<IUpdateable> drawables;

        private Gamepad controller;

        public Game()
        {
            barrier = new Barrier();
            razor = new Fang(100, 100, Colors.White, 50, 50,2,2,barrier);
            hair = new Block(150, 200, Colors.Brown, 60, 60);
            drawables = new List<IUpdateable>();
            
            
            drawables.Add(razor);
            drawables.Add(FangGenerator.GenerateFang(Colors.White,barrier));
            drawables.Add(FangGenerator.GenerateFang(Colors.White, barrier));
            drawables.Add(hair);
            drawables.Add(barrier);
        }

        public bool update()
        {
            foreach(var updateable in drawables)
            {
                if (!updateable.update())
                {
                    drawables.Remove(updateable);
                }

            }


            if (!razor.update())
            {
                drawables.Remove(razor);
            }
            hair.update();
            barrier.update();
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
