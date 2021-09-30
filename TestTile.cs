using System;
using TextGame;

namespace TextGame
{
    public class TestTile : CustomTile
    {
        public ConsoleKey getPlaceKey(){
            return ConsoleKey.B;
        }
        public string getDevIcon(){
            return "B";
        }
        public string getIcon(){
            return "B";
        }
        public int getId(){
            return 30;
        }
        public ConsoleColor getColor(){
            return ConsoleColor.DarkGray;
        }
        public void playerOnTop(int x, int y, Game game){
            
        }
        public string placeTile(bool dev){
            if(dev) return getDevIcon();
            return getIcon();
        }
    }
}