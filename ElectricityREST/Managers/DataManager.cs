using ElectricityLibrary.model;
using System.Data.SqlClient;
using System.Net;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {
        // TODO: Add connectionstring to access the database
        private const string connectionString = "THE CONNECTION STRING";

        public DataManager()
        {

        }

        public List<ElectricityMeter> GetExpendituresPerApartment(int apartmentNumber)
        {
            List<ElectricityMeter> expenditures = new List<ElectricityMeter>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ElectricityExpenditure, ApartmentNumber FROM ElectricityMeters WHERE ApartmentId = @ApartmentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApartmentId", apartmentNumber);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ElectricityMeter theExpenditure = new ElectricityMeter
                        {
                            ElectricityExpenditure = reader.GetDouble(0),
                            ApartmentNumber = reader.GetInt32(1)
                        };

                        expenditures.Add(theExpenditure);
                    }

                    reader.Close();
                }
            }
            return expenditures;
        }

        public List<BlockMeter> GetExpenditurePerBlock(string blockAplhabet)
        {
            return new List<BlockMeter>();
        }

        public List<CommunityMeter> GetExpenditurePerCommunity(string communityName)
        {
            return new List<CommunityMeter>();
        }

        public ElectricityMeter? ElectricityMeter(int apartmentNumber)
        {
            return null;
        }

        public BlockMeter? BlockMeter(string blockAplhabet)
        {
            return null;
        }

        public CommunityMeter? CommunityMeter(string communityName)
        {
            return null;
        }
    }
}
