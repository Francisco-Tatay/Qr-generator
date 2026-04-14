using System;
using System.IO;
using QRCoder;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== GENERADOR DE QR: DUAL MODE (Transparente + Sólido) ===");
        Console.Write("Introduce la URL: ");
        string? url = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(url)) return;

        try
        {
            // 1. Configurar rutas a la raíz del proyecto
            string rutaEjecucion = AppDomain.CurrentDomain.BaseDirectory;
            string? rutaRaiz = Directory.GetParent(rutaEjecucion)?.Parent?.Parent?.FullName ?? rutaEjecucion;

            string pathTransparente = Path.Combine(rutaRaiz, "qr_sin_fondo.png");
            string pathConFondo = Path.Combine(rutaRaiz, "qr_con_fondo.png");

            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.H);
                var qrCode = new PngByteQRCode(qrCodeData);

                // --- GENERAR VERSIÓN SIN FONDO (PNG Transparente) ---
                // Negro sólido {0,0,0,255} y Fondo transparente {255,255,255,0}
                byte[] bytesTrans = qrCode.GetGraphic(20, 
                    new byte[] { 0, 0, 0, 255 }, 
                    new byte[] { 255, 255, 255, 0 });
                File.WriteAllBytes(pathTransparente, bytesTrans);

                // --- GENERAR VERSIÓN CON FONDO (Como un JPG) ---
                // Negro sólido {0,0,0,255} y Fondo blanco sólido {255,255,255,255}
                byte[] bytesFondo = qrCode.GetGraphic(20, 
                    new byte[] { 0, 0, 0, 255 }, 
                    new byte[] { 255, 255, 255, 255 });
                File.WriteAllBytes(pathConFondo, bytesFondo);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✅ ¡Archivos actualizados en la raíz!");
                Console.ResetColor();
                Console.WriteLine($"1. Transparente: {pathTransparente}");
                Console.WriteLine($"2. Con fondo:    {pathConFondo}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        Console.WriteLine("\nPresiona Enter para finalizar.");
        Console.ReadLine();
    }
}