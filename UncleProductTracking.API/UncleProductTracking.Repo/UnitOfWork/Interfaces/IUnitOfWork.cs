using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UncleProductTracking.Repo.Interfaces;

namespace UncleProductTracking.Repo.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepo Device { get; }
        IDeviceTypeRepo DeviceType { get; }
        IUnitRepo Unit { get; }

        void Complete();

        Task CompleteAsync();
    }
}
