using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab2
{
    class Elevator
    {
        /// <summary>
        /// Инициализация нового лифта
        /// </summary>
        /// <param name="countoffloors">Количество этажей в здании</param>
        /// <param name="capacity">Вместимость лифта</param>
        public Elevator(int countoffloors, int capacity)
        {
            CountOfFloors = countoffloors;
            Capacity = capacity;
            State = States.CloseDoorsWaiting;
        }

        /// <summary>
        /// В перечислении хранятся состония, в которых может находится лифт.
        /// </summary>
        public enum States
        {
            OpenDoorsWaiting, 
            MovementUP,
            MovementDOWN,
            CloseDoorsWaiting
        }

        /// <summary>
        /// Текущее состояние лифта
        /// </summary>
        public States State { get; private set; }

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
        /// Метод, описываюищй движение лифта с людьми на борту.
        /// </summary>
        /// <param name="DestinationFloor">Этаж назначения</param>
        /// <param name="PeopleCount">Количество людей</param>
        public void LiftMovement(int DestinationFloor, int PeopleCount)
        {
            if (CheckBeforeMovement(DestinationFloor, PeopleCount))
            {
                Console.WriteLine($"Открываю дверь");
                State = States.OpenDoorsWaiting;
                Console.WriteLine($"Состояние лифта: {State}, людей погружено в лифт: {PeopleCount}");
                Console.WriteLine($"Закрываю дверь");
                State = States.CloseDoorsWaiting;
                Console.WriteLine($"Состояние лифта: {State}");
                
                if (DestinationFloor > _currentFloor)
                {
                    Console.WriteLine($"Начинаю движение");
                    State = States.MovementUP;
                    Console.WriteLine($"Состояние лифта: {State}");
                    for (int i = _currentFloor; i <= DestinationFloor; i++)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                else
                {
                    Console.WriteLine($"Начинаю движение");
                    State = States.MovementDOWN;
                    Console.WriteLine($"Состояние лифта: {State}");
                    for (int i = _currentFloor; i >= DestinationFloor; i--)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                
                Console.WriteLine($"Закончил движение");
                if (_currentFloor == DestinationFloor)
                {
                    Console.WriteLine("Приехал на нужный этаж, выпускаю людей.");
                    State = States.OpenDoorsWaiting;
                    Console.WriteLine($"Состояние лифта: {State}");
                    State = States.CloseDoorsWaiting;
                    Console.WriteLine("Закрыл двери, ожидаю.");
                    Console.WriteLine($"Состояние лифта: {State}");

                }
            }
        }

        /// <summary>
        /// Метод, описывающий вызов лифта на определенный этаж.
        /// </summary>
        /// <param name="DestinationFloor">Этаж назначения</param>
        public void CallElevator(int DestinationFloor)
        {

            if (CheckBeforeMovement(DestinationFloor))
            {
                Console.WriteLine($"Вызван лифт на этаж {DestinationFloor}");
                if (DestinationFloor > _currentFloor)
                {
                    Console.WriteLine($"Начинаю движение");
                    State = States.MovementUP;
                    Console.WriteLine($"Состояние лифта: {State}");
                    for (int i = _currentFloor; i <= DestinationFloor; i++)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                else
                {
                    Console.WriteLine($"Начинаю движение");
                    State = States.MovementDOWN;
                    Console.WriteLine($"Состояние лифта: {State}");
                    for (int i = _currentFloor; i >= DestinationFloor; i--)
                    {
                        _currentFloor = i;
                        Console.WriteLine($"Текущий этаж: {i}");
                    }
                }
                Console.WriteLine($"Закончил движение");
                Console.WriteLine("Приехал на нужный этаж, ожидаю погрузки людей.");
                State = States.OpenDoorsWaiting;
                Console.WriteLine($"Состояние лифта: {State}");
            }
        }


        /// <summary>
        /// Метод, делающий проверку перед запуском лифта.
        /// Проверяемые ошибки: проверка на перегрузку, вызов лифта на несуществующий этаж
        /// </summary>
        /// <param name="DestinationFloor">Этаж назначения</param>
        /// <param name="PeopleCount">Количество людей</param>
        /// <returns>В случае ошибки - false, иначе true</returns>
        private bool CheckBeforeMovement(int DestinationFloor, int PeopleCount = 0)
        {
            /*if (_currentFloor == DestinationFloor)
            {
                Console.WriteLine("Лифт находится на вызванном этаже!");
                return false;
            }*/
            /*if (PeopleCount <= 0 && WithPeople)
            {
                Console.WriteLine("Людей не может быть меньше одного!");
                return false;
            }*/
            if (PeopleCount > _capacity)
            {
                Console.WriteLine("Перегрузка!");
                return false;
            }
            if (DestinationFloor < 0 || DestinationFloor > _countOfFloors)
            {
                Console.WriteLine("Лифт вызван на несуществующий эатж!");
                return false;
            }


            return true;
        }




    }
}
