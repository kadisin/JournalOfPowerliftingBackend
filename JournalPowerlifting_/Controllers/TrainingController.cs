using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : Controller
    {
        private DatabaseContext _dbContext;

        public TrainingController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetTrainings")]
        public IActionResult Get()
        {
            try
            {
                var trainings = _dbContext.Training.ToList();
                if (trainings.Count == 0)
                {
                    return StatusCode(400, "No training found");
                }
                return Ok(trainings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateTrainings")]
        public IActionResult Create([FromBody] TrainingModel modelRequest)
        {
            var training = new TrainingDB();
            training.TrainingData = modelRequest.TrainingData;
            training.IdTrainingPlan = modelRequest.IdTrainingPlan;

            try
            {
                _dbContext.Training.Add(training);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainings = _dbContext.Training.ToList();
            return Ok(trainings);

        }

        [HttpPut("UpdateTrainings")]
        public IActionResult Update([FromBody] TrainingModel modelRequest)
        {
            try
            {
                var training = _dbContext.Training.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (training == null)
                {
                    return StatusCode(400, "Training not found");
                }

                training.TrainingData = modelRequest.TrainingData;
                training.IdTrainingPlan = modelRequest.IdTrainingPlan;

                _dbContext.Entry(training).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainings = _dbContext.Training.ToList();
            return Ok(trainings);
        }

        [HttpDelete("DeleteTraining/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var training = _dbContext.Training.FirstOrDefault(x => x.Id == Id);
                if (training == null)
                {
                    return StatusCode(400, "Training not found");
                }

                _dbContext.Entry(training).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainings = _dbContext.Training.ToList();
            return Ok(trainings);
        }


    }
}
