using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Data;
using MyLeasing.Common.Data.Ententies;
using MyLeasing.Common.Data.Models;
using MyLeasing.Common.Helpers;
using MyLeasing.Web.Data.Ententies;
using MyLeasing.Web.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MyLeasing.Web.Controllers
{
    
    public class OwnersController : Controller
    {
        
        private readonly IOwnerRepository _ownerrepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public OwnersController(IOwnerRepository ownerrepository, IUserHelper userHelper, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            
            _ownerrepository = ownerrepository;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {

                    
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "owners");

                }


                var owner = _converterHelper.toOwner(model, imageId, true);

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
                owner.User = user;
                await _ownerrepository.CreateAsync(owner);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        // GET: Owners/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerrepository.GetByIdAsyncWithUser(id.Value);
            if (owner == null)
            {
                return NotFound();
            }
            var model = _converterHelper.toOwnerViewModel(owner);
            return View(model);
        }

        

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OwnerViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    

                    Guid imageId = Guid.Empty;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {


                        imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "owners");

                    }

                    var owner1 = await _ownerrepository.GetByIdAsyncWithUser(id);
                    var owner = _converterHelper.toOwner(model, imageId, false);

                    //var user = await _userHelper.GetUserbyEmailAsync(owner.FirstName + owner.LastName + "@gmail.com");

                    //var user = new User
                    //{


                    //    PhoneNumber = model.FixedPhone.ToString(),
                    //    Document = model.Document.ToString(),
                    //    FirstName = model.FirstName,
                    //    LastName = model.LastName,
                    //    Address = model.Adress,
                    //    Email = model.FirstName + model.LastName + "@gmail.com",
                    //    UserName = model.FirstName + model.LastName + "@gmail.com",
                    //};

                    //var result = await _userHelper.UpdateUserAsync(user);

                    //if (result != IdentityResult.Success)
                    //{
                    //    throw new InvalidOperationException("Could not edit the user in Controller");
                    //}

                    //TODO: Modificar para o que tiver logado
                    owner.User = await _userHelper.GetUserbyEmailAsync(owner1.User.ToString());
                    await _ownerrepository.UpdateAsync(owner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _ownerrepository.ExistAsync(model.Id))
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

        // GET: Owners/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerrepository.GetByIdAsyncWithUser(id.Value);
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
            var owner = await _ownerrepository.GetByIdAsyncWithUser(id);

            //var user = await _userHelper.GetUserbyEmailAsync(owner.FirstName + owner.LastName + "@gmail.com");

            //var user = new User
            //{

            await _ownerrepository.DeleteAsync(owner);

            var result = await _userHelper.DeleteUserAsync(owner.User);

            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not delete the user in Controller");
            }

            
            
            return RedirectToAction(nameof(Index));
        }
        
    }
}
