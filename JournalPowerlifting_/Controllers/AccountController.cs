using Microsoft.AspNetCore.Mvc;
using JournalPowerlifting_.Model;
using JournalPowerlifting_.Database;
using Microsoft.EntityFrameworkCore;
using JournalPowerlifting_.Model.OperationModels;

namespace JournalPowerlifting_.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private DatabaseContext _dbContext;

        public AccountController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAccounts")]
        public IActionResult Get()
        {
            try
            {
                var accounts = _dbContext.Account.ToList();
                if(accounts.Count == 0)
                {
                    return StatusCode(400, "No account found");
                }
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel loginRequest)
        {
            try
            { 
                var account = _dbContext.Account.FirstOrDefault(x => x.Login == loginRequest.Login && x.Password == loginRequest.Password);
                if(account == null)
                {
                    return StatusCode(400, "Account with authorization data doesn't exist");
                }
                return Ok(account);


            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        [HttpPost("CreateAccount")]
        public IActionResult Create([FromBody] AccountModel modelRequest)
        {
            var account = new AccountDB();
            account.Login = modelRequest.Login;
            account.Password = modelRequest.Password;
            account.Name = modelRequest.Name;
            account.Surname = modelRequest.Surname;
            account.Status = modelRequest.Status;
            
            try
            {
                _dbContext.Account.Add(account);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var accounts = _dbContext.Account.ToList();
            return Ok(accounts);

        }

        [HttpPut("UpdateAccount")]
        public IActionResult Update([FromBody] AccountModel modelRequest)
        {
            try
            {
                var account = _dbContext.Account.FirstOrDefault(x => x.Id == modelRequest.Id);
                if(account == null)
                {
                    return StatusCode(400, "Account not found");
                }

                account.Login = modelRequest.Login;
                account.Password = modelRequest.Password;
                account.Name = modelRequest.Name;
                account.Surname = modelRequest.Surname;
                account.Status = modelRequest.Status;

                _dbContext.Entry(account).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var accounts = _dbContext.Account.ToList();
            return Ok(accounts);
        }
        
        [HttpDelete("DeleteAccount/{Id}")]
        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {
                var account = _dbContext.Account.FirstOrDefault(x => x.Id == Id);
                if (account == null)
                {
                    return StatusCode(400, "Account not found");
                }

                _dbContext.Entry(account).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            var accounts = _dbContext.Account.ToList();
            return Ok(accounts);
        }



    }
}
