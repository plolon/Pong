using System;

namespace pong
{
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
            _Angle = Angle._60;
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
