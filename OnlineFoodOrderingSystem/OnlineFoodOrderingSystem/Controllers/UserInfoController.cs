using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: PersonalInformation
        public ActionResult Index()
        {
            Model1 m = new Model1();

            // To find the user by id.
            int id = 1;  // This will come from session information.

            // Return the user information.
            User_ user = m.User_.FirstOrDefault(x => x.id == id);

            // Return the user's payment cards information.
            List<PaymentCard> userPaymentCards = m.PaymentCard.Where(x => x.id_user == id).ToList();

            // Return the user's addresses information.
            List<UserAddress> addresses = m.UserAddress.Where(x => x.id_user == id).ToList();
            List<Address_> userAddresses = new List<Address_>();

            for (int counter = 0; counter < addresses.Count; ++ counter)
            {
                int temp_address_id = addresses[counter].id_address;
                userAddresses.Add(m.Address_.FirstOrDefault(x => x.id == temp_address_id));
            }

            ViewBag.SubTitle = "User Information";
            ViewBag.Path = "/UserInfo/Index/";
            ViewBag.User = user;
            ViewBag.UserCards = userPaymentCards;
            ViewBag.UserAddresses = userAddresses;

            return View();
        }

        [HttpPost]
        public ActionResult UserInfoCardDelete(PaymentCard card)
        {
            Model1 m = new Model1();
            card = m.PaymentCard.FirstOrDefault(x => x.id == card.id);
            m.PaymentCard.Remove(card);
            m.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}