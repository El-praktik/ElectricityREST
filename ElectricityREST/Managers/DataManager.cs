using ElectricityLibrary.model;
using ElectricityREST.InterFaces;

namespace ElectricityREST.Managers
{
    public class DataManager : IDataManager
    {
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
        }
        public IEnumerable<Measure> GetApartCurrentMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Measure.AID == id
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetApartLastMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Measure.AID == id
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetBlockCurrentMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<int?> Apartments = from ApartUsage in _context.ApartUsage
                                           where ApartUsage.BID == id
                                           select ApartUsage.AID;

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth <= Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Apartments.Contains<int?>(Measure.AID)
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetBlockLastMonth(int id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<int?> Apartments = from ApartUsage in _context.ApartUsage
                                           where ApartUsage.BID == id
                                           select ApartUsage.AID;

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth <= Measure.FromTime && Measure.FromTime <= LastDayOfMonth && Apartments.Contains<int?>(Measure.AID)
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetAllCurrentMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            return measures;
        }
        public IEnumerable<Measure> GetAllLastMonth()
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
            FirstDayOfMonth = FirstDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddMonths(2);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            return measures;
        }
        public double GetPrizeCurrentMonth(double id)
        {
            DateTime Today = DateTime.Now;
            DateTime FirstDayOfMonth = new DateTime(Today.Year, Today.Month, 1, 0, 0, 0);
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, 1, 0, 0, 0);
            LastDayOfMonth = LastDayOfMonth.AddMonths(1);
            LastDayOfMonth = LastDayOfMonth.AddHours(-1);

            IEnumerable<Measure> measures = from Measure in _context.Measure
                                            where FirstDayOfMonth < Measure.FromTime && Measure.FromTime <= LastDayOfMonth
                                            select Measure;

            IEnumerable<Solar> solars = from Solar in _context.Solar
                                        where FirstDayOfMonth < Solar.FromTime && Solar.FromTime <= LastDayOfMonth
                                        select Solar;
            Console.WriteLine(measures.Count<Measure>());
            List<Measure> tempMeasures = new List<Measure>();

            DateTime time = FirstDayOfMonth.AddHours(1);
            Console.WriteLine(time);
            double payment = 0;
            bool last = false;
            Measure temp1 = measures.Last<Measure>();
            while (true)
            {
                foreach (Measure measure in measures)
                {
                    if (measure == temp1)
                    {
                        last = true;
                    }
                    if (measure.FromTime == time) //ok
                    {
                        Console.WriteLine("HELLO");
                        tempMeasures.Add(measure);
                    }
                    else if (measure.FromTime >= time)
                    {
                        break;
                    }
                }
                double generated = 0;
                foreach (Solar solar in solars)
                {
                    if (solar.FromTime == time)
                    {
                        generated += solar.PowerGenerated;
                    }
                    else if (solar.FromTime >= time) { }
                    {
                        break;
                    }
                }
                double generatedPer = generated/tempMeasures.Count;
                Measure removal = new Measure();

                //see how much {id} needs to pay for said hour

                bool done = false;
                bool less = false;
                double lessUsed = 0;

                while (!done)
                {
                    Measure temp2 = tempMeasures.Last<Measure>();
                    foreach (Measure measure in tempMeasures)
                    {
                        if (measure.PowerUsed < generatedPer)
                        {
                            if (measure.AID == id || measure == temp2)
                            {
                                lessUsed = measure.PowerUsed;
                                less = true;
                                done = true;
                                break;
                            }
                            else
                            {
                                removal = measure;
                                break;
                            }
                        }
                    }
                    tempMeasures.Remove(removal);
                    generatedPer = generated / tempMeasures.Count;
                }
                if (less)
                {
                    payment += lessUsed;
                }
                else
                {
                    payment += generatedPer;

                }
                if (last)
                {
                    break;
                }
                time.AddHours(1);
            }
            return payment;
        }
    }
}
