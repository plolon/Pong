using Microsoft.Xna.Framework.Input;

namespace pong
{
    public static class MovingHelper
    {
        static Direction player1;
        static Direction player2;

        public static void Move()
        {
            if (KeyboardHandler.IsPressed(Keys.Up))
            {
                player2 = Direction.Up;
            }
            if (KeyboardHandler.IsPressed(Keys.Down))
            {
                player2 = Direction.Down;
            }
            if (KeyboardHandler.IsPressed(Keys.W))
            {
                player1 = Direction.Up;
            }
            if (KeyboardHandler.IsPressed(Keys.S))
            {
                player1 = Direction.Down;
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
