using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int hight = 40;
            int length = 80;
            
            Field(hight, length);
            //FoodGen(hight, length);
            SnakeMovement(hight, length);
            
         
        }

        static void Field(int hight,int length)
        {
           
            for (int i = 0; i < hight; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (j == 0 || j == length - 1 )
                    {
                        Console.Write("|");
                    }
                    else if (i == 0 || i == hight - 1)
                    {
                        Console.Write("-");
                    }
                    else 
                    {
                        Console.Write(" ");
                    }                   
                }

                Console.WriteLine();
                
            }
            

        }

        static int[,] FoodGen(int rangeX,int rangeY)
        {
            int x = default;
            int y = default;
            int[,] coord = new int[2,1];
            Random ran = new Random();
            do
            {
                x = ran.Next(1, rangeX - 1);
            } while (x % 2 == 0);
                                       
            do
            {
              y =  ran.Next(1, rangeY - 1);
            } 
            while (y % 2 == 0);
          
            Console.SetCursorPosition(y, x);
            Console.Write("$");
            coord[0, 0] = x;
            coord[1, 0] = y;
            return coord;
        
        }

        

        static void SnakeMovement(int hight, int length)
        {   
            int x = 25;
            int y = 10;
            int xErase = default;
            int yErase = default;
            int snakeLenght = 0;
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;            
            int[,]snakeLenghtCoord = new int[2,50];
            int[,] foodCoord = new int[2,1];
            ConsoleKey keyPressed = default;
           foodCoord = FoodGen(hight,length);
            while (true)
            {
                //Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(false).Key;
                }
                xErase = x;
                yErase = y;
                snakeLenghtCoord[0, snakeLenght] = x;
                snakeLenghtCoord[1, snakeLenght] = y;

                switch (keyPressed)
                {
                    case ConsoleKey.RightArrow:
                    right = true;
                        left = false;
                        up = false;
                        down = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        right = false;
                        left = true;
                        up = false;
                        down = false;
                        break;
                    case ConsoleKey.DownArrow:
                        right = false;
                        left = false;
                        up = false;
                        down = true;
                        break;
                    case ConsoleKey.UpArrow:

                        right = false;
                        left = false;
                        up = true;
                        down = false;
                        break;
                    default:
                         break;
                }

                

                if (right == true && x < length-3)
                {
                                  
                   x = x+2;                    
                }
                if (left == true && x > 1)
                {
                                  
                    x=x-2;                 
                } 
                if (down == true && y < hight-2)
                {
                                  
                    y++;                   
                }
                if (up == true && y > 1)
                {                                   
                    y--;                   
                }
                if (foodCoord[0,0] == y && foodCoord[1,0] == x)
                {
                    snakeLenght++;
                    foodCoord = FoodGen(hight,length);
                    
                }
               
                
                //snakeLenghtCoord[0, snakeLenght] = x;
                //snakeLenghtCoord[1, snakeLenght] = y;
                Snake(x, y, xErase, yErase, snakeLenght, snakeLenghtCoord);


            }
        }

        static void Snake (int x,int y,int xErase,int yErase, int snakeLenght, int [,]snakeLenghtCoord)
        {

           
            





            //Console.SetCursorPosition(xErase, yErase);
            //Console.Write(snakeLenght);
            //Console.SetCursorPosition(x, y);
            //Console.Write("@");
            //Thread.Sleep(200);
            //Console.SetCursorPosition(xErase, yErase);
            //Console.Write("  ");


        }
    }



}
