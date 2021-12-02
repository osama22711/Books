package Client;
import FlyBehavior.FlyNoWay;
import QuackBehavior.Quack;

public class ModelDuck extends Duck {
	public ModelDuck() {
		// TODO Auto-generated constructor stub
		flyBehavior = new FlyNoWay();
		quackBehavior = new Quack();
	}
	
	@Override
	public void display() {
		// TODO Auto-generated method stub
		System.out.println("I'm a model duck");
	}
}
