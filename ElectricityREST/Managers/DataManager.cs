using ElectricityLibrary.model;
using ElectricityREST.Services;
using System.Data.SqlClient;
using System.Net;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {




        public DbService<Measure> measureService { get; set; }


        public DataManager(DbService<Measure> measures)
        {
            measures = measureService;
        }

        public List<Measure> GetAllMeasures()
        {
            return measureService.GetAllAsync().Result.ToList();

        }

        public Measure GetMeasureById(int measureId)
        {
            throw new NotImplementedException();
        }

        public List<ApartUsage> GetApartmentsInBlock(int blockId)
        {
            throw new NotImplementedException();
        }
        
        public BlockUsage GetBlockUsageById(int blockId)
        {
            throw new NotImplementedException();
        }

        public CommunityUsage GetCommunityUsageById(int communityId)
        {
            throw new NotImplementedException();
        }
    }
}
