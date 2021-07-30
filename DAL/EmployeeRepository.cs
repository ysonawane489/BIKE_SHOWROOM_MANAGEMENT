using BIKE_SHOWROOM_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.DAL
{
    public class EmployeeRepository
    {

        private BikeContext _dbcontext;
        public EmployeeRepository(BikeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Employee> GetEmployee()
        {
            return _dbcontext.Employees.ToList();
        }

        public void CreateEmployee(Employee emp)
        {
            _dbcontext.Employees.Add(emp);
            _dbcontext.SaveChanges();
        }
        public void EditEmployee(Employee emp)
        {
            try
            {
                _dbcontext.Employees.Update(emp);
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

        public void DeleteEmployee(int EmpId)
        {
            try
            {
                var selectEmployee = _dbcontext.Employees.Where(i => i.EmpId == EmpId).FirstOrDefault();
                if (selectEmployee != null)
                {
                    _dbcontext.Employees.Remove(selectEmployee);
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

    }
}
