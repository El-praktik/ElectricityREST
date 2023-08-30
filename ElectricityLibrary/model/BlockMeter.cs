using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class BlockMeter
    {
        public DateTime Date { get; set; }
        public string? BlockAplhabet { get; set; }
        public int BlockMeterId { get; set; }
        public double BlockElectricityExpenditure { get; set; }

        public BlockMeter()
        {
            
        }

        public BlockMeter(DateTime date, string blockAplhabet, int blockMeterId, double blockElectricityExpenditure)
        {
            Date = date;
            BlockAplhabet = blockAplhabet;
            BlockMeterId = blockMeterId;
            BlockElectricityExpenditure = blockElectricityExpenditure;
        }

        public double lockCalculateElectricityExpenditure()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Date: {Date}, BlockAplhabet: {BlockAplhabet}, BlockMeterId: {BlockMeterId}, BlockElectricityExpenditure: {BlockElectricityExpenditure}";
        }
    }
}
