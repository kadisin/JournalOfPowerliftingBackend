using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlanController : Controller
    {

        private DatabaseContext _dbContext;

        public TrainingPlanController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetTrainingPlans")]
        public IActionResult Get()
        {
            try
            {
                var trainingPlans = _dbContext.TrainingPlan.ToList();
                if (trainingPlans.Count == 0)
                {
                    return StatusCode(400, "No training plans found");
                }
                return Ok(trainingPlans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateTrainingPlan")]
        public IActionResult Create([FromBody] TrainingPlanModel modelRequest)
        {

            var trainingPlan = new TrainingPlanDB();
            trainingPlan.IdCompetitor = modelRequest.IdCompetitor;
            trainingPlan.IdCoach = modelRequest.IdCoach;
            trainingPlan.IdTrainingDay = modelRequest.IdTrainingDay;
            trainingPlan.IdExercise = modelRequest.IdExercise;
            trainingPlan.IdPlanSet = modelRequest.IdPlanSet;
            trainingPlan.Comment = modelRequest.Comment;

            try
            {
                _dbContext.TrainingPlan.Add(trainingPlan);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingPlans = _dbContext.TrainingPlan.ToList();
            return Ok(trainingPlans);

        }

        [HttpPut("UpdateTrainingPlan")]
        public IActionResult Update([FromBody] TrainingPlanModel modelRequest)
        {
            try
            {
                var trainingPlan = _dbContext.TrainingPlan.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (trainingPlan == null)
                {
                    return StatusCode(400, "Training day not found");
                }

                trainingPlan.IdCompetitor = modelRequest.IdCompetitor;
                trainingPlan.IdCoach = modelRequest.IdCoach;
                trainingPlan.IdTrainingDay = modelRequest.IdTrainingDay;
                trainingPlan.IdExercise = modelRequest.IdExercise;
                trainingPlan.IdPlanSet = modelRequest.IdPlanSet;
                trainingPlan.Comment = modelRequest.Comment;

                _dbContext.Entry(trainingPlan).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingPlans = _dbContext.TrainingPlan.ToList();
            return Ok(trainingPlans);
        }

        [HttpDelete("DeleteTrainingPlan/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var trainingPlan = _dbContext.TrainingPlan.FirstOrDefault(x => x.Id == Id);
                if (trainingPlan == null)
                {
                    return StatusCode(400, "Account not found");
                }

                _dbContext.Entry(trainingPlan).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var trainingPlans = _dbContext.TrainingPlan.ToList();
            return Ok(trainingPlans);
        }



    }
}
