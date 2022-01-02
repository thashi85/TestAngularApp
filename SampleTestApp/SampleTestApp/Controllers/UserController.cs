using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleTestApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Business;
using TestApp.Domain;
using TestApp.Domain.Interfaces;
using TestApp.Domain.User;
using TestApp.Domain.UserGroup;

namespace SampleTestApp.Controllers
{
    [ApiController]
    [Route("api/v1.0/users")]// todo:versioning
    [WebAPIAuthorize]
    public class UserController : ControllerBase
    {

        private readonly ILogger<User> _logger;
        private readonly UserLogicHandler _userLogicHandler;
        public UserController(ILogger<User> logger, UserLogicHandler userLogicHandler)
        {
            _logger = logger;
            _userLogicHandler = userLogicHandler;
        }
        #region Users

        [HttpGet("")]
        public IActionResult GetUsers([FromQuery] object filters = null, [FromQuery] string sort = null, [FromQuery] Paging page = null)
        {
            var _retData = new APIResult<List<User>>();
            try
            {
                if (page == null)
                    page = new Paging();
                int total = 0;
                _retData.Data = _userLogicHandler.UserSearch(filters, page, sort, out total);
                _retData.TotalResultCount = total;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:GetUsers", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }

        [HttpGet("{Id}")]
        public IActionResult GetUser([FromRoute] string Id)
        {
            var _retData = new APIResult<User>();
            try
            {
                //Input Validtaion Todo
                _retData.Data = _userLogicHandler.UserSelect(Int32.Parse(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:GetUser", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] User jsonParam)
        {
            var _retData = new APIResult<User>();
            try
            {
                //Input Validtaion Todo
                //due to time limits for both create and update post method is used
                //ideally Patch should be used and only updated fields need to be passe dto the patch
                _retData.Data = _userLogicHandler.SaveUser(jsonParam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:PostUser", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        [HttpPatch]
        public IActionResult PatchUser([FromBody] User jsonParam)
        {
            var _retData = new APIResult<User>();
            try
            {
                //Input Validtaion Todo
                //Get user by ID
                //Merge input  user object with user object return from DB
                //this step will update DB user with values pass from json
                //update DB

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:PatchUser", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser([FromRoute] string Id)
        {
            var _retData = new APIResult<bool>();
            try
            {
                //Input Validtaion Todo
                _retData.Data = _userLogicHandler.DeleteUser(Int32.Parse(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteUser", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        #endregion
        #region User Groups
        [HttpGet("groups")]
        public IActionResult GetUserGroups([FromQuery] object filters = null, [FromQuery] string sort = null, [FromQuery] Paging page = null)
        {
            var _retData = new APIResult<List<UserGroup>>();
            try
            {
                if (page == null)
                    page = new Paging();
                int total = 0;
                _retData.Data = _userLogicHandler.UserGroupSearch(filters, page, sort, out total);
                _retData.TotalResultCount = total;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:GetUserGroups", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }

        [HttpPost("groups")]
        public IActionResult PostUserGroup([FromBody] UserGroup jsonParam)
        {
            var _retData = new APIResult<UserGroup>();
            try
            {
                //Input Validtaion Todo
               
                _retData.Data = _userLogicHandler.SaveUserGroup(jsonParam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:PostUserGroup", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        [HttpDelete("groups/{Id}")]
        public IActionResult DeleteUserGroup([FromRoute] string Id)
        {
            var _retData = new APIResult<bool>();
            try
            {
                //Input Validtaion Todo
                _retData.Data = _userLogicHandler.DeleteUserGroup(Int32.Parse(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteUserGroup", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        #endregion


        #region Access Rule
        [HttpGet("access-rules")]
        public IActionResult GetAccessRules([FromQuery] object filters = null, [FromQuery] string sort = null, [FromQuery] Paging page = null)
        {
            var _retData = new APIResult<List<AccessRule>>();
            try
            {
                if (page == null)
                    page = new Paging();
                int total = 0;
                _retData.Data = _userLogicHandler.AccessRuleSearch(filters, page, sort, out total);
                _retData.TotalResultCount = total;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:GetAccessRuless", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }

        [HttpPost("access-rules")]
        public IActionResult PostAccessRules([FromBody] AccessRule jsonParam)
        {
            var _retData = new APIResult<AccessRule>();
            try
            {
                //Input Validtaion Todo

                _retData.Data = _userLogicHandler.SaveAccessRule(jsonParam);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:PostAccessRule", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        [HttpDelete("access-rules/{Id}")]
        public IActionResult DeleteAccessRule([FromRoute] string Id)
        {
            var _retData = new APIResult<bool>();
            try
            {
                //Input Validtaion Todo
                _retData.Data = _userLogicHandler.DeleteAccessRule(Int32.Parse(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteAccessRule", new { });
                RequestHandler.ToInternalServerError(_retData);
            }

            return Ok(_retData);
        }
        #endregion
    }
}
