
using Infobez.Task1;

string directory = @"C:\Users\denzi\source\repos\Infobez.Task1\Infobez.Task1\Test";

List<MyFile> myFiles = new List<MyFile>();

HashFileHelper.GetAllFilesInDirectory(directory, ref myFiles);

foreach (MyFile file in myFiles)
{
    Console.WriteLine($"\t{file.Path}:\t{file.Hash}");
}

HashFileHelper.SaveInfoFile(myFiles);