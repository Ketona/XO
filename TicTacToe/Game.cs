using System;

namespace TicTacToe
{
	public class Game
	{
		private Player[] _players = new Player[2];
		private char[,] _table = new char[3,3];
		private const int  LENGTH = 3;
		private int counter = 0;

		public Game ()
		{
			Console.WriteLine ("Welcome to the game!");
//FillTable();
			_players [0] = new Player ('O');
			_players [1] = new Player ('X');
			FillTableWithSpaces ();
			//Start ();
		}

		public void Start()
		{
		Player current;
			while (true) {
				counter++;
				if (!PlayerTurn (_players [0])) {
					current = _players [0];
					break;
				}
				counter++;
				if (!PlayerTurn (_players [1])) {
					current = _players [1];
					break;
				}
				if (counter == 9) {
					Console.WriteLine ("It'a s draw!");
					break;
				}
			}

			Console.WriteLine ("Congrets {0} ^.^  You fuckin won!",current.Name);
		}

		private void FillTableWithSpaces(){
			for (int i = 0; i < LENGTH; i++) {
				for (int j = 0; j < LENGTH; j++) {
					_table [i, j] = ' ';
				}
			}
		}

		private bool PlayerTurn(Player currentPlayer)
		{
			Console.WriteLine ("------------------------------------------");
			Console.WriteLine ("You are player {0}!", currentPlayer.Name);
			DrawTable ();
			Console.WriteLine ("It's {0}'s turn!", currentPlayer.Name);

			Console.WriteLine ("Where would you like to move? (Ex: A1, A2, etc)");
			string answer = Console.ReadLine();
			ConvertAnswer (answer.ToUpper(), currentPlayer);
			return Check (currentPlayer);
		}

		private bool Check(Player currentPlayer){
			int key = (int)currentPlayer.Name*3;
			if (_table[0, 0]+_table[1,1]+_table[2,2] == key || _table[0, 2]+_table[1,1]+_table[2,0] == key) {
				return false;
			}
			for (int i = 0; i < LENGTH; i++) {
				if (_table[i,0]+_table[i,1]+_table[i,2] == key ||
				    _table[0,i]+_table[1, i]+_table[2, i]== key ) {
					return false;
				}
			}
			return true;
		}

		private void ConvertAnswer(string answer, Player currentPlayer){
			try{
				char[] rowAndColumn = answer.ToCharArray ();
				int i = (int)rowAndColumn [0]-65;
				int j = int.Parse(rowAndColumn [1].ToString())-1;
				if (_table [i, j] == ' ') {
					_table [i, j] = currentPlayer.Name;
				} else {
					throw new Exception("Already taken");
				}
			}catch(Exception) {
				Console.WriteLine ("Error!");
				PlayerTurn (currentPlayer);
			}
		}

		private void DrawTable()
		{
			Console.WriteLine ("{0}|{1}|{2}\n-----\n{3}|{4}|{5}\n-----\n{6}|{7}|{8}",
			                   _table[0,0],_table[0,1],_table[0,2],_table[1,0],_table[1,1],
			                   _table[1,2],_table[2,0],_table[2,1],_table[2,2]);
		}
	}
}

