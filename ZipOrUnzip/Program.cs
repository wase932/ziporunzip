using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Collections;

namespace ZipOrUnzip
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Read environmental variables:
            var action = string.Empty;
            var source = string.Empty;
            var destination = string.Empty;
            var replace = false;

            string[] arguments = Environment.GetCommandLineArgs();
            for (int i = 1; i < arguments.Length; i++)
            {
                switch (arguments[i].ToLower())
                {
                    case "-a": //action
                        action = arguments[i + 1].ToLower();
                        break;
                    case "-f": //source
                        source = arguments[i + 1].ToLower();
                        break;
                    case "-d": //destination 
                        destination = arguments[i + 1].ToLower();
                        break;
                    case "-r": //replace file if exists
                        replace = true;
                        break;

                }
            }
            
            if(action == "zip")
            {
                if (replace == true)
                    File.Delete(destination + ".zip");
                ZipFile.CreateFromDirectory(source, destination + ".zip");
            }
            else if(action == "unzip")
            {
                if (replace == true)
                    if(Directory.Exists(destination))
                        Directory.Delete(destination, true);
                ZipFile.ExtractToDirectory(source, destination);
            }
            else
            {
                throw new Exception("Invalid action. Expected  \"Zip\" or \"UnZip\".");
            }
        }

    }
}
