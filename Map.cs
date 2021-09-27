using System.Net.Mail;
using System;
using System.Collections.Generic;

namespace TextGame
	{
	public class Map
	{
		public List<List<int>> map { get; set; }
		public List<int> color { get; set; }
		public List<int> startPosition { get; set; }

		public Map(){
			map = new List<List<int>>();
			color = new List<int>();
			startPosition = new List<int>();

			for(int x = 0; x < 20; x++){
				List<int> tmp = new List<int>();
				for(int y = 0; y < 20; y++){
					tmp.Add(0);
				}
				map.Add(tmp);
			}

			for(int i = 0; i < 20; i++){
				color.Add(0);
			}

			for(int i = 0; i < 20; i++){
				startPosition.Add(0);
			}
		}
		public string toString(){
			string output = "{ map = {";
			for (int x = 0; x < map.Count; x++)
			{
				for (int y = 0; y < map[0].Count; y++)
				{
					output += map[x][y] + (x != map.Count-1?",":"") +"\n";
				}
				output += "\n";
			}
			output+="}, color = {";
			for(int i = 0; i < color.Count; i++){
				output += color[i].ToString()+(i != color.Count-1?",":"");
			}
			output+="}, startPosition = {";
			for(int i = 0; i < startPosition.Count; i++){
				output += startPosition[i].ToString()+(i != startPosition.Count-1?",":"");
			}
			output+="}";
			return output;
		}
	}
}