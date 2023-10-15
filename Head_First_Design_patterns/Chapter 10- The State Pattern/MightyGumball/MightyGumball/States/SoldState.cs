namespace MightyGumball.States
{
    public class SoldState : State
    {
        public SoldState(GumballMachine gm) : base(gm)
        {
        }

        public override void Dispense()
        {
            gumballMachine.ReleaseBall();
            if (gumballMachine.count > 0)
            {
                gumballMachine.SetState(gumballMachine.noQuaterState);
            }
            else
            {
                Console.WriteLine(OUT_OF_GUMBALLS);
                gumballMachine.SetState(gumballMachine.soldOutState);
            }
        }

        public override void EjectQuarter()
        {
            Console.WriteLine(ALREADY_TURNED);
        }

        public override void InsertQuarter()
        {
            Console.WriteLine(PLEASE_WAIT);
        }

        public override void TurnCrank()
        {
            Console.WriteLine(TURNED_TWICE);
        }
    }
}