namespace TesteIbmMQ.Domain.Utils
{
    public static class TimeUtil
    {
        public static void WaitUntil(DateTime futureTime)
        {
            DateTime now = DateTime.Now;

            TimeSpan timeToWait = futureTime - now;

            if (timeToWait.TotalMilliseconds > 0)
            {
                Thread.Sleep((int)timeToWait.TotalMilliseconds);
            }

        }
    }
}
