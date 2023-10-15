namespace MightyGumball.States
{
    public class HasQuarterState : State
    {
        public HasQuarterState(GumballMachine gm) : base(gm)
        {
        }

        public override void Dispense()
        {
            Console.WriteLine(NO_GUMBALL_DISPENSED);
        }

        public override void EjectQuarter()
        {
            Console.WriteLine(QUARTER_RETURNED);
            gumballMachine.SetState(gumballMachine.noQuaterState);
        }

        public override void InsertQuarter()
        {
            Console.WriteLine(ANOTHER_QUARTER);
        }

        public override void TurnCrank()
        {
            Console.WriteLine("You turned...");
            gumballMachine.SetState(gumballMachine.soldState);
        }
    }
}