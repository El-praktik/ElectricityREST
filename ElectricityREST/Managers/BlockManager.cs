using ElectricityLibrary.model;

namespace ElectricityREST.Managers
{
    public class BlockManager
    {
        private ELDBContext _context;
        public BlockManager(ELDBContext context)
        {
                _context = context;
        }
        public IEnumerable<BlockUsage> GetAllBlocks()
        {
            IEnumerable<BlockUsage> blocks = from BlockUsage in _context.BlockUsages
                                             select BlockUsage;
            return blocks;
        }

        public BlockUsage GetBlockUsageById(int blockId)
        {
            return _context.BlockUsages.FirstOrDefault(block => block.BlockId == blockId);

        }

        public IEnumerable<BlockUsage> GetApartmentsInBlock(int blockId, int ApartID)
        {
            IEnumerable<BlockUsage> blocks = from blockUsage in _context.BlockUsages
                                             where (blockUsage.BlockId == blockId && blockUsage.ApartmentId == ApartID)
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
    }
}
