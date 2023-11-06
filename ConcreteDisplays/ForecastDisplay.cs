using Design_Patterns___Assignment5.Interfaces;
using Design_Patterns___Assignment5.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns___Assignment5.ConcreteDisplays
{
    public class ForecastDisplay : ISubscriber, IDisplay
    {
        public double Temperature { get; set; } = default!;
        public string Humidity { get; set; } = default!;
        public string Pressure { get; set; } = default!;

        // On initializing, subscribe to publisher and call update()
        public ForecastDisplay(WeatherSource source)
        {
            source.AddSubscriber(this);
            update(source);
        }

        /***
         * Update and display the latest data
         */
        public void update(WeatherSource source)
        {
            Temperature = source.ForecastTemperature;
            Humidity = source.ForecastHumidity;
            Pressure = source.ForecastPressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Tomorrow temperature: {Temperature} degree, humidity: {Humidity}, pressure: {Pressure}");
        }
    }
}
