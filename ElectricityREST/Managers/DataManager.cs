using ElectricityLibrary.model;
using ElectricityREST.Services;
using System.Data.SqlClient;
using System.Net;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {
        //private const string connectionString = @"data source=JINDOOHEX;initial catalog=master;trusted_connection=true";

        //private static List<Measure> _measures = new List<Measure>();
        public DbService<Measure> measureService { get; set; }
        public DbService<BlockUsage> blockService { get; set; }
        public DbService<ApartUsage> apartService { get; set; }
        public DbService<CommunityUsage> communityService { get; set; }

        public DataManager(DbService<Measure> measures, DbService<BlockUsage> blockService, DbService<ApartUsage> apartService, DbService<CommunityUsage> communityService)
        {
            measures = measureService;
            this.blockService = blockService;
            this.apartService = apartService;
            this.communityService = communityService;
        }

        public List<Measure> GetAllMeasures()
        {
            return measureService.GetAllAsync().Result.ToList();
            //List<Measure> measureList = new List<Measure>();
            //string sql = "select * from dbo.Measure";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(sql, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();                           -> This is all useless
            //    while (reader.Read())
            //    {
            //        Measure theMeasure = new Measure();
            //        theMeasure.MeasureId = reader.GetInt32(0);
            //        theMeasure.PowerUsed = reader.GetDouble(1);
            //        theMeasure.PowerGenerated = reader.GetDouble(2);
            //        theMeasure.CommunityId = reader.GetInt32(3);
            //        theMeasure.ApartmentId = reader.GetInt32(4);
            //        measureList.Add(theMeasure);
            //    }
            //}
            //return new List<Measure>(_measures);
        }

        public Measure GetMeasureById(int measureId)
        {
            return measureService.GetObjectByIdAsync(measureId).Result;
        }

        public List<ApartUsage> GetApartmentsInBlock(int blockId)
        {
            throw new NotImplementedException();
        }
        
        public BlockUsage GetBlockUsageById(int blockId)
        {
            return blockService.GetObjectByIdAsync(blockId).Result;
        }

        public CommunityUsage GetCommunityUsageById(int communityId)
        {
            return communityService.GetObjectByIdAsync(communityId).Result;
        }
    }
}
