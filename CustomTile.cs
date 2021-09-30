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


        string placeTile(bool dev);
    }
}