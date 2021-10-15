namespace pong
{
    public static class Counter
    {
        private static int tick=1;

        public static int Tick { get; set; }
        public static bool isCountering { get; set; }
        private static bool reduce = false;

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
