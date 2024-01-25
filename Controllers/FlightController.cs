using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using flightapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Newtonsoft.Json;

namespace flightapp.Controllers{
    
    public class FlightController:Controller{
        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public FlightController(Ace52024Context _db)
        {
            db=_db;
        }
        public ActionResult ShowFlightDetail(){
            ViewBag.Userid=HttpContext.Session.GetInt32("uid");
            if(ViewBag.Userid!=null){
                ViewBag.Flightsource=new SelectList(db.Suhasiniflights,"Flightsource");
                
                 List<Suhasiniflight> s=(from i in db.Suhasiniflights select i).ToList();
            
            return View(s);
            }
           else{
               return RedirectToAction("Login","Login");
            }

           

        }
        public ActionResult Bookingdetails(){
            ViewBag.Userid=HttpContext.Session.GetInt32("uid");
            int user=Convert.ToInt32(ViewBag.Userid);
            Console.WriteLine("useruseruser"+ViewBag.Userid);
            List<Suhasinibooking> s=(from i in db.Suhasinibookings
                                     where i.Customerid == user
            select i).ToList();
            return View(s);
        }
        public ActionResult Book(string Flightid, int Flightprice){
            ViewBag.Userid=HttpContext.Session.GetInt32("uid");

            Console.WriteLine(Flightprice);
            Suhasinibooking s=new Suhasinibooking();
            s.Flightid = Flightid;
            Random rnd = new Random();
            int num = rnd.Next();
            s.Bookingid= num.ToString();
            s.Customerid=Convert.ToInt32(ViewBag.Userid);
            s.Bookingdate=DateTime.Now;
            s.Bookingtotalcost=Flightprice;
            Console.WriteLine("fpfpfp"+s.Bookingtotalcost);
            TempData["rate"]=Flightprice;
            return View(s);


        }

        [HttpPost]
        public ActionResult Book(Suhasinibooking s){
            
            s.Bookingtotalcost=s.Bookingtotalmembers*((int)TempData["rate"]);
            TempData["rate"]=s.Bookingtotalcost;
            db.Suhasinibookings.Add(s);
            db.SaveChanges();
            Console.WriteLine("xxxxxx"+s.Bookingtotalcost);
            return RedirectToAction("ShowFlightDetail","Flight");

        }
        public ActionResult Showselectedflights(List<Suhasiniflight> s){
            s=JsonConvert.DeserializeObject<List<Suhasiniflight>>(TempData["selected"].ToString());
            Console.WriteLine("cccc"+s.Count);
            return View(s);
        }
        public ActionResult GetFlightDetail(){
            ViewBag.Flightsources=new SelectList(db.Suhasiniflights,"Flightsource","Flightsource");
            ViewBag.Flightdestinations=new SelectList(db.Suhasiniflights,"Flightdestination","Flightdestination");
            
            // foreach (var item in ViewBag.Flightsource){
            //         Console.WriteLine("ans"+item);
            //     }
            return View();

        }

        [HttpPost]
        public ActionResult GetFlightDetail(Suhasiniflight t ){
          
            List<Suhasiniflight> s;
            s=(from i in db.Suhasiniflights
            where i.Flightsource==t.Flightsource && i.Flightdestination==t.Flightdestination && i.Flightdate==t.Flightdate
            select i).ToList();
            if(s.Count==0){
                return View();
            }
            else{
                TempData["selected"]=JsonConvert.SerializeObject(s);
                return RedirectToAction("Showselectedflights","Flight");
            }
        
        }
       
        public ActionResult Cancel(string id){
            Suhasinibooking s=db.Suhasinibookings.Find(id);
            db.Suhasinibookings.Remove(s);
            db.SaveChanges();
            return  RedirectToAction("ShowFlightDetail","Flight");
        }
        public ActionResult Cancelflight(string id){
            Suhasiniflight s=db.Suhasiniflights.Find(id);
            db.Suhasiniflights.Remove(s);
            db.SaveChanges();
            return  RedirectToAction("Adminhome","Flight");
        }

        public ActionResult Adminhome(){
            
            return View(db.Suhasiniflights);
        }
          public ActionResult AddFlight(){

            return View();

        }
        [HttpPost]
         public ActionResult  AddFlight(Suhasiniflight s){
            db.Suhasiniflights.Add(s);
            db.SaveChanges();
            return RedirectToAction("Adminhome");
        }

        

}
}