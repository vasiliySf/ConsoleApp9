//Задание 1
//Создайте свой тип исключения.
//Сделайте массив из пяти различных видов исключений, включая собственный тип исключения. Реализуйте конструкцию TryCatchFinally, в которой будет итерация на каждый тип исключения (блок finally по желанию).
//В блоке catch выведите в консольном сообщении текст исключения.

using System.Collections.Generic;

namespace ExceptionSample;


class ExceptionCollection
{
    // Закрытое поле, хранящее товары в виде массива
    private Exception[] collection;
    public int CountException;
    // Конструктор с добавлением массива товаров
    public ExceptionCollection(Exception[] collection)
    {
        this.collection = collection;
        CountException = collection.Length;
    }

    // Индексатор по массиву
    public Exception this[int index]
    {
        get
        {
            // Проверяем, чтобы индекс был в диапазоне для массива
            if (index >= 0 && index < collection.Length)
            {
                return collection[index];
            }
            else
            {
                return null;
            }
        }

        private set
        {
            // Проверяем, чтобы индекс был в диапазоне для массива
            if (index >= 0 && index < collection.Length)
            {
                collection[index] = value;
            }
        }
    }
}

class ProgramException
{
    public static void Main(string[] args)
    {

        DivideByZeroException divideByZeroException = new DivideByZeroException();
        ArrayTypeMismatchException arrayTypeMismatchException = new ArrayTypeMismatchException();
        IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException();
        OverflowException overflowException = new OverflowException();
        RangeArrayException rangeArrayException = new RangeArrayException();

        var arrays = new Exception[] { divideByZeroException, arrayTypeMismatchException, indexOutOfRangeException, overflowException, rangeArrayException };

        int[] numbers = new int[6];
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = i;

        for (int i = 0; i < arrays.Length; i++)
        {
            int result;
            int j;
            try
            {
                switch (i)
                {
                    case 0:
                        {
                            int b = 1;
                            b--;
                            if (b==0)
                                throw arrays[0];
                            else
                            {                                
                                result = (numbers[1] / b);
                            }
                                                          
                            break;
                        }
                    case 1:
                        {
                            string str = "ноль";
                            
                            if (Int32.TryParse(str, out result))
                                numbers[1] = result;
                            else
                                throw arrays[1];
                            break;
                        }
                    case 2:
                        {
                            numbers[6] = 2;
                            throw arrays[2];
                            break;
                        }
                    case 3:
                        {
                            int a = 127;
                            int b =127;
                            byte res;
                            if ((a * b) > 255 || (a * b) < 0)
                               throw arrays[3];
                            else   
                                res = checked((byte)(a + b));                            
                            break;
                        }
                    case 4:
                        {
                            throw arrays[4];
                            break;
                        }

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType()+ " "+ e.Message); 
            }
            finally
            {
                j = i;
                Console.WriteLine(++j + " исключение закончено.");
            }

        }
    }

}