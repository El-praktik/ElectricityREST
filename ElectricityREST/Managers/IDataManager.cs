using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public interface IDataManager
    {
        List<Measure> GetAllMeasures();
        Measure GetMeasureById(int measureId);
        List<ApartUsage> GetApartmentsInBlock(int blockId);
        BlockUsage GetBlockUsageById(int blockId);
        CommunityUsage GetCommunityUsageById(int communityId);
    }
}
