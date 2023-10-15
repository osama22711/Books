namespace MightyGumball.States
{
    public abstract class State
    {
        public const string QUARTER_INSERTED = "You inserted a quarter";
        public const string NO_QUARTER = "You haven't inserted a quarter";
        public const string PAY_FIRST = "You need to pay first";
        public const string TURNED_BUT_NO_QUARTER = "You turned, but there's no quarter";
        public const string ALREADY_TURNED = "Sorry, you already turned the crank";
        public const string TURNED_TWICE = "Turning twice doesn't get you another gumball!";
        public const string PLEASE_WAIT = "Please wait, we're already giving you a gumball";
        public const string NO_GUMBALL_DISPENSED = "No gumball dispensed";
        public const string QUARTER_RETURNED = "Quarter returned";
        public const string OUT_OF_GUMBALLS = "Oops, out of gumballs!";
        public const string WINNER = "YOU'RE A WINNER! You get two gumballs for your quarter";
        public const string ANOTHER_QUARTER = "You can't insert another quarter";
        public GumballMachine gumballMachine { get; set; }

        public State(GumballMachine gm)
        {
            gumballMachine = gm;
        }

        public abstract void InsertQuarter();
        public abstract void EjectQuarter();
        public abstract void TurnCrank();
        public abstract void Dispense();
    }
}
