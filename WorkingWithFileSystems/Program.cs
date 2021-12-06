﻿using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            WorkWithDrives();
            //Console.WriteLine("Hello World!");
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0, -33} {1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
            WriteLine("{0, -33} {1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
            WriteLine("{0, -33} {1}", arg0: "Directory.GetCurrentDirectory()", arg1: GetCurrentDirectory());
            WriteLine("{0, -33} {1}", arg0: "Environment.CurrentDirectory", arg1: CurrentDirectory);
            WriteLine("{0, -33} {1}", arg0: "Environment.SystemDirectory", arg1: SystemDirectory);
            WriteLine("{0, -33} {1}", arg0: "Path.GetTempPath()", arg1: GetTempPath());

            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0, -33} {1}", arg0: " .System)",
                arg1: GetFolderPath(SpecialFolder.System));
            WriteLine("{0, -33} {1}", arg0: " .ApplicationData)",
                arg1: GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0, -33} {1}", arg0: " .MyDocuments)",
                arg1: GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0, -33} {1}", arg0: " .Personal)",
                arg1: GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkWithDrives()
        {
            WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}",
                "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine(
                        "{0, -30} | {1, -10} | {2, -7} | {3,18:NO} | {4,18:NO}",
                        drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0, -30} | {1, -10}", drive.Name, drive.DriveType);
                }
            }
        }
    }


}
