using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
//using ElectricityREST.Services;
using System.Data.SqlClient;
using System.Net;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {

        //private static List<Measure> _measures = new List<Measure>();
        //public DbService<Measure> measureService { get; set; }
        //public DbService<BlockUsage> blockService { get; set; }
        //public DbService<ApartUsage> apartService { get; set; }
        //public DbService<CommunityUsage> communityService { get; set; }
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
            return _context.Measure.FirstOrDefault(measure => measure.MID == measureId);
        }

        public IEnumerable<BlockUsage> GetApartmentsInBlock(int blockId,int ApartID)
        {
            IEnumerable<BlockUsage> blocks = from blockUsage in _context.BlockUsages
                                             where(blockUsage.BlockId == blockId && blockUsage.ApartmentId == ApartID)
                                             select blockUsage;
            return blocks;

            //List<BlockUsage> blocks = new List<BlockUsage>();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    SqlCommand comm = new SqlCommand($"Select BID, AID from BlockUsage where {blockId} = BID ORDER BY BID", conn);
            //    SqlDataReader reader = comm.ExecuteReader();
            //    while(reader.Read())
            //    {
                   
            //        int BID = Convert.ToInt32(reader["BID"]);

            //        int AID =Convert.ToInt32(reader["AID"]);
            //        blocks.Add(new BlockUsage() { BlockId = BID, ApartmentId = AID });

            //    }
            //}
            //    return blocks;
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
