using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
            switch (direction)
            {
                case Direction.Up:
                    Pos = new Vector2(Pos.X, Pos.Y - 3);
                    break;
                case Direction.Down:
                    Pos = new Vector2(Pos.X, Pos.Y + 3);
                    break;
                case Direction.Immobile:
                    break;
            }
            CheckBorders();
        }
        public List<Rectangle> GetRect()
        {
            return new List<Rectangle>()
            {
                new Rectangle((int)Pos.X, (int)Pos.Y, 20, 25),
                new Rectangle((int)Pos.X, (int)Pos.Y+25, 20, 25),
                new Rectangle((int)Pos.X, (int)Pos.Y+50, 20, 50),
                new Rectangle((int)Pos.X, (int)Pos.Y+100, 20, 25),
                new Rectangle((int)Pos.X, (int)Pos.Y+125, 20, 25),
            };
        }
        private void CheckBorders()
        {
            if (Pos.Y < 0)
            {
                Pos = new Vector2(Pos.X, 0);
            }
            if (Pos.Y > CONFIG.HEIGHT - CONFIG.PLATFORM_SIZE)
            {
                Pos = new Vector2(Pos.X, CONFIG.HEIGHT - CONFIG.PLATFORM_SIZE);
            }
        }
    }
}
