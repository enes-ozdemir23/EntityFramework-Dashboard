using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName).ToList();
            return View(values);
        }

        public IActionResult CustomerListOrderByDescBalance()
        {
            var values=_context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }

        public IActionResult CustomerGetByCity(string city)
        {
            var exist=_context.Customers.Any(x=>x.CustomerCity==city);
            if(exist)
            {
                ViewBag.message = $"{city} şehrinde en az 1 tane müşteri var";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde müşteri yok";

            }
            return View();
        }



        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer Customer)
        {
            _context.Customers.Add(Customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var values = _context.Customers.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer Customer)
        {
            var values = _context.Customers.Update(Customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers
                .ToList()
                .GroupBy(c => c.CustomerCity)
                .ToList();
            return View(groupedCustomers);
        }

        public IActionResult CustomerByCityCount()
        {
            var query =
                from c in _context.Customers
                group c by c.CustomerCity into cityGroup
                select new CustomerCityGroup
                {
                    City = cityGroup.Key,
                    CustomerCount = cityGroup.Count()
                };
            var model=query.ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values=_context.Customers.Select(c => c.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParalelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result=customers
                .AsParallel()
                .Where(c=>c.CustomerCity.StartsWith("A",StringComparison.OrdinalIgnoreCase))
                .ToList();
            return View(result);


        }

        public IActionResult CustomerExceptCityIstanbul()
        {
            var allCustomers = _context.Customers.ToList();
            var cutomersListInIstanbul = _context.Customers
                .Where(x => x.CustomerCity == "İstanbul")
                .Select(c=>c.CustomerCity)
                .ToList();
            var result = allCustomers.ExceptBy(cutomersListInIstanbul,c=>c.CustomerCity).ToList();
            return View(result);

        }

        public IActionResult CustomerListWithDefaultifEmpty()
        {
            var customers = _context.Customers.Where(x => x.CustomerCity == "Ağrı").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName="kayıt yok",
                CustomerSurname="---",
                CustomerCity="Ankara"
            }).ToList();
            return View(customers);
        }
        public IActionResult CustomerIntersectByCity()
        {
            var cityValues1=_context.Customers.Where(x=>x.CustomerCity=="İstanbul").Select(y=>y.CustomerName+" "+y.CustomerSurname).ToList();
            var cityValues2=_context.Customers.Where(x=>x.CustomerCity=="Ankara").Select(y=>y.CustomerName+" "+y.CustomerSurname).ToList();
            var intersectvalues=cityValues1.Intersect(cityValues2).ToList();
            return View(intersectvalues);
            
        }

        public IActionResult CustomerCastExample()
        {
            var values=_context.Customers.ToList();
            ViewBag.v=values;
            return View();
        }

        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers
                .ToList()
                .Select((c, index) => new
                {
                    SiraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity
                })
                .ToList();
            return View(customers);
            
        }

    }
}

