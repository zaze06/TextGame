using System;
namespace TextGame.Tiles
{
    public class EmptyTile : CustomTile
    {
        public ConsoleKey getPlaceKey() {
            return ConsoleKey.D0;
        }
        public string getIcon(){
            return "!";
        }
        public string getDevIcon(){
            return "!";
        }
        public int getId(){
            return -1;
        }
        public bool canWalkOn(){
            return false;
        }
        public ConsoleColor getColor(){
            return ConsoleColor.Black;
        }
        public void playerOnTop(int x, int y, Game game){

        }
        public void placeTile(int x, int y, bool dev, Game game){

        }
    }
}