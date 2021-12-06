﻿using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
        }
        //Writing to text streams
        static void WorkWithText()
        {
            //define a file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            //create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            //enumerate the strings, writing each one
            //to the stream on a separate line
            foreach (string item in Viper.Callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); //release resources

            //output the contents of the file
            WriteLine("{0} contains {1:NO} bytes.",
                arg0: textFile,
                arg1: new FileInfo(textFile).Length);

            WriteLine(File.ReadAllText(textFile));
        }

        //Writing to xml streams
        static void WorkWithXml()
        {
            FileStream? xmlFileStream = null;
            XmlWriter? xml = null;

            try
            {
                //define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                //create a file stream
                //FileStream xmlFileStream = File.Create(xmlFile);
                xmlFileStream = File.Create(xmlFile);

                //wrap the file stream in an XML writer helper
                //and automatically indent nested elements
                //XmlWriter xml = XmlWriter.Create(xmlFileStream,
                xml = XmlWriter.Create(xmlFileStream,
                new XmlWriterSettings { Indent = true });

                //write the Xml declaration
                xml.WriteStartDocument();

                //write a root element
                xml.WriteStartElement("callsigns");

                //enumerate the strings writing each one to the stream
                foreach (string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                //write the close root element
                xml.WriteEndElement();

                //close helper and stream
                xml.Close();
                xmlFileStream.Close();

                //output all the contents of the file
                WriteLine("{0} contains {1:NO} bytes.",
                    arg0: xmlFile,
                    arg1: new FileInfo(xmlFile).Length);
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                //if the path doesn't exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                    if (xmlFileStream != null)
                    {
                        xmlFileStream.Dispose();
                        WriteLine("The file stream's unmanaged resources have been disposed.");
                    }
                }
            }
        }

        static class Viper
        {
            //define an array of Viper pilot call signs
            public static string[] Callsigns = new[]
            {
                "Husker", "Starbuck", "Apollo", "Boomer",
                "Bulldog", "Athena", "Helo", "Racetrack"
            };
        }
    }
}
