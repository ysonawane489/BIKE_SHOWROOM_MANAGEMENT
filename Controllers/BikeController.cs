using BIKE_SHOWROOM_MANAGEMENT.DAL;
using BIKE_SHOWROOM_MANAGEMENT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static BIKE_SHOWROOM_MANAGEMENT.Bussness.CacheResourceFilter;
namespace BIKE_SHOWROOM_MANAGEMENT.Controllers
{
    public class BikeController : Controller
    {
        BikeRepository bikeRepo;
        EmployeeRepository empRepo;
        public BikeController(BikeContext _dbcontext)
        {
            bikeRepo = new BikeRepository(_dbcontext);
            empRepo = new EmployeeRepository(_dbcontext);

        }



        public IActionResult HomePage()
        {
            return View();
        }


        public IActionResult Index()
        {
            var test = bikeRepo.GetBike().ToList();
            var bklist = bikeRepo.GetBike().Select(e => new BikeViewModel
            {
               BikeId=e.BikeId,
               BikeName=e.BikeName,
               Company=e.Company,
               Milage=e.Milage,
               Price=e.Price
            }).ToList();
            return View(bklist);

        }


        [HttpGet]
        public IActionResult Create()
        {
            BikeViewModel bk = new BikeViewModel();
            return View(bk);
        }


        [HttpPost]
        public IActionResult Create(BikeViewModel bk)

        {
            if (ModelState.IsValid)
            {
                Bike bikeEntity = new Bike()
                {
                    BikeId = bk.BikeId,
                    BikeName = bk.BikeName,
                    Company = bk.Company,
                    Milage = bk.Milage,
                    Price = bk.Price
                };
                bikeRepo.CreateBike(bikeEntity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            BikeViewModel selecteBike = bikeRepo.GetBike().Where(i => i.BikeId == id).Select(e => new BikeViewModel
            {
               BikeId=e.BikeId,
               BikeName=e.BikeName,
               Company=e.Company,
               Milage=e.Milage,
               Price=e.Price
            }).FirstOrDefault();
            return View(selecteBike);
        }

        [HttpPost]
        public IActionResult Edit(BikeViewModel bk)
        {
            if (ModelState.IsValid)
            {
                Bike bikeEntity = new Bike()
                {
                    BikeId = bk.BikeId,
                    BikeName = bk.BikeName,
                    Company = bk.Company,
                    Milage = bk.Milage,
                    Price = bk.Price
                };
               bikeRepo.EditBike(bikeEntity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            BikeViewModel selecteBike = bikeRepo.GetBike().Where(i => i.BikeId == id).Select(e => new BikeViewModel
            {
                BikeId = e.BikeId,
                BikeName = e.BikeName,
                Company = e.Company,
                Milage = e.Milage,
                Price = e.Price
            }).FirstOrDefault();
            return View(selecteBike);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            BikeViewModel selecteBike = bikeRepo.GetBike().Where(i => i.BikeId == id).Select(e => new BikeViewModel
            {
                BikeId = e.BikeId,
                BikeName = e.BikeName,
                Company = e.Company,
                Milage = e.Milage,
                Price = e.Price
            }).FirstOrDefault();
            return View(selecteBike);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            bikeRepo.DeleteBike(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        // [ValidateModel]
        [CacheResource]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        // [ValidateModel]
        [CacheResource]
        public IActionResult LogIn(int userid, string username, string password)
        {
            LoginViewModel ValidUser = bikeRepo.GetUsers().Where(i => i.UserId == userid && i.UserName == username && i.Password == password).Select(e => new LoginViewModel
            {

                UserName = e.UserName,
                Password = e.Password
            }).FirstOrDefault();
            if (ValidUser == null)
            {
                ViewBag.errormessage = "Enter Valid UserID,  Username and Password";
                return RedirectToAction("LogIn");
            }
            return RedirectToAction("HomePage");
        }




        /// 
        /// emoeoeoe
        /// 



       

  



        public IActionResult EmployeeDetails()
            {
                var test = empRepo.GetEmployee().ToList();
                var emplist = empRepo.GetEmployee().Select(et => new EmployeeViewModel
                {
                    EmpId = et.EmpId,
                    EmpName = et.EmpName,
                    Age = et.Age,
                    AdharId = et.AdharId,
                    EmailId = et.EmailId,
                    Designation = et.Designation,
                    CTC = et.CTC,
                    JoiningDate = et.JoiningDate

                }).ToList();
                return View(emplist);
            }

            [HttpGet]
            public IActionResult CreateE()
            {
                EmployeeViewModel q = new EmployeeViewModel();
                return View(q);
            }


            [HttpPost]
            public IActionResult CreateE(EmployeeViewModel emp)

            {
                if (ModelState.IsValid)
                {
                    Employee empEntity = new Employee()
                    {
                        EmpId = emp.EmpId,
                        EmpName = emp.EmpName,
                        Age = emp.Age,
                        AdharId = emp.AdharId,
                        EmailId = emp.EmailId,
                        Designation = emp.Designation,
                        CTC = emp.CTC,
                        JoiningDate = emp.JoiningDate
                    };
                empRepo.CreateEmployee(empEntity);
                }
                return RedirectToAction("EmployeeDetails");
            }

            [HttpGet]
            public IActionResult EditE(int id)
            {
                EmployeeViewModel selecteEmp = empRepo.GetEmployee().Where(i => i.EmpId == id).Select(e => new EmployeeViewModel
                {

                    EmpId = e.EmpId,
                    EmpName = e.EmpName,
                    Age = e.Age,
                    AdharId = e.AdharId,
                    EmailId = e.EmailId,
                    Designation = e.Designation,
                    CTC = e.CTC,
                    JoiningDate = e.JoiningDate
                }).FirstOrDefault();
                return View(selecteEmp);
            }

            [HttpPost]
            public IActionResult EditE(EmployeeViewModel emp)
            {
                if (ModelState.IsValid)
                {
                    Employee empEntity = new Employee()
                    {

                        EmpId = emp.EmpId,
                        EmpName = emp.EmpName,
                        Age = emp.Age,
                        AdharId = emp.AdharId,
                        EmailId = emp.EmailId,
                        Designation = emp.Designation,
                        CTC = emp.CTC,
                        JoiningDate = emp.JoiningDate
                    };
                empRepo.EditEmployee(empEntity);
                }
                return RedirectToAction("EmployeeDetails");
            }

            [HttpGet]
            public IActionResult DetailsE(int id)
            {
                EmployeeViewModel selecteEmp = empRepo.GetEmployee().Where(i => i.EmpId == id).Select(e => new EmployeeViewModel
                {
                    EmpId = e.EmpId,
                    EmpName = e.EmpName,
                    Age = e.Age,
                    AdharId = e.AdharId,
                    EmailId = e.EmailId,
                    Designation = e.Designation,
                    CTC = e.CTC,
                    JoiningDate = e.JoiningDate
                }).FirstOrDefault();
                return View(selecteEmp);
            }


            //[HttpGet]
            //public IActionResult DeleteE(int ide)
            //{
            //    EmployeeViewModel selectEmp = empRepo.GetEmployee().Where(i => i.EmpId == ide).Select(e => new EmployeeViewModel
            //    {
            //        EmpId = e.EmpId,
            //        EmpName = e.EmpName,
            //        Age = e.Age,
            //        AdharId = e.AdharId,
            //        EmailId = e.EmailId,
            //        Designation = e.Designation,
            //        CTC = e.CTC,
            //        JoiningDate = e.JoiningDate
            //    }).FirstOrDefault();
            //    return View(selectEmp);
            //}
            //[HttpPost]
            //[ActionName("Delete")]
            //[ValidateAntiForgeryToken]

            //public IActionResult DeleteConfirmedE(int ide)
            //{
            //empRepo.DeleteEmployee(ide);
            //    return RedirectToAction("EmployeeDetails");
            //}

        }
    }
