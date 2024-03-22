namespace Test
{
    public class Program
    {
        private static float result = 0;
        private static List<float> numbers;
        private static bool accesNextProccesCircle = true;
        private static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                List<float> numbers;

                Console.WriteLine("Приветствую в калькуляторе!\nВведите кол-во чисел:");
                int countNumber = Convert.ToInt32(Console.ReadLine());

                numbers = new List<float>(countNumber);
                WriteNumbers(numbers);
                SelectOperation(Console.ReadLine());
            }
        }

        private static void SelectOperation(string symbol)
        {
            Console.WriteLine("+ / - / * / :");
            switch (symbol)
            {
                case "+":
                    foreach (var item in numbers)
                    {
                        result += item;
                    }
                    Console.WriteLine(result);
                    break;
                case "-":
                    foreach (var item in numbers)
                    {
                        result -= item;
                    }
                    Console.WriteLine(result);
                    break;
                case "*":
                    foreach (var item in numbers)
                    {
                        result *= item;
                    }
                    Console.WriteLine(result);
                    break;
                case ":":
                    foreach (float item in numbers)
                    {
                        result /= item;
                    }
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Такой операции не существует. Выберите другую операцию");
                    break;
            }
            result = 0;
        }

        private static void WriteNumbers(List<float> numbers)
        {
            for(int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = Convert.ToSingle(Console.ReadLine());
            }
        }
    }
}