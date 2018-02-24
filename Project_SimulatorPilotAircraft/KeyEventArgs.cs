using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SimulatorPilotAircraft
{
    /// <summary>
    /// Класс "хранит символ нажатой клавиши".
    /// </summary>
    class KeyEventArgs : EventArgs
    {
        //public ConsoleKeyInfo key;

        /// <summary>
        /// Символ нажатой клавиши.
        /// </summary>
        public ConsoleKeyInfo KeyInfo { get; set; }
    }
}
