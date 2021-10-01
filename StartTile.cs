using System;

namespace TextGame
{
    public class StartTile : CustomTile
    {
        bool alradyLoaded = false;
        public ConsoleKey getPlaceKey(){
            return ConsoleKey.S;
        }
        public string getDevIcon(){
            return "S";
        }
        public string getIcon(){
            return "-";
        }
        public int getId(){
            return 30;
        }
        public ConsoleColor getColor(){
            return (ConsoleColor.DarkBlue);
        }
        public void playerOnTop(int x, int y, Game game){
            if(!game.makeMap){
                game.playerX = (int)(new Random().NextDouble()*20);
                game.playerY = (int)(new Random().NextDouble()*20);
            }
        }
        public string placeTile(int x, int y, bool dev, Game game){
            if(!alradyLoaded && !dev){
                game.playerX = x;
                game.playerY = y;
                alradyLoaded = true;
            }
            if(dev) return getDevIcon();
            return getIcon();
        }
    }
}