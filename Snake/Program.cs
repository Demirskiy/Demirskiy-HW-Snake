using System;
using System.Threading;
using System.Collections.Generic;



namespace Snake
{
    class Program
    {
        static void Main()    
        {
            int hight = 40;
            int length = 80;
            
            Field(hight, length);
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
            int count = 0;
            int levelSpeed = 300;
            int levelCount = 0;
            int level = 0;
            bool gameRun = true;
            int snakeLength = 0;
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;
            var snakeCoordX = new List<int> { x };
            var snakeCoordY = new List<int>{y};
            int[,] foodCoord = new int[2,1];
            ConsoleKey keyPressed = default;
            foodCoord = FoodGen(hight,length);
            while (gameRun)
            {                
                if (Console.KeyAvailable)
                {
                    keyPressed = Console.ReadKey(false).Key;
                }

                
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
                    snakeLength++;
                    foodCoord = FoodGen(hight,length);
                    levelCount++;
                }

                if (right == true || left == true || up == true || down == true)
                {                   
                        snakeCoordX.Add(x);
                        snakeCoordY.Add(y);
                        count++;
                }

                if ((levelCount + 1) % 6 == 0 )
                {
                    levelSpeed = levelSpeed - 10;
                    levelCount = 0;
                    level++;
                }
                
               gameRun = Snake(snakeLength,snakeCoordX,snakeCoordY,count,levelSpeed);

                if (snakeCoordX.Count > snakeLength && count > snakeLength)
                {
                    snakeCoordX.RemoveAt(0);
                    snakeCoordY.RemoveAt(0);
                    count--;
                }
                InfoTable(snakeLength, level);
                if (keyPressed == ConsoleKey.Escape)
                {
                    gameRun = false;
                }
            }
        }

        static bool Snake(int snakeLength, List<int> snakeCoordX,List <int> snakeCoordY,int count,int levelSpeed)
        {

            
            Console.SetCursorPosition(snakeCoordX[count], snakeCoordY[count]);
            Console.Write("@");
            if (count > 0 && snakeLength > 0)
            {
                Console.SetCursorPosition(snakeCoordX[count - 1], snakeCoordY[count - 1]);
                Console.Write("#");
            }
            Thread.Sleep(levelSpeed);
            Console.SetCursorPosition(snakeCoordX[count - snakeLength],snakeCoordY[count - snakeLength]);
            Console.Write("  ");
            for (var i = snakeCoordX.Count-1 ; i > 1; i--)
            {

                if (snakeCoordX[count] == snakeCoordX[i] && snakeCoordY[count]== snakeCoordY[i] && count != i)
                {
                    Console.Write("game over");
                    return false;
                }                       
                
            }
            return true;
        }
        

        static void InfoTable(int snakeLength, int level)
        {
            Console.SetCursorPosition(90,10);
            Console.Write("Score: " + snakeLength);
            Console.SetCursorPosition(90, 12);
            Console.Write("Level: " + level);
        }
    }



}
