using System;
using System.Collections.Generic;
using TextGame.Tiles;

namespace TextGame
{
    public class Util
    {
        public static ConsoleColor[] convertIntArrayToColor(int[] colors){
			if(colors == null) return new ConsoleColor[0];
			ConsoleColor[] colors1 = new ConsoleColor[colors.GetLength(0)];
			for(int i = 0; i < colors.GetLength(0); i++){
				colors1[i] = (ConsoleColor)colors[i];
			}
			return colors1;
		}
		public static List<int> convertIntArrayToList(int[] intArray){
			if(intArray == null) return new List<int>();
			List<int> tmp = new List<int>();
			for(int i = 0; i < intArray.GetLength(0); i++){
				tmp.Add(0);
			}
			return tmp;
		}
		public static int[,] convertMapToIntArray(List<List<int>> map){
			if(map == null) return new int[0,0];
			int[,] map1 = new int[(map.Count), (map[0].Count)];
			for (int x = 0; x < map.Count; x++)
			{
				for (int y = 0; y < map[0].Count; y++)
				{
					map1[x,y] = 0;
				}
			}
			return map1;
		}
		public static int[] convertListToIntArray(List<int> color){
			if(color == null) return new int[0];
			int[] color1 = new int[(color.Count)];
			for (int i = 0; i < color.Count; i++)
			{
				color1[i] = 0;
			}
			return color1;
		}
		public static List<List<int>> convertIntArrayToMap(int[,] map){
			if(map == null) return new List<List<int>>();
			List<List<int>> tmp = new List<List<int>>();
			for(int x = 0; x < map.GetLength(0); x++){
				List<int> tmp1 = new List<int>();
				for(int y = 0; y < map.GetLength(1); y++){
					tmp1.Add(0);
				}
				tmp.Add(tmp1);
			}
			return tmp;
		}
		public static int[] convertColorToIntArray(ConsoleColor[] colors){
			if(colors == null) return new int[0];
			int[] colors1 = new int[colors.GetLength(0)];
			for(int i = 0; i < colors.GetLength(0); i++){
				colors1[i] = (int)colors[i];
			}
			return colors1;
		}
		public static bool containArray(Object[] array, Object key){
			if(array == null) return false;
			for(int i = 0; i < array.Length; i++){
				if(key == array[i]){
					return true;
				}
			}
			return false;
		}
		public static bool containArray(int[] array, int key){
			if(array == null) return false;
			for(int i = 0; i < array.Length; i++){
				if(key == array[i]){
					return true;
				}
			}
			return false;
		}
		public static bool containArray(CustomTile[] array, ConsoleKey key){
			if(array == null) return false;
			for(int i = 0; i < array.Length; i++){
				if(key == array[i].getPlaceKey()){
					return true;
				}
			}
			return false;
		}
		public static bool containsId(CustomTile[] array, int id){
			if(array == null) return false;
			for(int i = 0; i < array.Length; i++){
				if(id == array[i].getId()){
					return true;
				}
			}
			return false;
		}
		public static int[] consoleKeyArrayToIntArray(ConsoleKey[] array){
			if(array == null) return new int[0];
			int[] tmp = new int[array.Length];
			for(int i = 0; i < array.Length; i++){
				tmp[i] = (int) array[i];
			}
			return tmp;
		}
    }
}