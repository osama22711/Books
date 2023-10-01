namespace TheSingletonPatternSolutions
{
    public sealed class ThreadLockSingletonInstance
    {
        private static ThreadLockSingletonInstance? _instance = null;
        private static readonly object padlock = new object();

        ThreadLockSingletonInstance()
        {
        }

        public static ThreadLockSingletonInstance GetInstance()
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new ThreadLockSingletonInstance();
                }
                return _instance;
            }
        }
    }
}
