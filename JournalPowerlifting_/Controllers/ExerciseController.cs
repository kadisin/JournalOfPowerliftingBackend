using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {

        private DatabaseContext _dbContext;

        public ExerciseController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetExercises")]
        public IActionResult Get()
        {
            try
            {
                var exercises = _dbContext.Exercise.ToList();
                if (exercises.Count == 0)
                {
                    return StatusCode(400, "No exercise found");
                }
                return Ok(exercises);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateExercise")]
        public IActionResult Create([FromBody] ExerciseModel modelRequest)
        {
            var exercise = new ExerciseDB();
            exercise.Id = modelRequest.Id;
            exercise.Name = modelRequest.Name;

            try
            {
                _dbContext.Exercise.Add(exercise);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var exercises = _dbContext.Exercise.ToList();
            return Ok(exercises);

        }

        [HttpPut("UpdateExercise")]
        public IActionResult Update([FromBody] ExerciseModel modelRequest)
        {
            try
            {
                var exercise = _dbContext.Exercise.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (exercise == null)
                {
                    return StatusCode(400, "Exercise not found");
                }

                exercise.Name = modelRequest.Name;

                _dbContext.Entry(exercise).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var exercises = _dbContext.Exercise.ToList();
            return Ok(exercises);
        }

        [HttpDelete("DeleteExercise/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var exercise = _dbContext.Exercise.FirstOrDefault(x => x.Id == Id);
                if (exercise == null)
                {
                    return StatusCode(400, "Exercise not found");
                }

                _dbContext.Entry(exercise).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var exercises = _dbContext.Exercise.ToList();
            return Ok(exercises);
        }






    }
}
