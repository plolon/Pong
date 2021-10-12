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
    }
}
