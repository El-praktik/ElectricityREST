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
    }
}
