using ClothWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        /*Brand Table CRUD BASIC*/
        #region CRUD Brand
        public ActionResult BrandList()
        {
            return View();
        }

        public JsonResult DisplayBrandList()
        {
            var DisplayedBrandLst = new List<Brand>();
            using (var i = new ClothesDBEntities())
            {
                DisplayedBrandLst = i.Brands.Where(x => x.Status >= 0).ToList();
            }
            return Json(DisplayedBrandLst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrandId(int? id)
        {
            var BrandTable = new Brand();
            using (var brandDB = new ClothesDBEntities())
            {
                BrandTable = brandDB.Brands.FirstOrDefault(x => x.Idbrand == id);
            }
            return Json(BrandTable, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddandEditBrandName(int? id, string brandname)
        {
            var BrandTable = new Brand();
            using (var brandDB = new ClothesDBEntities())
            {
                /*   Edit Event Method */
                if(id > 0)
                {
                    brandDB.Brands.FirstOrDefault(x => x.Idbrand == id).Namebrand = brandname;
                    brandDB.Brands.FirstOrDefault(x => x.Idbrand == id).Updateddate = DateTime.Now;
                    brandDB.SaveChanges();
                }
                /* Add Event Method */
                else
                {
                    BrandTable.Namebrand = brandname;
                    BrandTable.Updateddate = DateTime.Now;
                    BrandTable.Createddate = DateTime.Now;
                    BrandTable.Status = 0;
                    brandDB.Brands.Add(BrandTable);
                    brandDB.SaveChanges();

                }
            }

            return Json("ADDED AND SYNCHRONIZED SUCCESSFULLY!", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteBrandName(int ?id)
        {
            using (var brandDB = new ClothesDBEntities())
            {
                brandDB.Brands.FirstOrDefault(x => x.Idbrand == id).Status = -1;
                brandDB.SaveChanges();
            }
            return Json("REMOVE SUCCESSFULLY", JsonRequestBehavior.AllowGet);
        }
        #endregion

        /*Size Table CRUD BASIC*/
        #region CRUD Size
        public ActionResult SizeList()
        {
            return View();
        }

        public JsonResult DisplaySizeList()
        {
            var DisplayedSizeLst = new List<Size>();
            using (var i = new ClothesDBEntities())
            {
                DisplayedSizeLst = i.Sizes.Where(x => x.Status >= 0).ToList();
            }
            return Json(DisplayedSizeLst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSizeId(int? id)
        {
            var SizeTable = new Size();
            using (var sizeDB = new ClothesDBEntities())
            {
                SizeTable = sizeDB.Sizes.FirstOrDefault(x => x.IdSize == id);
            }
            return Json(SizeTable, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddandEditSizeName(int? id, string sizename)
        {
            var SizeTable = new Size();
            using (var sizeDB = new ClothesDBEntities())
            {
                /*   Edit Event Method */
                if (id > 0)
                {
                    sizeDB.Sizes.FirstOrDefault(x => x.IdSize == id).NameofSize = sizename;
                    sizeDB.Sizes.FirstOrDefault(x => x.IdSize == id).Updateddate = DateTime.Now;
                    sizeDB.SaveChanges();
                }

                /* Add Event Method */
                else
                {
                    SizeTable.NameofSize = sizename;
                    SizeTable.Updateddate = DateTime.Now;
                    SizeTable.Createddate = DateTime.Now;
                    SizeTable.Status = 0;
                    sizeDB.Sizes.Add(SizeTable);
                    sizeDB.SaveChanges();

                }
            }

            return Json("ADDED AND SYNCHRONIZED SUCCESSFULLY!", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSizeName(int? id)
        {
            using (var sizeDB = new ClothesDBEntities())
            {
                sizeDB.Sizes.FirstOrDefault(x => x.IdSize == id).Status = -1;
                sizeDB.SaveChanges();
            }
            return Json("REMOVE SUCCESSFULLY", JsonRequestBehavior.AllowGet);
        }




        #endregion

        /*Type Table CRUD BASIC*/
        #region CRUD Type
        public ActionResult TypeList()
        {
            return View();
        }

        public JsonResult DisplayTypeList()
        {
            var DisplayedTypeLst = new List<TypeClothe>();
            using (var i = new ClothesDBEntities())
            {
                DisplayedTypeLst = i.TypeClothes.Where(x => x.Status >= 0).ToList();
            }
            return Json(DisplayedTypeLst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTypeId(int? id)
        {
            var TypeTable = new TypeClothe();
            using (var typeDB = new ClothesDBEntities())
            {
                TypeTable = typeDB.TypeClothes.FirstOrDefault(x => x.IdTypeCloth == id);
            }
            return Json(TypeTable, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddandEditTypeName(int? id, string typename)
        {
            var TypeTable = new TypeClothe();
            using (var typeDB = new ClothesDBEntities())
            {
                /*   Edit Event Method */
                if (id > 0)
                {
                    typeDB.TypeClothes.FirstOrDefault(x => x.IdTypeCloth == id).NameofType = typename;
                    typeDB.TypeClothes.FirstOrDefault(x => x.IdTypeCloth == id).Updateddate = DateTime.Now;
                    typeDB.SaveChanges();
                }
                /* Add Event Method */
                else
                {
                    TypeTable.NameofType = typename;
                    TypeTable.Updateddate = DateTime.Now;
                    TypeTable.Createddate = DateTime.Now;
                    TypeTable.Status = 0;
                    typeDB.TypeClothes.Add(TypeTable);
                    typeDB.SaveChanges();

                }
            }

            return Json("ADDED AND SYNCHRONIZED SUCCESSFULLY!", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTypeName(int? id)
        {
            using (var typeDB = new ClothesDBEntities())
            {
                typeDB.TypeClothes.FirstOrDefault(x => x.IdTypeCloth == id).Status = -1;
                typeDB.SaveChanges();
            }
            return Json("REMOVE SUCCESSFULLY", JsonRequestBehavior.AllowGet);
        }




        #endregion


    }
}