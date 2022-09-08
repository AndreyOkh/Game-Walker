// Console.SetCursorPosition() - позволяет поставить курсор в какую-либо точку консоли
// Console.CursorVisible - изменяет видимость курсора
// Console.ReadKey() - ожидает нажатия клавиши на клавиатуре и возвращает ConsoleKeyInfo
// В ConsoleKeyInfo.Key можно получить ConsoleKey - это нажатая пользователем клавиша

// 10.1. Задача написать игру-бродилку, где можно управлять персонажем стрелками вверх-вниз-влево-вправо. 
// Область движения ограничена стенками ('*') в виде лабиринта, персонаж обозначается символом '@'. 
// Область можно задать через двумерный массив. Персонаж должен иметь свободу движения в пределах его области.

using Welcome;
ConsoleKeyInfo pressedKey;
int positionCoursorLeft = 0;
int positionCoursorTop = 0;

HelloUser.Hello();
Console.WriteLine("Добро пожаловать в игру бродилку, что бы пройти лабиринт передвигайте @ стрелками. Что бы выйти нажмите ESC.");
Console.WriteLine("Нажмите любую клавишу что бы продолжить что бы продолжить");

Console.ReadKey();

Console.Clear();
Console.CursorVisible = false;
Console.SetCursorPosition(positionCoursorLeft, positionCoursorTop);
Console.Write("@");

do
{
    pressedKey = Console.ReadKey();
    if (pressedKey.Key == ConsoleKey.UpArrow || 
        pressedKey.Key == ConsoleKey.DownArrow) 
        positionCoursorTop = Movement(positionCoursorLeft, positionCoursorTop, pressedKey.Key);

    if (pressedKey.Key == ConsoleKey.LeftArrow ||
        pressedKey.Key == ConsoleKey.RightArrow)
        positionCoursorLeft = Movement(positionCoursorLeft, positionCoursorTop, pressedKey.Key);

} while (pressedKey.Key != ConsoleKey.Escape);

int Movement(int positionCoursorLeft, int positionCoursorTop, ConsoleKey pressedKey)
{
    int newPositionCoursorLeft = positionCoursorLeft;
    int newPositionCoursorTop = positionCoursorTop;

    if(pressedKey == ConsoleKey.UpArrow) --newPositionCoursorTop;
    if(pressedKey == ConsoleKey.DownArrow) ++newPositionCoursorTop;
    if(pressedKey == ConsoleKey.LeftArrow) --newPositionCoursorLeft;
    if(pressedKey == ConsoleKey.RightArrow) ++newPositionCoursorLeft;

    Console.SetCursorPosition(positionCoursorLeft, positionCoursorTop);
    Console.Write(' ');
    Console.SetCursorPosition(newPositionCoursorLeft, newPositionCoursorTop);
    Console.Write('@');

    if (positionCoursorLeft != newPositionCoursorLeft) return newPositionCoursorLeft;
    else return newPositionCoursorTop;
}