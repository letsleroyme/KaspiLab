using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab2
{
    class Elevator
    {

        public Elevator(int countoffloors, int capacity)
        {
            CountOfFloors = countoffloors;
            Capacity = capacity;
        }



        /// <summary>
        /// Этажность здания
        /// </summary>
        private int _countOfFloors;
        public int CountOfFloors
        {
            private set
            {
                if (value <= 0)
                    throw new Exception("В здании не может быть 0 или менее этажей!");
                else
                    _countOfFloors = value;
            }
            get
            {
                return _countOfFloors;
            }
        }

        /// <summary>
        /// Грузоподъемность
        /// </summary>
        private int _capacity;
        public int Capacity
        {
            private set
            {
                if (value <= 0)
                    throw new Exception("Грузоподъемность не может быть 0 или менее людей!");
                else
                    _capacity = value;
            }
            get
            {
                return _capacity;
            }
        }

        /// <summary>
        /// Текущий этаж, на котором находится лифт
        /// </summary>
        private int _currentFloor = 0;

        /// <summary>
        /// Переменная, необходимая для блокирования действий во время движения
        /// </summary>
        private bool _doorClosed = true;

        public void LiftMovement(int DestinationFloor, int PeopleCount)
        {
            if (CheckBeforeMovement(DestinationFloor, PeopleCount))
            {
                Console.WriteLine($"Открываю дверь");
                Console.WriteLine($"Начинаю движение");
                    
                if (DestinationFloor > _currentFloor)
                {
                    for (int i = _currentFloor; i <= DestinationFloor; i++)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                else
                {
                    for (int i = _currentFloor; i >= DestinationFloor; i--)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                Console.WriteLine($"Закончил движение");
            }
        }


        public void CallElevator(int DestinationFloor)
        {

            if (CheckBeforeMovement(DestinationFloor))
            {
                Console.WriteLine($"Вызван лифт на этаж {DestinationFloor}");
                if (DestinationFloor > _currentFloor)
                {
                    for (int i = _currentFloor; i <= DestinationFloor; i++)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                else
                {
                    for (int i = _currentFloor; i >= DestinationFloor; i--)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                Console.WriteLine($"Закончил движение");
            }
        }

        private void WorkWithDoors()
        {
            if (_doorClosed)
            {
                Console.WriteLine("Открываю дверь");
                _doorClosed = false;
            }
            else
            {
                Console.WriteLine("Открываю дверь");
                _doorClosed = true;
            }
        }




        private bool CheckBeforeMovement(int DestinationFloor, int PeopleCount = 0)
        {
            if (_currentFloor == DestinationFloor)
            {
                Console.WriteLine("Лифт находится на вызванном этаже!");
                return false;
            }
            if (PeopleCount > _capacity)
            {
                Console.WriteLine("Перегрузка!");
                return false;
            }
            if (DestinationFloor > _countOfFloors || DestinationFloor < _countOfFloors)
            {
                Console.WriteLine("Лифт вызван на несуществующий эатж!");
                return false;
            }


            return true;
        }




    }
}
