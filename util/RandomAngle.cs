using System;



    public class RandomAngle
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            //Создание объекта для генерации чисел (с указанием начального значения)
            

            //Получить случайное число 
            var value = rnd.Next(-90, 90);

            //Вернуть полученное значение
            return value;
        }
    }
