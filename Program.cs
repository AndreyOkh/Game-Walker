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
1. Вывод списка уровней, список уровней находится в папке Levels в формате .txt     // ГОТОВО
2. Реализовать выбор уровня     // ГОТОВО
3. Генерация предметов
4. Генерация и реализация движения врагов
5. Реализовать игровой счет
6. Реализовать сохранение
7. Реализовать игровые жизни
8. Поздравление с победой или провалом
*/
using Welcome;

// HelloUser.Hello();
// Console.ReadKey(true);

// Рисуем поле
Console.Clear();
char[,] arena = Arena();

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

Console.Clear();
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

// Метод выбора и вывода уровня
char[,] Arena()
{
    // Вывожу список уровней
    Console.WriteLine("Введите номер уровня");
    string[] dirs = Directory.GetFiles("Levels/", "*.txt");
    for (int i = 0; i < dirs.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {dirs[i]}");
    }

    // Предлагаю выбрать уровень
    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    int numLevel = 1;
    int.TryParse(pressedKey.KeyChar.ToString(), out numLevel);
    string dirLevel = dirs[numLevel - 1];
    Console.WriteLine(dirLevel);
    int levelLengthRow = File.ReadAllLines(dirLevel).Length;
    int levelLengthColumn = File.ReadAllLines(dirLevel)[0].Length;
    Console.WriteLine($"Row {levelLengthRow} Columns {levelLengthColumn}");

    // Переношу выбранный уровень в массив
    char[,] arena = new char[levelLengthRow, levelLengthColumn];
    string[] level = File.ReadAllLines(dirLevel);

    for (int s = 0; s < level.Length; s++)
    {
        char[] row = level[s].ToCharArray();
        for (int j = 0; j < arena.GetLength(1); j++)
        {
            arena[s, j] = row[j];
        }
    }

    // Печатаю пользователю выбранный уровень
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