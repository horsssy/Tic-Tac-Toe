using System;

namespace library
{
    public class Methods
    {
        
        static public void print(string input)
        {
            Console.Write(input);
        }
        static public void println(string input)
        {
            Console.WriteLine(input);
        }
        static public bool checkInput(string input, char[,] board)
        {
            if(input.Length !=2)
            {
                println("invalid input");
                return false;
            }
            else if((int)input[0]<'a' || (int)input[0] >'c' || (int)input[1]<'1' || (int)input[1]>'3')
			{
				println("invalid input");
                return false;
			}
            else if(board[input[0]-96,input[1]-'0'] != '.')
            {
				println("invalid input");
                return false;
            }
            else
            {
                return true;
            }
            
        }
        static public void PrintBoard(char[,] board )
        {
            for(int j = 0;j < board.GetLength(0);j++)
            {
				for (int i = 0; i < board.GetLength(1); i++)
				{
                    char element = board[i,j];
                    if(element == 'x')
                    {
                        Console.ForegroundColor =ConsoleColor.Red;
                    }
                    else if(element == 'o')
                    {
                        Console.ForegroundColor =ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor =ConsoleColor.Gray;
                    }
                    print(element.ToString()+" ");
				}
                print("\n");
            }
			
        }
        static public void InitializeBoard(ref char[,] board)
        {
           
            board = new char[4,4];
            board[0,0] = ' ';
            for(int i = 1;i < board.GetLength(0);i++)
            {
                
				for (int j = 1; j < board.GetLength(1); j++)
				{
					board[i,j] = '.'; //dot
				}

				board[i,0] = (char)(i + 96); //lowercase letters start at 97
                board[0,i] = (char)(i + '0'); //numbers letters start at 49
            }
        }
    
        static public char CheckWin(char[,] board)
        {
            
            for (int i = 1; i < 4; i++)
            {
                if(board[i,1] == board[i,2] && board[i,2] == board[i,3])
                {
                    println("\n row "+i+"\n");
                    return board[i,1];
                }
            }
            for (int i = 1; i < 4; i++)
            {
                if(board[1,i] == board[2,i] && board[2,i] == board[3,i])
                {
                    println("\n column "+i+"\n");
                    return board[1,i];
                }
            }
            if(board[1,1] == board[2,2] && board[2,2] == board[3,3])
            {
                println("\n diag 1 \n");
                return board[1,1];
            }
            else if(board[1,3] == board[2,2] && board[2,2] == board[3,1])
            {
                println("\n diag 2 \n");
                return board[1,1];
            }
            else
            {
                return 'n';
            }
            
        }
    }
}
