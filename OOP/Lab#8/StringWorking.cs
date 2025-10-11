using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class StringWorking
{
    public string stroke { get; set; }
    
    Predicate<string> isNullOrEmpty = (string stroke) => string.IsNullOrEmpty(stroke);

    Action op;

    public StringWorking(string stroke)
    {
        this.stroke = stroke;
        op = () => this.stroke = this.stroke.Trim();
    }

    public string ReplacingInString(string replaceText, string replace, Func<string, string, string> replacing) => replacing(replaceText, replace);

    public void DeleteWhiteSpaces() => op();

    public void DeletePoints(Func<string, string> operation, Func<string, string> toUpper)
    {
        try
        {
            if (isNullOrEmpty(this.stroke))
                throw new Exception("Строка-то пустая или не определена");

            this.stroke = toUpper(operation(this.stroke));

            Console.WriteLine("Результат обработки: " + this.stroke);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    public void AddText(string addText, Action<string> op) => op(addText);

    public string Operation1(string text)
    {
        var changed = text.Where(c => !char.IsPunctuation(c));
        return string.Join("", changed);
    }

    public string Operation2(string text) 
    { 
        return text.ToUpper();
    }

    public void Operation3(string addText)
    {
        this.stroke = string.Format($"{this.stroke} {addText}", addText);
    }

    public string Operation4(string replaceText, string replacing)
    {
        return this.stroke.Replace(replacing, replaceText);
    }

}
