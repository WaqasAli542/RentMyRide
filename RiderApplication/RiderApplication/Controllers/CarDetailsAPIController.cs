using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RiderApplication.Models; 
namespace RiderApplication.Controllers
{
    public class CarDetailsAPIController : ApiController
    {
        Database database = new Database();


        //Get 
        //With all parameters and here all parameters are optional
        //
        //http://localhost:27152/api/CarDetailsAPI/GetCarDetailsList?year=2016&&make=Acura&&model=RLX&&description=4d Sedan&&price=45900
        public IEnumerable<CarDetail> GetCarDetailsList(String year=null,String make=null,String model=null,String description=null,double price=0.0)
        {
            List<CarDetail> lst = database.CarDetails.ToList();
            if(year!=null)
                lst = lst.Where(x => x.Year == year).ToList();

            if(make!=null)
                lst = lst.Where(x => x.Make == make).ToList();

            if (model != null)
                lst = lst.Where(x => x.Model == model).ToList();

            if(description!=null)
                lst = lst.Where(x => x.Description == description).ToList();
         
            if(price!=0.0)
                lst = lst.Where(x => x.Price == price).ToList();

            return lst;
        }




        public IEnumerable<CarOwner_Rider> GetCarOwner_RidersList(String year = null, String make = null, String model = null, String description = null, double price = 0.0,String area=null,int OwnerId=0)
        {
            List<CarOwner_Rider> lst = database.CarOwner_Rider.ToList();
            if (year != null)
                lst = lst.Where(x => x.CarDetail.Year == year).ToList();

            if (make != null)
                lst = lst.Where(x => x.CarDetail.Make == make).ToList();

            if (model != null)
                lst = lst.Where(x => x.CarDetail.Model == model).ToList();

            if (description != null)
                lst = lst.Where(x => x.CarDetail.Description == description).ToList();

            if (price != 0.0)
                lst = lst.Where(x => x.CarDetail.Price == price).ToList();

            if (area != null)
                lst = lst.Where(x => x.Area == area).ToList();

            if (OwnerId!=0)
                lst = lst.Where(x => x.OwnerId == OwnerId).ToList();
            return lst;
        }


        public int saveCarOwner_Rider(CarOwner_Rider caror)
        {
            caror.IsAvailable = 1;
            database.CarOwner_Rider.Add(caror);
            return database.SaveChanges();
        }
    }
}