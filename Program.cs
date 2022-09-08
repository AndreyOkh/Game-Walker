// Console.SetCursorPosition() - позволяет поставить курсор в какую-либо точку консоли
// Console.CursorVisible - изменяет видимость курсора
// Console.ReadKey() - ожидает нажатия клавиши на клавиатуре и возвращает ConsoleKeyInfo
// В ConsoleKeyInfo.Key можно получить ConsoleKey - это нажатая пользователем клавиша

// 10.1. Задача написать игру-бродилку, где можно управлять персонажем стрелками вверх-вниз-влево-вправо. 
// Область движения ограничена стенками ('*') в виде лабиринта, персонаж обозначается символом '@'. 
// Область можно задать через двумерный массив. Персонаж должен иметь свободу движения в пределах его области.

using Welcome;
ConsoleKeyInfo pressedKey;
int positionCoursorX = 2;
int positionCoursorY = 2;

HelloUser.Hello();
Console.WriteLine("Добро пожаловать в игру бродилку, что бы пройти лабиринт передвигайте @ стрелками. Что бы выйти нажмите ESC.");
Console.WriteLine("Нажмите любую клавишу что бы продолжить что бы продолжить");

Console.ReadKey();

Console.Clear();
Console.CursorVisible = false;
Console.SetCursorPosition(positionCoursorX, positionCoursorY);
Console.Write("@");



do
{
    pressedKey = Console.ReadKey();
    if(pressedKey.Key == ConsoleKey.UpArrow)
    {
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write(" ");
        --positionCoursorY;
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write("@");
    }
    if(pressedKey.Key == ConsoleKey.DownArrow)
    {
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write(" ");
        ++positionCoursorY;
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write("@");
    }
    if(pressedKey.Key == ConsoleKey.LeftArrow)
    {
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write(" ");
        --positionCoursorX;
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write("@");
    }
    if(pressedKey.Key == ConsoleKey.RightArrow)
    {
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write(" ");
        ++positionCoursorX;
        Console.SetCursorPosition(positionCoursorX, positionCoursorY);
        Console.Write("@");
    }
    
} while (pressedKey.Key != ConsoleKey.Escape);

