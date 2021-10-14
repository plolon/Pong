using Microsoft.Xna.Framework;
using System;

namespace pong
{
    public class Ball
    {
        public Direction MyProperty { get; set; }

        public BallDirection direction;

        public bool InMotion { get; private set; }

        public Vector2 Pos { get; set; }
        public Ball(Vector2 startingPos)
        {
            Pos = startingPos;
            direction = new BallDirection();
            InMotion = true;
        }

        public void Move()
        {
            if (InMotion)
            {
                //move
                switchMove();
                //check collision
                //bound
            }
        }

        private void switchMove()
        {
            switch (direction.X)
            {
                case BallDirection.DirectionX.Left:
                    Pos = new Vector2(Pos.X - 1, Pos.Y);
                    break;
                case BallDirection.DirectionX.Right:
                    Pos = new Vector2(Pos.X + 1, Pos.Y);
                    break;
            }
        }

        public class BallDirection
        {
            public DirectionX X { get; set; }
            public DirectionY Y { get; set; }
            public Angle _Angle { get; set; }
            public BallDirection()
            {
                GenerateRandomDirections();
            }

            private void GenerateRandomDirections()
            {
                Random random = new Random();
                Y = (DirectionY)random.Next(0, 2);
                X = (DirectionX)random.Next(0, 2);
                _Angle = (Angle)random.Next(0, 3);
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
            public enum Angle
            {
                _30,
                _45,
                _60,
            }

        }
    }


}
