using System;

namespace TextGame
{
    public interface CustomTile
    {
        ConsoleKey getPlaceKey();
        string getIcon();
        string getDevIcon();
        int getId();
        ConsoleColor getColor();
        void playerOnTop(int x, int y, Game game);
        string placeTile(bool dev);
    }
}