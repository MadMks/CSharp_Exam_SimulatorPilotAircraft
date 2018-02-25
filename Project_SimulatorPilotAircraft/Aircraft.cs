using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SimulatorPilotAircraft
{
    /// <summary>
    /// Класс "Самолет".
    /// </summary>
    class Aircraft
    {
        private const int _minNumberDispatcher = 2;

        ConsoleKeyInfo key;

        /// <summary>
        /// Скорость самолета.
        /// </summary>
        //public int Speed { get; set; }
        private int _speed;

        public int Speed
        {
            get { return _speed; }
            set
            {
                if (ASufficientNumberOfDispatchers())
                {
                    _speed = value;

                    MessageToDispatchers();
                }
                else
                {
                    Console.WriteLine(" Полет не модет начаться, " + 
                        "если диспетчеров меньше двух.");   // TODO m недостаточно диспетч.
                }
                
            }
        }

        /// <summary>
        /// Высота самолета.
        /// </summary>
        //public int Height { get; set; }
        /// <summary>
        /// Высота самолета.
        /// </summary>
        private int _height;
        /// <summary>
        /// Высота самолета.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if (ASufficientNumberOfDispatchers())
                {
                    _height = value;

                    MessageToDispatchers();
                }
                else
                {
                    Console.WriteLine(" Полет не модет начаться, " +
                        "если диспетчеров меньше двух.");   // TODO m недостаточно диспетч.
                }
            }
        }


        public List<Dispatcher> Dispatchers { get; set; }

        // Конструкторы.

        public Aircraft()
        {
            Dispatchers = new List<Dispatcher>();

            // UNDONE допустим добавил диспетчеров
            Dispatchers.Add(new Dispatcher("Bob"));
            Dispatchers.Add(new Dispatcher("John"));


            KeyPress += SpeedIncrease;
            KeyPress += SpeedDecrease;
            KeyPress += HeightIncrease;
            KeyPress += HeightDecrease;


            foreach (Dispatcher item in Dispatchers)
            {
                ChangesInMeasurements += item.CalculationOfFlightAltitude;
                //item.ProvideRecommendations += Recommendations;
            }
        }

        private void ShowRecommendations()
        {
            if (Speed > 50)
            {
                Console.WriteLine();
                foreach (Dispatcher item in Dispatchers)
                {
                    Console.WriteLine($" Диспетчер {item.Name}: "
                        + $"рекомендуемая высота: {item.RecommendedHeight}");
                }
            }
        }




        // Делегаты.

        public delegate void KeyDelegate(ConsoleKeyInfo key);
        public delegate void ChangeDelegate(int speed, int height);

        // События.

        /// <summary>
        /// Событие "нажатие клавиши".
        /// </summary>
        public event KeyDelegate KeyPress;
        /// <summary>
        /// Событие "Изменение измерений самолета".
        /// </summary>
        public event ChangeDelegate ChangesInMeasurements;


        // Методы.

        /// <summary>
        /// Запуск симуляции.
        /// </summary>
        public void StartSimulator()
        {


            do
            {
                Console.Clear();

                ShowAircraftData();

                ShowRecommendations();

                // TODO вывод меню.
                //Console.WriteLine("\n Вывел меню");
                ShowMenuPilot();


                // TODO запрос нажать клавишу - всегда последний.
                KeyInputRequest();

                
            } while (key.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вывод меню пилота.
        /// </summary>
        private void ShowMenuPilot()
        {
            WriteLine("\n Меню:\n" + new string('=', 36));
            Console.WriteLine(" F1 - add");
            Console.WriteLine(" F2 - del");
            WriteLine(" R: +50км/ч\tS R: +150км/ч\tLeft: -50км/ч\tS L: -150км/ч");
            Console.WriteLine(" S R - add");
        }


        /// <summary>
        /// Вывод данных самолета.
        /// </summary>
        private void ShowAircraftData()
        {
            Console.WriteLine("\n Данные самолета:");
            Console.WriteLine($" Скорость: {Speed}км/ч\t Высота: {Height}м.");
            Console.WriteLine("\n" + new string('=', 36));
        }

        private void KeyInputRequest()
        {
            //ConsoleKeyInfo key;

            //do
            //{
            Console.WriteLine(" Запрос ввода:");
            key = Console.ReadKey();

            //OnKeyPress(key);    // HACK KeyPress?.Invoke(key);
            KeyPress?.Invoke(key);

            //} while (key.Key != ConsoleKey.Escape);
        }


        /// <summary>
        /// Метод вызывается при нажатии на клавишу.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        //public void OnKeyPress(ConsoleKeyInfo key)  // TODO UNDONE не особо нужен
        //{
        //    KeyPress?.Invoke(key);
        //}


        /// <summary>
        /// автоматическое сообщение диспетчеру
        /// </summary>
        private void MessageToDispatchers()
        {
            if (Speed > 50) // TODO magNumber
            {
                ChangesInMeasurements?.Invoke(Speed, Height);
            }
        }

        /// <summary>
        /// Увеличение скорости.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        private void SpeedIncrease(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow &&
                key.Modifiers == ConsoleModifiers.Shift)
            {
                Console.WriteLine(" +150 км/ч");

                Speed += 150;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                Console.WriteLine(" +50 км/ч");

                Speed += 50;
            }
        }



        /// <summary>
        /// Уменьшение скорости.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        private void SpeedDecrease(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow &&
                key.Modifiers == ConsoleModifiers.Shift)
            {
                Console.WriteLine(" -150 км/ч");

                Speed -= 150;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Console.WriteLine(" -50 км/ч");

                Speed -= 50;
            }
        }




        /// <summary>
        /// Увеличение высоты.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        private void HeightIncrease(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow &&
                key.Modifiers == ConsoleModifiers.Shift)
            {
                Console.WriteLine(" +500 м");

                Height += 500;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                Console.WriteLine(" +250 м");

                Height += 250;
            }
        }


        /// <summary>
        /// Уменьшение высоты.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        private void HeightDecrease(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow &&
                key.Modifiers == ConsoleModifiers.Shift)
            {
                Console.WriteLine(" -500 м");

                Height = 500;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                Console.WriteLine(" -250 м");

                Height -= 250;
            }
        }



        /// <summary>
        /// Достаточное количество диспетчеров.
        /// </summary>
        /// <returns>
        /// "true" если диспетчеров хватает,
        /// "false" если не хватает.
        /// </returns>
        public bool ASufficientNumberOfDispatchers()
        {
            return Dispatchers.Count >= _minNumberDispatcher;
        }


    }
}
