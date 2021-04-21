using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Context;
using UncleProductTracking.Repo.Context.Base;
using UncleProductTracking.Repo.Interfaces;

namespace UncleProductTracking.Repo.Manager
{
    public class DeviceRepoManager : BaseDbContext, IDeviceRepo
    {
        public DeviceRepoManager(AppDbContext db)
        {
            this._db = db;
        }

        public Device Create(Device model)
        {
            try
            {
                Device entity = _db.Device.Add(model).Entity;
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Device entity = this.GetById(id);
                _db.Device.Remove(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Device> GetAll()
        {
            try
            {
                return _db.Device
                    .Include(x => x.DeviceType)
                    .Include(x => x.Unit)
                    .OrderByDescending(x => x.Id)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Device GetById(int id)
        {
            try
            {
                return _db.Device
                    .Include(x => x.Unit)
                    .Include(x => x.DeviceType)
                    .First(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Device Update(Device model)
        {
            try
            {
                Device entity = _db.Device.Update(model).Entity;
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
