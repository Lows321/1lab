using System;

public class RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        int numerator = a.Numerator * b.Denominator;
        int denominator = a.Denominator * b.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator == a.Denominator * b.Numerator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator > a.Denominator * b.Numerator;
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator < a.Denominator * b.Numerator;
    }


    public override string ToString()
    {
        if (Denominator == 1)
        {
            return Numerator.ToString();
        }
        else
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    public RationalNumber Simplify()
    {
        int gcd = GCD(Math.Abs(Numerator), Denominator);
        return new RationalNumber(Numerator / gcd, Denominator / gcd);
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первую дробь (например, 1/2):");
        string[] input1 = Console.ReadLine().Split('/');
        RationalNumber num1 = new RationalNumber(int.Parse(input1[0]), int.Parse(input1[1]));

        Console.WriteLine("Введите вторую дробь (например, 1/2):");
        string[] input2 = Console.ReadLine().Split('/');
        RationalNumber num2 = new RationalNumber(int.Parse(input2[0]), int.Parse(input2[1]));

        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
        Console.WriteLine("5. Сравнение");
        int operation = int.Parse(Console.ReadLine());

        RationalNumber result = null;

        switch (operation)
        {
            case 1:
                result = num1 + num2;
                break;
            case 2:
                result = num1 - num2;
                break;
            case 3:
                result = num1 * num2;
                break;
            case 4:
                if (num2.Numerator == 0)
                {
                    Console.WriteLine("Деление на нуль");
                    return;
                }
                result = num1 / num2;
                break;
            case 5:
                var greater = num1 > num2;
                var less = num1 < num2;
                var equal = num1 == num2;
                Console.WriteLine($"{num1} {(greater ? ">" : (less ? "<" : "=="))} {num2}");
                return;
            default:
                Console.WriteLine("Некорректный выбор операции");
                return;
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(result.ToString());

        Console.WriteLine("Хотите упростить результат? (да/нет)");
        string simplify = Console.ReadLine();
        if (simplify.ToLower() == "да")
        {
            result = result.Simplify();
            Console.WriteLine("Упрощенный результат:");
            Console.WriteLine(result.ToString());
        }
    }
}
