using Microsoft.Xna.Framework;

namespace pong
{
    public class Platform
    {
        public Vector2 Pos { get; set; }
        public string Name { get; set; }
        public Platform(Vector2 startingPos, string name)
        {
            Pos = startingPos;
            Name = name;
        }
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    Pos = new Vector2(Pos.X, Pos.Y-1);
                    break;
                case Direction.Down:
                    Pos = new Vector2(Pos.X, Pos.Y + 1);
                    break;
                case Direction.Immobile:
                    break;
            }
            CheckBorders();
        }

        private void CheckBorders()
        {
            if (Pos.Y < 0)
            {
                Pos = new Vector2(Pos.X, 0);
            }
            if (Pos.Y > CONFIG.HEIGHT-CONFIG.PLATFORM_SIZE)
            {
                Pos = new Vector2(Pos.X, CONFIG.HEIGHT - CONFIG.PLATFORM_SIZE);
            }
        }
    }
}
