using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleGraphics.Classes;

namespace TurtleGraphics
{
    class Program
    {
 
        static void Main(string[] args)
        {

            int[,] floor = new int[20,20];
          
            Turtle turtle = new Turtle(floor);
          
            int[,] programm = { { 2,0 }, { 3, 0 },{ 5 ,12 },{3 ,0 },{5 ,12 },{3 ,0 },{5 ,12}, { 3, 0 }, { 5, 12 }, { 1, 0 },{ 6, 0 }, { 9, 0 } };
            turtle.ReadCommands(programm);

            
            Console.ReadKey();

        }

    }
}
