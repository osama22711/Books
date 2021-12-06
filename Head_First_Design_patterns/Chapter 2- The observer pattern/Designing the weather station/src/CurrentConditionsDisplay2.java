import interfaces.DisplayElement;
import java.util.Observer;
import java.util.Observable;

public class CurrentConditionsDisplay2 implements Observer, DisplayElement {
	private float temperature;
	private float humidity;
	Observable observable;
	
	public CurrentConditionsDisplay2(Observable weatherData) {
		this.observable = weatherData;
		observable.addObserver(this);
	}
	
	public void Update(Observable obs, Object arg) {
		if (obs instanceof WeatherData2) {
			WeatherData2 weatherData = (WeatherData2)obs; 
			this.temperature = weatherData.getTemperature();
			this.humidity = weatherData.getHumidity();
			display();
		}
	}
	
	public void display() {
		System.out.println("Current conditions: " + temperature + "F degrees and " + humidity + "% humidity");
	}
}
