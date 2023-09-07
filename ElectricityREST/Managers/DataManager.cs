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

        public IEnumerable<BlockUsage> GetApartmentsInBlock(int blockId,int ApartID)
        {
            IEnumerable<BlockUsage> blocks = from blockUsage in _context.BlockUsages
                                             where(blockUsage.BlockId == blockId && blockUsage.ApartmentId == ApartID)
                                             select blockUsage;
            return blocks;
        }
        
        public IEnumerable<BlockUsage> GetBlockUsageById(int blockId)
        {
            IEnumerable<BlockUsage> blocks = from blockUsage in _context.BlockUsages
                                             where (blockUsage.BlockId == blockId)
                                             select blockUsage;
            return blocks;
                                 
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
