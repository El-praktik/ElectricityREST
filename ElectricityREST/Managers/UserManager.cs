using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public class UserManager
    {
        private ELDBContext _context;
        public UserManager(ELDBContext context)
        {
            _context = context;                
        }

    }
}
