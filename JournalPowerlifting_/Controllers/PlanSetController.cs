using JournalPowerlifting_.Database;
using JournalPowerlifting_.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalPowerlifting_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanSetController : Controller
    {
        private DatabaseContext _dbContext;

        public PlanSetController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetPlanSets")]
        public IActionResult Get()
        {
            try
            {
                var planSets = _dbContext.PlanSet.ToList();
                if (planSets.Count == 0)
                {
                    return StatusCode(400, "No plan set found");
                }
                return Ok(planSets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreatePlanSet")]
        public IActionResult Create([FromBody] PlanSetModel modelRequest)
        {

            var planSet = new PlanSetDB();
            planSet.NumberOfSeries = modelRequest.NumberOfSeries;
            planSet.NumberOfRepetitions = modelRequest.NumberOfRepetitions;
            planSet.Weight = modelRequest.Weight;

            try
            {
                _dbContext.PlanSet.Add(planSet);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var planSets = _dbContext.PlanSet.ToList();
            return Ok(planSets);

        }

        [HttpPut("UpdatePlanSet")]
        public IActionResult Update([FromBody] PlanSetModel modelRequest)
        {
            try
            {
                var planSet = _dbContext.PlanSet.FirstOrDefault(x => x.Id == modelRequest.Id);
                if (planSet == null)
                {
                    return StatusCode(400, "Plan set not found");
                }

                planSet.NumberOfSeries = modelRequest.NumberOfSeries;
                planSet.NumberOfRepetitions = modelRequest.NumberOfRepetitions;
                planSet.Weight = modelRequest.Weight;

                _dbContext.Entry(planSet).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var planSets = _dbContext.PlanSet.ToList();
            return Ok(planSets);
        }

        [HttpDelete("DeletePlanSet/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                //var planSet = _dbContext.PlanSet.FirstOrDefault(x => x.Id == Id);
                //if (planSet == null)
                //{
                 //   return StatusCode(400, "Plan set not found");
                //}

                //_dbContext.Entry(planSet).State = EntityState.Deleted;
                //_dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var planSet = _dbContext.PlanSet.ToList();
            return Ok(planSet);
        }




    }
}
