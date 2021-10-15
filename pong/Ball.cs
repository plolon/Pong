using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace pong
{
    public class Ball
    {
        public Direction MyProperty { get; set; }

        public BallDirection direction;
        public int CurrentA { get; set; }

        public bool InMotion { get; private set; }

        public Vector2 Pos { get; set; }
        private Vector2 startingPos;
        public Ball(Vector2 startingPos)
        {
            Counter.StartCounter();
            CurrentA = 2;
            this.startingPos = startingPos;
            Pos = startingPos;
            direction = new BallDirection();
            InMotion = true;
        }
        
        public void Move()
        {
            if (InMotion)
            {
                if (!Counter.isCountering)
                {
                    switchMove();
                    CheckWallCollision();
                    CheckPaddles();
                    CheckLives();
                }
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
            if (Pos.Y < 0)
            {
                direction.Y = BallDirection.DirectionY.Down;
            }
            if (Pos.Y > CONFIG.HEIGHT - 20)
            {
                direction.Y = BallDirection.DirectionY.Up;
            }
        }
        private void CheckPaddles()
        {
            int? an = null;
            if (Pos.X < 25)
            {
                an = angle(MovingHelper.p1);
                if (an.HasValue)
                {
                    direction.X = BallDirection.DirectionX.Right;
                }
            }
            if (Pos.X > CONFIG.WIDTH - 45)
            {
                an = angle(MovingHelper.p2);
                if (an.HasValue)
                {
                    direction.X = BallDirection.DirectionX.Left;
                }
            }
            if (an.HasValue)
            {
                switch (an)
                {
                    case 0:
                        direction._Angle = BallDirection.Angle._60;
                        if (CurrentA > 1)
                            CurrentA--;
                        break;
                    case 1:
                        direction._Angle = BallDirection.Angle._45;
                        break;
                    case 2:
                        direction._Angle = BallDirection.Angle._30;
                        CurrentA++;
                        break;
                    case 3:
                        direction._Angle = BallDirection.Angle._45;
                        CurrentA++;
                        break;
                    case 4:
                        direction._Angle = BallDirection.Angle._60;
                        if (CurrentA > 1)
                            CurrentA--;
                        break;
                }
            }
        }
        private void CheckLives()
        {
            if (Pos.X < 10)
            {
                MovingHelper.Player1L--;
                SetStartingPos();
                Counter.StartCounter();
            }
            if (Pos.X > CONFIG.WIDTH - 10)
            {
                MovingHelper.Player2L--;
                SetStartingPos();
                Counter.StartCounter();
            }
        }

        private void SetStartingPos()
        {
            direction = new BallDirection();
            Pos = startingPos;
            CurrentA = 2;
        }

        private int? angle(List<Rectangle> col)
        {
            for (int i = 0; i < 5; i++)
            {
                if (col[i].Contains(Pos))
                {
                    return i;
                }
            }
            return null;
        }
    }
}

