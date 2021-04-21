using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Repo.Context;
using UncleProductTracking.Repo.Context.Base;
using UncleProductTracking.Repo.Interfaces;

namespace UncleProductTracking.Repo.Manager
{
    public class UnitRepoManager : BaseDbContext, IUnitRepo
    {
        public UnitRepoManager(AppDbContext db)
        {
            this._db = db;
        }

        public Unit Create(Unit model)
        {
            try
            {
                Unit unit = _db.Unit.Add(model).Entity;
                _db.SaveChanges();
                return unit;
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
                Unit unit = this.GetById(id);
                _db.Unit.Remove(unit);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Unit> GetAll()
        {
            try
            {
                return _db.Unit.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Unit GetById(int id)
        {
            try
            {
                return _db.Unit.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Unit Update(Unit model)
        {
            try
            {
                Unit unit = _db.Unit.Update(model).Entity;
                _db.SaveChanges();
                return unit;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
