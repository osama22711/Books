
public class StarbuzzCoffee {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Beverage beverage = new Espresso();
		
		beverage = new Mocha(beverage);
		beverage = new Mocha(beverage);
		beverage = new Whip(beverage);
		
		System.out.println(beverage.getDescription() + " $" + beverage.cost());
	}

}
