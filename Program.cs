using System;
using System.IO;
using QRCoder;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== GENERADOR DE QR A PNG ===");
        Console.Write("Introduce la URL: ");
        string? url = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(url)) return;

        try
        {
            // 1. Generamos la base del QR
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.H);

                // 2. Usamos PngByteQRCode
                var qrCode = new PngByteQRCode(qrCodeData);

                // 3. Llamada simplificada sin nombres de parámetros (Posicional)
                // Parámetros: (pixelsPerModule, darkColorRgb, lightColorRgb)
                byte[] qrBytes = qrCode.GetGraphic(
                    20,                             // Tamaño de cada punto
                    new byte[] { 0, 0, 0 },         // Color negro (R, G, B)
                    new byte[] { 255, 255, 255 }    // Color blanco (R, G, B)
                );

                // 4. Guardar archivo
                File.WriteAllBytes("codigo_qr.png", qrBytes);
                
                Console.WriteLine("\nArchivo 'codigo_qr.png' generado con éxito.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Presiona Enter para cerrar...");
        Console.ReadLine();
    }
}