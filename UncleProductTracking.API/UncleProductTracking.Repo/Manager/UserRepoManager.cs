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
    public class UserRepoManager : BaseDbContext, IUserRepo
    {
        public UserRepoManager(AppDbContext db)
        {
            this._db = db;
        }

        public User Create(User model)
        {
            try
            {
                User user = _db.User.Add(model).Entity;
                _db.SaveChanges();
                return user;
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
                User user = this.GetById(id);
                _db.User.Remove(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _db.User.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _db.User.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            try
            {
                User user = _db.User.First(x => x.UserName == username && x.Password == password);
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Update(User model)
        {
            try
            {
                User user = _db.User.Update(model).Entity;
                _db.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
