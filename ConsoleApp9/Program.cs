//Задание 2
//Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. Сортировка должна происходить при помощи события. 
//Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
//Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.

using System;
using System.Linq;


namespace ArrayException;
class OperationSort
{
    public delegate void Notify();
    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // событие
        public void StartProcess()
        {
            Console.WriteLine("Процесс начат!");
            OnProcessCompleted();
        }
        protected virtual void OnProcessCompleted() //protected virtual method
        {
            ProcessCompleted?.Invoke();
        }
    }
        public static void Main(string[] args)
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += WorkArray;

        bl.StartProcess();


    }
    public static void WorkArray() //string[] arrays
    {
        string[] familys = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
        try
        {

            Console.WriteLine("Введите тип сортировки число 1 (сортировка А-Я), либо число 2 (сортировка Я-А)");
            string num = Console.ReadLine();
            int i;
            bool res = int.TryParse(num, out i);
            if ((res) && (i==1 || i == 2))
                MySortArray(familys, i);
            else
                throw new FormatInputException("Введите или 1, или 2!");
        }
        catch (Exception ex)
        { Console.WriteLine(ex.ToString()); }
        finally 
        {
            Console.WriteLine("\n Программа завершена.");
        }
    }

    public static void MySortArray(string[] arrays, int TypeSort)
    {
        IOrderedEnumerable<string> query;
        if (TypeSort == 1)
        {
            query = from family in arrays
                        orderby family
                        select family;
            DisplayArray(query);

        }

        else
            if (TypeSort == 2)
        {
           query = from family in arrays
                        orderby family descending
                        select family;
            DisplayArray(query);
        }
                
    }
    


    public static void DisplayArray(IOrderedEnumerable<string> array)
    {
        foreach (string word in array)
        {
            Console.WriteLine(word);
        }
    }
}