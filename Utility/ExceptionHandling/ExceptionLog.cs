using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web;

namespace Utility.ExceptionHandling
{
    public class ExceptionLog
    {
        public static void CheckFiles()
        //static void Main(string args)
        {

            // Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");

            string ErrorLogFilePath = HttpContext.Current.Server.MapPath("~/" + (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["errorLogPath"].ToString()) ? ConfigurationManager.AppSettings["errorLogPath"].ToString() : "/"));

            //if (args.ToString() == "System.String[]")
                //ErrorLogFilePath = "d:\\Radni\\SQL_WEB\\ConsoleApplication1\\WorkFiles";
            //else
                //ErrorLogFilePath = args[0].ToString();

            

            CreateEmptyFile(ErrorLogFilePath + "\\error.log");
            CreateEmptyFile(ErrorLogFilePath + "\\error_last.log");
            //CreateEmptyFile(ErrorLogFilePath + "\\error_backup.log");

            //CreateNewFolder(ErrorLogFilePath+"\\Errors");
            IzmestiPrevelikuBackupDatoteku(ErrorLogFilePath, 1);

            CreateEmptyFile(ErrorLogFilePath + "\\error_backup.log");

            MoveLastToBackup(ErrorLogFilePath);
            MoveLogToLast(ErrorLogFilePath);

            //Console.WriteLine("");
            //Console.WriteLine("Gotovo");

            //Console.ReadKey();
        }

        static void CreateEmptyFile(string args)
        {
            //string path = @ErrorLogFilePath + "\\MyTest.txt";
            string myFilePath = @args;
            if (!File.Exists(myFilePath))
            {
                // Create a file to write to. 
                //using (StreamWriter sw = File.CreateText(path))
                //{
                //sw.WriteLine("Hello");
                //}
                string myFolderPath = Path.GetDirectoryName(myFilePath);
                if (Directory.Exists(myFolderPath) == false)
                {
                    DirectoryInfo di = Directory.CreateDirectory(myFolderPath);
                }

                //StreamWriter sw = File.CreateText(myFilePath);
                //using (sw)
                //{
                //    sw.Close();
                //}

                using (StreamWriter sw = new StreamWriter(myFilePath, false, System.Text.Encoding.UTF8))
                {
                    //sw.WriteLine("ŠĐŽČĆ");
                    //sw.Close();
                }
            }

        }


        static void IzmestiPrevelikuBackupDatoteku(string FolderPath, int FileSizeMB)
        {

            //string path = @ErrorLogFilePath + "\\MyTest.txt";
            string path = @FolderPath;
            System.IO.Directory.CreateDirectory(path + "\\Errors");

            string FilePath = @FolderPath + "\\error_backup.log";
            if (File.Exists(FilePath))
            {
                long flength = new System.IO.FileInfo(FilePath).Length;
                //Console.WriteLine("Postoji");
                if (flength > FileSizeMB * 1000000)
                {
                    //Console.WriteLine("Jeste veći");


                    string myfilenamemask = "error_backup_";
                    string myfileext = "log";
                    int mysufixLenght = 6;

                    //int VecPostojeciBrojDatoteka = NumberOfFilesLikeMask(path + "\\Errors", "error_backup_", "log", 6);
                    int VecPostojeciBrojDatoteka = NumberOfFilesLikeMask(path + "\\Errors", myfilenamemask, myfileext, mysufixLenght);
                    //Console.WriteLine(VecPostojeciBrojDatoteka);

                    // Ovde
                    string sourceFile = @path + "\\error_backup.log";
                    //string mynewsufix = "8";
                    string mynewsufix = (VecPostojeciBrojDatoteka + 1).ToString().PadLeft(mysufixLenght, '0');
                    string destinationFile = @path + "\\Errors\\error_backup_" + mynewsufix + ".log";

                    System.IO.File.Move(sourceFile, destinationFile);


                }
            }
            else
            {
                //Console.WriteLine("Ne postoji");
            }

        }

        static int NumberOfFilesLikeMask(string FolderPath, string filenamemask, string fileextension, int numbermasklenght)
        {
            //string filenamemask = "error_backup_";
            int filenamemasklength = filenamemask.Length;

            //string[] filePaths = Directory.GetFiles(@path + "\\Errors", filenamemask + "*.log");
            string[] filePaths = Directory.GetFiles(@FolderPath, filenamemask + "*." + fileextension);

            int sufixcount = 1;
            int[] fsufixes = new int[sufixcount];

            foreach (string fpath in filePaths)
            {
                if (File.Exists(fpath))
                {
                    // This path is a file
                    //Console.WriteLine("{0} is a valid file or directory.", path);
                    string indexoferrorfile = fpath.Substring(fpath.IndexOf(filenamemask) + filenamemasklength, numbermasklenght);
                    //Console.WriteLine(indexoferrorfile);
                    try
                    {
                        fsufixes[sufixcount - 1] = Int32.Parse(indexoferrorfile);
                        sufixcount += 1;
                        Array.Resize(ref fsufixes, sufixcount);
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }

                //else
                //{
                // This path is a directory
                //ProcessDirectory(path);
                //Console.WriteLine("{0} is not a valid file or directory.", path);
                //}

            }

            Array.Resize(ref fsufixes, sufixcount - 1);

            //foreach (int myInt in fsufixes)
            //{
            //    Console.WriteLine(myInt);
            //}

            //Array.
            //fsufixes.

            //int maxValue = fsufixes.Max();
            //int maxVal = MaxArrayValue(fsufixes);
            int maxVal = 0;
            if (fsufixes.Length != 0)
            {
                maxVal = MaxArrayValue(fsufixes);
            }

            //Console.WriteLine("The maximum value in myArray is {0}", maxVal);

            return maxVal;

        }

        static int MaxArrayValue(int[] intArray)
        {
            int maxVal = intArray[0];
            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] > maxVal)
                    maxVal = intArray[i];
            }
            return maxVal;
        }

        static void MoveLastToBackup(string args)
        {

            try
            {
                //using (StreamReader sr = new StreamReader("d:\\Radni\\SQL_WEB\\ConsoleApplication1\\WorkFiles\\error.log"))
                //using (StreamReader sr = new StreamReader(args + "\\error_last.log", System.Text.Encoding.ASCII))
                using (StreamReader sr = new StreamReader(args + "\\error_last.log", System.Text.Encoding.UTF8))
                {
                    //String line = sr.ReadToEnd();
                    String line = sr.ReadToEnd();

                    //line += char(13);

                    string ErrorLogAllFileName = args + "\\error_backup.log";
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@ErrorLogAllFileName, true))
                    {
                        if (line != "")
                        {
                            file.WriteLine();
                            file.WriteLine(line);
                            file.WriteLine();
                            //file.WriteLine("*/*/* Kraj upisa " + DateTime.Now.ToString("dd.MM.yyyy HH:MM:ss") + " */*/*");
                            file.WriteLine("*/*/* Kraj upisa " + DateTime.Now + " */*/*");
                        }
                    }

                    //Ovo treba za iz error u error_last
                    //string ErrorLogAllFileName = args + "\\error_all.log";
                    //System.IO.File.WriteAllText(@ErrorLogAllFileName, line);

                    //Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


        static void MoveLogToLast(string args)
        {

            try
            {
                //using (StreamReader sr = new StreamReader("d:\\Radni\\SQL_WEB\\ConsoleApplication1\\WorkFiles\\error.log"))
                using (StreamReader sr = new StreamReader(args + "\\error.log"))
                {
                    String line = sr.ReadToEnd();

                    string ErrorLogAllFileName = args + "\\error_last.log";
                    System.IO.File.WriteAllText(@ErrorLogAllFileName, line);

                    //sr.Close();

                    ErrorLogAllFileName = args + "\\error.log";
                    System.IO.File.WriteAllText(@ErrorLogAllFileName, "");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void LogError(Exception ex)
        {
            if (ex is DLException || ex is Exception)
            {
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/" + ConfigurationManager.AppSettings["errorLogPath"] + "/error.log"), true))
                {
                    sw.WriteLine("----------------------------------");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("Message: " + ex.Message + Environment.NewLine + "Stack trace: " + ex.StackTrace);
                }
                if (ex.InnerException != null)
                    LogError(ex.InnerException);
            }
        }
    }
}
