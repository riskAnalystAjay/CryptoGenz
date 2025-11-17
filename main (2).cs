using System;
using System.Collections.Generic;

namespace CryptoGenz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Welcome to CryptoGenz =====\n");

            // List of cryptocurrencies
            List<string> cryptos = new List<string> { "Bitcoin", "Ethereum", "Cardano", "Dogecoin", "Solana" };
            
            // Dictionary to store fake prices
            Dictionary<string, double> cryptoPrices = new Dictionary<string, double>();
            Random rnd = new Random();

            // Initialize fake prices
            foreach (var crypto in cryptos)
            {
                cryptoPrices[crypto] = Math.Round(rnd.NextDouble() * 50000, 2);
            }

            while (true)
            {
                Console.WriteLine("\nAvailable Cryptos:");
                for (int i = 0; i < cryptos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cryptos[i]}");
                }
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice (number): ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("\nExiting CryptoGenz. Goodbye!");
                    break;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= cryptos.Count)
                {
                    string selectedCrypto = cryptos[choice - 1];
                    
                    // Simulate price change
                    double changePercent = rnd.Next(-5, 6); // -5% to +5%
                    double oldPrice = cryptoPrices[selectedCrypto];
                    double newPrice = Math.Round(oldPrice + (oldPrice * changePercent / 100), 2);
                    cryptoPrices[selectedCrypto] = newPrice;

                    Console.WriteLine($"\nCrypto: {selectedCrypto}");
                    Console.WriteLine($"Old Price: ${oldPrice}");
                    Console.WriteLine($"Price Change: {changePercent}%");
                    Console.WriteLine($"Current Price: ${newPrice}");
                }
                else
                {
                    Console.WriteLine("Invalid choice! Try again.");
                }
            }
        }
    }
}