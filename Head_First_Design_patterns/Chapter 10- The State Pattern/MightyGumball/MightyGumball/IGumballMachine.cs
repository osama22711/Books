namespace MightyGumball
{
    public interface IGumballMachine
    {
        public int GetGumballCount();
        public void InsertQuarter();
        public void EjectQuarter();
        public void TurnCrank();
    }
}
