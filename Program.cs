using System.Drawing;
using System.Threading.Tasks.Dataflow;
using System.Threading;
using System;
using library;

namespace C__Learning 
{
    class Program : Methods
    {
		static bool runProg = true;
        static char[,] board;

		static bool turn = true;
        static void Main(string[] args)
        {
			
			
            
            Start();
            
            while(runProg)
            {
                
                Update();
                
            }
			print("\n");
            println("end");
			Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        static void Start()
        {
			Console.Clear();
			 println("Started\n");
            InitializeBoard(ref board);
			PrintBoard(board);
			Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        static void Update()
        {
			Console.ForegroundColor = (turn)? ConsoleColor.Red:ConsoleColor.Green;
			char curentTurn = (turn)? 'x':'o';
			print(curentTurn + ": ");
			string input = Console.ReadLine();
			
			if(input.ToLower() == "exit")
			{
				runProg = false;
			}
			else
			{
				int row,column;
				

				if(checkInput(input,board))
				{
					row = (int)input[0] - 96;
            		column = (int)input[1] - 48;
					board[row,column] = curentTurn;
					
					Console.Clear();
					PrintBoard(board);
					char winner = CheckWin(board);
					if(winner == 'x' || winner == 'o')
					{
						println(winner + " has won!");
						println("press \"Enter\" to play again or \"Esc\" to quit ");
						ConsoleKey key = Console.ReadKey(false).Key;
						while (key != ConsoleKey.Enter && key != ConsoleKey.Escape)
						{
							key = Console.ReadKey(false).Key;
							print(key.ToString());
						}
						if(key == ConsoleKey.Escape)
						{
							runProg = false;
						}
						else
						{
							Start();
							turn = true;
						}
					}
					turn = !turn;
				}
			}
        }
    }
}
