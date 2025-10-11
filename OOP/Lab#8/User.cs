using System;

internal class User
{
    public int x;
    public int y;

    // Делегаты событий
    public delegate void Move(string message);
    public delegate void Press(string message);

    // События
    public event Move? Notify1;
    public event Press? Notify2;

    public User(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Moving(int dx, int dy)
    {
        x += dx;
        y += dy;
        Notify1?.Invoke($"Пользователь переместился на {dx} по X и на {dy} по Y. Новые координаты: ({x}, {y})");
    }

    public void Pressing(double ratio)
    {
        x = (int)(x / ratio);
        y = (int)(y / ratio);
        Notify2?.Invoke($"Пользователь сжат с коэффициентом {ratio}. Новые координаты: ({x}, {y})");
    }

    public void PrintState()
    {
        Console.WriteLine($"Текущее состояние: x = {x}, y = {y}");
    }
}
