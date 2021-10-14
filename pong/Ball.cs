using Microsoft.Xna.Framework;
using System;

namespace pong
{
    public class Ball
    {
        public Direction MyProperty { get; set; }

        public BallDirection direction;

        public Vector2 Pos { get; set; }
        public Ball(Vector2 startingPos)
        {
            Pos = startingPos;
            direction = new BallDirection();
        }

        public class BallDirection
        {
            public DirectionX X { get; set; }
            public DirectionY Y { get; set; }
            public BallDirection()
            {
                GenerateRandomDirections();
            }

            private void GenerateRandomDirections()
            {
                Random random = new Random();
                Y = (DirectionY)random.Next(0, 2);
                X = (DirectionX)random.Next(0, 2);
            }
            public enum DirectionY
            {
                Up,
                Down,
            }
            public enum DirectionX
            {
                Left,
                Right,
            }


        }
    }


}
