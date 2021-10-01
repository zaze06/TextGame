using System.Net.Mime;
using System;
using TextGame;

namespace TextGame.Tiles
{
    public class StartTile : CustomLightTile
    {
        int x = 0;
        int y = 0;
        bool alradyLoaded = false;
        public ConsoleKey getPlaceKey(){
            return ConsoleKey.S;
        }
        public string getDevIcon(){
            return "S";
        }
        public string getIcon(){
            return "S";
        }
        public int getId(){
            return 31;
        }
        public ConsoleColor getColor(){
            return (Game.colors[2]);
        }
        public bool canWalkOn(){
            return true;
        }
        public void playerOnTop(int x, int y, Game game){

        }
        public int getX(){
            return x;
        }
        public int getY(){
            return y;
        }
        public void placeTile(int x, int y, bool dev, Game game){
            if(!alradyLoaded && !dev){
                game.playerX = x;
                game.playerY = y;
                alradyLoaded = true;
                this.x = x;
                this.y = y;
            }
        }
    }
}