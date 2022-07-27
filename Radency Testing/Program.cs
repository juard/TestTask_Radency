using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radency_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public static string Order(string input)
        {

            if (input is null) return input; // якщо стрічка пуста, вертаємо пусту стрічку
            string[] Subs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray(); //розбиваємо стрічку на окремі "числа" та видаляємо пробіли

            var Orders = new Dictionary<int, List<string>>(); //створюємо словник, в якому ключ є сумою цифр числа, а значення - список чисел, які відповідають сумі

            foreach (string sub in Subs) //заповнення словника
            {
                var Sum = ReturnSumOfString(sub); //знаходження суми цифр числа за допомогою методу ReturnSumOfString
                if (!Orders.ContainsKey(Sum)) Orders[Sum] = new List<string>(); //якщо словник не містить ключа, якій відповідає суми, то створюється новий список чисел, які відповідають сумі-ключу.
                                                                                
                Orders[Sum].Add(sub);                                           //якщо ключ з такою сумою вже існує, то до списку дописується число
                Orders[Sum].Sort();                                             //сортування списку чисел за ключем
            }

            

            var Ordered = Orders.OrderBy(x => x.Key).SelectMany(x => x.Value);//сортування словника за значенням ключа(сумі цифр) та зведення відсортованих за ключем чисел в єдину колекцію

            StringBuilder newstr = new StringBuilder("");//створюємо нову стрічку за допомогою класу StringBuilder
            foreach (var num in Ordered)
            {
                newstr.Append(num + " "); //записуємо в стрічку значення кожного елементу відсортованої колекції Ordered
            }

            return newstr.ToString();//повертаємо відсортовану стрічку
        }

        public static int ReturnSumOfString(string input)
        {
            int[] vs = input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();//перетворення числа в массив цілочисельних чисел
            return vs.Sum(); //поверення суми цифр 
        }
    }
}
