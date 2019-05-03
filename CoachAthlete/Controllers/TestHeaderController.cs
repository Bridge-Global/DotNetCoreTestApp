using CoachAthlete.Data;
using CoachAthlete.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CoachAthlete.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Remotion.Linq.Clauses;

namespace CoachAthlete.Controllers
{
    [Authorize]
    public class TestHeaderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TestHeaderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TestHeader
        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            return View(await _context.TestHeaders
                .Select(x => new TestHeaderEntity()
                {
                    TestHeaderId = x.TestHeaderId,
                    TestDate = x.TestDate,
                    TestType = x.TestType,
                    NoOfParticipants = _context.TestDetails.Count(y => y.TestHeaderId == x.TestHeaderId).ToString()
                })
                .ToListAsync());
        }

        // GET: TestHeader/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testHeader = await _context.TestHeaders
                .FirstOrDefaultAsync(m => m.TestHeaderId == id);
            if (testHeader == null)
            {
                return NotFound();
            }

            return View(testHeader);
        }


        [Authorize(Roles = "Coach")]
        // GET: TestHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestHeader/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Create([Bind("TestHeaderId,TestDate,TestType")] TestHeaderEntity testHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testHeader);
        }

        [Authorize(Roles = "Coach")]
        // GET: TestHeader/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                TempData["selectedHeaderId"] = id;
            }

            var testHeader = await _context.TestHeaders.FindAsync(id);
            if (testHeader == null)
            {
                return NotFound();
            }
            return View(testHeader);
        }

        // POST: TestHeader/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Coach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestHeaderId,TestDate,TestType")] TestHeaderEntity testHeader)
        {
            if (id != testHeader.TestHeaderId)
            {
                return NotFound();
            }
            else
            {
                TempData["selectedHeaderId"] = id;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestHeaderExists(testHeader.TestHeaderId))
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
            return View(testHeader);
        }

        [Authorize(Roles = "Coach")]
        // GET: TestHeader/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testHeader = await _context.TestHeaders
                .FirstOrDefaultAsync(m => m.TestHeaderId == id);
            if (testHeader == null)
            {
                return NotFound();
            }

            return View(testHeader);
        }

        // POST: TestHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testHeader = await _context.TestHeaders.FindAsync(id);
            _context.TestHeaders.Remove(testHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestHeaderExists(int id)
        {
            return _context.TestHeaders.Any(e => e.TestHeaderId == id);
        }
    }
}
