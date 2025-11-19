using System;

Console.Write("Enter a name for your avatar: ");
string? input = Console.ReadLine();

// Fallback if user just presses enter
if (string.IsNullOrWhiteSpace(input))
{
    input = "Anonymous";
}

Console.WriteLine($"Generating avatar for: {input}");
//Convert the name into a numeric seed
int seed = 0;
foreach (char c in input!)
{
    seed +=c;
}

Random rng = new Random(seed);

Console.WriteLine($"Internal seed: {seed}");

int size = 5;
bool[,] grid = new bool[size, size];

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < (size + 1)/2; col++)
    {
        bool filled = rng.Next(2) == 1;
        grid[row,col] = filled;

        int mirrorCol = size - col - 1;
        grid[row, mirrorCol] = filled;
    }
}

Console.WriteLine();
Console.WriteLine("Your avatar:");

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (grid[row, col])
        {
            Console.Write("█"); //filled
        } else {
            Console.Write(" "); //empty
        }
    }
    Console.WriteLine();
}

