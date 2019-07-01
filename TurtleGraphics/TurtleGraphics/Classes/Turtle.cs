using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGraphics.Classes
{
    public class Turtle
    {
        int[,] _floor; 

        //holds the turtles current position
        int[] _position = { 0, 0 };

        /// <summary>
        /// 0 is up, 1 is right, 2 is down and 3 is left
        /// </summary>
        int _direction = 0;

        bool penUp = true;

        enum Commands { PenUp, PenDown, TurnRight, TurnLeft, MoveForward, Print, EndOfData }

        public Turtle(int[,] floor)
        {
            _floor = floor;
        }

        /// <summary>
        /// reads commands and writes to its floor array. 2d array second dimension is for movement distance * always add a 9 at the end*
        /// commands are:
        /// 1 Pen up,
        /// 2 pen down,
        /// 3 turn right,
        /// 4 turn left,
        /// 5 move forward,
        /// 6 Print,
        /// 9 for end of data
        /// </summary>
        /// <param name="commands"></param>
        public void ReadCommands(int[,] commands)
        {
            
            int index = 0;
            int curCommand = commands[index,0];
            while (curCommand != 9)
            {
                curCommand = commands[index,0];
                switch (curCommand) {

                    case (int)Commands.PenUp +1:
                        PenUp();
                        break;
                    case (int)Commands.PenDown + 1:
                        PenDown();
                        break;
                    case (int)Commands.TurnRight + 1:
                        TurnRight();
                        break;
                    case (int)Commands.TurnLeft + 1:
                        TurnLeft();
                        break;
                    case (int)Commands.MoveForward + 1:
                        MoveForward(commands[index,1]);
                        break;
                    case (int)Commands.Print + 1:
                        Print();
                        break;
                    default:
                        break;
                }

                index++;
            }
        }

        void PenUp()
        {
            penUp = true;
        }

        void PenDown()
        {
            penUp = false;
        }

        void TurnRight()
        {
            _direction ++;
            if(_direction > 3)
            {
                _direction = 0;
            }
        }

        void TurnLeft()
        {
            _direction--;
            if (_direction < 0)
            {
                _direction = 3;
            }
        }

        /// <summary>
        /// moves the turtle in the direction its facing for the specified distance, writes to the floor based on what direction its facing 
        /// </summary>
        /// <param name="distance"></param>
        void MoveForward(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                if (!penUp)
                {
                    switch (_direction)
                    {
                        case 0:
                            if(_position[1]-1 > 0)
                            {
                                _position[1] = _position[1] - 1;
                                _floor[_position[0], _position[1]] = 2;
                            }
                            break;
                        case 1:
                            if (_position[0] + 1 < _floor.GetLength(0))
                            {
                                _position[0] = _position[0] + 1;
                                _floor[_position[0], _position[1]] = 1;
                            }
                            break;
                        case 2:
                            if (_position[1] + 1 < _floor.GetLength(1))
                            {
                                _position[1] = _position[1] + 1;
                                _floor[_position[0], _position[1]] = 2;
                            }
                            break;
                        case 3:
                            if (_position[0] -1 > 0)
                            {
                                _position[0] = _position[0] - 1;
                                _floor[_position[0], _position[1]] = 1;
                            }
                            break;
                    }
                    
                }
            }
        }


        /// <summary>
        /// prints the floor to the console with characters instead of the ints 
        /// </summary>
        void Print()
        {
            for (int i = 0; i < _floor.GetLength(0); i++)
            {
                for (int j = 0; j < _floor.GetLength(1); j++)
                {
                    if(_floor[j,i] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if(_floor[j, i] == 1)
                    {
                        Console.Write("-");
                    }
                    else if (_floor[j, i] == 2)
                    {
                        Console.Write("|");
                    }
                    else 
                    {
                        Console.Write(_floor[j, i]);
                    }

                }
                Console.WriteLine();
            }
        }

    }
}
