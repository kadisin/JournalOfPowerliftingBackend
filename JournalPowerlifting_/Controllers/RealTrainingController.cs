using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealTrainingController : Controller
    {
        private DatabaseContext _dbContext;

        public RealTrainingController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetRealTrainings")]
        public IActionResult Get()
        {
            try
            {
                var realTrainings = _dbContext.RealTraining.ToList();
                if (realTrainings.Count == 0)
                {
                    return StatusCode(400, "No real training found");
                }
                return Ok(realTrainings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateRealTraining")]
        public IActionResult Create([FromBody] RealTrainingModel modelRequest)
        {
            var realTraining = new RealTrainingDB();
            realTraining.IdPlanSet = modelRequest.IdPlanSet;
            realTraining.IdTraining = modelRequest.IdTraining;
            realTraining.RealSetNumber = modelRequest.RealSetNumber;
            realTraining.RealRepetitions = modelRequest.RealRepetitions;
            realTraining.RealWeight = modelRequest.RealWeight;

            try
            {
                _dbContext.RealTraining.Add(realTraining);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var realTrainings = _dbContext.RealTraining.ToList();
            return Ok(realTrainings);

        }

        [HttpPut("UpdateRealTraining")]
        public IActionResult Update([FromBody] RealTrainingModel modelRequest)
        {
            try
            {
                var realTraining = _dbContext.RealTraining.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (realTraining == null)
                {
                    return StatusCode(400, "Real training not found");
                }

                

                _dbContext.Entry(realTraining).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var realTrainings = _dbContext.RealTraining.ToList();
            return Ok(realTrainings);
        }

        [HttpDelete("DeleteRealTraining/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var realTraining = _dbContext.RealTraining.FirstOrDefault(x => x.Id == Id);
                if (realTraining == null)
                {
                    return StatusCode(400, "Real training not found");
                }

                _dbContext.Entry(realTraining).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var realTrainings = _dbContext.RealTraining.ToList();
            return Ok(realTrainings);
        }




    }
}
