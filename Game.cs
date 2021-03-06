using System;
using System.IO;
using System.Reflection;
using System.Text;
using TextGame.Tiles;
using static System.Net.Mime.MediaTypeNames;

namespace TextGame
{
    public class Game
    {
        //public static GetMaps maps = new GetMaps();
        public static int lvl = 0;
        public static Map map3 = new Map();
        public int[,] map = Util.convertMapToIntArray(map3.map);
        public int endX = 18;
        public int endY = 18;
        public int mapSizeX = 0;
        public int mapSizeY = 0;
        public int lives = 5;
        public int playerX = map3.startPosition[0];
        public string infoString = "";
        public int playerY = map3.startPosition[1];
        public int renderDistend = 1;
        public bool makeMap = false;
        public bool playerWasOnTp = false;
        public int[] walkibles = {0, 8, 9, 10, 15, 16, 17};
        public ConsoleKey[] keyIcons = { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6,
            ConsoleKey.D7, ConsoleKey.H, ConsoleKey.D8, ConsoleKey.K, ConsoleKey.D9, ConsoleKey.O, ConsoleKey.U, ConsoleKey.I, ConsoleKey.Y, ConsoleKey.R,
            ConsoleKey.G, ConsoleKey.D};

        public static CustomTile[] customTiles;
        public readonly CustomTile[] defualtTiles = {new StartTile()};
        public static ConsoleColor[] colors = Util.convertIntArrayToColor(Util.convertListToIntArray(map3.color));
        public string[] icons = {"-", "|", "/", "\\", "¯", "_", " ", "*", "H", "E", "L", "<", ">", "v", "^", " ", "=", "|", "#"};
        public string[] devIcons = {"-", "|", "/", "\\", "¯", "_", "+", "*", "H", "E", "L", "<", ">", "v", "^", "%", "=", "|", "#"};
        public string mapIcons = "0='-' : 1='|' : 2='/' : 3='\\' : 4='¯' : 5='_' : 6=' ' : 7='*' : " + 
            "H='H'(Teleport must have 2 to work no more no less) : "+
            "8='E'(End point) : K='L'(Same as 'H' but difrent) : <='<'(a one way door can go thru the big end) : "+
            "O='>'(a one way door can go thru the big end) : U='v'(a one way door can go thru the big end) : "+
            "I='^'(a one way door can go thru the big end) : Y=' '(same as 6 but walkible) :"+
            " R='='(a walk way that only posible to walk anong side cant go up or down on it) : "+
            "G='|'(a walk way thay only posible to walk along side cant go left or right on it) : "+
            "D='#'(a point that you tack one dmg when you walk on it)";
        public string commands = "C='clear' : F1='export map' : "+
        "M+(map id)+Enter='so (map id) stands for the id of the map so if you press M+4+Enter it will open map 4 end whit enter'"+
        "L+(lives)+Enter='so (lives) is a number of how many lives you whana give your self end whit enter'";
        private int lastTile = 0;

        static void Main(string[] args)
        {
            new Game();
        }
        public Game()
        {
            //new GetMaps();
            //maps = new GetMaps();
            //map3 = GetMaps.getMap(lvl);
            map = GetMaps.getMap(lvl);
            colors = ColorMaps.colorMap(lvl);

            int max = defualtTiles.Length;
            if(customTiles != null){
                max += customTiles.Length;
            }
            CustomTile[] tmp = (CustomTile[])customTiles.Clone();
            customTiles = new CustomTile[max];
            for(int i = 0; i < max; i++){
                //Console.Write(i+", ");
                if(!(i >= tmp.Length)){
                    customTiles[i] = tmp[i];
                }else{
                    customTiles[i] = defualtTiles[i-1];
                }
            }

            playerX = 1;
            playerY = 1;
            mapSizeX = map.GetLength(0);
            mapSizeY = map.GetLength(1);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Console.WriteLine("Text game made by Zacharias\n©Zacharias 2021");
            //Console.WriteLine(now.Hour + ":" + now.Minute + ":" + now.Second);
            //clearMap();
            wait(3);
            Console.Clear();
            for(int i = 0; i < mapSizeY+2; i++){
                Console.WriteLine("");
            }
            Console.Write("W="+mapSizeX+" H="+mapSizeY+"\n");
            //Environment.Exit(0);
            writeMap(false);
            while (true)
            {
                writeMap(true);
                //Console.Write("A");
                if(wasOnSpecial)  writeMap(true);
                //Console.Write("B");}
                keyPress();
                if(playerWasOnTp) writeMap(true);
                //Console.Write("C");}
            }
        }

        private void clearMap()
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x, y] = 0;
                }
            }
        }

        private void keyPress()
        {
            Console.SetCursorPosition(0, mapSizeY + 10);
            ConsoleKeyInfo rawKey = Console.ReadKey();
            ConsoleKey key = rawKey.Key;
            //Console.Clear();
            if (key == ConsoleKey.UpArrow && playerX > 0)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 16) && !makeMap)
                {
                    playerX++;
                }
                playerX--;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] == 14)
                    {
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX--;
                    }
                    else
                    {
                        playerX++;
                    }
                }
            }else if (key == ConsoleKey.DownArrow && playerX < mapSizeX - 1)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 16) && !makeMap)
                {
                    playerX--;
                }
                playerX++;
                if (!canDoMove())
                {
                    
                    if (map[playerX, playerY] == 13)
                    {
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX++;
                    }
                    else
                    {
                        playerX--;
                    }
                }
            }
            else if (key == ConsoleKey.LeftArrow && playerY > 0)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 17) && !makeMap)
                {
                    playerY++;
                }
                playerY--;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] != 11)
                    {

                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }
                    else
                    {
                        playerY--;
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("<<<"+map[playerX,playerY]+">>>");
                    }
                }
            }
            else if (key == ConsoleKey.RightArrow && playerY < mapSizeY - 1)
            {
                if (makeMap)
                {
                    this.lastTile = map[playerX, playerY];
                }
                if ((map[playerX, playerY] == 17) && !makeMap)
                {
                    playerY--;
                }
                playerY++;
                if (!canDoMove())
                {
                    if (map[playerX, playerY] == 12)
                    {

                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }
                    else
                    {
                        playerY--;
                    }

                }
            }
            else if (key == ConsoleKey.Enter)
            {
                makeMap = !makeMap;
            }/*else if(key == ConsoleKey.OemMinus)
            {
                typeMode = !typeMode;
            }*/else if (makeMap)
            {
                if (key == ConsoleKey.F1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                    Console.Write("case " + lvl + ": return new int[20,20]\n");
                    Console.Write("{");
                    for (int x = 0; x < mapSizeX; x++)
                    {
                        Console.Write("{");
                        for (int y = 0; y < mapSizeY; y++)
                        {
                            Console.Write(map[x, y] + (y < mapSizeY - 1 ? "," : ""));
                        }
                        Console.Write("}" + (x < mapSizeX - 1 ? ",\n" : ""));
                    }
                    Console.WriteLine("};");
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    map[playerX, playerY] = 0;
                }
                else if (key == ConsoleKey.C)
                {
                    clearMap();
                }
                else if (key == ConsoleKey.M)
                {
                    string lvl = "";
                    do
                    {
                        Console.SetCursorPosition(0, mapSizeY + 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(0, mapSizeY + 2);
                        ConsoleKeyInfo key1 = Console.ReadKey();
                        if(key1.Key == ConsoleKey.Enter){
                            break;
                        }else{
                            lvl += key1.KeyChar;
                        }
                    } while (true);

                    try{
                        
                        loadMap(int.Parse(lvl));
                        Console.BackgroundColor = colors[1];
                    }catch(Exception e){
                        e.ToString();
                    }
                }
                else if(key == ConsoleKey.L){
                    string lives = "";
                    do
                    {
                        Console.SetCursorPosition(0, mapSizeY + 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(0, mapSizeY + 2);
                        ConsoleKeyInfo key1 = Console.ReadKey();
                        if(key1.Key == ConsoleKey.Enter){
                            break;
                        }else{
                            lives += key1.KeyChar;
                        }
                    } while (true);
                    
                    try{
                        
                        this.lives = int.Parse(lives);
                        Console.BackgroundColor = colors[1];
                    }catch(Exception e){
                        e.ToString();
                    }
                }
                else if (key == ConsoleKey.NumPad0)
                {
                    map[playerX, playerY] = lastTile;
                }
                else if(Util.containArray(Util.consoleKeyArrayToIntArray(keyIcons), (int)key))
                {
                    for (int i = 0; i < keyIcons.Length; i++)
                    {
                        if (key == keyIcons[i])
                        {
                            map[playerX, playerY] = i;
                            break;
                        }
                    }
                }else if(customTiles != null){
                    //Console.Write("\r\n\r\n\r\nCT "+customTiles.Length);
                    for(int i = 0; i < customTiles.Length; i++){
                        //Console.Write(i+" ");
                        if(customTiles[i].getPlaceKey() == key){
                            map[playerX, playerY] = customTiles[i].getId();
                            break;
                        }
                    }
                }
            }/*else if (typeMode)
            {
                map[playerX, playerY] = asciiToInt(rawKey.KeyChar);
            }*/
            else if (key == ConsoleKey.Escape)
            {
                if (!mapEqual(/*Util.convertMapToIntArray(GetMaps.getMap(lvl).map)/*/GetMaps.getMap(lvl)/**/, map))
                {
                    ConsoleColor forgrund = Console.ForegroundColor;
                    ConsoleColor backgrund = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, mapSizeY + 10);
                    Console.Write("OPS: Do you whana exit and discard chages? press esc again to conferm");
                    Console.SetCursorPosition(0, mapSizeY + 11);
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = backgrund;
                        Console.ForegroundColor = forgrund;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.SetCursorPosition(0, mapSizeY + 4);
                //Console.Write(key.ToString());
            }
            Console.SetCursorPosition(0, mapSizeY + 10);
            Console.Write(" ");
        }

        private bool mapEqual(int[,] map1, int[,] map2)
        {
            int mapSizeX = map1.GetLength(0);
            int mapSizeY = map1.GetLength(1);
            if ((mapSizeX != map2.GetLength(0)) || (mapSizeY != map2.GetLength(1))) return false;
            //Console.SetCursorPosition(0, 0);
            //Console.Write("same size");
            for(int x = 0; x < mapSizeX; x++)
            {
                for(int y = 0; y < mapSizeY; y++)
                {
                    if(map1[x,y] != map2[x, y])
                    {
                        return false;
                    }
                }
            }
            //Console.SetCursorPosition(0, 0);
            //Console.Write("same blocks");
            return true;
        }

        private bool canDoMove()
        {
            if (makeMap)
            {
                return true;
            }
            if (isAllowed(map[playerX, playerY]))
            {
                return true;
            }
            return false;
        }

        private bool isAllowed(int v)
        {
            for(int i = 0; i < walkibles.Length; i++)
            {
                if(v == walkibles[i])
                {
                    return true;
                }
            }
            if(customTiles != null){
                for(int j = 0; j < customTiles.Length; j++){
                    if(v == customTiles[j].getId()){
                        return true;
                    }
                }
            }
            return false;
        }

        bool wasOnSpecial = false;
        bool wasOnDmg = false;
        private void writeMap(bool doTp)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            int[] tpX = {-1, -1};
            int[] tpY = {-1, -1};
            bool[] playerOnTp = {false, false};
            int xMEnd = -1;

            if(lives == 0 && doTp){
                lives = 5;
                loadMap(0);
                lvl = 0;
                playerX = 1;
                playerY = 1;
                writeMap(true);
                return;
            }
            Console.Write((lvl != 0?("Level " + (lvl-1) + " compleat. "):"")+"Curent lvl " + lvl + "\n");
            Console.Write("You have "+lives+" lives left\n");
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    //Console.Write(x+" "+y+" ", Console.Error);
                    int num = map[x, y];
                    string icon = num.ToString();
                    if (x == playerX && y == playerY) {
                        if(customTiles != null){
                            for(int i = 0; i < customTiles.Length; i++){
                                if(num == customTiles[i].getId()){
                                    customTiles[i].playerOnTop(x, y, this);
                                    break;
                                }
                            }
                        }
                        //Console.Write("436 ", Console.Error);
                        if (num == 9 && !makeMap)
                        {
                            /*if (!mapEqual(/*Util.convertMapToIntArray(GetMaps.getMap(lvl).map)*//*GetMaps.getMap(lvl), map))
                            {
                                ConsoleColor forgrund = Console.ForegroundColor;
                                ConsoleColor backgrund = Console.BackgroundColor;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(0, mapSizeY + 1);
                                Console.Write("OPS: Do you whana exit and discard chages? press esc again to conferm");
                                Console.SetCursorPosition(0, mapSizeY + 2);
                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = backgrund;
                                    Console.ForegroundColor = forgrund;
                                }
                            }*/
                            lvl++;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Level " + (lvl - 1) + " compleat. Curent lvl " + lvl);
                            loadMap(lvl);
                            if(mapEqual(map, new int[20,20]))
                            {

                            }
                            writeMap(true);
                            return;
                        }
                        if(num == 18 && !makeMap && !wasOnDmg){
                            wasOnDmg = true;
                            lives--;
                        }else{
                            wasOnDmg = false;
                        }
                    }
                    if(num == 9){
                        //Console.Write("478 ", Console.Error);
                        endX = x;
                        endY = y;
                        wasOnSpecial = true;
                    }
                    else if(num == 8 && doTp)
                    {
                        //Console.Write("485 ", Console.Error);
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
                                    infoString += "n8 m; ";
                                }
                                else
                                {
                                    //writeMap(false);
                                    playerOnTp[0] = true;
                                }
                            }
                            else
                            {
                                tpX[0] = x;
                                tpY[0] = y;
//                                infoString += "n8 c; ";
                            }
                            if (playerOnTp[0])
                            {
                                if (tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
                                    infoString += "n8 n; ";
                                }
                            }
                        }else{
                            playerWasOnTp = false;
                        }
                        /*int[] tmp = tp(tpX[0], tpY[0], x, y, playerOnTp);
                        tpX[0] = tmp[0];
                        tpY[0] = tmp[1];
                        playerOnTp = tmp[2]==1;*/
                    }
                    else if(num == 10 && doTp)
                    {
                        //Console.Write("529 ", Console.Error);
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                    infoString += "nA m; ";
                                }
                                else
                                {
                                    //writeMap(false);
                                    playerOnTp[1] = true;
                                }
                            }
                            else
                            {
                                tpX[1] = x;
                                tpY[1] = y;
//                                infoString += "nA c; ";
                            }
                            if(playerOnTp[1]) {
                                infoString += "nA n; ";
                            }
                            /*if (playerOnTp)
                            {
                                if (tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                }
                            }*/
                        }else{
                            playerWasOnTp = false;
                        }
                        /*int[] tmp = tp(tpX[1], tpY[1], x, y, playerOnTp);
                        tpX[1] = tmp[0];
                        tpY[1] = tmp[1];
                        playerOnTp = tmp[2]==1;*/
                    }
                    try
                    {
                        //Console.Write("575 ", Console.Error);
                        //Console.ForegroundColor = colors[num + 2];
                        if (num == 6 || num == 15)
                        {
                            Console.ForegroundColor = colors[2];
                        }
                    }
                    catch (Exception e) { 
                        e.ToString();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    try
                    {
                        icon = getIcon(num, makeMap, true);
                    }catch(Exception e) {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(e.ToString());
                        Environment.Exit(1);
                    }
                    
                    /*if(x == playerX){
                        while(xMEnd == -1){
                            
                        }
                    }*/
                    //try{
                    bool tmp = Util.containsId(customTiles, num);
                    if(tmp){
                        for(int i = 0; i < customTiles.Length; i++){
                            if(customTiles[i].getId() == num){
                                customTiles[i].placeTile(x, y, makeMap, this);
                                break;
                            }
                        }
                    }
                    //}catch(Exception e){
                        //e.ToString();
                        //Console.Write("644");
                        //Environment.Exit(1);
                    //}
                    if(!(((  x <= playerX + renderDistend && x >= playerX - renderDistend) && 
                            (y <= playerY + renderDistend && y >= playerY - renderDistend)) || 

                            ((x <= endX + renderDistend && x >= endX - renderDistend) && 
                            (y <= endY + renderDistend && y >= endY - renderDistend))))
                    {
                        if (!makeMap) icon = " ";
                    }
                    if(customTiles != null){
                        for(int i = 0; i < customTiles.Length; i++){
                            tmp = customTiles[i] is CustomLightTile;
                            if(tmp){
                                CustomLightTile tile = (CustomLightTile) customTiles[i];
                                if((((x <= tile.getX() + renderDistend && x >= tile.getX() - renderDistend) && 
                                    (y <= tile.getY() + renderDistend && y >= tile.getY() - renderDistend))))
                                {
                                    if (!makeMap) icon = getIcon(num, makeMap, true);
                                }else{
                                    
                                }
                            }
                            
                        }
                    }
                    
                    if(num == 18){
                        icon = getIcon(num, makeMap, true);
                    } else
                    if((map[playerX, playerY] == 16) && (map[x, y] != 16) && (!makeMap))
                    {
                        //Console.Write("630 ", Console.Error);
                        icon = " ";
                        if (((y > playerY || y < playerY) && ((y <= playerY + renderDistend && y >= playerY - renderDistend))) && !(x < playerX || x > playerX)) icon = getIcon(map[playerX, playerY], makeMap, true);
                        
                    }else if ((map[playerX, playerY] == 16) && (x > playerX || x < playerX) && !makeMap) icon = " ";
                    else if((map[playerX, playerY] == 17) && (map[x, y] != 17 && (!makeMap)))
                    {
                        //Console.Write("637 ", Console.Error);
                        icon = " ";
                        if ((!(y > playerY || y < playerY)) && ((x < playerX || x > playerX) && (x <= playerX + renderDistend && x >= playerX - renderDistend))) icon = getIcon(map[playerX, playerY], makeMap, true);
                        
                    }else if ((map[playerX, playerY] == 17) && (x > playerX || x < playerX) && !makeMap) icon = " ";

                    if (x == playerX && y == playerY)
                    {
                        //Console.Write("610 ", Console.Error);
                        Console.ForegroundColor = colors[0];
                        icon = "&";
                    }
                    
                    if(doTp){
                        Console.Write(icon);
                    }
                }
                //Console.WriteLine("", Console.Error);
                if(doTp){
                    Console.Write("\n");
                }
            }
            if (makeMap && doTp)
            {
                //Console.Write("652 ", Console.Error);
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Curent pice: '" + getIcon(map[playerX, playerY], false, false) + "' id: " + map[playerX, playerY]+ "  ");
                Console.WriteLine(mapIcons);
                Console.WriteLine(commands);
                //Console.Write("652 End");
            }
            else if (!makeMap && doTp)
            {
                //Console.Write("661 ", Console.Error);
                for (int i = 0; i < 25; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
                for (int i = 0; i < mapIcons.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.Write(" ");
                }
                //Console.WriteLine("\nX[0] = "+tpX[0]+": Y[0] = "+tpY[0]);
                //Console.WriteLine("X[1] = "+tpX[1]+": Y[1] = "+tpY[1]);
            }
            /*for(int i = 0; i < 20; i++){
                Console.Write("");
            }
            Console.Write("\n"+infoString);*/
            //Console.WriteLine("NEW MAP", Console.Error);
        }

        public string getIcon(int id, bool devMode, bool chageColor){
            if (devMode){
                if(!(id >= icons.Length)){
                    try{if(chageColor) Console.ForegroundColor = colors[id+2];}catch{
                        int x = 0;
                    }
                    return devIcons[id];
                }
                //Console.Write("728, ");
                if(Util.containsId(customTiles, id))
                {
                    for(int i = 0; i < customTiles.Length; i++){
                        if(id == customTiles[i].getId()){
                            if(chageColor) Console.ForegroundColor = customTiles[i].getColor();
                            return customTiles[i].getDevIcon();
                        }
                    }
                }
            }else if(!(id >= icons.Length)){
                if(chageColor) Console.ForegroundColor = colors[id+2];
                return icons[id];
            }
            //Console.Write("742, ");
            if(Util.containsId(customTiles, id))
            {
                for(int i = 0; i < customTiles.Length; i++){
                    if(id == customTiles[i].getId()){
                        if(chageColor) Console.ForegroundColor = customTiles[i].getColor();
                        return customTiles[i].getIcon();
                    }
                }
            }
            return "?";
        }

        private void loadMap(int lvl1){
            //Map map = GetMaps.getMap(lvl1);
            customTiles = null;
            map = GetMaps.getMap(lvl1);

            int max = defualtTiles.Length;
            if(customTiles != null){
                max += customTiles.Length;
            }
            CustomTile[] tmp = (CustomTile[])customTiles.Clone();
            customTiles = new CustomTile[max];
            for(int i = 0; i < max; i++){
                Console.Write(i+", ");
                if(!(i >= tmp.Length)){
                    customTiles[i] = tmp[i];
                }else{
                    customTiles[i] = defualtTiles[i-1];
                }
            }
            
            playerX = playerX;//map.startPosition[0];
            playerY = playerY;//map.startPosition[1];
            colors = ColorMaps.colorMap(lvl1);//Util.convertIntArrayToColor(Util.convertListToIntArray(map.color));
            //colors = ColorMaps.colorMap(lvl);
            lvl = lvl1;
            //mapSizeX = map.GetLength(0);
            //mapSizeY = map.GetLength(1);
            writeMap(false);
        }

        private int[] tp(int tpX, int tpY, int x, int y, bool playerOnTp){
            if (!playerWasOnTp && !makeMap)
            {
                if(x == playerX && y == playerY)
                {
                    if(tpX != -1 && tpY != -1)
                    {
                        playerX = tpX;
                        playerY = tpY;
                        playerWasOnTp = true;
                    }
                    else
                    {
                        playerOnTp = true;
                    }
                }
                else
                {
                    tpX = x;
                    tpY = y;
                }
                if (playerOnTp)
                {
                    if (tpX != -1 && tpY != -1)
                    {
                        playerX = tpX;
                        playerY = tpY;
                        playerWasOnTp = true;
                    }
                }
            }else{
                playerWasOnTp = false;
            }
            return new int[]{tpX, tpY, (playerOnTp?1:0)}; 
        }

        static string getSafeLocation()
        {
            PlatformID p = Environment.OSVersion.Platform;
            Console.WriteLine(p);
            Console.WriteLine(p);
            /*if(p == PlatformID.MacOSX)
            {
                return "~/Library/Application\\ Support/Zacharias/TextGame";
            }else if(p == PlatformID.Win32NT)
            {
                string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                Console.WriteLine(user);
                Console.WriteLine(user.Split('\\')[1]);
                return Path.Combine("C:", "Users", user.Split('\\')[1], "Documents","MyGames","Zacharias","TextGame");
            }
            else
            {*/
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/data";
            //}
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
            string loc = getSafeLocation();
            Console.WriteLine(loc);
            Console.WriteLine(Path.Combine(loc, "Test.txt"));
            if (!Directory.Exists(loc))
            {
                Directory.CreateDirectory(loc);
            }
            loc = Path.Combine(loc, "Test.txt");
            if (!File.Exists(loc))
            {
                File.Create(loc);
            }
            FileStream file = File.OpenWrite(loc);
            byte[] ext = Encoding.ASCII.GetBytes("You ended on lvl: " + lvl);
            file.Write(ext, 0, ext.Length);
            file.Flush();
            file.Close();
            Console.WriteLine(loc);
        }
        private void wait(int time)
        {
            DateTime timeToEnd = DateTime.Now.AddSeconds(time);
            //timeToEnd = timeToEnd.AddSeconds(time);
            DateTime now = DateTime.Now;
            while (timeToSring(now.Hour, now.Minute, now.Second) != timeToSring(timeToEnd.Hour, timeToEnd.Minute, timeToEnd.Second)) {
                now = DateTime.Now;
            }
        }
        private string timeToSring(int H, int M, int S)
        {
            return H + ":" + M + ":" + S;
        }
    }
}