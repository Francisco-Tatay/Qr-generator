using System;
using QRCoder;

class Program
{
    static void Main(string[] args)
    {
        // 1. Pedimos la URL al usuario
        Console.Write("Escribe la URL que quieres convertir a QR: ");
        string? url = Console.ReadLine();
        if (url == null) return;
        // 2. Llamamos a la función
        GenerateQrCode(url);
    }

    static void GenerateQrCode(string url)
    {
        // Imprimimos un mensaje de confirmación
        Console.WriteLine("\nGenerando QR para: " + url + "\n");
        
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Default);

        // Tu bucle original (el sencillo)
        foreach (var row in qrCodeData.ModuleMatrix)
        {
            foreach (bool pixel in row)
            {
                // Si el pixel es true, pintamos bloque, si no, espacio
                Console.Write(pixel ? "██" : "  ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("\nListo. Escanea el código.");
        Console.ReadLine(); // Esperamos a que el usuario presione Enter para cerrar
    }
}