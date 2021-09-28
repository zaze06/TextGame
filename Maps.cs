using System;
using System.Collections.Generic;

namespace TextGame
{
	public class Maps
	{
		public Map[] maps {get; set;}

		public Maps(){
			Console.Write("[MAPS]Default constructor\r\n");
			maps = new Map[0];//{new Map()};
			Console.Write("[MAPS]End constructor\r\n");
		}

		public string toString(){
			string output = "{";
			for(int i = 0; i < maps.GetLength(0); i++){
				
				output += maps[i].toString()+(i != maps.GetLength(0)-1?",":"");
			}
			output += "}";
			return output;
		}
	}
}