using System;

namespace BoBo2D_Eyal_Gal
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new Game1();
            game.Run();
        }

        /*
        static void Main()
        {
            using var splashScreen = new SplashScreen();
            splashScreen.Run();

            /*if (!splashScreen.IsActive)
            {
                using var mainMenu = new MainMenu();
                mainMenu.Run();
            }*/
        //}
    }
}
