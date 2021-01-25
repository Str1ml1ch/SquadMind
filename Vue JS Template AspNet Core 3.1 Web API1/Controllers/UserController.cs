using Microsoft.AspNetCore.Mvc;
using System;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Repos;
using System.Text.Json;
using System.Collections.Generic;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.LogicFunction;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository articlesRepository;
        public UserController(UserRepository articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        [HttpPut]
        public ActionResult Put()
        {
            try
            {
                return Ok(articlesRepository.SaveArticle());
            }
            catch(InvalidCastException)
            {
                return BadRequest("Введены неверные данные!");
            }
        }

        [HttpPost("addnewuser")]
        public ActionResult AddNewUSer() // Add new empty user
        {
            try
            { 
            User newUser = new User
            {
                Name = "UserName",
                LastName = "UserLastName",
                Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/User_font_awesome.svg/1200px-User_font_awesome.svg.png",
                Skype = "UserSkype",
                Email = "UserEmail",
                Signature = "UserSignature",
                RoleIdenty = 1
                
            };

                return Ok(articlesRepository.AddNewUser(newUser));
             }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost("getdatabyid")]
        public ActionResult getDataById([FromBody]dynamic id) //Get User by id
        {
            try
            {
                return Ok(articlesRepository.GetArticleById((short)id.id));
            }
            catch(Exception)
            {
               return BadRequest("Такого пользователя не существует!");
            }
        }

        [HttpPost("searchuser")]
        public ActionResult searchUser([FromBody] dynamic searchData) // Search by the User main params
        {
            var queryResult = articlesRepository.SerarchUsers((string)searchData.data);
            return Ok(UserLogicFunction.SimpleUsers(queryResult));
        }

        [HttpGet("getsimpledatauser")]
        public ActionResult getSimpleDataUser() // get shortdata in our pagnitation
        {
            try
            {
                var quaryResulet = articlesRepository.GetArticles();
                return Ok(UserLogicFunction.SimpleUsers(quaryResulet));
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("changeuser")]
        public ActionResult changeUser([FromBody] User user)//Change our user params
        {
            try
            {
                var data = articlesRepository.ChangeUser(user);
                if (data == true)
                {
                    return Ok(this.show());
                }
                else
                {
                    return Ok(this.showFirstData());
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        

        [HttpPost("showenableuser")]
        public ActionResult show()
        {
            
            return Ok(UserLogicFunction.SimpleUsers(articlesRepository.GetEnabledUSer()));
        }//Sow Enable data by the click

        [HttpGet("showenableuser")]
        public ActionResult showFirstData() // Show mainPage Data
        {

            return Ok(UserLogicFunction.SimpleUsers(articlesRepository.GetDisableUser()));
        }

        [HttpPost("showdisableuser")]
        public ActionResult showDisable()
        {
            return Ok(UserLogicFunction.SimpleUsers(articlesRepository.GetDisableUser()));
        }//Sow Disable data by the click



    }
}
