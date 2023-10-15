using MightyGumball.States;

namespace MightyGumball
{
    public class GumballMachine
    {
        public State soldOutState { get; set; }
        public State noQuaterState { get; set; }
        public State hasQuarterState { get; set; }
        public State soldState { get; set; }

        public int count = 0;
        private State state { get; set; }

        public GumballMachine(int numberOfGumballs)
        {
            count = numberOfGumballs;
            soldOutState = new SoldOutState(this);
            noQuaterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);
            SetInitialState();
        }

        public void InsertQuarter()
        {
            state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            state.EjectQuarter();
        }

        public void TurnCrank()
        {
            state.TurnCrank();
            state.Dispense();
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot....");
            if (count != 0)
            {
                count--;
            }
        }

        private void SetInitialState()
        {
            if (count > 0)
            {
                state = noQuaterState;
            }
            else
            {
                state = soldOutState;
            }
        }
    }
}