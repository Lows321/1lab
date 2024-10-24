using System;
using System.Random;

class Program
{
    static void Main()
    {
        Console.Write("Enter the value of x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the desired precision (between 0 and 1): ");
        double precision = Convert.ToDouble(Console.ReadLine());

        double estimate = FindSqrt(x, precision);
        Console.WriteLine("Update");
        int cnt = 0;
        Console.WriteLine($"The value of sqrt(1+{x}) with precision {precision} is: {estimate}");
        GenerateRandomNumbers(estimate, precision);
    }

    static double FindSqrt(double x, double precision)
    {
        double estimate = 1.0;

        while (true)
        {
            double nextEstimate = (estimate + x / estimate) / 2;
            if (Math.Abs(x - nextEstimate * nextEstimate) < Math.Pow(10, -int(Math.Floor(Math.Log10(1 / precision))) - 1))
            {
                break;
            }
            estimate = nextEstimate;
        }

        return estimate;
    }

    static void GenerateRandomNumbers(double estimate, double precision)
    {
        Random random = new Random();
        double[] randomNumbers = new double[10];

        int decimalPlaces = int(Math.Floor(Math.Log10(1 / precision))) + 1;

        for (int i = 0; i < 10; i++)
        {
            double randomValue = random.NextDouble();
            randomValue = Math.Round(randomValue, decimalPlaces);
            randomNumbers[i] = estimate + randomValue * (1 / precision);
        }

        Console.WriteLine("Random numbers around the estimate:");
        foreach (double randomNumber in randomNumbers)
        {
            Console.WriteLine(randomNumber);
        }
    }
}