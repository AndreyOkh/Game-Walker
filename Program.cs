// Console.SetCursorPosition() - позволяет поставить курсор в какую-либо точку консоли
// Console.CursorVisible - изменяет видимость курсора
// Console.ReadKey() - ожидает нажатия клавиши на клавиатуре и возвращает ConsoleKeyInfo
// В ConsoleKeyInfo.Key можно получить ConsoleKey - это нажатая пользователем клавиша

// 10.1. Задача написать игру-бродилку, где можно управлять персонажем стрелками вверх-вниз-влево-вправо. 
// Область движения ограничена стенками ('*') в виде лабиринта, персонаж обозначается символом '@'. 
// Область можно задать через двумерный массив. Персонаж должен иметь свободу движения в пределах его области.

using Welcome;
using Level1;

HelloUser.Hello();
Console.ReadKey();

// Рисуем поле
Console.Clear();
char[,] arena = GameLevelOne.Arena();

// Создаем игрока
ConsoleKeyInfo pressedKey;
int positionCoursorLeft = 1;
int positionCoursorTop = 1;
Console.CursorVisible = false;
Console.SetCursorPosition(positionCoursorLeft, positionCoursorTop);
Console.Write('@');


do
{
    pressedKey = Console.ReadKey();
    if (pressedKey.Key == ConsoleKey.UpArrow || 
        pressedKey.Key == ConsoleKey.DownArrow) 
        positionCoursorTop = Movement(positionCoursorLeft, positionCoursorTop, arena, pressedKey.Key);

    if (pressedKey.Key == ConsoleKey.LeftArrow ||
        pressedKey.Key == ConsoleKey.RightArrow)
        positionCoursorLeft = Movement(positionCoursorLeft, positionCoursorTop, arena, pressedKey.Key);

} while (pressedKey.Key != ConsoleKey.Escape);

// Метод перемещения игрока в поле
int Movement(int positionCoursorLeft, int positionCoursorTop, char[,] arena, ConsoleKey pressedKey)
{
    int newPositionCoursorLeft = positionCoursorLeft;
    int newPositionCoursorTop = positionCoursorTop;

    if(pressedKey == ConsoleKey.UpArrow) --newPositionCoursorTop;
    if(pressedKey == ConsoleKey.DownArrow) ++newPositionCoursorTop;
    if(pressedKey == ConsoleKey.LeftArrow) --newPositionCoursorLeft;
    if(pressedKey == ConsoleKey.RightArrow) ++newPositionCoursorLeft;

    bool checkStep = arena[newPositionCoursorTop, newPositionCoursorLeft] == ' ';
    if(checkStep)
    {
        Console.SetCursorPosition(positionCoursorLeft, positionCoursorTop);
        Console.Write(' ');
        Console.SetCursorPosition(newPositionCoursorLeft, newPositionCoursorTop);
        Console.Write('@');
        if (positionCoursorLeft != newPositionCoursorLeft) return newPositionCoursorLeft;
        else return newPositionCoursorTop;
    }
    else
    {
        if (positionCoursorLeft != newPositionCoursorLeft) return positionCoursorLeft;
        else return positionCoursorTop;
    }
}