using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Interfaces;
using TestApp.Domain;
using TestApp.Domain.User;
using Microsoft.Extensions.Logging;
using TestApp.Domain.UserGroup;

namespace TestApp.Business
{
    //Logic layer : if there is any complex logics that can be implemented here
    public class UserLogicHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserLogicHandler> _logger;
        public UserLogicHandler(ILogger<UserLogicHandler> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;            
        }
        #region User Groups
       
        public List<User> UserSearch(object filters, Paging page, string sort,out int total)
        {
            try
            {
                var _res = _unitOfWork.Users.GetAll();
                //sort filter todo
                var _ret = _res.Skip((page.number - 1) * page.size).Take(page.size).ToList();
                total = _res.Count();

                return _ret.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:UserSearch", new { });
                throw;
            }           
        }

        public User UserSelect(int id)
        {
            try
            {
                var _res = _unitOfWork.Users.GetById(id);
                return _res as User;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:UserSelect", new { });
                throw;
            }
            
        }

        public User SaveUser(User jsonParam)
        {
            try
            {
                User json;
                if (jsonParam.Id==0)
                {
                    json = jsonParam;
                    if ((jsonParam.UserGroup?.UserGroupId ?? 0) > 0)
                    {
                        json.UserGroup = _unitOfWork.UserGroups.GetById(jsonParam.UserGroup.UserGroupId);
                    }
                    //json.CreatedAt = TimezoneUtility.GetCurrentTime();
                    // json.CreatedUser = RequestHandler.getUserId(Request);
                    _unitOfWork.Users.Add(json);
                }
                else
                {
                    json = _unitOfWork.Users.GetById(jsonParam.Id);
                    json.FirstName = jsonParam.FirstName;
                    json.LastName = jsonParam.LastName;
                    json.EmailAddress = jsonParam.EmailAddress;
                    if ((jsonParam.UserGroup?.UserGroupId ?? 0) > 0)
                    {
                        json.UserGroup = _unitOfWork.UserGroups.GetById(jsonParam.UserGroup.UserGroupId);
                    }
                       
                    //json.UpdatedAt = TimezoneUtility.GetCurrentTime();
                    // json.UpdatedUser = RequestHandler.getUserId(Request);

                    _unitOfWork.Users.Update(json);
                }
                _unitOfWork.Complete();
                return json;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:SaveUser", new { });
                throw;
            }

        }

        public bool DeleteUser(int Id)
        {
            try
            {
                //If there is any logic to validate before delete
                // that nee dto be done here
                var _user = _unitOfWork.Users.GetById(Id);
                if (_user != null)
                {
                    _unitOfWork.Users.Remove(_user);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteUser", new { });
                throw;
            }

        }
        #endregion
        #region User Groups
        public List<UserGroup> UserGroupSearch(object filters, Paging page, string sort, out int total)
        {
            try
            {
                var _res = _unitOfWork.UserGroups.GetAll();
                //sort filter todo
                var _ret = _res.Skip((page.number - 1) * page.size).Take(page.size).ToList();
                total = _res.Count();

                return _ret.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:UserGroupSearch", new { });
                throw;
            }
        }
        public UserGroup SaveUserGroup(UserGroup jsonParam)
        {
            try
            {
                UserGroup json;
                if (jsonParam.UserGroupId == 0)
                {
                    json = jsonParam;

                    //json.CreatedAt = TimezoneUtility.GetCurrentTime();
                    // json.CreatedUser = RequestHandler.getUserId(Request);
                    _unitOfWork.UserGroups.Add(json);
                }
                else
                {
                    json = _unitOfWork.UserGroups.GetById(jsonParam.UserGroupId);
                    json.GroupName = jsonParam.GroupName;
                   
                    //json.UpdatedAt = TimezoneUtility.GetCurrentTime();
                    // json.UpdatedUser = RequestHandler.getUserId(Request);

                    _unitOfWork.UserGroups.Update(json);
                }
                _unitOfWork.Complete();
                return json;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:SaveUserGroup", new { });
                throw;
            }

        }

        public bool DeleteUserGroup(int Id)
        {
            try
            {
                //If there is any logic to validate before delete
                // that nee dto be done here
                var _userGroup = _unitOfWork.UserGroups.GetById(Id);
                if (_userGroup != null)
                {
                    _unitOfWork.UserGroups.Remove(_userGroup);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteUserGroup", new { });
                throw;
            }

        }
        #endregion

        #region Access Rule
        public List<AccessRule> AccessRuleSearch(object filters, Paging page, string sort, out int total)
        {
            try
            {
                var _res = _unitOfWork.AccessRules.GetAll();
                //sort filter todo
                var _ret = _res.Skip((page.number - 1) * page.size).Take(page.size).ToList();
                total = _res.Count();

                return _ret.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:AccessRuleSearch", new { });
                throw;
            }
        }
        public AccessRule SaveAccessRule(AccessRule jsonParam)
        {
            try
            {
                AccessRule json;
                if (jsonParam.AccessRuleId == 0)
                {
                    json = jsonParam;

                    //json.CreatedAt = TimezoneUtility.GetCurrentTime();
                    // json.CreatedUser = RequestHandler.getUserId(Request);
                    _unitOfWork.AccessRules.Add(json);
                }
                else
                {
                    json = _unitOfWork.AccessRules.GetById(jsonParam.AccessRuleId);
                    json.AccessRuleName = jsonParam.AccessRuleName;                    

                    //json.UpdatedAt = TimezoneUtility.GetCurrentTime();
                    // json.UpdatedUser = RequestHandler.getUserId(Request);
                    _unitOfWork.AccessRules.Update(json);
                }
                _unitOfWork.Complete();
                return json;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:SaveUser", new { });
                throw;
            }

        }

        public bool DeleteAccessRule(int Id)
        {
            try
            {
                //If there is any logic to validate before delete
                // that nee dto be done here
                var _user = _unitOfWork.AccessRules.GetById(Id);
                if (_user != null)
                {
                    _unitOfWork.AccessRules.Remove(_user);
                    _unitOfWork.Complete();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User:DeleteAccessRule", new { });
                throw;
            }

        }
        #endregion
       
    }
}
