# URL to QR Code Generator

A simple command-line application that converts URLs into QR codes displayed directly in the terminal.

## Description

This C# console application allows you to generate QR codes from URLs and display them as ASCII art in your terminal. Simply run the program, enter a URL, and get an instantly scannable QR code.

## Features

- Convert any URL to a QR code
- Display QR codes directly in the terminal using ASCII blocks
- Simple and easy to use command-line interface
- Built with .NET and QRCoder library

## Requirements

- .NET 10.0 or higher
- Windows, Linux, or macOS

## Installation

1. Clone this repository:
```bash
git clone <your-repository-url>
cd urlToQr
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

## Usage

Run the application:
```bash
dotnet run
```

Follow the prompt to enter a URL, and the QR code will be displayed in your terminal.

Example:
```
Escribe la URL que quieres convertir a QR: https://github.com

Generando QR para: https://github.com

[QR code appears here]

Listo. Escanea el código.
```

## Dependencies

- [QRCoder](https://github.com/codebude/QRCoder) - QR code generation library
- System.Drawing.Common - For graphics support

## Building from Source

```bash
dotnet build --configuration Release
```

The compiled executable will be in `bin/Release/net10.0/`

## License

This project is open source and available under the MIT License.

## Contributing

Contributions are welcome! Feel free to submit issues or pull requests.

