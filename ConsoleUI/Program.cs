using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("En başta var edilen arabalara dair açıklama:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("\n\n-----------\n\n");
            Console.WriteLine("İlk arabaya dair açıklama:");
            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.Description);
            }

            Car carToAdd = new Car()
            {
                Id = 5,
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 140,
                ModelYear = 2010,
                Description = "Yalnızca bellekteyken araba listesine eklenecek olan en kral araba"
            };

            carManager.AddCar(carToAdd);

            Console.WriteLine("En başta var edilen arabalara dair açıklama:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Car carToUpdate = carToAdd;
            carToUpdate.ColorId = 55;
            carManager.UpdateCar(carToUpdate);
            Console.Write("\n\nSonradan eklenen arabanın colorId'si 55 olarak güncellendi:\t");
            Console.WriteLine(carToUpdate.ColorId);

            Car carToDelete = carToAdd;
            carManager.DeleteCar(carToDelete);
            Console.WriteLine("Sonradan eklenen araba silindi:\n\nDizide gözüküyor mu açıklaması?");

            var cars = carManager.GetAll();

            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadLine();
        }
    }
}
