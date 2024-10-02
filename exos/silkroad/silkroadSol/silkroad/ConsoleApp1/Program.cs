Random alea = new Random();

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
int silkSquares = 30;
while (silkSquares > 0)
{
    int row = alea.Next(0, 8);
    int col = alea.Next(0, 8);
    if (!silkyWay[row, col])
    {
        silkyWay[row, col] = true;
        silkSquares--;
    }
}

DrawBoard(silkyWay);

// TODO Create a data structure that allow us to remember which square has already been tested
bool[,] beenThere = new bool[8, 8];
// TODO Create a data structure that allow us to remember the successful steps
bool[,] exitPath = new bool[8, 8];

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

bool CanDoItFrom(int x, int y)
{
    if (x == 7 && y == 7) return true; // H8 is the goal
    if (x < 0 || y < 0 || x > 7 || y > 7) return false; // outside the board
    if (beenThere[x, y]) return false; // don't go in circles
    beenThere[x, y] = true; // mark our passing
    if (!silkyWay[x, y]) return false;
    if (
        CanDoItFrom(x + 1, y) ||
        CanDoItFrom(x, y + 1) ||
        CanDoItFrom(x - 1, y) ||
        CanDoItFrom(x, y - 1) ||
        CanDoItFrom(x + 1, y + 1) ||
        CanDoItFrom(x - 1, y + 1) ||
        CanDoItFrom(x + 1, y - 1) ||
        CanDoItFrom(x - 1, y - 1)
        )
    {
        exitPath[x, y] = true;
        return true;
    }
    else { return false; }
}

// TODO Call the function and show the results
if (CanDoItFrom(0, 0))
{
    Console.WriteLine("Yes");
    exitPath[7,7] = true;
    DrawBoard(exitPath);
}
else
{
    Console.WriteLine("No");
}

Console.ReadLine();