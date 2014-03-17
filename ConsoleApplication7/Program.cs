using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication7
{

    class Program
    {
        public static int Num = 0;
        //public static string[] point = new string[(int)Math.Pow(2, (Num-1))];
        //public static int k = 0; 


        


        public static int create_point(BinaryTree xy,double x, double y, int i, double step)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(x.ToString() + " ; " + y.ToString());
            xy.SetSection(sb.ToString());

           

                if (i == Num)
                {
                    return 0;
                }

                else
                {
                    

                    System.Console.WriteLine(xy.section);
                    
                    

                   
                       
                    

                    if (i % 2 != 0)
                    {
                        xy.AdditionR();
                        create_point(xy.Right , x + step, y, i + 1, step / 2);
                        xy.AdditionL();
                        create_point(xy.Left ,  x - step, y, i + 1, step / 2);
                    }
                    else
                    {
                        xy.AdditionR();
                        create_point(xy.Right ,x, y + step, i + 1, step / 2);
                        xy.AdditionL();
                        create_point(xy.Left , x, y - step, i + 1, step / 2);
                    }
                }
            
                return 0;
            
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа   для  генерации   точек  фрактала,");
            System.Console.WriteLine("координаты точек  хранятся  в бинарном дереве");
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine("Длина  родительского   отрезка  и  количество");
            System.Console.WriteLine("ветвлений задается пользователем с клавиатуры");
            System.Console.WriteLine("---------------------------------------------");

            System.Console.WriteLine("Введите длину начального отрезка фрактала:");


            try
            {
                float Len = float.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Длина родительского звена = " + Len);

                System.Console.WriteLine();
                System.Console.WriteLine("Введите количество ветвлений фрактала:");
                Num = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine();
                System.Console.WriteLine("Количество ветвлений = " + Num);

                


                BinaryTree BT = new BinaryTree();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

     
                create_point(BT , 0, Len, 1, Len / 2);

               // System.Console.WriteLine(BT.Right.section);
                //System.Console.WriteLine(BT.Left.section);

            }

            //адекватная реакция на ошибки

            catch (FormatException e1)
            {
                System.Console.WriteLine("Введены недопустимые символы"); //исключение неверного формата
            }

            catch (OverflowException e2)
            {
                System.Console.WriteLine("Введена слишком большая последовательность символов"); //исключение слишком большого числа
            }







            
            finally
            {
                System.Console.WriteLine();
                System.Console.WriteLine("По нажатию любой клавиши работа завершится автоматически");
                System.Console.ReadKey();
            }
        }
    }
}
