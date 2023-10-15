// See https://aka.ms/new-console-template for more information

using MightyGumball;

var gumballMachine = new GumballMachine(5);

gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();
gumballMachine.TurnCrank();
gumballMachine.TurnCrank();

gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();
gumballMachine.InsertQuarter();
gumballMachine.EjectQuarter();
gumballMachine.TurnCrank();