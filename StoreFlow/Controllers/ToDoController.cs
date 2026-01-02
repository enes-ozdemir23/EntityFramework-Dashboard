using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class ToDoController : Controller
    {
        private readonly StoreContext _context;

        public ToDoController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateToDo()
        {
            var todos = new List<Todo>
            {
                new Todo{Description="Mail Gönder",Status=true,Priority="Birincil"},
                new Todo{Description="Rapor Hazırla",Status=true,Priority="İkincil"},
                new Todo{Description="Toplantıya Katıl",Status=false,Priority="Birincil"}
            };
            _context.Todos.AddRange(todos);
            _context.SaveChanges();
            return View();
        }

        //public IActionResult TodoAggregatePriority()
        //{
        //    var priorityFirstlyTodo=_context.Todos
        //        .Where(x=>x.Priority=="Birincil")
        //        .Select(y=>y.Description)
        //        .ToList();

        //    string result=priorityFirstlyTodo.Aggregate((acc,desc)=>acc+","+desc);
        //    ViewBag.results=result;
        //    return View();
        //}

        //Renkli Maddeler için kod

        public IActionResult TodoAggregatePriority()
        {
            var priorityFirstlyTodo = _context.Todos
                .Where(x => x.Priority == "Birincil")
                .Select(y => y.Description)
                .ToList();

            int colorIndex = 0;
            string[] colors = { "red", "blue", "green", "orange", "purple" };

            string result = priorityFirstlyTodo.Aggregate("", (acc, desc) =>
            {
                string color = colors[colorIndex % colors.Length];
                colorIndex++;

                return acc + $"<li style='color:black'><span style='color:{color}'>●</span> {desc}</li>";
            });

            ViewBag.results = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos
                .Where(x => !x.Status)
                .Select(y => y.Description)
                .ToList()
                .Prepend("Gün başında tüm görevleri kontrol etmeyi unutmayın")
                .ToList();
            return View(values);
        }

        public  IActionResult TodoChunk()
        {
            var values=_context.Todos
                .Where (x => !x.Status)
                .ToList ()
                .Chunk(2)
                .ToList();
            return View(values);
        }
        public IActionResult TodoConcat()
        {
            var values=_context.Todos
                .Where (x => x.Priority=="Birincil")
                .ToList ()
                .Concat(
                _context.Todos.Where(y=>y.Priority=="İkincil").ToList()
                )
                .ToList();
            return View(values);
        }
        public IActionResult TodoUnion()
        {
            var values=_context.Todos.Where(x=>x.Priority=="Birincil").ToList();
            var values2=_context.Todos.Where(x=>x.Priority=="İkincil").ToList();
            var result=values.UnionBy(values2,x=>x.Description).ToList();
            return View(result);

        }

    }
}
