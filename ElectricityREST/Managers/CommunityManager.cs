using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public class CommunityManager
    {
        private ELDBContext _context;
        public CommunityManager(ELDBContext context)
        {
                _context = context;
        }
        public IEnumerable<CommunityUsage> GetAllCommunityUsages()
        {
            IEnumerable<CommunityUsage> communities = from CommunityUsage in _context.CommunityUsages
                                                      select CommunityUsage;
            return communities;
        }
        public IEnumerable<CommunityUsage> GetCommunityUsageById(int communityId)
        {
            IEnumerable<CommunityUsage> community = from communityUsage in _context.CommunityUsages
                                                    where (communityUsage.CommunityId == communityId)
                                                    select communityUsage;
            return community;
        }
    }
}
