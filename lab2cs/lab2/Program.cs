using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    // Клас для представлення маршруту
    class Route
    {
        public string StationName { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

        public Route(string stationName, TimeSpan arrivalTime, TimeSpan departureTime, int availableSeats)
        {
            StationName = stationName;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }
    }

// Клас для представлення квиткової каси
    class TicketOffice
    {
        private List<Route> _routes;

        public TicketOffice()
        {
            _routes = new List<Route>();
        }

        // Додати маршрут до квиткової каси
        public void AddRoute(Route route)
        {
            _routes.Add(route);
        }

        // Видалити маршрут з квиткової каси
        public void RemoveRoute(Route route)
        {
            _routes.Remove(route);
        }

        // Сортування маршрутів за кількістю вільних місць, днем тижня та номером рейсу
        public void SortRoutes()
        {
            _routes = _routes.OrderBy(r => r.AvailableSeats)
                .ThenBy(r => r.DepartureTime)
                .ThenBy(r => r.ArrivalTime)
                .ThenBy(r => r.StationName)
                .ToList();
        }

        // Показати список маршрутів
        public void ShowRoutes()
        {
            foreach (var route in _routes)
            {
                Console.WriteLine($"Station: {route.StationName}, Arrival: {route.ArrivalTime}, Departure: {route.DepartureTime}, Seats: {route.AvailableSeats}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TicketOffice ticketOffice = new TicketOffice();

            // Додавання даних про маршрути
            ticketOffice.AddRoute(new Route("Station A", new TimeSpan(8, 0, 0), new TimeSpan(8, 30, 0), 50));
            ticketOffice.AddRoute(new Route("Station B", new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0), 40));
            ticketOffice.AddRoute(new Route("Station C", new TimeSpan(10, 0, 0), new TimeSpan(10, 30, 0), 30));

            // Виведення несортованих маршрутів
            Console.WriteLine("Unsorted Routes:");
            ticketOffice.ShowRoutes();

            // Сортування та виведення відсортованих маршрутів
            Console.WriteLine("\nSorted Routes:");
            ticketOffice.SortRoutes();
            ticketOffice.ShowRoutes();
        }
    }
}