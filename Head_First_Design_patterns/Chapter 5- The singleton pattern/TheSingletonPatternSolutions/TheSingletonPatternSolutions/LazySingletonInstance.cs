namespace TheSingletonPatternSolutions
{
    public class LazySingletonInstance
    {
        private static LazySingletonInstance _instance;
        private LazySingletonInstance() { }

        public static LazySingletonInstance GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LazySingletonInstance();
            }
            return _instance;
        }
    }
}
