using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SimulatorPilotAircraft
{
    class Dispatcher
    {
        private static Random rand;

        public string Name { get; set; }
        /// <summary>
        /// Корректировка для погодных условий.
        /// </summary>
        public int Correcting { get; }


        // Конструкторы.

        static Dispatcher()
        {
            rand = new Random();
        }

        public Dispatcher() : this ("no name", 0)
        {

        }

        public Dispatcher(string name, int correcting)
        {
            Correcting = rand.Next(-200, 200);
            Console.WriteLine(" >>> " + Correcting);

            Name = name;
            Correcting = correcting;
        }



        /// <summary>
        /// Расчет рекомендуемой высоты полета.
        /// </summary>
        public void CalculationOfFlightAltitude(int speed, int height)
        {
            Console.WriteLine(" Диспетчер получил данные: "
                + $"speed={speed}, height{height}");

            int recommendedHeight;

            recommendedHeight = (7 * speed) - Correcting;

            Console.WriteLine($" Рекомендуемая высота: {recommendedHeight}");
        }
    }
}
