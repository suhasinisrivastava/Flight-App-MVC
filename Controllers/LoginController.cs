using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using flightapp.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace flightapp.Controllers{
    
    public class LoginController:Controller{
        public static Ace52024Context db;
        
        //Dependency Injection  in constructor
        public LoginController(Ace52024Context _db)
        {
            db=_db;
        }
        public ActionResult Login(){
            return View();
        }
        public ActionResult Register(){
            return View();
        }
        [HttpPost]
        public ActionResult Login(Suhasinicustomer s){
            
            var result=(from i in db.Suhasinicustomers
            where i.Customeremail==s.Customeremail && i.Customerpw==s.Customerpw
            select i).SingleOrDefault();
            
            if(result!=null){
                HttpContext.Session.SetInt32("uid",result.Customerid);
                Console.WriteLine("idididididi"+HttpContext.Session.GetInt32("uid"));
                if(s.Customeremail=="admin@email.com" && s.Customerpw=="admin123"){
                return RedirectToAction("Adminhome","Flight");
                
            }
            
                return RedirectToAction("ShowFlightDetail", "Flight");
            }
            else{
                return View();
            }
        }
        public ActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        }

        [HttpPost]

        public ActionResult Register(Suhasinicustomer s){
            if(ModelState.IsValid){
            db.Suhasinicustomers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Login");
            }
            else{
                return View();
            }
        }

}
}