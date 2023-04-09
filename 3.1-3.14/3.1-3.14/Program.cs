using System;
using System.Drawing;
using System.Text.RegularExpressions;

public class MaxMinDemo
{
    public static void Main()
    {
        //3.1
        int x;
        int y;
        int z;

        Console.Write("Введите первое число: ");
        x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите третье число: ");
        z = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Наибольшее число из трех: " +
        FindMax3(x, y, z));
        Console.WriteLine("Наименьшее число из трех: " +
        FindMin3(x, y, z));
        Console.ReadLine();

        //3.2-3.3
        String[] s = Regex.Split("Январь Февраль Март Апрель Май Июнь Июль Август Сентябрь Октябрь Ноябрь Декабрь", " ");
        // Выводим 12 элемент массива
        Console.WriteLine(s[11]);


        //3.4 . Конвертируем градусы в радианы
        Console.Write("\nКонвертируем градусы в радианы: ");
        double degrees = Convert.ToInt32(Console.ReadLine());
        double radians = (Math.PI / 180) * degrees;
        Console.WriteLine(radians);

        //3.5 Конвертируем радианы в градусы
        Console.Write("Конвертируем радианы в градусы: ");
        double radiansn = Convert.ToDouble(Console.ReadLine());
        double degreesn = (180 / Math.PI) * radiansn;
        Console.WriteLine(degreesn);

        //3.6 Определение четности числа
        Console.Write("Определение четности числа: ");
        int intValue = Convert.ToInt32(Console.ReadLine());
        if ((intValue % 2) == 0)
        {
            Console.WriteLine("Чётное");
        }
        else { Console.WriteLine("Нечётное"); }

        //3.7  Перегруженная версия метода IsEven для чисел типа Long
        Console.Write("Определение четности числа типа long: ");
        long lValue = Convert.ToInt64(Console.ReadLine());
        if ((intValue % 2) == 0)
        {
            Console.WriteLine("Чётное");
        }

        //3.9 Конвертируем градусы Фаренгейта в градусы Цельсия
        Console.Write("Конвертируем градусы Фаренгейта в градусы Цельсия: ");
        double Fahrenheit = Convert.ToInt32(Console.ReadLine());
        double f = (5.0 / 9.0) * (Fahrenheit - 32);
        Console.WriteLine(f);

        //3.10
        Console.Write("Конвертируем градусы Цельсия в градусы Фаренгейта: ");
        double Celsius = Convert.ToInt32(Console.ReadLine());
        double с = (((9.0 / 5.0) * Celsius) + 32);
        Console.WriteLine(с);

        //3.12  Подсчет суммы всех целых чисел диапазона
        Console.Write("Введите число от 1 до 125");
        Console.WriteLine();
        byte su = Convert.ToByte(Console.ReadLine());
        Console.WriteLine(SumAll(su));
        Console.ReadLine();

        //3.13 Получение списка простых чисел
        // Выводим список простых чисел
        Console.Write("Введите число от 2 до 100000");
        Console.WriteLine();
        x = Convert.ToInt32(Console.ReadLine());
        int[] Array = GetSimpleNumbers(x);
        //вывод чисел в консоль
        for (int i = 0; i < Array.Length; i++)
            Console.Write("{0} ", Array[i]);
        Console.ReadLine();

        //3.14  Пример программы, выводящей свой код
        //string s1 = "using System;class A{{static void Main(){{string s ={ 0} { 1}{ 0}; char q = '{0}'; Console.Write(s, q, s);}}}}";
        //char q = '"'; Console.Write(s1, q, s1);
    }


    public static int FindMax3(int a, int b, int c)
    {
        int max;
        max = Math.Max(a, Math.Max(b, c));
        return max;
    }
    public static int FindMin3(int a, int b, int c)
    {
        int min;
        min = Math.Min(a, Math.Min(b, c));
        return min;
    }


    // 3.8. Получение старшего и младшего слов из 32-битного целого числа
    public static int GetHighWord(int intValue)
    {
        return (intValue & (0xFFFF << 16));
    }
    public static int GetLowWord(int intValue)
    {
        return (intValue & 0x0000FFFF);
    }

    public static int SumAll(byte Value)
    {
        int sum;
        sum = 0;
        for (int i = 1; i <= Value; i++)
            sum = sum + i;
        return sum;
    }

    static int[] GetSimpleNumbers(int Value)
    {
        if (Value < 2)
        {
            int[] A = new int[0];
            
        return A;
        }
        else
        {
            int[] T = new int[Value];
            T[0] = 2;
            int K = 1, I = 3;
            bool B = true;
            while (I <= Value)
            {
                B = true;
                for (int J = 0; J < K; J++)
                    if (I % T[J] == 0)
                    {
                        B = false;
                        break;
                    }
                if (B) T[K++] = I;
                I += 2;
            }
            int[] A = new int[K];
            for (int J = 0; J < A.Length; J++)
                A[J] = T[J];
            return A;
        }
    }

}
