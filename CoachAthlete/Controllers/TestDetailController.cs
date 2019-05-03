using System;
using CoachAthlete.Data;
using CoachAthlete.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CoachAthlete.Core.Enum;
using CoachAthlete.Data.Entities;
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


            var applicationDbContext = _context.TestDetails
                .Include(t => t.TestHeader)
                .Include(t => t.Athlete)
                .OrderByDescending(t => t.DistanceOrTime)
                .Where(x => x.TestHeaderId == id)
                .Select(x => new TestDetailEntity()
                {
                    TestHeaderId = x.TestHeaderId,
                    SlNo = x.SlNo,
                    TestHeader = x.TestHeader,
                    DistanceOrTime = x.DistanceOrTime,
                    Athlete = x.Athlete,
                    AthleteId = x.AthleteId,
                    FitnessRating = x.DistanceOrTime <= 1000 ? FitnessRating.BelowAverage : x.DistanceOrTime <= 2000 ? FitnessRating.Average : x.DistanceOrTime <= 3500 ? FitnessRating.Good : FitnessRating.VeryGood
                });

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
        public async Task<IActionResult> Create([Bind("SlNo,DistanceOrTime,TestHeaderId,AthleteId")] TestDetailEntity testDetail)
        {
            if (ModelState.IsValid)
            {
                TempData["selectedHeaderId"] = testDetail.TestHeaderId;
                _context.Add(testDetail);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index), "TestDetail", new {id = testDetail.TestHeaderId});
                //return RedirectToAction(nameof(Index), "TestDetailController ", new { id = testDetail.TestHeaderId });
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
            else
            {
                TempData["selectedHeaderId"] = testDtl.TestHeaderId;
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
        public async Task<IActionResult> Edit(long id, [Bind("SlNo,DistanceOrTime,TestHeaderId,AthleteId")] TestDetailEntity testDetail)
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
