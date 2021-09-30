﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace TextGame
{
    public class GetMaps
    {
        static Maps maps;// = new Maps();
        public GetMaps()
        {
            Console.Write("Start GetMaps\r\n");
            string str = File.ReadAllText(System.IO.Path.GetDirectoryName
                (Assembly.GetEntryAssembly().Location) + "/Maps.json");
            maps = JsonConvert.DeserializeObject<Maps>(str);
            //Console.WriteLine(str);
            Console.Write(maps.toString());
            //Console.Write("HEJHEJ");
            Environment.Exit(0);
        }

        public static /*Map/*/ int[,]/**/ getMap(int v)
        {
            //return maps.maps[v];
            /**/
            switch (v){
                case -1: return new int[20,20]
                    {
                        {7,7,7,7,7,0,7,7,7,0,3,0,0,0,2,0,7,7,7,0},
                        {0,0,7,0,0,0,7,0,0,0,0,3,0,2,0,0,0,7,0,0},
                        {0,0,7,0,0,0,7,7,7,0,0,0,7,0,0,0,0,7,0,0},
                        {0,0,7,0,0,0,7,0,0,0,0,2,0,3,0,0,0,7,0,0},
                        {0,0,7,0,0,0,7,7,7,0,2,0,0,0,3,0,0,7,0,0},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {0,7,7,7,7,0,0,0,2,3,0,0,0,7,0,0,0,7,0,0},
                        {7,0,0,0,0,0,0,0,1,1,0,0,0,7,7,0,7,7,0,0},
                        {7,0,7,7,7,0,0,2,7,7,3,0,0,7,0,7,0,7,0,0},
                        {7,0,0,0,7,0,0,1,0,0,1,0,0,7,0,0,0,7,0,0},
                        {0,7,7,7,7,0,2,0,0,0,0,3,0,7,0,0,0,7,0,0},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {7,7,7,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,0,7,0,7,7,7,7,7,7,7,7,7,0,0,0,7},
                        {7,7,7,0,0,7,0,0,0,0,0,0,12,0,0,0,0,7,0,7},
                        {7,0,0,0,0,7,0,7,0,7,7,7,7,7,7,7,7,7,0,7},
                        {7,7,7,0,0,7,0,7,0,0,0,0,12,0,0,0,0,7,0,7},
                        {0,0,0,0,0,7,0,7,7,7,7,7,7,7,7,0,7,7,0,7},
                        {0,0,0,0,0,7,0,11,18,11,0,0,0,0,0,0,0,7,8,7},
                        {0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                    };
                case 0: Game.customTiles = new CustomTile[]{new TestTile()};
                    return new int[20,20]
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
                    };
                case 1: return new int[20,20]
                    {
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                        {7,7,0,7,7,7,7,0,7,7,7,7,7,7,7,7,7,7,0,7},
                        {7,0,0,0,7,7,7,8,0,0,0,0,0,0,0,0,0,7,0,7},
                        {7,0,0,0,0,0,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                        {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                        {7,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,0,7,0,7},
                        {7,0,0,0,7,8,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                        {7,0,0,0,7,7,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                        {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,7,0,0,0,7},
                        {7,0,0,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                        {7,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7},
                        {7,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                        {7,0,0,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,7,0,7,0,0,0,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,7,0,0,0,7,0,0,0,0,0,0,0,0,0,9,7},
                        {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                    };
                case 2: return new int[20,20]
                    {
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                        {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7},
                        {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7},
                        {7,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,0,7,0,7},
                        {7,0,7,0,7,0,0,0,0,0,0,0,0,0,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,7,7,7,7,7,7,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,0,0,0,0,0,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,0,7,7,7,7,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,0,7,7,7,7,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,0,11,0,8,7,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,7,7,7,7,7,7,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,0,0,0,0,0,0,0,0,7,0,7,0,7,0,7},
                        {7,0,7,0,7,7,7,7,7,7,7,7,7,7,0,7,0,7,9,7},
                        {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7,7,7},
                        {7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7,8,7},
                        {7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,7},
                        {7,0,7,7,0,7,7,7,7,7,7,7,7,7,7,7,7,11,0,7},
                        {7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                    };
                case 3: return new int[20,20]
                    {
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,0,0,0,0,0,0,12,0,12,0,0,0,0,7,0,0,0,7},
                        {7,0,7,7,7,7,7,13,7,13,7,7,7,7,0,7,0,0,0,7},
                        {7,14,7,7,7,7,7,0,7,0,7,0,0,7,0,7,0,0,0,7},
                        {7,0,12,0,0,0,11,0,7,0,7,0,0,7,0,7,0,0,0,7},
                        {7,0,7,7,7,13,7,7,7,0,7,7,7,7,0,7,0,0,0,7},
                        {7,0,11,0,12,0,7,0,11,0,12,0,7,7,0,7,0,0,0,7},
                        {7,7,7,14,7,13,7,13,7,7,7,0,7,7,13,7,0,0,0,7},
                        {7,18,11,0,7,18,7,18,7,8,0,0,7,7,18,7,0,0,0,7},
                        {7,13,7,14,7,13,7,13,7,7,7,7,7,7,13,7,7,7,7,7},
                        {7,0,12,0,11,0,0,0,0,0,11,0,0,0,0,0,0,0,0,7},
                        {7,7,7,14,7,7,7,7,7,14,7,7,7,7,7,7,7,7,7,7},
                        {0,0,0,0,0,0,11,0,7,0,0,0,0,0,0,0,11,0,7,7},
                        {13,7,7,7,7,7,7,0,7,7,7,7,7,7,7,7,7,0,0,7},
                        {0,7,0,0,0,0,11,0,7,6,6,6,6,6,7,0,11,0,7,7},
                        {0,7,13,7,7,7,7,0,7,6,6,6,6,6,7,0,7,7,7,7},
                        {0,7,0,7,7,0,11,0,7,6,6,6,6,6,7,0,7,8,7,7},
                        {13,7,13,7,7,13,7,14,7,7,7,7,7,7,7,0,7,0,7,7},
                        {0,0,0,0,12,18,12,0,0,0,0,0,0,0,0,0,7,9,7,7},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                    };
                case 4: return new int[20, 20]
                    {
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {7,0,11,16,8,16,16,16,11,0,0,0,0,0,0,7,0,0,0,7},
                        {7,0,11,16,16,16,16,16,11,0,7,7,7,7,14,7,0,0,0,7},
                        {7,0,11,16,16,16,16,16,11,0,7,7,7,7,0,7,0,0,0,7},
                        {7,13,7,7,7,7,7,7,7,7,17,7,17,7,17,7,0,0,0,7},
                        {7,0,10,0,0,0,0,0,0,0,11,16,11,16,11,7,0,0,0,7},
                        {7,0,7,7,7,7,7,7,7,7,14,7,14,7,14,7,0,0,0,7},
                        {7,18,7,0,0,0,0,0,0,7,0,0,0,0,0,7,0,0,0,7},
                        {7,13,7,7,7,7,7,7,7,7,7,7,14,7,7,7,7,7,7,7},
                        {7,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,0,7},
                        {7,14,7,7,7,7,7,7,7,13,7,7,7,7,7,7,7,7,0,7},
                        {7,13,11,16,16,16,11,0,7,0,12,16,16,16,16,17,7,7,0,7},
                        {7,13,11,16,16,16,11,0,7,0,12,16,16,16,16,17,7,7,0,7},
                        {7,13,11,16,16,16,11,0,7,0,12,16,16,16,12,13,16,16,0,7},
                        {7,13,11,16,16,16,11,0,7,7,7,7,7,7,7,18,7,7,7,7},
                        {7,0,7,7,7,7,7,0,16,16,16,16,16,16,11,0,7,8,0,7},
                        {7,0,7,0,0,7,0,16,16,16,16,16,16,16,11,0,7,7,9,7},
                        {7,0,7,7,7,7,13,7,7,7,7,7,7,7,7,14,7,7,7,7},
                        {7,0,0,0,0,12,16,16,12,18,12,16,16,16,12,0,0,0,7,7},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7}
                    };
                case 5: return new int[20,20]
                    {
                        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,9},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,7,14},
                        {0,7,7,7,7,7,0,7,0,7,0,7,0,0,7,7,7,0,7,0},
                        {0,7,0,7,7,0,0,7,0,7,0,7,7,0,0,0,0,0,7,0},
                        {13,7,0,7,0,7,7,7,0,7,0,7,7,0,7,0,7,7,7,14},
                        {0,12,0,7,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0},
                        {14,7,0,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0},
                        {0,12,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,11,0},
                        {14,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,13},
                        {0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,12,0},
                        {14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,7,0},
                        {0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,12,0},
                        {14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,7,0},
                        {0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,0,12,12,0},
                        {14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,14,7,7,13},
                        {0,11,0,11,0,11,0,11,0,11,0,11,0,11,0,11,0,11,0,0},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,13,7,14,7},
                        {8,7,0,0,0,0,0,7,7,7,0,0,0,0,0,7,0,7,0,7},
                        {0,0,0,7,7,7,0,0,0,0,0,7,7,7,0,11,0,12,0,7}
                    };
                case 6: return new int[20,20]
                    {
                        {8,12,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {7,7,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {7,13,7,13,7,13,7,13,7,13,7,13,7,13,7,13,7,13,7,13},
                        {7,0,7,0,7,0,7,0,7,0,7,0,7,0,7,0,7,0,7,0},
                        {7,0,7,0,7,0,7,0,7,0,7,0,0,0,11,0,11,0,11,0},
                        {7,0,7,0,7,0,7,0,7,0,7,0,7,7,7,7,7,7,7,0},
                        {7,0,7,0,7,0,7,0,7,0,7,0,7,0,0,0,0,0,0,0},
                        {7,18,7,18,7,18,7,18,7,18,7,18,7,0,0,7,7,7,7,7},
                        {7,0,7,0,7,0,7,0,7,0,7,0,7,0,0,0,0,0,0,0},
                        {7,8,0,0,11,0,11,0,11,0,11,0,11,0,0,0,0,0,0,0},
                        {7,7,7,7,7,14,7,13,7,13,7,13,7,0,0,0,0,0,0,0},
                        {0,18,0,0,0,0,7,0,7,0,7,0,7,7,7,7,7,7,0,0},
                        {0,7,0,0,0,0,7,0,7,0,7,0,0,0,0,0,0,7,0,0},
                        {0,7,0,0,0,0,7,0,7,0,7,7,7,7,7,7,0,7,0,0},
                        {0,7,0,0,0,0,7,0,7,0,0,0,0,0,0,7,0,7,0,0},
                        {0,7,0,0,0,0,7,0,7,0,0,0,0,0,0,7,0,7,0,0},
                        {0,7,0,0,0,0,7,0,7,0,0,0,0,0,0,7,0,7,0,0},
                        {0,7,7,7,7,7,7,0,11,0,0,0,0,0,0,11,0,7,0,0},
                        {0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,7,7,7,0,9}
                    };
                case 7: return new int[20,20]
                    {
                        {0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,7,0,0,0},
                        {0,0,0,0,0,0,0,0,0,0,0,18,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {7,0,0,0,0,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,7,7,7,7,7,7,7,7,7,7,7,0,0,7,0,7,0,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,7,7,7,7,7,7,7,7,7,7,7,0,0,7,0,7,0,7,0},
                        {0,7,0,7,7,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,7,0,7,7,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {0,7,0,7,7,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,7,0,7,7,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {0,7,0,7,7,0,0,0,0,0,0,11,0,0,7,0,7,0,7,0},
                        {0,7,7,7,7,0,0,0,0,0,0,7,0,0,7,0,7,0,7,0},
                        {0,7,8,18,11,0,0,0,0,0,0,11,0,0,7,0,0,0,8,0},
                        {0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,7,0}
                    };
                case 8: return new int[20,20]
                    {
                        {9,7,16,16,16,16,16,16,16,16,16,16,16,16,16,0,7,7,7,7},
                        {8,7,16,16,16,16,16,16,16,16,16,16,16,16,16,0,16,18,16,18},
                        {7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,14,7,14},
                        {16,16,16,0,16,16,16,0,16,0,0,16,0,0,16,16,16,0,16,0},
                        {7,7,7,0,7,7,7,0,7,0,0,7,0,0,7,7,7,7,7,14},
                        {18,16,0,0,0,16,0,0,0,0,0,0,0,0,0,16,16,16,16,0},
                        {14,7,0,7,0,7,0,7,0,0,7,0,0,0,0,7,7,7,7,14},
                        {0,16,0,16,0,16,0,16,0,0,16,0,0,0,0,16,16,16,16,0},
                        {14,7,0,0,7,0,7,7,0,0,0,7,0,0,7,7,7,7,7,14},
                        {0,16,0,0,16,0,16,16,0,0,0,16,0,0,16,16,16,0,16,0},
                        {14,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,13,7,14},
                        {0,7,8,16,16,16,16,16,16,16,16,18,16,16,16,16,16,0,16,0},
                        {14,7,7,7,7,7,7,7,7,7,7,14,7,7,7,7,7,14,7,14},
                        {0,16,16,16,16,16,16,16,16,16,16,0,16,16,16,16,16,0,16,0},
                        {14,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,14,7,14},
                        {0,7,16,16,16,16,16,16,16,16,16,16,16,16,16,0,16,0,16,0},
                        {14,7,7,7,7,7,7,7,7,7,7,7,7,7,7,0,7,14,7,0},
                        {0,16,16,16,16,16,16,16,16,16,16,16,16,16,16,0,7,0,7,0},
                        {14,16,16,16,16,16,16,16,16,16,16,16,16,16,16,0,7,0,7,0},
                        {0,16,16,16,16,16,16,16,16,16,16,16,16,16,16,0,7,0,7,0}
                    };
                default: return new int[20, 20];
            }
            /**/
        }
    }
}