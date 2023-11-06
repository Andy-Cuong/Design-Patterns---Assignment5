using Design_Patterns___Assignment5.ConcreteDisplays;
using Design_Patterns___Assignment5.Publisher;

WeatherSource src = new WeatherSource();

//Show data first time
CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(src);
StatisticsDisplay statDisplay = new StatisticsDisplay(src);
ForecastDisplay forecastDisplay = new ForecastDisplay(src);

//Each time weather data regenerate (refresh), each display should be notified and show the new data
int i = 0;
while (i++ < 3) { //Show 3 more times
    Console.WriteLine();
    src.GenerateDummyData(); 
}