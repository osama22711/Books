namespace MightyGumball.States
{
    public class SoldOutState : State
    {
        public SoldOutState(GumballMachine gm) : base(gm)
        {
        }

        public override void Dispense()
        {
            Console.WriteLine(NO_GUMBALL_DISPENSED);
        }

        public override void EjectQuarter()
        {
            Console.WriteLine(NO_QUARTER);
        }

        public override void InsertQuarter()
        {
            Console.WriteLine("Machine is soldout...");
        }

        public override void TurnCrank()
        {
            Console.WriteLine(NO_GUMBALL_DISPENSED);
        }
    }
}