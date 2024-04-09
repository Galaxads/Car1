// See https://aka.ms/new-console-template for more information
Console.WriteLine("Сколько создать машин?");
int mashinu=Convert.ToInt32(Console.ReadLine());
Avto[] avtopark= new Avto[mashinu+1];
for(int i=1;i<avtopark.Length;i++)
{
    avtopark[i] = new Avto();
   
}
for (int i = 0; i < 2;)
{    
    Console.WriteLine("Для использования машин нажмите 1.Для режима АВАРИЯ нажмите 2");
    int vibor= Convert.ToInt32(Console.ReadLine());
    switch (vibor)
    {
        case 1:
            Console.WriteLine($"Введите индекс машины (достпуно {avtopark.Length - 1} машины)");
            int nomerm = Convert.ToInt32(Console.ReadLine());
            if (nomerm < avtopark.Length)
            {
                avtopark[nomerm].Drive();
            }
            else
            {
                Console.WriteLine("Такой машины не существует");
            }
            break;
        case 2:
            avtopark[1].avaria(mashinu);break;
    }
       
}



