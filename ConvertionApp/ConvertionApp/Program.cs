// See https://aka.ms/new-console-template for more information
using Libwebp.Net;
using Libwebp.Standard;
using System.IO;

Console.WriteLine("Hello, World!");


var name = "img5";
var folder = $@"C:\Users\pjmfb\OneDrive\Escritorio\F92Images\jpg\";

// get file to encode
using var file = new FileStream($"{folder}{name}.jpg", FileMode.Open);

// copy file to Memory
using var ms = new MemoryStream();
await file.CopyToAsync(ms);

//setup configuration for the encoder
var config = new WebpConfigurationBuilder()
                .Output("output.webp")
                .Build();

// create an encoder and pass in the configuration
var encoder = new WebpEncoder(config);





// start encoding by passing your memorystream and filename      
var output = await encoder.EncodeAsync(ms, Path.GetFileName(file.Name));

using (FileStream outputFileStream = new FileStream($"{folder}{name}.webp", FileMode.Create))
{
    output.CopyTo(outputFileStream);
}