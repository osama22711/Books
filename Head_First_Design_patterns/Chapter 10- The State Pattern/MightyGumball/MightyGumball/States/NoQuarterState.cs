namespace MightyGumball.States
{
    public class NoQuarterState : State
    {
        public NoQuarterState(GumballMachine gm) : base(gm)
        {
        }

        public override void Dispense()
        {
            Console.WriteLine(PAY_FIRST);
        }

        public override void EjectQuarter()
        {
            Console.WriteLine(NO_QUARTER);
        }

        public override void InsertQuarter()
        {
            Console.WriteLine(QUARTER_INSERTED);
            gumballMachine.SetState(gumballMachine.hasQuarterState);
        }

        public override void TurnCrank()
        {

            Console.WriteLine(TURNED_BUT_NO_QUARTER);
        }
    }
}
