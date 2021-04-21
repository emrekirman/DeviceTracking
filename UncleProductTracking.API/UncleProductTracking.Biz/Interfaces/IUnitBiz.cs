using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Biz.Interfaces.Base;
using UncleProductTracking.Common.Helpers.Classes;
using UncleProductTracking.Entities.Models;

namespace UncleProductTracking.Biz.Interfaces
{
    public interface IUnitBiz : IBaseBiz<Unit>
    {
        List<OptionModel<int>> GetAllUnitsFromOpt();
    }
}
