using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HDF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        Game game;
        int score;
        public BlankPage1()
        {
            this.InitializeComponent();
            game = new Game();
            Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
            Window.Current.CoreWindow.KeyUp += Canvas_KeyUp;
            score = game.getScore();
        }
        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            game.DrawGame(args.DrawingSession);
        }
        private void Canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            game.update();
        }

        private void Canvas_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {

            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                game.barrier.rotateAtAllClocker = true;
                game.barrier.rotateClockwise = true;
            }
            else if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                game.barrier.rotateAtAllCounter = true;
                game.barrier.rotateClockwise = false;
            }
        }

        private void Canvas_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {

            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                game.barrier.rotateAtAllClocker = false;
            }
            else if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                game.barrier.rotateAtAllCounter = false;
            }
        }
    }
}
