Console.OutputEncoding = System.Text.Encoding.Unicode;

int boardSize = -1;

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
	for (int i = 0; i < boardSize; i++)
	{
		RenderBoard();
	}
}
void RenderBoard()
{
	Console.WriteLine();
	for (int i = 0; i < boardSize; i++)
	{
		if (i % 2 == 0)
			Console.Write("◼︎ ");
		else
			Console.Write("◻︎ ");
	}
}
Console.ReadKey();