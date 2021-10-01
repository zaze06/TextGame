using System;

namespace TextGame
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
        string placeTile(int x, int y, bool dev, Game game);
    }
}