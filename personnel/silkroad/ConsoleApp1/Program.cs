using System.Runtime.CompilerServices;

bool[,] silkyWay = new bool[8, 8];

silkyWay[0, 0] = true; // A1
silkyWay[7, 7] = true; // H8

void DrawBoard(bool[,] board)
{
    Console.WriteLine("  12345678");
    Console.WriteLine(" ┌────────┐");
    for (char row = 'A'; row <= 'H'; row++)
    {
        Console.Write(row + "│");
        for (int col = 1; col <= 8; col++)
        {
            if (board[row - 'A', col - 1])
            {
                Console.Write("█");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine("│");
    }
    Console.WriteLine(" └────────┘");
}

// TODO Put silk on 30 more squares
Random random = new Random();

for (int i = 0; i < 30;)
{
    int x = random.Next(0, 8);
    int y = random.Next(0, 8);

    if (!silkyWay[x, y])
    {
        silkyWay[x, y] = true;
        i++;
    }

}

DrawBoard(silkyWay);

// TODO Create a data structure that allow us to remember which square has already been tested
bool[,] beenHere = new bool[8, 8];

// TODO Create a data structure that allow us to remember the successful steps
bool[,] roadRome = new bool[8, 8];

bool CanDoItFrom(int x, int y)
{
    if(x == 7 && y == 7) return true;
    if(x < 0 || x > 7 || y < 0 || y > 7) return false;
    if (!silkyWay[x, y]) return false;
    if(beenHere[x, y]) return false;
    beenHere[x, y] = true;
    if(
        CanDoItFrom(x + 1, y) ||
        CanDoItFrom(x, y + 1) ||
        CanDoItFrom(x - 1, y) ||
        CanDoItFrom(x, y - 1) ||
        CanDoItFrom(x + 1, y + 1) ||
        CanDoItFrom(x - 1, y + 1) ||
        CanDoItFrom(x - 1, y - 1) ||
        CanDoItFrom(x + 1, y - 1)        
      )
    {
        roadRome[x, y] = true;
        return true;
    }
    else { return false; }
}
// TODO Write the recursive function
// Recursive function that tells if we can reach H8 from the given position
// The algorithm is in fact simple to spell out (even in french ;)):
//
//      Je peux sortir depuis cette case si:
//          1. Je suis sur H8
//
//              ou
//
//          2. Je peux sortir depuis une des cases où je peux aller (et où je ne suis pas encore allé)

// TODO Call the function and show the results
// TODO Call the function and show the results
if (CanDoItFrom(0, 0))
{
    Console.WriteLine("Yes");
    roadRome[7, 7] = true;
    DrawBoard(roadRome);
}
else
{
    Console.WriteLine("No");
}

Console.ReadLine();