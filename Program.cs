using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Ex : Exception
    {
        public Ex(string m) : base(m)
        {

        }
        class Ex1 :FileNotFoundException
        {
            public Ex1(string m) : base(m)
            {

            }
        }
    }
    class Ex2 : DivideByZeroException
    {
        public Ex2(string m) : base(m)
        {

        }
    }


    class Exclusion
    {
        public static Exclusion exc = new Exclusion(100);
        int numb;
       

        public Exclusion(int n)
        {
            numb = n;
        }

        public void FormatEx()
        {
            Console.WriteLine("Введите число");
            int x=Convert.ToInt32(Console.ReadLine());
            if (x<100)
            {
                x *= x;
                Console.WriteLine("Квадрат числа: " + x);
            }
            else 
            {
                throw new FormatException("Значение больше 100");

            }
          
        }
        void FormatEx1()
        {
            Console.WriteLine("Введите число");
            int x = Convert.ToInt32(Console.ReadLine());
            try
            {
                try {
                    if (x > 100)
                    {
                        throw new FormatException("Неправильный формат");
                    }
                }
                catch
                {
                    Console.WriteLine("Возникло исключение");
                    throw;
                }
               
            }
            catch(FormatException ex10)
            {
                Console.WriteLine(ex10.Message);
            }
          
        }
        public void ZeroEx()
        {
            Console.WriteLine("Введите число");
            string input1 = Console.ReadLine();
            int x = int.Parse(input1);
            Console.WriteLine("Введите число");
            string input2 = Console.ReadLine();
            int y = int.Parse(input2);
            if (y == 0)
            {
                throw new Ex2("Деление на 0 невозможно");
            }
            else
            {
                Console.WriteLine($"{x} / {y} = {x / y}");
            }
        }
        public void IndexEx()
        {
            int[] arr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = i;
            }
            Console.WriteLine("Введите индекс: ");
            int x;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out x))
            {
                if (x < 0 || x > 4)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы массива");
                }
                else
                {
                    Console.WriteLine("Элемент массива: " + arr[x]);
                }
            }
        }
        public void FileEx()
        {
            FileInfo fileInfo = new FileInfo(@"C:\Пацей\Lab6\Lab6");
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла:{fileInfo.Name}");
            }
            else
            {
                throw new FileNotFoundException("Файл не найден");
            }
        }
        unsafe void Point()
        {
            int pol = exc.numb;
            int* point = &pol;
            NullEx(*point);
        }
        public void NullEx(int? point)
        {
            if (point != null)
            {
                Console.WriteLine($"число:{exc.numb}");
            }
            else
            {
                throw new NullReferenceException("нулевой указатель");
            }
        }
        
      
        internal class Program
        {
           
            static void Main(string[] args)
            {
                int aa = 10;
                Debug.Assert(aa != 1, "Некорректно");
            
                try
                {
                    Exclusion.exc.FormatEx();
                    Exclusion.exc.ZeroEx();
                    Exclusion.exc.IndexEx();
                    Exclusion.exc.FileEx();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine($"Метод: {ex.TargetSite}");
                    Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
                    Console.WriteLine($"Имя сборки:{ex.Source}");
                    Console.WriteLine($"Информация об исключении:{ex.InnerException}");
                }
                catch (Ex2 ex1)
                {
                    Console.WriteLine($"Ошибка: {ex1.Message}");
                    Console.WriteLine($"Метод: {ex1.TargetSite}");
                    Console.WriteLine($"Трассировка стека: {ex1.StackTrace}");
                    Console.WriteLine($"Имя сборки:{ex1.Source}");
                    Console.WriteLine($"Информация об исключении:{ex1.InnerException}");
                }
                catch (IndexOutOfRangeException ex2)
                {
                    Console.WriteLine($"Ошибка: {ex2.Message}");
                    Console.WriteLine($"Метод: {ex2.TargetSite}");
                    Console.WriteLine($"Трассировка стека: {ex2.StackTrace}");
                    Console.WriteLine($"Имя сборки:{ex2.Source}");
                    Console.WriteLine($"Информация об исключении:{ex2.InnerException}");
                }
               /* catch (FileNotFoundException ex3)
                {
                    Console.WriteLine($"Ошибка: {ex3.Message}");
                    Console.WriteLine($"Метод: {ex3.TargetSite}");
                    Console.WriteLine($"Трассировка стека: {ex3.StackTrace}");
                    Console.WriteLine($"Имя сборки:{ex3.Source}");
                    Console.WriteLine($"Информация об исключении:{ex3.InnerException}");

                }*/
                catch (NullReferenceException ex4)
                {
                    Console.WriteLine($"Ошибка: {ex4.Message}");
                    Console.WriteLine($"Метод: {ex4.TargetSite}");
                    Console.WriteLine($"Трассировка стека: {ex4.StackTrace}");
                    Console.WriteLine($"Имя сборки:{ex4.Source}");
                    Console.WriteLine($"Информация об исключении:{ex4.InnerException}");

                }
          
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка");
                }
                finally
                {
                   
                    Console.WriteLine("Программа завершена");
                }
                try
                {
                    int x = 5;
                    int y = x / 0;
                    Console.WriteLine($"Результат: {y}");
                }
                catch
                {
                    Console.WriteLine("Возникло исключение!");
                }
                finally
                {
                    Console.WriteLine("Блок finally");
                }
            }
        }
    }
}
