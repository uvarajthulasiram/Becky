using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Becky.Data;
using Becky.Task.Interface;
using Microsoft.Owin.Security;

namespace Becky.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserTask _userTask;

        public UserController(IUserTask userTask)
        {
            _userTask = userTask;
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:2166", headers: "*", methods: "*")]
        public IEnumerable<User> Get() => _userTask.GetUsers();

        [HttpGet]
        [EnableCors(origins: "http://localhost:2166", headers: "*", methods: "*")]
        public User Get(int id) => _userTask.GetUser(id);
        
        [HttpPost]
        [EnableCors(origins: "http://localhost:2166", headers: "*", methods: "*")]
        public HttpResponseMessage PostUser(User user)
        {
            var response = new HttpResponseMessage();

            try
            {
                _userTask.AddUser(user);
                response.StatusCode = HttpStatusCode.Created;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
            }

            return response;
        }

        [HttpPost]
        [EnableCors(origins: "http://localhost:2166", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var response = new HttpResponseMessage();

            try
            {
                _userTask.RemoveUser(id);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
            }

            return response;
        }
    }
}
