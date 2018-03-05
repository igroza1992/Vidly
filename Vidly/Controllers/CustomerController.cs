using System;
using System.Collections.Generic;
using System.Linq;
using  System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _contex;

        public CustomerController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }

        public ActionResult New()
        {
            var membershippTypes = _contex.MembershipTypes.ToList();
            var viewModel = new NewCustomerVIewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershippTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerVIewModel
                {
                    Customer = customer,
                    MembershipTypes = _contex.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if(customer.Id==0)
            _contex.Customers.Add(customer);
            else
            {
                var customerInDb = _contex.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

            }


            _contex.SaveChanges();

            return RedirectToAction("Customers", "Customer");
        }
        // GET: Customer
        public ActionResult Customers()
        {
            var customers = _contex.Customers.Include(x=>x.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _contex.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();



            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerVIewModel
            {
                Customer = customer,
                MembershipTypes = _contex.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}