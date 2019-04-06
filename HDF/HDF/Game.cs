
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
        private List<IDrawable> drawables;

        private Gamepad controller;

        public Game()
        {


        }

        public bool update()
        {

            return true;
        }




    }
}
