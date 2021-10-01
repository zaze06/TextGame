using System;

namespace TextGame.Tiles
{
    public class LightTile : CustomLightTile
    {
        int x = 0;
        int y = 0;
        bool alradyLoaded = false;
        public ConsoleKey getPlaceKey(){
            return ConsoleKey.E;
        }
        public string getDevIcon(){
            return "L";
        }
        public string getIcon(){
            return "-";
        }
        public int getId(){
            return 32;
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
                this.x = x;
                this.y = y;
            }
        }
    }
}