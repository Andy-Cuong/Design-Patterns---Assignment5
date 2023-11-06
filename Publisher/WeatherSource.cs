using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns___Assignment5.Interfaces;

namespace Design_Patterns___Assignment5.Publisher
{
    public class WeatherSource
    {
        //Public properties that will be retrieved when implementing concrete subscribers
        public double CurrentTemperature { get; private set; } = default!;
        public string CurrentHumidity { get; private set; } = default!;
        public string CurrentPressure { get; private set; } = default!;
        public double StatTemperature { get; private set; } = default!;
        public string StatHumidity { get; private set; } = default!;
        public string StatPressure { get; private set; } = default!;
        public double ForecastTemperature { get; private set; } = default!;
        public string ForecastHumidity { get; private set; } = default!;
        public string ForecastPressure { get; private set; } = default!;

        private List<ISubscriber> subscribers = new List<ISubscriber>();

        public WeatherSource()
        {
            GenerateDummyData();
        }

        /***
         * Subscriber will add itself to publisher when initialized
         */
        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        /***
         * When a subscriber no longer needs this publisher, it will remove
         * itself from the publisher
         */
        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        /***
         * Notify all subscribers whenever there is a data change
         */
        private void notifySubscribers()
        {
            foreach (ISubscriber subscriber in subscribers)
            {
                subscriber.update(this);
            }
        }

        /***
         * Methods that fake data fetching. IRL, data should come from public APIs or ICT sensors
         */
        public void GenerateDummyData()
        {
            GenerateDummyCurrentData();
            GenerateDummyStatData();
            GenerateDummyForecastData();
            notifySubscribers();
        }

        private void GenerateDummyCurrentData()
        {
            Random rng = new Random();
            CurrentTemperature = Math.Round(30 * rng.NextDouble() - 10, 1); //From -10.0 to 20.0
            CurrentHumidity = Math.Round(60 * rng.NextDouble() + 20, 1) + "%";//From 20.0% to 80.0%
            CurrentPressure = rng.Next(0, 2) == 0 ? "low" : "high"; //Either high or low
        }

        private void GenerateDummyStatData()
        {
            Random rng = new Random();
            StatTemperature = Math.Round(30 * rng.NextDouble() - 10, 1); //From -10.0 to 20.0
            StatHumidity = Math.Round(60 * rng.NextDouble() + 20, 1) + "%";//From 20.0% to 80.0%
            StatPressure = rng.Next(0, 2) == 0 ? "low" : "high"; //Either high or low
        }

        private void GenerateDummyForecastData()
        {
            Random rng = new Random();
            ForecastTemperature = Math.Round(30 * rng.NextDouble() - 10, 1); //From -10.0 to 20.0
            ForecastHumidity = Math.Round(60 * rng.NextDouble() + 20, 1) + "%";//From 20.0% to 80.0%
            ForecastPressure = rng.Next(0, 2) == 0 ? "low" : "high"; //Either high or low
        }
    }
}
