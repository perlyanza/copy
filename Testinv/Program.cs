using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testinv
{
    internal class Program
    {
        private static string[] val;

        static void Main(string[] args)
        {
            val = args;
           
            if (args.Contains("-h"))
            {
                help();
            }
            else if (args.Contains("-o"))
            {
                if (args.Length == 5)
                {
                    if (args.Contains("-t"))
                    {
                        if (args.Contains("json"))
                        {
                           copyJson();
                        }
                        else if (args.Contains("text"))
                        {
                            copyText();
                        }
                    }
                    else
                    {
                        help(); 
                    }
                }
                else
                {
                    copy();

                }

            }
            else if (args.Contains("-t"))
            {
                if (args.Length == 3)
                {
                    if (val.Contains("json"))
                    {
                        json();
                    }
                    else if (val.Contains("text"))
                    {
                        text();
                    }
                    else
                    {
                        help();
                    }
                }
                else
                {
                    text();
                }
            }

        }
        static void help()
        {
            Console.WriteLine("-h \t\t Help");
            Console.WriteLine("-o \t\t For Copy To Directory var/b/b -o var/c/c");
            Console.WriteLine("-t -o \t\t For Copy To Directory var/b/b -t json -o var/c/c");
            Console.WriteLine("-t \t\t Open with text or json : var/file.log -t json");
        }
        static void json()
        {
            var logfile = val[0];
            if (File.Exists(logfile))
            {
                Stream stream = File.Open(logfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader streamReader = new StreamReader(stream);
                string str = streamReader.ReadToEnd();
                Console.WriteLine(str);
                streamReader.Close();
                stream.Close();
            }
            else
            {
                Console.WriteLine(logfile);
            }
        }
        static void text()
        {
            var logfile = val[0];
            if (File.Exists(logfile))
            {
                Stream stream = File.Open(logfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader streamReader = new StreamReader(stream);
                string str = streamReader.ReadToEnd();
                Console.WriteLine(str);
                streamReader.Close();
                stream.Close();
            }
            else
            {
                Console.WriteLine(logfile);
            }
        }
        static void copy()
        {
            string fileSource = val[0];
            string fileDest = val[2];
            if (!fileDest.Contains(".txt"))
            {
                fileDest += ".txt";
            }
            File.Copy(fileSource, fileDest, true);
            Console.WriteLine("Success Copy To "+fileDest);
        }
        static void copyJson()
        {
            string fileSource = val[0];
            string fileDest = val[4];
            if (!fileDest.Contains(".json"))
            {
                fileDest += ".json";
            }
            File.Copy(fileSource, fileDest, true);
            Console.WriteLine("Success Copy To " + fileDest);
        }
        static void copyText()
        {
            string fileSource = val[0];
            string fileDest = val[4];
            if (!fileDest.Contains(".txt"))
            {
                fileDest += ".json";
            }
            File.Copy(fileSource, fileDest, true);
            Console.WriteLine("Success Copy To " + fileDest);
        }
    }
}
