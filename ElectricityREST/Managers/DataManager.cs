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

        public Measure GetMeasureById(int measureId)
        {
            return _context.Measure.FirstOrDefault(measure => measure.MID == measureId);
        }

       
        
       

        public IEnumerable<CommunityUsage> GetCommunityUsageById(int communityId)
        {
            IEnumerable<CommunityUsage> community = from communityUsage in _context.CommunityUsages
                                                    where(communityUsage.CommunityId == communityId)
                                                    select communityUsage;
            return community;
        }
    }
}
