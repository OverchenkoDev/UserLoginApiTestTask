using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLoginApi.Models;

namespace UserLoginApi.Classes
{
    public class GetUserDataResult
    {
        public UserNotes userData;
        public string status;

        public GetUserDataResult(UserNotes data, string status)
        {
            userData = data;
            this.status = status;
        }
    }
}
