// See https://aka.ms/new-console-template for more information
using Task3;


string directory = @"C:\Users\denzi\source\repos\Infobez.Task1\Task3\TestForTask3";

string files = FileHelper.GetFilesInDirectoryInString(directory);

string encodeText = Encoder.EncodeText(files, "avcvvfgfvbvfgfgh");

//File.Delete(directory); 

string decodeText = Decoder.Decode(encodeText, "avcvvfgfvbvfgfgh");

FileHelper.CreateDirectoryFromString(@"W:\", decodeText);