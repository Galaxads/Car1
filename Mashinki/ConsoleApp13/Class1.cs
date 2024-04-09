using System;
using System.Numerics;

public class Avto
{

    private string nom; //Номер машины m
    private float bak; //Кол-во бензина в баке
    private float ras; //Расход топлива

    private int milleage1 ;//пробег за указанный отрезок
    private double milleage;//оищий Пробег
                           //Текущее кол-во бензина
    private double benzseychas;
    private double distance;//счетчик дистанции для остановок 
    private bool finalezda;
    private bool finalezda1;
    private double rasstoykoorf(double x1, double x2, double y1, double y2)
    {
        distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        Console.WriteLine($"Расстояние между начальной и конечной точкой координат {distance}");
        return distance;
    }
    
    private void info(string nom, float bak, float ras) //Конструктор класса
    {
        this.nom = nom;
        this.bak = bak;
        this.ras = ras;
        this.benzseychas = 0;
        this.milleage = 0;
    }
    //Вывод информации
    private void Out()
    {
        Console.WriteLine($"Вся информация о машине \nНомер машины:{nom}  \nРазмер бака:{bak} \nРасход топлива на 100км:{ras}");
    }
    //Заправка
    private double Zapravka()
    {

        Console.WriteLine($"Введите кол-во бензина (в литрах), на которое хотите заправить машину (макс значение:{bak}).");
        double popolbenz = Convert.ToDouble(Console.ReadLine());
        if (benzseychas + popolbenz <= bak)
        {
            benzseychas += popolbenz;
            Console.WriteLine($"Машина заправлена на {popolbenz} литров. Текущее количество топлива: {benzseychas} литров.");

        }
        else
        {
            Console.WriteLine("Бак машины переполнен. Невозможно добавить больше топлива.");//В случае превышение лимита бензина записывается максимально допустимое значение
            return benzseychas=bak;
        }
        return benzseychas;
    }

    //Цикл езды
    public void Drive()
    {
        if(nom!=null&&bak!=0&&ras!=0)
        {

        }
        else
        {
            Console.WriteLine($"Введите информацию о машине ");
            Console.WriteLine("Введите номер машины");
            string nomer = Console.ReadLine();
            Console.WriteLine("Введите размер бака");            //Проверка и заполнение данных машины 
            int bak = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите расход топлива на 1км");
            int ras = Convert.ToInt32(Console.ReadLine());
            if (ras < bak)
            {
                info(nomer, bak, ras);
                Out(); 
            }     
            else
            { Console.WriteLine("Данные введены некоректно"); }
        }
        double x1=0;
        double y1=0;
        double x2 = 0;
        double y2 = 0;
        int speed = 0;
        Console.WriteLine($"Возможные действия:1)Увеличить скорость\n2)Сбросить скорость\n3)Ехать пока не кончится бензин\n4)Авария\n5)Смена машины\n6)Вывод информации о машине");
        int otvet = Convert.ToInt32(Console.ReadLine());
        switch (otvet)
        {
            case 1:
                speedUp(speed); Drive(); break;
            case 2:                                //Увеличение и уменьшение скорости влияет на расход бензина
                speeddown(speed);Drive() ; break;
            case 3:
                if (0 < distance && finalezda == true)
                {
                                                          //Значение True означает что финальная точка еще не достигнута
                }
                else
                {
                    Console.WriteLine("Введите координату X");
                     x1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите координату Y");
                     y1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите конечную координату X");
                    x2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите конечную координату Y");
                    y2 = Convert.ToDouble(Console.ReadLine());
                    this.rasstoykoorf(x1, x2, y1, y2);
                    milleage1 = 0;
                    finalezda = true;
                     finalezda1=false;

}
                for (; milleage1 < distance;)
                {

                    if (benzseychas < ras)
                    {
                        Console.WriteLine($"Недостаточно топлива для прохождения {distance} км. Пожалуйста, заправьте машину.");
                        this.Zapravka();
                    }

                    benzseychas -= ras;
                    milleage1 += 1;
                    milleage += 1;
                    int ostanovka = (int)(distance / 2);
                    
                    
                    Console.WriteLine($"Пройдено {milleage1} км.Общий пробег: {milleage}. Остаток топлива: {benzseychas} литров.");
                    if (ostanovka < milleage1&&finalezda1==false)
                    {
                        Console.WriteLine("Вы хотите остановиться?");
                        string otvetostanovka = Console.ReadLine();
                        switch (otvetostanovka)
                        {
                            case "Да":
                                finalezda1 = true; Drive(); break;
                            case "да":
                                finalezda1 = true; Drive(); break;
                            case "Нет":
                                finalezda1 = true; break;
                            case "нет":
                                finalezda1 = true; break;
                            case "":
                                finalezda1 = true; break;

                        }
                    }
                    if (benzseychas < 0)
                    {
                        Console.WriteLine($"Топливо закончилось");
                        return;
                    }
                   // this.rasstoykoorf(x1, x2, y1, y2);
                    
                }
                distance = 0;
                  break;
                case 4:
                return; 
                case 5:
                return;
                case 6: Console.WriteLine($"Информация о машине:\nНомер машины:{nom}\nВместиость бака:{bak}\nРасход на 1км:{ras}"); Drive(); break;
        }
    }

    private void speedUp(int speed)
    {
        if(ras<200)
        {
            Console.WriteLine("На сколько увеличить скорость?");
            speed += Convert.ToInt32(Console.ReadLine());
            if (speed <10000)
            {
                this.ras = this.ras + (speed / 100);
            }
            else {Console.WriteLine("Вы не можете ехать так быстро"); }            
        }
        else
        {
            Console.WriteLine("Скорость слишком большая");
        }

    }
    private void speeddown(int speed)
    {
        if (ras > 0)
        {
            Console.WriteLine("На сколько уменьшить скорость?");
            speed = Convert.ToInt32(Console.ReadLine());
            float scor = this.ras - (speed / 100);
            if ( scor < ras)
            {
                Console.WriteLine("Скорость слишком низкая");
            }
            else { ras = scor; }

           
           
        }
        else { Console.WriteLine("Скорость слишком низкая"); }
    }
    public void avaria(int mashinu)
    {
        Random rnd = new Random();
        int index1=rnd.Next(1,mashinu);
        int index2 = rnd.Next(1,mashinu);
      if (index1 != index2)
            Console.WriteLine($"Машина {index1} и {index2} попали в аварию");
      
    }
   
}


