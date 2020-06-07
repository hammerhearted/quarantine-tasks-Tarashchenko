using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours
{
    public enum VehicleType
    {
        Plane,
        Train,
        Car,
        SeaTransport,
        RiverTransport
    }
    public class Tour
    {
        public string TourName;
        public readonly String Code;
        public string Places;
        public VehicleType Vehicle;
        public string Price;
        public TimeSpan Duration;
        public DateTime Start;
        public readonly DateTime Finish;
        public string Description;
        //{
        //    get
        //    {
        //        return ДатаНачала.Day - DateTime.Now.Day;
        //    }
        //}
        public Tour(string name, string code, string places, string duration)
        {
            TourName = name;
            Code = code;
            Places = places;
            Duration = TimeSpan.Parse(duration);
        }
        public override string ToString()

        {
            return $"{TourName} {Code} {Places} {Duration}";
        }
        public virtual void PrintInfo()

        {

            Console.WriteLine(this);
            var vehicle = "";

            switch (Vehicle)

            {
                case VehicleType.Plane:

                    vehicle = "Самолет";

                    break;

                case VehicleType.Train:

                    vehicle = "Поезд";

                    break;
                case VehicleType.Car:

                    vehicle = "Автомобиль";

                    break;
                case VehicleType.SeaTransport:

                    vehicle = "Морской транспорт";

                    break;
                case VehicleType.RiverTransport:

                    vehicle = "Речной транспорт";

                    break;
            }
            Console.WriteLine($"Цена {Price}. Способ передвижения: {vehicle}. Дата начала:{Start}. Дата окончания: {Finish}.");

        }
        public class OverseasTour : Tour
        {
            public string Country;
            public string VisaRequirement;
            public string VisaCost;

            public OverseasTour(string name, string code, string places, string duration) : base(name, code, places, duration)
            {
            }
        }
        public class HikingTour : Tour
        {
            public string DifficultyLevel;
            public string TypeOfHiking;

            public HikingTour(string name, string code, string places, VehicleType Vehicle, string duration) : base(name, code, places, duration)
            {

            }
        }
    }
}
