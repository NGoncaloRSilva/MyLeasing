using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common;
using MyLeasing.Common.Data;
using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Data.Models;
using MyLeasing.Common.Helpers;

namespace MyLeasing.Web.Controllers
{
    public class LesseesController : Controller
    {
        
        private readonly ILesseeRepository _lesseerepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public LesseesController(ILesseeRepository lesseerepository, IUserHelper userHelper, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {

            _lesseerepository = lesseerepository;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
        }

        // GET: Lessees
        public IActionResult Index()
        {
            return View(_lesseerepository.GetAll().OrderBy(p => p.FirstName));
        }

        // GET: Lessees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessee = await _lesseerepository.GetByIdAsync(id.Value);
            if (lessee == null)
            {
                return NotFound();
            }
            
            return View(lessee);
        }

        // GET: Lessees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LesseeViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                Guid imageId = Guid.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {


                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "lessees");

                }


                var lessee = _converterHelper.toLessee(model, imageId, true);

                var user = new User
                {


                    PhoneNumber = model.FixedPhone.ToString(),
                    Document = model.Document.ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Adress,
                    Email = model.FirstName + model.LastName + "@gmail.com",
                    UserName = model.FirstName + model.LastName + "@gmail.com",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in Controller");
                }

                //TODO: Modificar para o que tiver logado
                lessee.User = user;
                await _lesseerepository.CreateAsync(lessee);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Lessees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessee = await _lesseerepository.GetByIdAsyncWithUser(id.Value);
            if (lessee == null)
            {
                return NotFound();
            }
            var model = _converterHelper.toLesseeViewModel(lessee);
            return View(model);
        }

        // POST: Lessees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LesseeViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Guid imageId = Guid.Empty;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {


                        imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "lessees");

                    }

                    var lessee1 = await _lesseerepository.GetByIdAsyncWithUser(id);
                    var lessee = _converterHelper.toLessee(model, imageId, false);



                    //TODO: Modificar para o que tiver logado
                    lessee.User = await _userHelper.GetUserbyEmailAsync(lessee1.User.ToString());
                    await _lesseerepository.UpdateAsync(lessee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _lesseerepository.ExistAsync(model.Id))
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
            return View(model);
        }

        // GET: Lessees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessee = await _lesseerepository.GetByIdAsyncWithUser(id.Value);
            if (lessee == null)
            {
                return NotFound();
            }

            return View(lessee);
        }

        // POST: Lessees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessee = await _lesseerepository.GetByIdAsyncWithUser(id);

            await _lesseerepository.DeleteAsync(lessee);

            var result = await _userHelper.DeleteUserAsync(lessee.User);

            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not delete the user in Controller");
            }



            return RedirectToAction(nameof(Index));
        }

        
    }
}
