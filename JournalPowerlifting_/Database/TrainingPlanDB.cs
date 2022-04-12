using System.ComponentModel.DataAnnotations;

namespace JournalPowerlifting_.Database
{
    public class TrainingPlanDB
    {

        [Key]
        public int Id { get; set; }
        public int IdCompetitor { get; set; }
        public int IdCoach { get; set; }
        public int IdTrainingDay { get; set; }
        public int IdExercise { get; set; }
        public int IdPlanSet { get; set; }
        public string? Comment { get; set; }


    }
}
