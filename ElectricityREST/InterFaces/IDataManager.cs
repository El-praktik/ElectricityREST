using ElectricityLibrary.model;

namespace ElectricityREST.InterFaces
{
    public interface IDataManager
    {
        IEnumerable<Measure> GetAllMeasures();
        Measure GetMeasureById(int measureId);
        //IEnumerable<BlockUsage> GetBlockUsageById(int blockId);
        IEnumerable<CommunityUsage> GetCommunityUsageById(int communityId);
        IEnumerable<Measure> GetApartCurrentMonth(int id);
        IEnumerable<Measure> GetApartLastMonth(int id);
        IEnumerable<Measure> GetBlockCurrentMonth(int id);
    }
}
