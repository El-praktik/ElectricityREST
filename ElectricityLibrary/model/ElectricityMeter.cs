using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class ElectricityMeter
    {
        public DateTime Date { get; set; }
        public int ApartmentNumber { get; set; }
        public int ElectricityMeterId { get; set; }
        public double ElectricityExpenditure { get; set; }
        

        public ElectricityMeter()
        {

        }

        public ElectricityMeter(DateTime date, int apartmentNumber, int electricityMeterId, double electricityExpenditure)
        {
            Date = date;
            ApartmentNumber = apartmentNumber;
            ElectricityMeterId = electricityMeterId;
            ElectricityExpenditure = electricityExpenditure;
        }

        public double CalculateElectricityExpenditure()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Date: {Date}, ApartmentNumber: {ApartmentNumber}, ElectricityMeterId: {ElectricityMeterId}, ElectricityExpenditure: {ElectricityExpenditure}";
        }
    }
}
