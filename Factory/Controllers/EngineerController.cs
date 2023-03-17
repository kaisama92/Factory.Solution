using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;
    {
      public EngineerController(FactoryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View(_db.Engineers.ToArray());
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Engineer engineer)
      {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
        Engineer thisEngineer = _db.Engineers
                                    .Include(doctor => doctor.JoinEntities)
                                    .ThenInclude(join => join.Machine)
                                    .FirstOrDefault(doctor => doctor.DoctorId = id);
        return View(thisEngineer);
      }
    }
  }
}