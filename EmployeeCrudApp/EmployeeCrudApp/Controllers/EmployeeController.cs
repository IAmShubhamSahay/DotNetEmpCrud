using EmployeeCrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
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

    public async Task<IActionResult> Index()
    {
        var employees = await _context.Employees.ToListAsync();
        return View(employees);
    }

    public IActionResult Create()
    {
        ViewBag.States = new SelectList(GetStates());
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        employee.DateOfBirth = DateTime.SpecifyKind(employee.DateOfBirth, DateTimeKind.Utc);
        employee.DateOfJoining = DateTime.SpecifyKind(employee.DateOfJoining, DateTimeKind.Utc);
        if (ModelState.IsValid)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                ModelState.AddModelError("", "Error saving the employee. Please try again.");
            }
        }
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    public async Task<IActionResult> Edit(int id)
    {
        
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        employee.DateOfBirth = DateTime.SpecifyKind(employee.DateOfBirth, DateTimeKind.Utc);
        employee.DateOfJoining = DateTime.SpecifyKind(employee.DateOfJoining, DateTimeKind.Utc);
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.Id == employee.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.States = new SelectList(GetStates());
        return View(employee);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        try
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
           
            ModelState.AddModelError("", "Error deleting the employee. Please try again.");
            return View(employee);
        }

        return RedirectToAction(nameof(Index));
    }
}
