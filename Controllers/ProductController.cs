using Mailo.Models;
using Microsoft.AspNetCore.Mvc;
using Mailo.Repo;
using Mailo.IRepo;

namespace Mailo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.products.GetAll());
        }


        public async Task<IActionResult> New()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Productss product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.products.Insert(product);
                TempData["Success"] = "product Has Been Added Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id != 0)
            {
                return View(await _unitOfWork.products.GetByID(id));
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productss product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.products.Update(product);
                TempData["Success"] = "Product Has Been Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id != 0)
            {
                return View(await _unitOfWork.products.GetByID(id));
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int id = 0)
        {
            if (id != 0)
            {
                var product = await _unitOfWork.products.GetByID(id);
                if (product != null)
                {
                    _unitOfWork.products.Delete(product);
                    TempData["Success"] = "product Has Been Deleted Successfully";
                    return RedirectToAction("Index");
                }
            }
            return NotFound();

        }
    }
}












