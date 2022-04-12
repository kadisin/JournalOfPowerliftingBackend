using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : Controller
    {
        private DatabaseContext _dbContext;

        public TrainingDayController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetTrainingDays")]
        public IActionResult Get()
        {
            try
            {
                var trainingDays = _dbContext.TrainingDay.ToList();
                if (trainingDays.Count == 0)
                {
                    return StatusCode(400, "No training days found");
                }
                return Ok(trainingDays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateTrainingDay")]
        public IActionResult Create([FromBody] TrainingDayModel modelRequest)
        {
            var trainingDay = new TrainingDayDB();
            trainingDay.Name = modelRequest.Name;


            try
            {
                _dbContext.TrainingDay.Add(trainingDay);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingDays = _dbContext.TrainingDay.ToList();
            return Ok(trainingDays);

        }

        [HttpPut("UpdateTrainingDay")]
        public IActionResult Update([FromBody] TrainingDayModel modelRequest)
        {
            try
            {
                var trainningDay = _dbContext.TrainingDay.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (trainningDay == null)
                {
                    return StatusCode(400, "Training day not found");
                }

                trainningDay.Name = modelRequest.Name;

                _dbContext.Entry(trainningDay).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingDays = _dbContext.TrainingDay.ToList();
            return Ok(trainingDays);
        }

        [HttpDelete("DeleteTrainingDay/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var trainingDay = _dbContext.TrainingDay.FirstOrDefault(x => x.Id == Id);
                if (trainingDay == null)
                {
                    return StatusCode(400, "Account not found");
                }

                _dbContext.Entry(trainingDay).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingDays = _dbContext.TrainingDay.ToList();
            return Ok(trainingDays);
        }




    }
}
