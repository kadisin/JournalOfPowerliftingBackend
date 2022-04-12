using System.ComponentModel.DataAnnotations;

namespace JournalPowerlifting_.Database
{
    public class TrainingDB
    {
        [Key]
        public int Id { get; set; }
        public DateTime TrainingData { get; set; }
        public int IdTrainingPlan { get; set; }

    }
}
