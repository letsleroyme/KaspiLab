using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Elevator el = new Elevator(10, 10);
                el.CallElevator(9);
                el.LiftMovement(1, 9);
                Elevator el2 = new Elevator(-1, 12);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }
        }
    }
}
