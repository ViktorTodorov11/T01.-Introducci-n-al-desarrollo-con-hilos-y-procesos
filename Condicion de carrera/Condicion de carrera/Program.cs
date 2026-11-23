
using System;
using System.Threading;

class Program
{
    static int contador = 0;
    static object bloqueo = new object();

    static void Main()
    {
        // SIN PROTECCION
        for (int i = 0; i < 5; i++)
        {
            contador = 0;

            Thread h1 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                    contador++;
            });

            Thread h2 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                    contador++;
            });

            h1.Start();
            h2.Start();

            h1.Join();
            h2.Join();

            Console.WriteLine("Sin proteccion: " + contador);
        }

        // CON LOCK
        for (int i = 0; i < 5; i++)
        {
            contador = 0;

            Thread h1 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                {
                    lock (bloqueo)
                    {
                        contador++;
                    }
                }
            });

            Thread h2 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                {
                    lock (bloqueo)
                    {
                        contador++;
                    }
                }
            });

            h1.Start();
            h2.Start();

            h1.Join();
            h2.Join();

            Console.WriteLine("Con lock: " + contador);
        }

        // CON INTERLOCKED
        for (int i = 0; i < 5; i++)
        {
            contador = 0;

            Thread h1 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                    Interlocked.Increment(ref contador);
            });

            Thread h2 = new Thread(() =>
            {
                for (int j = 0; j < 100000; j++)
                    Interlocked.Increment(ref contador);
            });

            h1.Start();
            h2.Start();

            h1.Join();
            h2.Join();

            Console.WriteLine("Con Interlocked: " + contador);
        }
    }
}
