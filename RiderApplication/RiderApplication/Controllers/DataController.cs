using RiderApplication.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace RiderApplication.Controllers
{
    public class DataController : ApiController
    {
        // GET api/data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/data/5
        public Owner GetOwner(string userName, string password)
        {
            return new Database().Owners.FirstOrDefault(owner => owner.UserName == userName && owner.Password == password);
        }


        public string uploadRider(string firstName, string lastName, string userName, string password,string phone,string CCnumber,string ccexp,string country,string zipcode)
        {
            Database de = new Database();
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            List<Rider> rider = de.Riders.ToList();
            Rider temp = rider.LastOrDefault();
            Rider ownerTodatabase = new Rider { FirstName = firstName, LastName = lastName, Password = password, UserName = userName,PhoneNumber=phone,CCNumber=CCnumber,CCExpiryDate=ccexp,Country=country,Zipcode=zipcode };
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            string[] keys = hfc.AllKeys;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        string[] e = hpf.FileName.Split('.');
                        string extention = e[e.Length - 1];
                        hpf.SaveAs(sPath + Path.GetFileName(keys[iCnt] + (temp.Id + 1) + "." + extention));
                        if (iCnt == 0)
                        {
                            ownerTodatabase.RiderPicture = Path.GetFileName(keys[iCnt] + (temp.Id + 1) + "." + extention);
                        }
                        else
                        {
                            ownerTodatabase.CCPicture = Path.GetFileName(keys[iCnt] + (temp.Id + 1) + "." + extention);
                        }
                    }
                }
            }
            de.Riders.Add(ownerTodatabase);
            // Owner owner = new Owner() { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, OwnerPicture = storeImagetoData(firstName + "OwnerImage", ownerImage), OwnerInsuranceSlip = storeImagetoData(firstName + "OwnerInsuranceSlip", ownerPassportImage) };
            //
            //   de.Owners.Add(owner);
            de.SaveChanges();
            return "Uploaded";

        }
        // POST api/data
        public string uploadOwner(string firstName,string lastName, string userName,string password)
        {
            Database de = new Database();
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            List<Owner> owner = de.Owners.ToList();
            Owner temp = owner.LastOrDefault();
            Owner ownerTodatabase = new Owner {FirstName=firstName,LastName=lastName,Password=password,UserName=userName };
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            string[] keys = hfc.AllKeys;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        string[] e = hpf.FileName.Split('.');
                        string extention = e[e.Length - 1];
                        hpf.SaveAs(sPath + Path.GetFileName(keys[iCnt] + (temp.Id + 1) + "." + extention));
                        if(iCnt==0)
                        {
                            ownerTodatabase.OwnerPicture = Path.GetFileName(keys[iCnt] + (temp.Id+1) + "." + extention);
                        }
                        else
                        {
                            ownerTodatabase.OwnerInsuranceSlip = Path.GetFileName(keys[iCnt] + (temp.Id + 1) + "." + extention);
                        }
                       
                    }
                }
            }
            de.Owners.Add(ownerTodatabase);
           // Owner owner = new Owner() { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, OwnerPicture = storeImagetoData(firstName + "OwnerImage", ownerImage), OwnerInsuranceSlip = storeImagetoData(firstName + "OwnerInsuranceSlip", ownerPassportImage) };
          //
             //   de.Owners.Add(owner);
            de.SaveChanges();
                return "Uploaded";
        }


        // PUT api/data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/data/5
        public void Delete(int id)
        {
        }


    }
}
