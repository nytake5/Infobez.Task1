// See https://aka.ms/new-console-template for more information


using Task2;

string container = File.ReadAllText(@"C:\Users\denzi\source\repos\Infobez.Task1\Task2\Container.txt");

string message = "Hello world!";

string stego = Encoder.EncodeMessage(container, message);
Console.WriteLine(stego);

var answer = Decoder.DecodeMessage(stego);
Console.WriteLine(answer);