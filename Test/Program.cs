using System;

namespace Test
{
    public class Program
    {
        private static float _result = 0;
        private static int _countNumber = 0;
        private static List<float> _numbers;
        private static bool _acceptOperation = true;
        private static void Main(string[] args)
        {
            Console.WriteLine("Приветствую в калькуляторе!\nВведите кол-во чисел:");
            int.TryParse(Console.ReadLine(),out _countNumber);

            if (_countNumber > 0)
                WriteNumbers();
            else
            {
                Console.WriteLine("Должно быть хотя-бы 1 число!");
                _acceptOperation = false;
            }
            if (_acceptOperation)
            {
                Console.WriteLine("Выберите одну из операций: | + | - | * | / |");
                SelectOperation(Console.ReadLine());
            }
            Console.WriteLine("Нажмите любую клавишу чтобы выйти.");
            Console.ReadKey();
        }

        private static void SelectOperation(string symbol)
        {
            bool acceptOperation = true;
            switch (symbol)
            {
                case "+":
                    foreach (var item in _numbers)
                    {
                        _result += item;
                    }
                    break;
                case "-":
                    foreach (var item in _numbers)
                    {
                        _result -= item;
                    }
                    break;
                case "*":
                    if (_numbers.Count > 1)
                    {
                        _result = _numbers[0];
                        for (int i = 1; i < _numbers.Count; i++)
                        {

                            _result *= _numbers[i];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Чисел меньше, чем нужно для операции. Требуется минимум 2 числа.");
                        acceptOperation = false;
                        break;
                    }
                    break;
                case "/":
                    if (_countNumber > 1) {
                        _result += _numbers[0];
                        for (int i = 1; i < _numbers.Count; i++)
                        {
                            if (_result == 0 || _numbers[i] == 0)
                            {
                                Console.WriteLine("Делить на ноль нельзя.");
                                acceptOperation = false;
                                break;
                            }
                            _result /= _numbers[i];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Чисел меньше, чем нужно для операции. Требуется минимум 2 числа.");
                        acceptOperation = false;
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Такой операции не существует. Выберите другую операцию");
                    acceptOperation = false;
                    break;
            }
            if (acceptOperation)
                Console.WriteLine(_result);
        }

        private static void WriteNumbers()
        {
            _numbers = new List<float>(_countNumber);
            int positionNumber;

            for (int i = 0; i < _countNumber; i++)
            {
                positionNumber = i + 1;
                Console.WriteLine("Введите " + positionNumber + " число");

                string num = Console.ReadLine();
                if (float.TryParse(num, out float result))
                    _numbers.Add(result);
                else
                {
                    Console.WriteLine("Ошибка данных, указано не число!");
                    _acceptOperation = false;
                    break;
                }
            }
        }
    }
}
