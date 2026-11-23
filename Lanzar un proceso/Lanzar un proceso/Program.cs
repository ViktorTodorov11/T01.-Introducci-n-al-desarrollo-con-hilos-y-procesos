using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        ProcessStartInfo inicio = new ProcessStartInfo();

        inicio.FileName = "dotnet";
        inicio.Arguments = "--version";
        inicio.UseShellExecute = false;
        inicio.RedirectStandardOutput = true;
        inicio.RedirectStandardError = true;
        inicio.CreateNoWindow = true;


        try
        {
            using (Process proceso = Process.Start(inicio))
            {
                string salida = proceso.StandardOutput.ReadToEnd();
                string error = proceso.StandardError.ReadToEnd();

                proceso.WaitForExit();

                Console.WriteLine("Resultado:");
                Console.WriteLine(salida);

                Console.WriteLine("Codigo de salida: " + proceso.ExitCode);

                if (error != "")
                {
                    Console.WriteLine("Error: " + error);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("No se pudo ejecutar el programa: " + ex.Message);
        }
    }
}