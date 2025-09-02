Console.OutputEncoding = System.Text.Encoding.Unicode;

int boardSize = -1;

bool confirmed = false;
bool usingOwnKeys = false;

ConsoleKey response;
string boardKeyX = null;
string boardKeyY = null;

while (!confirmed)
{
	Console.Write("Vill du använda egna tecken för brädet? [y/n] ");
	response = Console.ReadKey(false).Key;
	confirmed = response == ConsoleKey.N;

	Console.Clear();
	if(response == ConsoleKey.Y)
	{
		usingOwnKeys = true;
		Console.WriteLine("Vänligen mata in första tecknet: ");
		boardKeyX = Console.ReadLine();
		Console.WriteLine("Vänligen mata in andra tecknet: ");
		boardKeyY = Console.ReadLine();
		confirmed = true;
	}
}

ReadSize();

void ReadSize()
{
	while (boardSize < 0)
	{
		Console.Write("Mata in storleken på Schackbrädet: ");

		if (!int.TryParse(Console.ReadLine(), out boardSize))
		{
			Console.WriteLine("Ogiltig siffra, försök igen.");
			boardSize = -1;
		}
	}

	Console.Clear();
	Console.WriteLine("Sätter brädet till storleken: " + boardSize);
	
	RenderBoard();
	
}
void RenderBoard()
{
	Console.WriteLine();
	if (usingOwnKeys)
	{
		for (int row = 0; row < boardSize; row++)
		{
			for (int col = 0; col < boardSize; col++)
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
	else
	{
		for (int row = 0; row < boardSize; row++)
		{
			for (int col = 0; col < boardSize; col++)
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