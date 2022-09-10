namespace Level1;

public static class GameLevelOne
{
    public static char[,] Arena()
    {
        char[,] arena = new char[20,20]
        {
            {'*','S','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
            {'*',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ','*'},
            {'*',' ','*','*','*',' ',' ',' ',' ','*',' ',' ',' ',' ','*','*',' ',' ',' ','*'},
            {'*',' ','*',' ','*',' ',' ',' ',' ','*','*','*','*',' ',' ','*',' ','*',' ','*'},
            {'*',' ',' ',' ','*','*','*','*',' ','*',' ',' ','*',' ','*','*',' ','*',' ','*'},
            {'*','*','*','*','*',' ',' ','*',' ','*',' ',' ','*',' ','*',' ',' ','*',' ','*'},
            {'*',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ','*',' ','*',' ',' ','*',' ','*'},
            {'*',' ',' ','*',' ','*','*','*','*','*','*','*','*',' ','*',' ','*','*',' ','*'},
            {'*',' ','*','*',' ',' ',' ','*',' ',' ',' ',' ',' ',' ','*',' ','*',' ',' ','*'},
            {'*',' ',' ','*',' ',' ',' ','*',' ',' ','*','*','*','*','*',' ','*',' ',' ','*'},
            {'*',' ',' ',' ',' ',' ',' ','*',' ',' ','*',' ',' ',' ',' ',' ','*',' ','*','*'},
            {'*',' ','*','*','*','*','*','*',' ',' ','*',' ',' ',' ',' ',' ','*',' ',' ','*'},
            {'*',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ','*','*','*','*',' ',' ','*'},
            {'*',' ','*','*','*','*','*',' ','*','*','*',' ',' ',' ',' ','*',' ',' ',' ','*'},
            {'*',' ',' ',' ',' ',' ','*',' ','*',' ',' ',' ',' ',' ',' ','*',' ','*','*','*'},
            {'*',' ','*','*','*','*','*',' ','*',' ',' ','*','*','*',' ','*',' ',' ',' ','*'},
            {'*',' ','*',' ',' ',' ',' ',' ','*',' ','*','*',' ','*','*','*',' ','*',' ','*'},
            {'*',' ','*','*','*','*','*','*','*',' ','*',' ',' ',' ',' ',' ',' ','*',' ','*'},
            {'*',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ','*',' ','*'},
            {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','F','*'}
        };

        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < arena.GetLength(0); i++)
        {
            for (int j = 0; j < arena.GetLength(1); j++)
            {
                Console.Write(arena[i, j]);
            }
            Console.WriteLine();
        }
        return arena;
    }
}