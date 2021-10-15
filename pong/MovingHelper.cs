using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace pong
{
    public static class MovingHelper
    {
        public static Direction player1 { get; private set; }
        public static Direction player2 { get; private set; }

        public static List<Rectangle> p1 { get; set; }
        public static List<Rectangle> p2 { get; set; }

        public static int Player1L { get; set; }
        public static int Player2L { get; set; }

        public static void Move()
        {
            if (KeyboardHandler.IsPressed(Keys.Up))
            {
                player2 = Direction.Up;
            }
            else if (KeyboardHandler.IsPressed(Keys.Down))
            {
                player2 = Direction.Down;
            }
            else
            {
                player2 = Direction.Immobile;
            }

            if (KeyboardHandler.IsPressed(Keys.W))
            {
                player1 = Direction.Up;
            }
            else if (KeyboardHandler.IsPressed(Keys.S))
            {
                player1 = Direction.Down;
            }
            else
            {
                player1 = Direction.Immobile;
            }
        }
    }
}
public enum Direction
{
    Up,
    Down,
    Immobile,
}
