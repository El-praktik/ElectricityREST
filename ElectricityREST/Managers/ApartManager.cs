using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public class ApartManager
    {
        private ELDBContext _context;
        public ApartManager(ELDBContext context)
        {
                _context = context;
        }
        public IEnumerable<ApartUsage> GetAllAparts()
        {
            IEnumerable<ApartUsage> apartList = from ApartUsage in _context.ApartUsage
                                                select ApartUsage;
            return apartList;


        }
        public IEnumerable<ApartUsage> GetApartCurrentMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddDays(-1);

            IEnumerable<ApartUsage> apartList = from ApartUsage in _context.ApartUsage
                                                where FirstDayOfMonth < ApartUsage.FromTime && ApartUsage.FromTime < LastDayOfMonth && ApartUsage.Apartment == id
                                                select ApartUsage;

            return apartList;
        }
        public IEnumerable<ApartUsage> GetApartLastMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddDays(-1);

            IEnumerable<ApartUsage> apartList = from ApartUsage in _context.ApartUsage
                                                where FirstDayOfMonth < ApartUsage.FromTime && ApartUsage.FromTime < LastDayOfMonth && ApartUsage.Apartment == id
                                                select ApartUsage;

            return apartList;
        }
    }
}
