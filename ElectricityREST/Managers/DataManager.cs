using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
using Microsoft.AspNetCore.Hosting.Server;
using System.Linq;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {
        private ELDBContext _context;

        public DataManager(ELDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Measure> GetAllMeasures()
        {
            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            select Measure;
            return measures;
        }
        public IEnumerable<Measure> GetApartCurrentMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Measure.AID == id
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetApartLastMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Measure.AID == id
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetBlockCurrentMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<int?> Apartments = from ApartUsage in _context.ApartUsage
                                           where ApartUsage.BID == id
                                           select ApartUsage.AID;

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth <= Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Apartments.Contains<int?>(Measure.AID)
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetBlockLastMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<int?> Apartments = from ApartUsage in _context.ApartUsage
                                           where ApartUsage.BID == id
                                           select ApartUsage.AID;

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth <= Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Apartments.Contains<int?>(Measure.AID)
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetAllCurrentMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetAllLastMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            return measures;
        }
        public double GetPrizeCurrentMonth(double id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1, 0, 0, 0);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1, 0, 0, 0);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            IEnumerable<Solar> solars = from Solar in _context.Solar
                                        where FirstDayOfMonth < Solar.FromTime && Solar.FromTime <= LastDayOfMonth
                                        select Solar;

            List<Measure> MeasureList = (List<Measure>)solars;
            List<Solar> SolarList = (List<Solar>)solars;

            double payment = 0;

            for (int i = 0; i < LastDayOfMonth.Day*24; i++)
            {
                Console.WriteLine(i);
                List<Measure> MeasureHour = new List<Measure>(MeasureList.FindAll(m => m.FromTime == FirstDayOfMonth));
                //List<Solar> SolarHour = new List<Solar>(SolarList.FindAll(s => s.FromTime == FirstDayOfMonth));
                double totalSolarForHour = SolarList.FindAll(s => s.FromTime == FirstDayOfMonth).Sum(item => item.PowerGenerated);
                double generatedPer = totalSolarForHour/MeasureHour.Count;

                Console.WriteLine(MeasureHour.Count);
                Console.WriteLine(generatedPer);

                while (true)
                {
                    if (MeasureHour.Any(mh => mh.PowerUsed < generatedPer && mh.AID != id))
                    {
                        MeasureHour = MeasureHour.Where(mh => mh.PowerUsed < generatedPer && mh.AID != id).ToList();
                        generatedPer = totalSolarForHour / MeasureHour.Count;

                        Console.WriteLine(MeasureHour.Count);
                    }
                    else
                    {
                        if (MeasureHour.Any(mh => mh.PowerUsed < generatedPer))
                        {
                            break;
                        }
                        else
                        {
                            payment += generatedPer;
                        }
                    }
                }
                FirstDayOfMonth = FirstDayOfMonth.AddHours(1);
            }
            Console.ReadKey();
            return payment;
        }
    }
}
