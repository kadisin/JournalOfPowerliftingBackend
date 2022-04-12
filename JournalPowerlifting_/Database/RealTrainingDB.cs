using System.ComponentModel.DataAnnotations;

namespace JournalPowerlifting_.Database
{
    public class RealTrainingDB
    {
        [Key]
        public int Id { get; set; }
        public int IdPlanSet { get; set; }
        public int IdTraining { get; set; }
        public int RealSetNumber { get; set; }
        public int RealRepetitions { get; set; }
        public int? RealWeight { get; set; }

    }
}
