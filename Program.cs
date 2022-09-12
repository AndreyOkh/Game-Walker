// Console.SetCursorPosition() - позволяет поставить курсор в какую-либо точку консоли
// Console.CursorVisible - изменяет видимость курсора
// Console.ReadKey() - ожидает нажатия клавиши на клавиатуре и возвращает ConsoleKeyInfo
// В ConsoleKeyInfo.Key можно получить ConsoleKey - это нажатая пользователем клавиша

// 10.1. Задача написать игру-бродилку, где можно управлять персонажем стрелками вверх-вниз-влево-вправо. 
// Область движения ограничена стенками ('*') в виде лабиринта, персонаж обозначается символом '@'. 
// Область можно задать через двумерный массив. Персонаж должен иметь свободу движения в пределах его области.

// 10.2 Нужно доработать игру до пакмана. Игрок может собирать ягодки (символ можно выбрать самостоятельно, рекомендуется точка) 
// У игры есть несколько уровней, уровни прописываются в виде лабиринта в отдельном файле. То есть любой может создать уровень, закинуть его в папку с уровнями, пронумеровать и должно работать. 
// Метод для чтения файла File.ReadAllLines

// Так же есть враги. Ходят в случайном направлении (точная механика на твое усмотрение, но они должны мешать игроку). При соприкосновении с игроком игрок проигрывает. 

// Возможности для доработок: 
// Меню выбора уровней
// Жизни
// Сохранения

/*
1. Вывод списка уровней, список уровней находится в папке Levels в формате .txt
2. Реализовать выбор уровня
3. Генерация предметов
4. Генерация и реализация движения врагов
5. Реализовать игровой счет
6. Реализовать сохранение
7. Реализовать игровые жизни

*/
using Welcome;
using Level1;

HelloUser.Hello();
Console.ReadKey(true);

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
    pressedKey = Console.ReadKey(true);
    switch (pressedKey.Key)
    {
        case (ConsoleKey.UpArrow):
        case (ConsoleKey.DownArrow):
            positionCoursorTop = Movement(positionCoursorLeft, positionCoursorTop, arena, pressedKey.Key);
            break;

        case (ConsoleKey.LeftArrow):
        case (ConsoleKey.RightArrow):
            positionCoursorLeft = Movement(positionCoursorLeft, positionCoursorTop, arena, pressedKey.Key);
            break;
    }

} while (pressedKey.Key != ConsoleKey.Escape);

Console.CursorVisible = true;

// Метод перемещения игрока в поле
int Movement(int positionCoursorLeft, int positionCoursorTop, char[,] arena, ConsoleKey pressedKey)
{
    int newPositionCoursorLeft = positionCoursorLeft;
    int newPositionCoursorTop = positionCoursorTop;

    switch (pressedKey)
    {
        case (ConsoleKey.UpArrow):
            --newPositionCoursorTop;
            break;

        case (ConsoleKey.DownArrow):
            ++newPositionCoursorTop;
            break;

        case (ConsoleKey.LeftArrow):
            --newPositionCoursorLeft;
            break;

        case (ConsoleKey.RightArrow):
            ++newPositionCoursorLeft;
            break;
    }

    bool checkStep = arena[newPositionCoursorTop, newPositionCoursorLeft] == ' ';
    if (checkStep)
    {
        Console.SetCursorPosition(positionCoursorLeft, positionCoursorTop);
        Console.Write(' ');
        Console.SetCursorPosition(newPositionCoursorLeft, newPositionCoursorTop);
        Console.Write('@');
        if (positionCoursorLeft != newPositionCoursorLeft)
            return newPositionCoursorLeft;
        else
            return newPositionCoursorTop;
    }
    else
    {
        if (positionCoursorLeft != newPositionCoursorLeft)
            return positionCoursorLeft;
        else
            return positionCoursorTop;
    }
}