using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

public class Test
{

    

    public Test()
	{
        List<KeyValuePair<int, Map>> maps = new List<KeyValuePair<int, Map>>();
        maps.Add(new KeyValuePair<int, Map>(0, new Map
        {
            map = new int[20, 20]
            {
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
            },
            color = new ConsoleColor[20] {ConsoleColor.DarkCyan, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.DarkGray, ConsoleColor.DarkGray,
                    ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.DarkGray, ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.DarkMagenta,
                    ConsoleColor.White, ConsoleColor.DarkMagenta, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.Cyan,
                    ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Blue},
            startPosition = new int[2] { 1, 1 }
        }));


        Maps maps1 = new Maps
        {
            maps = maps
        };

        string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/maps.json";

        File.WriteAllText(path, JsonConvert.SerializeObject(maps1));

        using (StreamWriter file = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, maps1);
        }
    }
	/*static void Main()
    {
        new Test();
    }*/
}
