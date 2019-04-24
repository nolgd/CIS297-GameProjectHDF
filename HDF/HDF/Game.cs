
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
        private int spawn;
        private int score;
        private int numBlocks;
        private Random random;
        
        private Fang razor;
        private Block hair;
        public Barrier barrier { get; set; }
        private List<IUpdateable> drawables;
        private List<IUpdateable> deleteables;
        private List<Fang> fangs;
        private Gamepad controller;


        public Game()
        {
            spawn = 0;
            numBlocks = 0;
            barrier = new Barrier();
            razor = new Fang(100, 100, Colors.White, 50, 50,2,2,barrier);
            hair = new Block(150, 200, Colors.Brown, 60, 60);
            drawables = new List<IUpdateable>();
            deleteables = new List<IUpdateable>();
            fangs = new List<Fang>();
            score = 0;
            for (float loop = 0; loop < 5; loop++)
            {
                for (float i = 0; i < 2 * Math.PI; i = i + 0.3f)
                {
                    float xx = (float)(940 + 35*loop* System.Math.Cos(i));
                    float yy = (float)(530 + 35*loop * System.Math.Sin(i));
                    

                    Block temp1 = new Block(xx, yy, Colors.SaddleBrown, 20, 20);

                    drawables.Add(temp1);
                    numBlocks++;
                }
            }

            drawables.Add(razor);
            drawables.Add(barrier);
        }

        public int getScore()
        {
            return score;
        }

        public bool update()
        {
            

            if (numBlocks > 0)
            {
                spawn++;
                if (spawn >= 60 - score)
                {
                    spawn = 0;
                    Fang temp = FangGenerator.GenerateFang(Colors.White, barrier);
                    drawables.Add(temp);
                    fangs.Add(temp);
                }



                foreach (var updateable in drawables)
                {
                    if (!updateable.update())
                    {
                        deleteables.Add(updateable);
                        score++;
                    }

                }

                foreach (var block in drawables)
                {
                    if (block is Block)
                    {
                        foreach (var fang in fangs)
                        {
                            if (block.Collides(fang.rect))
                            {
                                deleteables.Add(block);
                                numBlocks--;
                            }
                        }
                    }
                }


                if (deleteables.Count() > 0)
                {
                    foreach (var deletable in deleteables)
                    {
                        drawables.Remove(deletable);
                    }
                }

                return true;
            }
            return false;
        }

        public void DrawGame(CanvasDrawingSession canvas)
        {
            foreach (var drawable in drawables)
            {
                drawable.Draw(canvas);
            }
            canvas.DrawText("Score: ", 0, 0, Windows.UI.Colors.Black);
            canvas.DrawText(Convert.ToString(score),60,0,Windows.UI.Colors.Black);
            canvas.DrawText(Convert.ToString(numBlocks), 60, 50, Windows.UI.Colors.Black);
        }


    }
}
