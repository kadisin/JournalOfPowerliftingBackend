using System.ComponentModel.DataAnnotations;

namespace JournalPowerlifting_.Database
{
    public class TrainingDayDB
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
