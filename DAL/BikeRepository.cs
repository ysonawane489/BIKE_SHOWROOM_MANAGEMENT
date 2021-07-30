using BIKE_SHOWROOM_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.DAL
{
    public class BikeRepository
    {

        private BikeContext _dbcontext;
        public BikeRepository(BikeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Bike> GetBike()
        {
            return _dbcontext.Bikes.ToList();
        }

        public void CreateBike(Bike bike)
        {
            _dbcontext.Bikes.Add(bike);
            _dbcontext.SaveChanges();
        }
        public void EditBike(Bike bike)
        {
            try
            {
                _dbcontext.Bikes.Update(bike);
                _dbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {

            }
        }

        public void DeleteBike(int BikeId)
        {
            try
            {
                var selectBike = _dbcontext.Bikes.Where(i => i.BikeId == BikeId).FirstOrDefault();
                if (selectBike != null)
                {
                    _dbcontext.Bikes.Remove(selectBike);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {

            }

        }


        //for login
        public List<Login> GetUsers()
        {
            return _dbcontext.Users.ToList();
        }
        public void ValidateUser(Login login)
        {
            try
            {
                var validate = (from user in _dbcontext.Users
                                where user.UserName == login.UserName && user.Password == login.Password && user.UserId == login.UserId
                                select user).FirstOrDefault();
                if (validate == null)
                {
                    Console.WriteLine("Enter Valid Password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("LOGIN SUCCESSFULLY...!");
            }
        }

        //bike rep




       
    }
}
