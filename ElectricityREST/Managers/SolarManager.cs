using ElectricityLibrary.model;
using ElectricityREST.InterFaces;

namespace ElectricityREST.Managers
{
    public class SolarManager
    {
        private ELDBContext _context;

        public SolarManager(ELDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Solar> GetAllSolar()
        {
            IEnumerable<Solar> solars = from Solar in _context.Solar
                                        select Solar;

            return solars;
        }
        public IEnumerable<Solar> GetAllCurrentMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Solar> measures = from Solar in _context.Solar
                                            where FirstDayOfMonth < Solar.FromTime && Solar.FromTime <= LastDayOfMonth
                                            select Solar;

            return measures;
        }
        public IEnumerable<Solar> GetAllLastMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Solar> measures = from Solar in _context.Solar
                                            where FirstDayOfMonth < Solar.FromTime && Solar.FromTime <= LastDayOfMonth
                                            select Solar;

            return measures;
        }
    }
}
