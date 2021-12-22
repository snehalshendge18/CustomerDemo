using CustomerDemo.Migrations;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerDemo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
       

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()

        {
            //var objCustomerList = _db.CustomerClass.ToList();
            //return View();
            IEnumerable<CustomerFirstClass> objCustomerList =_db.CustomerClass;
            return View(objCustomerList);
        }
        //Get
        public IActionResult Create()
        {
            return View();  
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerFirstClass obj)
        {
            if (obj.Product
                == obj.CustmomerID.ToString())
            {
                ModelState.AddModelError("CustomError", "Can not Match");
            }
            if (ModelState.IsValid)
            {
                _db.CustomerClass.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Created Successfully";
                    return RedirectToAction("Index");
            }

            return View(obj);
        }

       
       //Get
     
       
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CustomerFromDb = _db.CustomerClass.Find(id);
            if (CustomerFromDb == null)
            {

                return NotFound();
            }
           
            return View(CustomerFromDb);
        } 
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerFirstClass obj)
        {
            if (obj.Product
                == obj.CustmomerID.ToString())
            {
                ModelState.AddModelError("CustomError", "Can not Match");
            }
            if (ModelState.IsValid)
            {
                _db.CustomerClass.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //Get


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CustomerFromDb = _db.CustomerClass.Find(id);
            if (CustomerFromDb == null)
            {

                return NotFound();
            }

            return View(CustomerFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CustomerFirstClass obj)
        {
            if (obj.Product
                == obj.CustmomerID.ToString())
            {
                ModelState.AddModelError("CustomError", "Can not Match");
            }
            if (ModelState.IsValid)
            {
                _db.CustomerClass.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
