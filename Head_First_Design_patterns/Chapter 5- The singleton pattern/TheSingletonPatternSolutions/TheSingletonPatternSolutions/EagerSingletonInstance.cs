namespace TheSingletonPatternSolutions
{
    public class EagerSingletonInstance
    {
        private static EagerSingletonInstance _instance = new EagerSingletonInstance();
        private EagerSingletonInstance() { }

        public static EagerSingletonInstance GetInstance()
        {
            return _instance;
        }
    }
}
