using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CON_ReadWriteDelete
{
    class ReadWriteDelete
    {

        /*  Hier ein paar Beispiele wie man mit C# Textdatein auslesen, erstellen und löschen kann 
         *  v 1.0 von Marc Winter IT42+ 
         *  2021-10-13
         *
         * Beim Schreiben und Lesen von großen Datein empfiehlt es sich die Methoden ReadAllTextAsync und WriteAllTextAsync zu verwenden.
         * Hier auf Konsolenebene ist Task, Async und Await nicht notwendig, da die Konsolenanwendung nicht blockiert wird bzw Parrallelität nicht notwendig ist.
         * Aber bei einer GUI Anwendung, wo Paralelität notwenig ist, ist es wichtig, dass die Anwendung nicht blockiert wird, da sonst die GUI nicht mehr reagiert.
         * 
         * Die Interessanten Klassen sind:
         * 
         * File.XX
         * Directory.XX
         * FileInfo.XX
         * DirectoryInfo.XX
         * 
         * Bitte den 'DateiPfad' entsprechend anpassen.
         */
                


        static string? DateiPfad = "C:\\Users\\MWB\\OneDrive\\CloudRepos\\CON_ReadAndWriteFiles\\CON_ReadAndWriteFiles\\bin\\Debug\\net7.0";

        static void Main(string[] args)
        {
            Console.WriteLine("1. Textdatei auslesen");
            Console.WriteLine("2. Textdatei erstellen");
            Console.WriteLine("3. Textdatei löschen");
            Console.Write("Eingabe: ");
            string eingabe = Console.ReadLine();

            Console.Clear();

            switch (eingabe)
            {
                case "1":
                    ShowTextFilesInFolder(DateiPfad ?? "C:\\");
                    Console.Write("Eingabe: ");
                    ReadFromFile(Console.ReadLine());
                    break;

                case "2":
                    Console.WriteLine("Gib den Namen der Datei ein");
                    Console.Write("Eingabe: ");
                    string fileName = Console.ReadLine() ?? "unbenannt.txt";

                    Console.WriteLine("Schreib mir den Text, der in die Datei geschrieben werden soll");
                    Console.Write("Eingabe: ");
                    WriteStringToFile(Console.ReadLine(), fileName);
                    break;

                case "3":
                    ShowTextFilesInFolder(DateiPfad ?? "C:\\");
                    Console.WriteLine("Gib den Namen der Datei ein, die gelöscht werden soll");
                    Console.Write("Eingabe: ");
                    DeleteTxtFile(Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    break;
            }

            AnyKeyToExit();
        }


        static void ShowTextFilesInFolder(string folderPath)
        {
            string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");
            List<string> FileList = new List<string>(txtFiles);

            Console.WriteLine("Wähle:");
            foreach (string txtFile in FileList)
            {
                Console.WriteLine(FileList.IndexOf(txtFile) + 1 + ". " + Path.GetFileName(txtFile));
            }
        }


        static async void WriteStringToFile(string textToWrite, string fileName)
        {
            try
            {
                await File.WriteAllTextAsync(fileName, textToWrite);

                Console.WriteLine(fileName + " wurde erfolgreich erstellt");
            }
            catch (IOException e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }

        }

        static async void ReadFromFile(string fileName)
        {
            try
            {
                string textFromFile = await File.ReadAllTextAsync(fileName);
                Console.WriteLine(textFromFile);
            }
            catch (IOException e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }
        }

        static void DeleteTxtFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
                Console.WriteLine(fileName + " wurde erfolgreich gelöscht");
            }
            catch (IOException e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }
        }

        static void AnyKeyToExit()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}