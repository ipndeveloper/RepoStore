using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SANNA.Cross.Helpers.Enums;
using SANNA.Services.Masters.DataContracts;
using SANNA.Services.Masters.Interfaces;

namespace StoreOnline.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        //private readonly IProductXmlService _productXmlService;
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product

        //[ValidateAntiForgeryToken]
        //public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string source)
        //{

        //    ViewBag.Locations = this.GetOptionSource;
        //    return View();
        //}
        //[ValidateAntiForgeryToken]
   
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string source)
        {
            PagedList.PagedList<SANNA.Services.Masters.DataContracts.ProductResponse> model = null;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            ViewBag.source = this.GetOptionSource;

            Enumerates.TypeSource TypeSourceValue;
            ViewBag.currentFilter = currentFilter;

            source = string.IsNullOrEmpty(source) ? "" : source;
            if (Enum.TryParse(source.ToString(), out TypeSourceValue))
            {

                ViewBag.SourceCode = source;

                model = _productService.ProductFilterPagination(new ProductRequest { Page = pageNumber, Size = pageSize, Name = searchString, Source = TypeSourceValue });
            }
            else
                model = this.DefaultProductsResponse;
            
     
            

            return View(model);
        }


        private List<SelectListItem> GetOptionSource
        {

            get
            {

                List<SelectListItem> Options = new List<SelectListItem>
                {
                     new SelectListItem { Text = "Seleccione", Value = "0" }
                };

                //var item =new SelectList(Enum.GetValues(typeof(Enumerates.TypeSource)), "Value", "Text");
                //Options.AddRange(new SelectList(Enum.GetValues(typeof(Enumerates.TypeSource))));
                foreach (var item in Enum.GetValues(typeof(Enumerates.TypeSource)))
                {
                    var id = (int)item;
                    Options.Add(new SelectListItem { Text = item.ToString(), Value = id.ToString() });
                }

                return Options;
            }

        }

        private int DefaultPageNumber
        {
            get { return 1; }
        }

        private int DefaultSizeNumber
        {
            get { return 10; }
        }
        private PagedList.PagedList<ProductResponse> DefaultProductsResponse
        {
            get { return new PagedList.PagedList<ProductResponse>(new List<SANNA.Services.Masters.DataContracts.ProductResponse>(), this.DefaultPageNumber, this.DefaultSizeNumber); }
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(string sourceType)
        {
            
            Enumerates.TypeSource TypeSourceValue;
            if (string.IsNullOrEmpty(sourceType))
            {
                return RedirectToAction("Index");
            }
              

            int id = Convert.ToInt32(sourceType);


            if (Enum.TryParse(sourceType.ToString(), out TypeSourceValue))
            {
                ViewBag.Source = sourceType;
                PopulateCategoryDropDownList(TypeSourceValue);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _productService.Register(entity);
                    if (response.Success)
                        return RedirectToAction("Index");
                    else
                    {
                        Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                        PopulateCategoryDropDownList(Source, entity.IdCategory);
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                else
                {
                    Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                    PopulateCategoryDropDownList(Source, entity.IdCategory);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(entity);
        }
        private void PopulateCategoryDropDownList(Enumerates.TypeSource source, object selectedCategory = null)
        {
            var all = _productService.ItemsCategory(source);
            ViewBag.IdCategory = new SelectList(all, "IdCategory", "Name", selectedCategory);


        }
        //[ValidateAntiForgeryToken]
       
        public ActionResult Edit(int? id, int? sourceType)
        {

            Product entity ;
            Enumerates.TypeSource TypeSourceValue;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
 
           
            if (Enum.TryParse(sourceType.ToString(), out TypeSourceValue))
            {
                entity = new Product();
                entity.Source = sourceType.Value;
                entity = _productService.GetProducById(new ProductRequest { IdProduct = id.Value, Source = TypeSourceValue });
                if (entity == null)
                {
                    return HttpNotFound();
                }
                 PopulateCategoryDropDownList(TypeSourceValue, entity.IdCategory);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _productService.Update(entity);
                    if (response.Success)
                        return RedirectToAction("Index");
                    else
                    {
                        Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                        PopulateCategoryDropDownList(Source, entity.IdCategory);
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                else
                {
                    Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                    PopulateCategoryDropDownList(Source, entity.IdCategory);
                }

            }
            catch (Exception ex)
            {
              
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(entity);
        }
      
        public ActionResult Delete(int? id, int? sourceType)
        {
            Product entity;
            Enumerates.TypeSource TypeSourceValue;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (Enum.TryParse(sourceType.ToString(), out TypeSourceValue))
            {
                entity = new Product();
                entity = _productService.GetProducById(new ProductRequest { IdProduct = id.Value, Source = TypeSourceValue });
                
                if (entity == null)
                {
                    return HttpNotFound();
                }
                PopulateCategoryDropDownList(TypeSourceValue, entity.IdCategory);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
           
            return View(entity);
        }
        [HttpPost]
        public ActionResult Delete(Product entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _productService.Update(entity);
                    if (response.Success)
                        return RedirectToAction("Index");
                    else
                    {
                        Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                        PopulateCategoryDropDownList(Source, entity.IdCategory);
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }
                else
                {
                    Enumerates.TypeSource Source = (Enumerates.TypeSource)entity.Source;
                    PopulateCategoryDropDownList(Source, entity.IdCategory);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(entity);
        }


        }
    }