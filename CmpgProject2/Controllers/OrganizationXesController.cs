using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmpgProject2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CmpgProject2.Controllers
{
    [Authorize]
    public class OrganizationXesController : Controller
    {
        private readonly CmpgProject2Context _context;
        private readonly UserManager<IdentityUser> _userManger;

        public OrganizationXesController(CmpgProject2Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        // GET: OrganizationXes
        public async Task<IActionResult> Index()
        {
            ViewBag.User = _userManger.GetUserId(User);
            return View(await _context.OrganizationX.ToListAsync());
        }

        // GET: OrganizationXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationX = await _context.OrganizationX
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationX == null)
            {
                return NotFound();
            }

            return View(organizationX);
        }

        // GET: OrganizationXes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizationXes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerId,EmployeeNumber,age,attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] OrganizationX organizationX)
        {
            var usrId = _userManger.GetUserId(User);
            organizationX.OwnerId = usrId;
            if (ModelState.IsValid)
            {
                _context.Add(organizationX);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationX);
        }

        // GET: OrganizationXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationX = await _context.OrganizationX.FindAsync(id);
            if (organizationX == null)
            {
                return NotFound();
            }
            return View(organizationX);
        }

        // POST: OrganizationXes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerId,EmployeeNumber,age,attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] OrganizationX organizationX)
        {
            if (id != organizationX.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationX);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationXExists(organizationX.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(organizationX);
        }

        [Authorize(Roles = "Admin")]
        // GET: OrganizationXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationX = await _context.OrganizationX
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationX == null)
            {
                return NotFound();
            }

            return View(organizationX);
        }

        [Authorize(Roles = "Admin")]
        // POST: OrganizationXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationX = await _context.OrganizationX.FindAsync(id);
            _context.OrganizationX.Remove(organizationX);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationXExists(int id)
        {
            return _context.OrganizationX.Any(e => e.Id == id);
        }
    }
}
