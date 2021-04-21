using System;
using System.Threading.Tasks;
using UncleProductTracking.Repo.Context;
using UncleProductTracking.Repo.Context.Base;
using UncleProductTracking.Repo.Interfaces;
using UncleProductTracking.Repo.UnitOfWork.Interfaces;

namespace UncleProductTracking.Repo.UnitOfWork.Manager
{
    public class UnitOfWork : BaseDbContext, IUnitOfWork
    {
        public IDeviceRepo Device { get; private set; }

        public IDeviceTypeRepo DeviceType { get; private set; }

        public IUnitRepo Unit { get; private set; }

        public UnitOfWork(AppDbContext db, IDeviceRepo device, IDeviceTypeRepo deviceType, IUnitRepo unit)
        {
            Device = device;
            DeviceType = deviceType;
            Unit = unit;
            _db = db;
        }



        public void Complete()
        {
            using (var tran = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.SaveChanges();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }
        public void Dispose()
        {
            _db.Dispose();
        }


        public async Task CompleteAsync()
        {
            using (var tran = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.SaveChangesAsync();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }
    }
}
