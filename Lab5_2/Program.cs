using System;
using System.Collections.Generic;

namespace Lab5_2
{
    enum CarMake
    {
        Ford,
        Chevrolet,
        Crysler,
        Honda,
        Toyota
    }

    class Car
    {
        protected CarMake make;
        protected string model;
        protected int year;
        protected decimal price;

        public CarMake Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value;}
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public Car(CarMake _Make, string _Model, int _Year, decimal _Price)
        {
            Make = _Make;
            Model = _Model;
            Year = _Year;
            Price = _Price;
        }
    }

    class NewCar : Car
    {
        protected bool extendedWarranty;
        public bool ExtendedWarranty
        {
            get { return extendedWarranty; }
            set { extendedWarranty = value; }
        }
        public NewCar(CarMake _Make, string _Model, int _Year, decimal _Price, bool _ExtendedWarranty) : base (_Make, _Model, _Year, _Price)
        {
            ExtendedWarranty = _ExtendedWarranty;
        }
        public override string ToString()
        {
            if (extendedWarranty == true)
            {
                return $"This new car is a {make}, {model}. It costs {price} and has an extended warrenty.";
            }
            else
            {
                return $"This new car is a {make}, {model}. It costs {price} and does not have an extended warrenty.";
            }
        }
    }

    class UsedCar : Car
    {
        protected int numberOfOwners;
        protected int mileage;

        public int NumberOfOwners
        {
            get { return numberOfOwners; }
            set { numberOfOwners = value; }
        }
        public int Mileage
        {
            get { return mileage; }
            set { mileage = Mileage; }
        }
        public UsedCar(CarMake _Make, string _Model, int _Year, decimal _Price, int _NumberOfOwners, int _Mileage) : base(_Make, _Model, _Year, _Price)
        {
            numberOfOwners = _NumberOfOwners;
            mileage = _Mileage;
        }
        public override string ToString()
        {
            return $"This new car is a {make}, {model}. It costs {price}. It has had {numberOfOwners} owners and has {mileage} miles.";
        }
    }

    class Program
    {
        public static Car FindCar(string model, List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }
        public static void CarList(List<Car> _mylist)
        {
            foreach (Car car in _mylist)
            {
                Console.WriteLine(car);
            }
        }

        public static void Add(List<Car> mylist)
        {
            Console.Write("Is the car you are adding (N)ew or (U)sed?: ");
            string entry = Console.ReadLine().ToUpper();
            Console.Write("Make of car (Ford, Chevrolet, Crystler, Honda, or Toyota): ");
            string formatStr = Console.ReadLine();
            CarMake format = CarMake.Ford;
            switch (formatStr)
            {
                case "Ford":
                    format = CarMake.Ford;
                    break;
                case "Chevrolet":
                    format = CarMake.Chevrolet;
                    break;
                case "Crystler":
                    format = CarMake.Crysler;
                    break;
                case "Honda":
                    format = CarMake.Honda;
                    break;
                case "Toyota":
                    format = CarMake.Toyota;
                    break;
            }
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Year: ");
            int year = Int32.Parse(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            if (entry == "N")
            {
                bool extendedWarrenty = true;
                Console.Write("Extended warrenty? (y/n): ");
                string yn = Console.ReadLine().ToLower();
                if (yn == "y")
                {
                    extendedWarrenty = true;
                }
                else if (yn == "n")
                {
                    extendedWarrenty = false;
                }
                NewCar n1 = new NewCar(format, model, year, price, extendedWarrenty);
                mylist.Add(n1);
            }
            else if (entry == "U")
            {
                Console.Write("# of prevoius owners: ");
                int owners = Int32.Parse(Console.ReadLine());
                Console.Write("Mileage: ");
                int mileage = Int32.Parse(Console.ReadLine());
                UsedCar u1 = new UsedCar(format, model, year, price, owners, mileage);
                mylist.Add(u1);
            }
        }

        static void Main(string[] args)
        {
            List<Car> mylist = new List<Car>();
            Car c1 = new Car(CarMake.Ford, "F250", 1990, 10.00m);
            NewCar nc1 = new NewCar(CarMake.Ford, "F150", 2021, 40000.00m, true);
            mylist.Add(nc1);
            nc1 = new NewCar(CarMake.Honda, "Civic", 2020, 50000.00m, false);
            mylist.Add(nc1);
            UsedCar uc2 = new UsedCar(CarMake.Toyota, "Highlander", 2016, 3000.00m, 3, 120000);
            mylist.Add(uc2);
            uc2 = new UsedCar(CarMake.Crysler, "Voyager LX", 2015, 2000.00m, 4, 140000);
            mylist.Add(uc2);

            Console.WriteLine("Here is our current selection of new and used cars:");
            CarList(mylist);
            Console.WriteLine();
            while (true)
            {
                Console.Write("Would you like to (A)dd a car, (P)urchase a car or (Q)uit?: ");
                string input = Console.ReadLine().ToUpper();

                if (input == "A")
                {
                    Add(mylist);
                }
                else if ( input == "P")
                {
                    Console.Write("What is the model of car you want to buy?: ");
                    string purchModel = Console.ReadLine();
                    c1 = FindCar(purchModel, mylist);
                    mylist.Remove(c1);
                }
                else if (input == "Q")
                {
                    break;
                }
                Console.WriteLine("Here is the updated inventory.");
                CarList(mylist);
            }
            Console.WriteLine("Clever goodbye message!");
        }
    }
}
