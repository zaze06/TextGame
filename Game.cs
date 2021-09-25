using System;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    class Game
    {
        static int lvl = 0;
        static int[,] map = Map.map(lvl);
        static int endX = 18;
        static int endY = 18;
        int mapSizeX = map.GetLength(0);
        int mapSizeY = map.GetLength(1);
        int playerX = 1;
        int playerY = 1;
        private static int renderDistend = 1;
        bool makeMap = false;
        bool playerWasOnTp = false;
        ConsoleKey[] keyIcons = { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.H, ConsoleKey.D8, ConsoleKey.L, ConsoleKey.D9, ConsoleKey.O, ConsoleKey.U, ConsoleKey.I, ConsoleKey.Y, ConsoleKey.EQUALS};
        string[] icons = {"-", "|", "/", "\\", "¯", "_", " ", "*", "H", "E", "L", "<", ">", "ˇ", "^", " ", "="};
        string[] devIcons = {"-", "|", "/", "\\", "¯", "_", "#", "*", "H", "E", "L", "<", ">", "ˇ", "^", "%", "="};
        string mapIcons = "0='-':1='|':2='/':3='\\':4='¯':5='_':6=' ':7='*':H='H'(Teleport must have 2 to work no more no less):8='-'(End point):L='-'(Same as 'H' but difrent):<='<'(a one way door can go thru the big end):O='>'(a one way door can go thru the big end):U='ˇ'(a one way door can go thru the big end):I='^'(a one way door can go thru the big end):Y=' '(same as 6 but walkible)";
        string commands = "C='clear':F1='export map'";

        static void Main(string[] args)
        {
            new Game().game(args);
        }
        void game(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Console.WriteLine("Game made by Zacharias\n©Zacharias 2021");
            //Console.WriteLine(now.Hour + ":" + now.Minute + ":" + now.Second);
            //clearMap();
            wait(3);
            Console.Clear();
            for(int i = 0; i < mapSizeY+2; i++){
                Console.WriteLine("");
            }
            Console.Write("W="+mapSizeX+" H="+mapSizeY+"\n");
            //Environment.Exit(0);
            while (true)
            {
                writeMap();
                if(wasOnSpecial) writeMap();
                keyPress();
                if(playerWasOnTp) writeMap();
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
            Console.SetCursorPosition(0, mapSizeY + 2);
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow && playerX > 0)
            {
                playerX--;
                if (!canDoMove())
                {
                    if(map[playerX,playerY] == 14){
                        
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX--;
                    }else{
                        playerX++;
                    }
                }
            }else if(key == ConsoleKey.DownArrow && playerX < mapSizeX - 1)
            {
                playerX++;
                if (!canDoMove())
                {
                    if(map[playerX,playerY] == 13){
                        
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerX++;
                    }else{
                        playerX--;
                    }
                }
            }
            else if(key == ConsoleKey.LeftArrow && playerY > 0)
            {
                playerY--;
                if (!canDoMove())
                {
                    if(map[playerX,playerY] != 11){
                        
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }
                    else {
                        playerY--;
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("<<<"+map[playerX,playerY]+">>>");
                    }
                }
            }
            else if(key == ConsoleKey.RightArrow && playerY < mapSizeY - 1)
            {
                playerY++;
                if (!canDoMove())
                {
                    if(map[playerX,playerY] == 12){
                        
                        //Console.SetCursorPosition(0,25);
                        //Console.WriteLine("###"+map[playerX,playerY]+"###");
                        playerY++;
                    }else{
                        playerY--;
                    }
                    
                }
            }else if(key == ConsoleKey.Enter)
            {
                makeMap = !makeMap;
            }else if (makeMap)
            {
                if(key == ConsoleKey.F1)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
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
                    Console.WriteLine("}");
                    Environment.Exit(0);
                }else if(key == ConsoleKey.Backspace)
                {
                    map[playerX, playerY] = 0;
                }
                for(int i = 0; i < keyIcons.Length; i++)
                {
                    if(key == keyIcons[i])
                    {
                        map[playerX, playerY] = i;
                    }
                }
                if(key == ConsoleKey.C)
                {
                    clearMap();
                }
            }else if(key == ConsoleKey.Escape){
                Environment.Exit(0);
            }
            Console.SetCursorPosition(0, mapSizeY + 1);
            Console.Write(" ");
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
            return (v == 0 || v == 8 || v == 9 || v == 10 || v == 14);
        }

        bool wasOnSpecial = false;

        public static void setRenderDistens(int dist){
            renderDistend = dist;
        }
        public static void setEndPos(int x, int y){
            endX = x;
            endY = y;
        }
        
        private void writeMap()
        {
            Console.SetCursorPosition(0, 1);
            int[] tpX = {-1, -1};
            int[] tpY = {-1, -1};
            bool playerOnTp = false;
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    int num = map[x, y];
                    string icon = num.ToString();
                    if (x == playerX && y == playerY) {
                        if (num == 9 && !makeMap)
                        {
                            lvl++;
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Level " + (lvl - 1) + " compleat. Curent lvl " + lvl);
                            loadMap(lvl);
                            writeMap();
                            return;
                        }
                    }
                    if(num == 9){
                        endX = x;
                        endY = y;
                        wasOnSpecial = true;
                    }
                    else if(num == 8)
                    {
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
                                }
                                else
                                {
                                    playerOnTp = true;
                                }
                            }
                            else
                            {
                                tpX[0] = x;
                                tpY[0] = y;
                            }
                            if (playerOnTp)
                            {
                                if (tpX[0] != -1 && tpY[0] != -1)
                                {
                                    playerX = tpX[0];
                                    playerY = tpY[0];
                                    playerWasOnTp = true;
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
                    else if(num == 10)
                    {
                        if (!playerWasOnTp && !makeMap)
                        {
                            if(x == playerX && y == playerY)
                            {
                                if(tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                }
                                else
                                {
                                    playerOnTp = true;
                                }
                            }
                            else
                            {
                                tpX[1] = x;
                                tpY[1] = y;
                            }
                            if (playerOnTp)
                            {
                                if (tpX[1] != -1 && tpY[1] != -1)
                                {
                                    playerX = tpX[1];
                                    playerY = tpY[1];
                                    playerWasOnTp = true;
                                }
                            }
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
                        icon = this.icons[num];
                    }catch(Exception e) { e.ToString(); }
                    if (x == playerX && y == playerY)
                    {
                        icon = "&";
                    }
                    if(!(((x <= playerX + renderDistend && x >= playerX - renderDistend) && 
                            (y <= playerY + renderDistend && y >= playerY - renderDistend)) || 

                            ((x <= endX + renderDistend && x >= endX - renderDistend) && 
                            (y <= endY + renderDistend && y >= endY - renderDistend))))
                    {
                        if (!makeMap) icon = " ";
                    }
                    Console.Write(icon);
                }
                Console.Write("\n");
            }
            if (makeMap)
            {
                Console.WriteLine("Curent pice: '" + this.icons[map[playerX, playerY]] + "'");
                Console.WriteLine(mapIcons);
                Console.WriteLine(commands);
            }
            else
            {
                
                for (int i = 0; i < 16; i++)
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
        }

        private void loadMap(int lvl){
            map = Map.map(lvl);
            //mapSizeX = map.GetLength(0);
            //mapSizeY = map.GetLength(1);
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
            if(p == PlatformID.MacOSX)
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
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/data";
            }
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
