using EmployeeCrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
public class EmployeeController : Controller 
{
    private readonly AppDbContext _context;
    public EmployeeController(AppDbContext context )
    {
        _context = context;
    }
    private List<string> GetStates()
    {
        return new List<string> {
            "Uttar Pradesh", "Maharashtra", "Delhi", "Haryana", "Punjab",
            "Karnataka", "Tamil Nadu", "Rajasthan", "Gujarat", "Bihar",
            "Madhya Pradesh", "West Bengal", "Kerala", "Odisha", "Assam"
        };
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    public IActionResult Create()
    {
        ViewBag.States = new SelectList(GetStates());
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}

