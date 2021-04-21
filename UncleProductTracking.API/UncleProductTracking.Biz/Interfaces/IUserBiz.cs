using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces.Base;
using UncleProductTracking.Common.Enums.CheckManda;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.Biz.Interfaces
{
    public interface IUserBiz : IBaseBiz<User>
    {
        User GetUserByUsernameAndPassword(string username, string password);

        void CheckManda(User model, JobType jobType);
    }
}
