using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        private readonly IDictionary<string, int> _database;

        // Constructor to initialize database
        public UserCreditService()
        {
            _database = new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000}
            };
        }

        // Method to simulate contact with remote service and get client's credit limit
        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            // Simulate delay
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
            {
                return _database[lastName];
            }

            throw new ArgumentException($"Client {lastName} does not exist");
        }

        // Dispose method to release resources
        public void Dispose()
        {
            // Simulate disposing of resources
        }
    }
}