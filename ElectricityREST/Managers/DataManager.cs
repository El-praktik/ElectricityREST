using ElectricityLibrary.model;
using ElectricityREST.InterFaces;

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
    }
}
