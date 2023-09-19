using ElectricityLibrary.model;
using Microsoft.AspNetCore.Mvc;

namespace ElectricityREST.InterFaces
{
    public interface IDataManager
    {
        IEnumerable<Measure> GetAllCurrentMonth();
        IEnumerable<Measure> GetAllLastMonth();
        IEnumerable<Measure> GetAllMeasures();
        //Measure GetMeasureById(int measureId);
        //IEnumerable<BlockUsage> GetBlockUsageById(int blockId);
        IEnumerable<Measure> GetApartCurrentMonth(int id);
        IEnumerable<Measure> GetApartLastMonth(int id);
        IEnumerable<Measure> GetBlockCurrentMonth(int id);
        IEnumerable<Measure> GetBlockLastMonth(int id);
        double GetPrizeCurrentMonth(double id);
    }
}
