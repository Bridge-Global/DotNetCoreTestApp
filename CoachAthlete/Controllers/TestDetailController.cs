using System;
using CoachAthlete.Data;
using CoachAthlete.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoachAthlete.Controllers
{
    [Authorize]
    public class TestDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestDetail
        public async Task<IActionResult> Index(long? id)
        {
            if (id == null)
            {
                var testHeaderId = TempData["selectedHeaderId"];
                if(testHeaderId == null)
                    return NotFound();
                id = Convert.ToInt32(testHeaderId);
            }
            else
            {
                TempData["selectedHeaderId"] = id;
            }
    

            var applicationDbContext = _context.TestDetails.Include(t => t.TestHeader)
                                        .Where(x => x.TestHeaderId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TestDetail/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDtl = await _context.TestDetails
                .Include(t => t.TestHeader)
                .FirstOrDefaultAsync(m => m.SlNo == id);
            if (testDtl == null)
            {
                return NotFound();
            }

            return View(testDtl);
        }


        // GET: TestDetail/Create
        [Authorize(Roles = "Coach")]
        public IActionResult Create()
        {
            ViewData["TestHeaderId"] = new SelectList(_context.TestHeaders.Select(x => new { x.TestHeaderId, TestName = $"{x.TestType} - {x.TestDate.ToString("yyyy-MMM-dd")}" }), "TestHeaderId", "TestName");
            ViewData["userID"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: TestDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Create([Bind("SlNo,DistanceOrTime,TestHeaderId,Athlete")] TestDetail testDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestHeaderId"] = new SelectList(_context.TestHeaders.Select(x => new { x.TestHeaderId, TestName = $"{x.TestType} - {x.TestDate.ToString("yyyy-MMM-dd")}" }), "TestHeaderId", "TestName", testDetail.TestHeaderId);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "UserName", testDetail.Athlete);
            return View(testDetail);
        }

        // GET: TestDetail/Edit/5
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var testDtl = await _context.TestDetails.FindAsync(id);
            if (testDtl == null)
            {
                return NotFound();
            }
            ViewData["TestHeaderId"] = new SelectList(_context.TestHeaders.Select(x=>new {x.TestHeaderId, TestName = $"{x.TestType} - {x.TestDate.ToString("yyyy-MMM-dd")}"}), "TestHeaderId", "TestName", testDtl.TestHeaderId);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "UserName", testDtl.Athlete);
            return View(testDtl);
        }

        // POST: TestDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Edit(long id, [Bind("SlNo,DistanceOrTime,TestHeaderId,Athlete")] TestDetail testDetail)
        {
            if (id != testDetail.SlNo)
            {
                return NotFound();
            }
            else
            {
                TempData["selectedHeaderId"] = testDetail.TestHeaderId;
            }
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDtlExists(testDetail.SlNo))
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
            ViewData["TestHeaderId"] = new SelectList(_context.TestHeaders.Select(x => new { x.TestHeaderId, TestName = $"{x.TestType} - {x.TestDate.ToString("yyyy-MMM-dd")}" }), "TestHeaderId", "TestName", testDetail.TestHeaderId);
            ViewData["userID"] = new SelectList(_context.Users, "Id", "UserName", testDetail.Athlete);
            return View(testDetail);
        }

        // GET: TestDetail/Delete/5
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDtl = await _context.TestDetails
                .Include(t => t.TestHeader)
                .FirstOrDefaultAsync(m => m.SlNo == id);
            if (testDtl == null)
            {
                return NotFound();
            }

            return View(testDtl);
        }

        // POST: TestDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var testDtl = await _context.TestDetails.FindAsync(id);
            _context.TestDetails.Remove(testDtl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDtlExists(long id)
        {
            return _context.TestDetails.Any(e => e.SlNo == id);
        }

    }
}
