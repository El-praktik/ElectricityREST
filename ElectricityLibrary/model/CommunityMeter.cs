using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class CommunityMeter
    {
        public DateTime Date { get; set; }
        public string? CommunityName { get; set; }
        public int CommunityMeterId { get; set; }
        public double CommunityElectricityExpenditure { get; set; }

        public CommunityMeter()
        {
            
        }

        public CommunityMeter(DateTime date, string communityName, int communityMeterId, double communityElectricalExpenditure)
        {
            Date = date;
            CommunityName = communityName;
            CommunityMeterId = communityMeterId;
            CommunityElectricityExpenditure = communityElectricalExpenditure;
        }
    }
}
