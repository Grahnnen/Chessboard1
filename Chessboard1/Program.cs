using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.Unicode; // Allow Unicode characters in console

		var settings = new BoardSettings(); // Object to store board settings

		// Ask the user if they want to use custom characters for the board
		settings.UseCustomKeys = AskYesNo("Do you want to use your own characters for the board?");
		if (settings.UseCustomKeys) // If the answer is Yes
		{
			Console.Clear(); // Clear the console
			Console.Write("Please enter the first character: ");
			settings.KeyX = Console.ReadLine(); // Set the X string
			Console.Write("Please enter the second character: ");
			settings.KeyY = Console.ReadLine(); // Set the Y string
		}

		// Read the board size from the user
		settings.Size = ReadSize();

		Console.Clear(); // Clear the console
		Console.WriteLine("Setting the board size to: " + settings.Size);

		// Render the chessboard
		RenderBoard(settings);

		Console.ReadKey(); // Wait for a key press before closing
	}

	// Method that asks the user a Yes/No question (loops until valid input)
	static bool AskYesNo(string question)
	{
		while (true)
		{
			Console.Write(question + " [y/n] ");
			var key = Console.ReadKey(true).Key; // Reads a key without displaying it
			if (key == ConsoleKey.Y) return true;  // If Y, return true
			if (key == ConsoleKey.N) return false; // If N, return false
			Console.Clear();
			Console.WriteLine("Invalid input, try again."); // If invalid input
		}
	}

	// Method to read the size of the board
	static int ReadSize()
	{
		int size = -1;
		while (size < 0) // Loop until we get a valid size
		{
			Console.Clear();
			Console.Write("Enter the size of the chessboard (number): ");

			// Try to parse the input as an integer
			if (!int.TryParse(Console.ReadLine(), out size) || size <= 0 || size >= 1000)
			{
				// If parsing failed or the size is too small/large

				Console.WriteLine("Invalid size, try again.");
				size = -1; // Continue the loop
			}
		}
		return size; // Return the valid size
	}

	// Method to render the chessboard
	static void RenderBoard(BoardSettings settings)
	{
		// Choose which characters to use (custom or default)
		string first = settings.UseCustomKeys ? settings.KeyY : "◼︎";
		string second = settings.UseCustomKeys ? settings.KeyX : "◻︎";

		Console.WriteLine(); // Add spacing before the board
		for (int row = 0; row < settings.Size; row++) // Create rows
		{
			for (int col = 0; col < settings.Size; col++) // Create columns
			{
				// If the sum of row + col is even, print first character, otherwise second
				Console.Write(((row + col) % 2 == 0 ? first : second) + " ");
			}
			Console.WriteLine(); // New line after each row
		}
	}
}

// Class to hold chessboard settings
class BoardSettings
{
	public int Size { get; set; } // The board size
	public bool UseCustomKeys { get; set; } // Whether the user chose custom characters
	public string KeyX { get; set; } = "◼︎"; // First default character (black square)
	public string KeyY { get; set; } = "◻︎"; // Second default character (white square)
}
