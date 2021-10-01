using System;

namespace TextGame.Tiles
{
    public interface CustomTile
    {
        ConsoleKey getPlaceKey();
        string getIcon();
        string getDevIcon();
        int getId();
        bool canWalkOn();
        ConsoleColor getColor();
        void playerOnTop(int x, int y, Game game);
        void placeTile(int x, int y, bool dev, Game game);
    }
}