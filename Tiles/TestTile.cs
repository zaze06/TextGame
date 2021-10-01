using System;

namespace TextGame.Tiles
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
            return (ConsoleColor.DarkBlue);
        }
        public bool canWalkOn(){
            return true;
        }
        public void playerOnTop(int x, int y, Game game){
            if(!game.makeMap){
                game.playerX = (int)(new Random().NextDouble()*20);
                game.playerY = (int)(new Random().NextDouble()*20);
            }
        }
        public void placeTile(int x, int y, bool dev, Game game){
            
        }
    }
}