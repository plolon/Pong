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
                //move
                switchMove();
                //check collision
                //bound
            }
        }

        private void switchMove()
        {
            // X
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
    }


}
