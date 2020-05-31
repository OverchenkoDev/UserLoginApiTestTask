using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserLoginApi.Models;

namespace UserLoginApi.Classes
{
    public class UsersOperations
    {
        private UsersTestDBContext _db;

        public UsersOperations(UsersTestDBContext context)
        {
            _db = context;
        }

        public HttpStatusCode? LoginUser(string username, string password)
        {
            try
            {
                Users user = _db.Users.Where(x => x.Username == username).FirstOrDefault();
                if (user == null)
                    return HttpStatusCode.NotFound;
                return user.Password == password ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GetUserDataResult GetUserData(string username)
        {
            try
            {
                Users user = _db.Users.Where(x => x.Username == username).FirstOrDefault();
                if (user == null)
                    return new GetUserDataResult(null, "not found");
                if (user.Activated)
                {
                    UserNotes userData = _db.UserNotes.Where(x => x.Id == user.UserData).FirstOrDefault();
                    return new GetUserDataResult(userData, "ok");
                }
                else
                    return new GetUserDataResult(null, "not active");
            }
            catch (Exception)
            {
                return new GetUserDataResult(null, "error");
            }
        }

        public UserNotes GetUserDataError(string username)
        {
            Users user = _db.Users.Where(x => x.Username == username).FirstOrDefault();
            if (user.Activated)
            {
                UserNotes userData = _db.UserNotes.Where(x => x.Id == user.UserData).FirstOrDefault();
                return userData;
            }
            else
                return null;
        }

        public IActionResult UpdateUserData(UserNotes data)
        {
            Users user = _db.Users.Where(x => x.UserData == data.Id).FirstOrDefault();
            try
            {
                if (user.Activated)
                {
                    _db.UserNotes.Update(data);
                    _db.SaveChanges();
                    return new OkResult();
                }
                else
                    return new UnprocessableEntityResult();
            }
            catch (NullReferenceException)
            {
                return new NotFoundResult();
            }
        }
    }
}
