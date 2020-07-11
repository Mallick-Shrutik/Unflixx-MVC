using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Unflixx.Models;
using Unflixx.ViewModels;

namespace Unflixx.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            //we can use return View(membershipTypes) directly but this approach will not help in editing option a customer later
            //so we use the approach for the ViewModels
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(), //this helps as MembershiptypeId is a hidden field and will show input required in browser as it is an empty string which needs to be converted to int
                MembershipTypes = membershipTypes
            };
            return View("New",viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //This is the method with the helper method in view to stop POST request from another servers or websites to avoid manipulation with the data
        public ActionResult Save(Customer customer) //Create(NewCustomerViewModel viewModel) can be used here as all form.data had Customer prefixed and this is called Model Binding
        {
            //Model state property is used to add validation to form like if the input by user is correct or not(This is Part 2 of validation)
            //See part 1 in Customer.cs
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            //upto this is the ModelState Property

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Below methods can be used for updating database but they are concern for security and will update all the fields but not only the required one
                //TryUpdateModel(customerInDb)
                //Mapper.Map(customer , customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
            //this is 2nd part of Application level Optimization - Data Caching
            //this will store data from database to cache but again use it if only necessary
            /*if(MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            */

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };


            return View("New",viewModel);
        }
       
    }
}