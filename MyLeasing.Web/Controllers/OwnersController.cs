using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Data;
using MyLeasing.Common.Helpers;
using MyLeasing.Web.Data.Ententies;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        
        private readonly IOwnerRepository _ownerrepository;
        private readonly IUserHelper _userHelper;

        public OwnersController(IOwnerRepository ownerrepository, IUserHelper userHelper)
        {
            
            _ownerrepository = ownerrepository;
            _userHelper = userHelper;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(_ownerrepository.GetAll().OrderBy(p => p.FirstName));
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerrepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                //TODO: Modificar para o que tiver logado
                owner.User = await _userHelper.GetUserbyEmailAsync("ngoncalorsilva@gmail.com");
                await _ownerrepository.CreateAsync(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerrepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Modificar para o que tiver logado
                    owner.User = await _userHelper.GetUserbyEmailAsync("ngoncalorsilva@gmail.com");
                    await _ownerrepository.UpdateAsync(owner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _ownerrepository.ExistAsync(owner.Id))
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
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerrepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _ownerrepository.GetByIdAsync(id);
            await _ownerrepository.DeleteAsync(owner);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
