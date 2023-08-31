using ElectricityLibrary.model;
using System.Data.SqlClient;
using System.Net;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {
        private const string connectionString = @"data source=JINDOOHEX;initial catalog=master;trusted_connection=true";

        private static List<Measure> _measures = new List<Measure>();

        public DataManager()
        {

        }

        public List<Measure> GetAllMeasures()
        {
            List<Measure> measureList = new List<Measure>();
            string sql = "select * from dbo.Measure";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Measure theMeasure = new Measure();
                    theMeasure.MeasureId = reader.GetInt32(0);
                    theMeasure.PowerUsed = reader.GetDouble(1);
                    theMeasure.PowerGenerated = reader.GetDouble(2);
                    theMeasure.CommunityId = reader.GetInt32(3);
                    theMeasure.ApartmentId = reader.GetInt32(4);
                    measureList.Add(theMeasure);
                }
            }
            return new List<Measure>(_measures);
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
