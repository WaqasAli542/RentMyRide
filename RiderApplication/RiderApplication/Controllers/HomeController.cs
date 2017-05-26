using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using RiderApplication.Models; 

namespace RiderApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Database database = new Database();
        public ActionResult Index()
        {
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\System A\Desktop\data\NewCarMarketValue.csv");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;
 
            //int rowCount = xlRange.Rows.Count;
            //int colCount = xlRange.Columns.Count;
            //for (int i = 4; i <= rowCount; i++)
            //{ 
            //    CarDetail cardetail= new CarDetail();

            //    if ((xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null) && (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null) && (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null) && (xlRange.Cells[i, 5] != null && xlRange.Cells[i, 5].Value2 != null) && (xlRange.Cells[i, 6] != null && xlRange.Cells[i, 6].Value2 != null))
            //    {
            //        cardetail.Year = xlRange.Cells[i, 2].Value2.ToString();
            //        cardetail.Make = xlRange.Cells[i, 3].Value2.ToString();
            //        cardetail.Model = xlRange.Cells[i, 4].Value2.ToString();
            //        cardetail.Description = xlRange.Cells[i, 5].Value2.ToString();

            //        String temp = xlRange.Cells[i, 6].Value2.ToString();
            //        temp = temp.Replace("$", ""); temp = temp.Replace(",", "");
            //        cardetail.Price = (float)Convert.ToDouble(temp);
            //        database.CarDetails.Add(cardetail);
            //        database.SaveChanges();
            //    }
            //}
            return View();

      }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

       
    }
}
