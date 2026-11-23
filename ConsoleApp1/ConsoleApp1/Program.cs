
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread hilo = new Thread(() =>
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Hilo secundario: " + i);
                Thread.Sleep(500);
            }
        });

        hilo.Start();

        Console.WriteLine("Mensaje del hilo principal");

        Console.WriteLine("ID principal: " + Environment.CurrentManagedThreadId);

        hilo.Join();

        Console.WriteLine("ID secundario: " + hilo.ManagedThreadId);
    }
}

