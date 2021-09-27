using System;
using System.Collections.Generic;

namespace TextGame
{
	public class Maps
	{
		public Map[] maps {get; set;}

		public Maps(){
			maps = new Map[]{new Map()};
		}

		public string toString(){
			string output = "{";
			for(int i = 0; i < maps.GetLength(0); i++){
				
				output += maps[i].ToString()+(i != maps.GetLength(0)-1?",":"");
			}
			output += "}";
			return output;
		}
	}
}