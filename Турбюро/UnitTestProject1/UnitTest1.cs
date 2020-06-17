using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TourClasses;
using System.IO;

namespace TourUnitTests

{

    [TestClass]

    public class PersonUnitTest

    {
        [TestMethod]
        public void ConstructorTestMethod()

        {
            var tour1 = CreateTestTour();

            Assert.AreEqual("Тур в Швецию", tour1.Name);
            Assert.AreEqual( 0001, tour1.Code);
            Assert.AreEqual("Стокгольм", tour1.Places);
            Assert.AreEqual(VehicleType.Plane, tour1.VehicleType);
            Assert.AreEqual(DateTime.Now.Month, tour1.Start);
            Assert.AreEqual(DateTime.Now.Month + 1, tour1.Finish);
            Assert.AreEqual(TimeSpan.FromDays(30), tour1.Duration);
        }

        [TestMethod]

        public void ToStringTestMethod()

        {
            var tour1 = CreateTestPerson();
            Assert.AreEqual("Тур в Швецию", tour1.ToString());
        }

        [TestMethod]

        public void PrintInfoTestMethod()

        {
            var tour1 = CreateTestPerson();
            var tour2 = new Tour ("Тур в Испанию", 0002, "Барселона+Мадрид", VehicleType.Train, DateTime.Now.Month, DateTime.Now.Month + 2, TimeSpan.FromDays(61));

            var consoleOut = new[]
            {
                "Тур в Швецию",
                $"Код: 0001, Места: Стокгольм, Транспорт: {VehicleType.Plane}, Начало: {DateTime.Now.Month}, Конец: {DateTime.Now.Month + 1}, Продолжительность: {TimeSpan.FromDays(30)}",
                "Тур в Испанию",
                $"Код: 0002, Места: Барселона+Мадрид, Транспорт: {VehicleType.Train}, Начало: {DateTime.Now.Month}, Конец: {DateTime.Now.Month + 2}, Продолжительность: {TimeSpan.FromDays(61)}",
            };

            TextWriter oldOut = Console.Out;
            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))

                {
                    Console.SetOut(writer);
                    tour1.PrintInfo();
                    tour2.PrintInfo();
                }
            }

            Console.SetOut(oldOut);
            var i = 0;

            foreach (var line in File.ReadLines("test.txt"))

                Assert.AreEqual(consoleOut[i++], line);

            File.Delete("test.txt");
        }
        private Tour CreateTestTour()
        {
            return new Tour("Тур в Швецию", 0001, VehicleType.Plane, DateTime.Now.Month, DateTime.Now.Month + 1, TimeSpan.FromDays(30));
        }       

        public class TourUnitTest

        {
            [TestMethod]
            public void ConstructorOverseasTourTestMethod()
            {

                var tour = GetTestOverseasTour();
                Assert.AreEqual("Швеция", tour.Country);
                Assert.AreEqual("Виза нужна", tour.VisaRequirement);
                Assert.AreEqual(3000, tour.VisaCost);

            }

            [TestMethod]

            public void PrintInfoOverseasTourTestMethod()

            {

                var tour = GetTestOverseasTour();

                var lines = new[]

                {
                "Тур в Швецию",
                 $"Код: 0001, Места: Стокгольм, Транспорт: {VehicleType.Plane}, Начало: {DateTime.Now.Month}, Конец: {DateTime.Now.Month + 1}, Продолжительность: {TimeSpan.FromDays(30)}",
                 $"Страна: Швеция, Необходимость визы: Виза нужна, Стоимомть визы: 3000"
                 };
                TextWriter oldOut = Console.Out;
                using (FileStream file = new FileStream("test.txt", FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(file))

                    {
                        Console.SetOut(writer);
                        tour.PrintInfo();
                    }
                }
                Console.SetOut(oldOut);
                using (FileStream file = new FileStream("test.txt", FileMode.Open))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        var i = 0;
                        while (!(reader as StreamReader).EndOfStream)
                            Assert.AreEqual(lines[i++], reader.ReadLine());
                        Assert.AreEqual(lines.Length, i); 
                    }
                }
                File.Delete("test.txt");
            }

            [TestMethod]
            public void ConstructorHikingTourTestMethod()
            {
                var tour = GetTestHikingTour();
                Assert.AreEqual("Средняя сложность", tour.DifficultyLevel);
                Assert.AreEqual("конный", tour.TypeOfHiking);
            }

            [TestMethod]

            public void PrintInfoHikingTourTestMethod()

            {
                var tour = GetTestHikingTour();

                var lines = new[]

                {
                "Тур в Испанию",
                $"Код: 0002, Места: Барселона+Мадрид, Транспорт: {VehicleType.Train}, Начало: {DateTime.Now.Month}, Конец: {DateTime.Now.Month + 2}, Продолжительность: {TimeSpan.FromDays(61)}",
                $"Уровень сложности: Средняя сложность, Вид: конный"
                 };
                TextWriter oldOut = Console.Out;
                using (FileStream file = new FileStream("test.txt", FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(file))

                    {
                        Console.SetOut(writer);
                        tour.PrintInfo();
                    }
                }
                Console.SetOut(oldOut);
                using (FileStream file = new FileStream("test.txt", FileMode.Open))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        var i = 0;
                        while (!(reader as StreamReader).EndOfStream)
                            Assert.AreEqual(lines[i++], reader.ReadLine());
                        Assert.AreEqual(lines.Length, i);
                    }
                }
                File.Delete("test.txt");
            }
            private OverseasTour GetTestOverseasTour()

            {
                var tour = new OverseasTour ("Тур в Швецию", 0001, VehicleType.Plane, DateTime.Now.Month, DateTime.Now.Month + 1, TimeSpan.FromDays(30)); ;

                tour.Country = "Швеция";
                tour.VisaRequirement = "Виза нужна";
                tour.VisaCost = "3000";

                return tour;
            }
            private HikingTour GetTestHikingTour()

            {
                var tour = new HikingTour ("Тур в Испанию", 0002, "Барселона+Мадрид", VehicleType.Train, DateTime.Now.Month, DateTime.Now.Month + 2, TimeSpan.FromDays(61));

                tour.DifficultyLevel = "Средняя сложность";
                tour.TypeOfHiking = "конный";
                
                return tour;
            }
        }
    }

}