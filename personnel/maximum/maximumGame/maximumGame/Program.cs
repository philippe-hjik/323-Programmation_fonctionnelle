using System;
using System.Threading;

class Program
{
    static int linesOfCode = 9210;
    static Random random = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine($"Opening shop with {linesOfCode} lines in our program");
        Thread thread1 = new Thread(Bob);
        Thread thread2 = new Thread(Alice);

        // Start both threads
        thread1.Start();
        Thread.Sleep(300); // Alice starts her day a bit later
        thread2.Start();

        // Wait until both threads terminate
        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Closing shop with {linesOfCode} lines in our program");
        Console.ReadLine();
    }

    static void Bob()
    {
        int myLineCounter = 0; // Bob starts working
        int workingHours = 0;

        while (workingHours < 9) // He has a 9-hours day ahead of him
        {
            Thread.Sleep(1000); // Bob works for "1 hour"
            workingHours++;
            int BobProduction = 1;
            Console.WriteLine($"Bob commits {BobProduction} lines of code.");
            myLineCounter += BobProduction;
        }
        linesOfCode += myLineCounter; // he turns his work in
        Console.WriteLine($"Bob checks out, he claims the program has now {linesOfCode} lines");
    }

    // Method to be executed by thread2 - increments by 2 every 3 seconds
    static void Alice()
    {
        int myLineCounter = 0; // Alice starts working
        int workingHours = 0;
        while (workingHours < 7) // She has a 7-hours day ahead of her
        {
            Thread.Sleep(1000); // Alice works for "1 hour"
            workingHours++;
            int AliceProduction = 5;
            Console.WriteLine($"Alice commits {AliceProduction} lines of code.");
            myLineCounter += AliceProduction;
        }
        linesOfCode += myLineCounter; // she turns her work in
        Console.WriteLine($"Alice checks out, she claims the program has now {linesOfCode} lines");
    }
}
