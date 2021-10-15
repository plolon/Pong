namespace pong
{
    public static class Counter
    {
        private static int tick;

        public static int Tick { get; set; }
        public static bool isCountering { get; set; }
        private static bool reduce;

        public static void StartCounter()
        {
            Tick = 3;
            isCountering = true;
            tick = 0;
            reduce = false;
        }
        public static void StopWatch()
        {
            checkTick();
            if (reduce)
            {
                Tick--;
                reduce = false;
            }
            if (Tick == 0)
                isCountering = false;
        }

        private static void checkTick()
        {
            tick++;
            if (tick == 20)
            {
                tick = 0;
                reduce = true;
            }
        }
    }
}
