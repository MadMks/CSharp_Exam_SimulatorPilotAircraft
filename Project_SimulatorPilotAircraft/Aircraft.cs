using System;
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
                _speed = value;

                MessageToDispatchers();
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
                _height = value;

                MessageToDispatchers();
            }
        }


        public List<Dispatcher> Dispatchers { get; set; }

        // Конструкторы.

        public Aircraft()
        {
            Dispatchers = new List<Dispatcher>();

            // UNDONE допустим добавил диспетчеров
            Dispatchers.Add(new Dispatcher("Bob", 0));


            KeyPress += SpeedIncrease;
            KeyPress += SpeedDecrease;
            KeyPress += HeightIncrease;
            KeyPress += HeightDecrease;


            foreach (Dispatcher item in Dispatchers)
            {
                ChangesInMeasurements += item.CalculationOfFlightAltitude;
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
            // TODO вывод меню.
            Console.WriteLine(" Вывел меню");


            // TODO запрос нажать клавишу - всегда последний.
            KeyInputRequest();
        }


        private void KeyInputRequest()
        {
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine(":");
                key = Console.ReadKey();

                OnKeyPress(key);    // HACK KeyPress?.Invoke(key);

            } while (key.Key != ConsoleKey.Escape);
        }


        /// <summary>
        /// Метод вызывается при нажатии на клавишу.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        public void OnKeyPress(ConsoleKeyInfo key)  // TODO UNDONE не особо нужен
        {
            KeyPress?.Invoke(key);
        }


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



    }
}
