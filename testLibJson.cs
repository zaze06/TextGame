using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System;
using System.Collections.Generic;
using TextGame;

namespace Test
{
    public class testLibJson
    {
        static void Main1(){
            Map list1 = new Map
            {
                map = Util.convertIntArrayToMap(new int[,]{
                    { 7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                    { 7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                    { 7,7,7,7,7,7,7,0,7,7,7,7,7,7,7,7,7,7,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,7,0,7,7,7,7,7,7,0,0,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,0,0,7,7,7,7,7},
                    { 7,7,7,7,7,7,7,0,7,7,7,7,7,7,0,7,0,0,0,7},
                    { 7,0,0,0,0,0,0,0,7,0,0,0,0,7,0,0,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,7,7,7,7,0,7,7,7,7,7,0,7},
                    { 7,0,7,0,0,0,0,7,0,0,0,7,0,0,0,0,0,7,0,7},
                    { 7,0,7,0,0,0,0,7,0,7,0,7,7,7,7,7,0,7,0,7},
                    { 7,0,7,7,7,7,7,7,0,7,0,0,0,0,0,7,0,7,0,7},
                    { 7,0,7,0,0,0,0,0,0,7,7,7,7,7,0,7,0,7,0,7},
                    { 7,0,7,0,7,7,7,7,7,7,0,0,0,0,0,7,0,0,0,7},
                    { 7,0,7,0,0,0,0,0,7,7,0,7,7,7,7,7,7,7,7,7},
                    { 7,0,7,7,7,7,7,0,7,7,0,0,0,0,0,0,0,0,0,7},
                    { 7,0,7,0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,0,7},
                    { 7,0,7,0,7,7,7,7,7,7,0,0,0,0,0,0,0,7,0,7},
                    { 7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,7,9,7},
                    { 7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                }),
                color = Util.convertIntArrayToList(Util.convertColorToIntArray(new ConsoleColor[]{ConsoleColor.DarkCyan, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.DarkGray, ConsoleColor.DarkGray,
                        ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.DarkMagenta,
                        ConsoleColor.White, ConsoleColor.DarkMagenta, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan,
                        ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Blue})),
                startPosition = Util.convertIntArrayToList(new int[2] { 1, 1 })
            };

            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Maps.json";

            File.WriteAllText(path, JsonConvert.SerializeObject(list1));
            list1 = null;
            string str = File.ReadAllText(System.IO.Path.GetDirectoryName
                (Assembly.GetEntryAssembly().Location) + "/Maps.json");
            list1 = JsonConvert.DeserializeObject<Map>(str);
            Console.Write(list1.toString());
        }
    }
}