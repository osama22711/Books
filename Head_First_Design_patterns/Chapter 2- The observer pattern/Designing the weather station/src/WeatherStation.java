
public class WeatherStation {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		WeatherData weatherData = new WeatherData();
		
		CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
		
		weatherData.setMeasurements(80, 65, 30.4f);
		weatherData.setMeasurements(82, 70, 29.2f);
		weatherData.setMeasurements(78, 90, 29.2f);
		
		System.out.println("NEXT LINE IS BUILTIN OBSERVABLE");
		
		WeatherData2 weatherData2 = new WeatherData2();
		CurrentConditionsDisplay2 currentDisplay2 = new CurrentConditionsDisplay2(weatherData2);
		
		weatherData2.setMeasurements(74, 26, 28.2f);
	}

}
