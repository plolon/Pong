using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
