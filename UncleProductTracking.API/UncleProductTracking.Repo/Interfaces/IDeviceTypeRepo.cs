using System;
using System.Collections.Generic;
using System.Text;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Interfaces.Base;

namespace UncleProductTracking.Repo.Interfaces
{
    public interface IDeviceTypeRepo : IBaseRepo<DeviceType>
    {
        List<DeviceType> GetCreatedDateOrderDescList();
    }
}
