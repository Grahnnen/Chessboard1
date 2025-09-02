Console.OutputEncoding = System.Text.Encoding.Unicode; // Allow the use of boardkeys

int boardSize = -1;

bool confirmed = false; // Bool for userinput loop
bool usingOwnKeys = false; 
ConsoleKey response; //userinput Response

string boardKeyX = null; //userinput boardPieceX
string boardKeyY = null; //userinput boardPieceY

while (!confirmed)//Running until the user selects if they want to use their own board
{
	Console.Write("Vill du använda egna tecken för brädet? [y/n] ");
	response = Console.ReadKey(false).Key; //sets the response


	if (response == ConsoleKey.N)
	{
		confirmed = true; // if the response is N exit the loop
	}
	else if (response == ConsoleKey.Y) // If the response is Y
	{
		Console.Clear();  //clear the console
		usingOwnKeys = true; //set the usingOwnKeys bool to true
		Console.Write("Vänligen mata in första tecknet: ");
		boardKeyX = Console.ReadLine(); // sets the X string
		Console.Write("Vänligen mata in andra tecknet: ");
		boardKeyY = Console.ReadLine(); //set the Y string
		confirmed = true; // exit the loop
	}
	else
	{
		Console.Clear();//Clears the console and repeats the loop if you press anything else
	}
}

Console.Clear();

ReadSize();

void ReadSize()
{
	while (boardSize < 0)
	{
		Console.Write("Mata in storleken på Schackbrädet(siffra): ");

		if (!int.TryParse(Console.ReadLine(), out boardSize)) // Converts your input to a string
		{
			Console.WriteLine("Ogiltig siffra, försök igen.");
			Console.ReadKey();
			Console.Clear();
			boardSize = -1; // repeats the loop
		}
		if(boardSize >= 1000) //Check if the board is to big
		{
			Console.WriteLine("Lite väl stort Schackbräde va? Prova igen.");
			Console.ReadKey();
			Console.Clear();
			boardSize = -1; //repeats the loop
		}
	}

	Console.Clear();
	Console.WriteLine("Sätter brädet till storleken: " + boardSize);
	
	RenderBoard();
	
}
void RenderBoard()
{
	Console.WriteLine(); //Create space for chessboard
	if (usingOwnKeys) //if user selected to us their own keys
	{
		for (int row = 0; row < boardSize; row++) //create the rows
		{
			for (int col = 0; col < boardSize; col++) //create the columns
			{
				if ((row + col) % 2 == 0) //Check if cells is even
				{
					Console.Write(boardKeyY + " ");
				}
				else
				{
					Console.Write(boardKeyX + " ");
				}
			}
			Console.WriteLine(); //Switch to a new line
		}
	}
	else //use default keys
	{
		for (int row = 0; row < boardSize; row++)//create the rows
		{
			for (int col = 0; col < boardSize; col++)//create the columns
			{
				if ((row + col) % 2 == 0) //Check if cells is even
				{
					Console.Write("◼︎ ");
				}
				else
				{
					Console.Write("◻︎ ");
				}
			}
			Console.WriteLine(); //Switch to a new line
		}
	}
}
Console.ReadKey();