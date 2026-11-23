
using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Stopwatch reloj = new Stopwatch();

        // EJECUCION UNA DETRAS DE OTRA
        reloj.Start();

        await Task.Delay(1000);
        Console.WriteLine("Descarga 1 terminada");

        await Task.Delay(2000);
        Console.WriteLine("Descarga 2 terminada");

        await Task.Delay(3000);
        Console.WriteLine("Descarga 3 terminada");

        reloj.Stop();
        Console.WriteLine("Tiempo secuencial: " + reloj.ElapsedMilliseconds + " ms");

        // EJECUCION A LA VEZ
        reloj.Restart();

        Task tarea1 = Task.Delay(1000);
        Task tarea2 = Task.Delay(2000);
        Task tarea3 = Task.Delay(3000);

        await Task.WhenAll(tarea1, tarea2, tarea3);

        reloj.Stop();
        Console.WriteLine("Tiempo simultaneo: " + reloj.ElapsedMilliseconds + " ms");
    }
}
