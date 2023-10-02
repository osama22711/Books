// See https://aka.ms/new-console-template for more information

using TheAdapterPattern;
using TheAdapterPattern.Interfaces;

ITurkey turkey = new Turkey();
IDuck turkeyDuckAdapter = new TurkeyDuckAdapter(turkey);

turkeyDuckAdapter.Quack();
turkeyDuckAdapter.Fly();