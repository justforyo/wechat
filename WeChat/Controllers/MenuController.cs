using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.EF;

namespace WeChat.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            //CreateDb();
            AddData();
            List<Model.Person> model =  Query();
            return View(model);
        }


        private void CreateDb()
        {
            using (var context = new weContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        private void AddData()
        {
            using (var context = new weContext())
            {
                List<Model.Person> list = new List<Model.Person>()
                {
                    new Model.Person { Id = 1,  Name = "刘备", Age = 50 },
                    new Model.Person { Id = 2,  Name = "关羽", Age = 49 },
                    new Model.Person { Id = 3,  Name = "张飞", Age = 48 }
                };

                context.Persons.AddRange(list);
                context.SaveChanges();
            }
        }

        private List<Model.Person> Query()
        {
            using (var context = new weContext())
            {
                var persons = context.Persons.Where(o => o.Age > 48).OrderByDescending(o => o.Age).Select(o => o).ToList();
                return persons;
            }
        }





    }
}