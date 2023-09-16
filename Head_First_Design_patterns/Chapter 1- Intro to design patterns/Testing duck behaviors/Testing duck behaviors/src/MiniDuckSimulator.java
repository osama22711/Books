import Client.Duck;
import Client.MallardDuck;
import Client.ModelDuck;
import FlyBehavior.FlyRocketPowered;

public class MiniDuckSimulator {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Duck mallard = new MallardDuck();
		mallard.performQuack();
		mallard.performFly();

		Duck model = new ModelDuck();
		model.performFly();
		// NOTE: the following is an example of changing a behavior at runtime
		model.setFlyBehavior(new FlyRocketPowered());
		model.performFly();
	}
}
