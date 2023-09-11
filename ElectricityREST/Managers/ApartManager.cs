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
            IEnumerable<ApartUsage> apartList = from ApartUsage in _context.ApartUsages
                                                select ApartUsage;
            return apartList;


        }
        public IEnumerable<ApartUsage> GetApartCurrentMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddDays(-1);

            IEnumerable<ApartUsage> apartList = from ApartUsage in _context.ApartUsages
                                                where FirstDayOfMonth < ApartUsage.FromTime && ApartUsage.FromTime < LastDayOfMonth
                                                select ApartUsage;

            return apartList;
        }
    }
}
