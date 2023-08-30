using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public interface IDataManager
    {
        List<ElectricityMeter> GetExpendituresPerApartment(int apartmentNumber);
        List<BlockMeter> GetExpenditurePerBlock(string blockAplhabet);
        List<CommunityMeter> GetExpenditurePerCommunity(string communityName);

        ElectricityMeter? ElectricityMeter(int apartmentNumber);
        BlockMeter? BlockMeter(string blockAplhabet);
        CommunityMeter? CommunityMeter(string communityName);
    }
}
