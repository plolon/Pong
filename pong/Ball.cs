using Microsoft.Xna.Framework;

namespace pong
{
    public class Ball
    {
        public Vector2 Pos { get; set; }
        public Ball(Vector2 startingPos)
        {
            Pos = startingPos;
        }
    }
}
