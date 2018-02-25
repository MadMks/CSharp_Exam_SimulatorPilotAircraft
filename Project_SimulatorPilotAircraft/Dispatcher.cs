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

        public int RecommendedHeight { get; set; }


        // Делегаты.

        //public delegate int MessageDel(int height);

        // События.

        //public event MessageDel ProvideRecommendations;

        // Конструкторы.

        static Dispatcher()
        {
            rand = new Random();
        }

        public Dispatcher() : this ("no name")
        {

        }

        public Dispatcher(string name)
        {
            Correcting = rand.Next(-200, 200);
            //Console.WriteLine(" >>> " + Correcting);

            Name = name;

            
        }



        /// <summary>
        /// Расчет рекомендуемой высоты полета.
        /// </summary>
        public void CalculationOfFlightAltitude(int speed, int height)
        {
            Console.WriteLine($" Диспетчер \"{Name}\" получил данные: "
                + $"speed={speed}, height{height}");

            Console.WriteLine($" Corr = {Correcting}");
            //int recommendedHeight;

            RecommendedHeight = (7 * speed) - Correcting;

            //Console.WriteLine($" Рекомендуемая высота: {recommendedHeight}");
            //ProvideRecommendations?.Invoke(recommendedHeight);
            //return recommendedHeight;
        }
    }
}
