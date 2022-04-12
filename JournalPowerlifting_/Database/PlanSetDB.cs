using System.ComponentModel.DataAnnotations;

namespace JournalPowerlifting_.Database
{
    public class PlanSetDB
    {
        [Key]
        public int Id { get; set; }

        public int NumberOfSeries { get; set; }
        public int? NumberOfRepetitions { get; set; }
        public int? Weight { get; set; }

    }
}
