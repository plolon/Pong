using Microsoft.Xna.Framework;
using System;

namespace pong
{
    public class Ball
    {
        public Direction MyProperty { get; set; }

        public BallDirection direction;
        public int CurrentA { get; set; }

        public bool InMotion { get; private set; }

        public Vector2 Pos { get; set; }
        public Ball(Vector2 startingPos)
        {
            CurrentA = 2;
            Pos = startingPos;
            direction = new BallDirection();
            InMotion = true;
        }

        public void Move()
        {
            if (InMotion)
            {
                switchMove();
                CheckWallCollision();
                CheckPaddles();
            }
        }

        private void switchMove()
        {
            switch (direction.X)
            {
                case BallDirection.DirectionX.Left:
                    Pos = new Vector2(Pos.X - CurrentA, Pos.Y);
                    break;
                case BallDirection.DirectionX.Right:
                    Pos = new Vector2(Pos.X + CurrentA, Pos.Y);
                    break;
            }
            float y = CountAngle();
            switch (direction.Y)
            {
                case BallDirection.DirectionY.Up:
                    Pos = new Vector2(Pos.X, Pos.Y - y);
                    break;
                case BallDirection.DirectionY.Down:
                    Pos = new Vector2(Pos.X, Pos.Y + y);
                    break;
            }

        }

        private float CountAngle()
        {
            float tangent = 0f;
            switch (direction._Angle)
            {
                case BallDirection.Angle._30:
                    tangent = 0.57735f;
                    break;
                case BallDirection.Angle._45:
                    tangent = 1f;
                    break;
                case BallDirection.Angle._60:
                    tangent = 1.73205f;
                    break;
            }
            return tangent * CurrentA;
        }

        private void CheckWallCollision()
        {
            if(Pos.Y < 0)
            {
                direction.Y = BallDirection.DirectionY.Down;
            }
            if(Pos.Y > CONFIG.HEIGHT-20)
            {
                direction.Y = BallDirection.DirectionY.Up;
            }
        }
        private void CheckPaddles()
        {
            if(Pos.X < 25)
            {
                if (MovingHelper.p1.Contains(Pos))
                {
                    direction.X = BallDirection.DirectionX.Right;
                }
            }
            else
            {
                //p1 lose
            }
            if (Pos.X > CONFIG.WIDTH-45)
            {
                if (MovingHelper.p2.Contains(Pos))
                {
                    direction.X = BallDirection.DirectionX.Left;
                }
            }
            else
            {
                //p1 lose
            }
        }
    }


}
