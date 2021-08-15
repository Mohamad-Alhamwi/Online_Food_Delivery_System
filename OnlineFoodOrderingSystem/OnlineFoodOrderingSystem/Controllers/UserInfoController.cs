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
        public ActionResult UpdateUser(User_ user)
        {
            Model1 m = new Model1();
            User_ u = m.User_.FirstOrDefault(x => x.id == user.id);

            u.first_name = user.first_name;
            u.last_name = user.last_name;
            u.email = user.email;
            u.pwd = "dummyThings";
            u.phoneNo = user.phoneNo;
            u.updated_at = DateTime.Now;

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCard()
        {
            PaymentCard card = new PaymentCard();
            return View(card);
        }

        [HttpPost]
        public ActionResult AddCard(PaymentCard card)
        {
            Model1 m = new Model1();
            PaymentCard c = m.PaymentCard.FirstOrDefault(x => x.id == card.id);

            if (c == null)
            {
                m.PaymentCard.Add(card);
            }
            else
            {
                c.card_no = card.card_no;
                c.card_name = card.card_name;
                c.cvv = card.cvv;
                c.expiration_data = card.expiration_data;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCard(PaymentCard card)
        {
            Model1 m = new Model1();
            card = m.PaymentCard.FirstOrDefault(x => x.id == card.id);
            m.PaymentCard.Remove(card);
            m.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult UpdateCard(int id)
        {
            Model1 m = new Model1();
            PaymentCard card = m.PaymentCard.FirstOrDefault(x => x.id == id);
            return View("AddCard", card);
        }

        [HttpGet]
        public ActionResult AddAddress()
        {
            Address_ address = new Address_();
            return View(address);
        }

        [HttpPost]
        public ActionResult AddAddress(Address_ address)
        {
            Model1 m = new Model1();

            Address_ a = m.Address_.FirstOrDefault(x => x.id == address.id);
            
            UserAddress user_address = new UserAddress();
            user_address.id_address = address.id;
            user_address.id_user = 1; // TODO: Get this from session information.

            if (a == null)
            {
               m.Address_.Add(address);
               m.UserAddress.Add(user_address);
            }
            else
            {
                a.address_name = address.address_name;
                a.city = address.city;
                a.town = address.town;
                a.neighborhood = address.neighborhood;
                a.street = address.street;
                a.building_name = address.building_name;
                a.building_no = address.building_no;
                a.flat_no = address.flat_no;
            }

            m.SaveChanges();

            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public ActionResult DeleteAddAddress(PaymentCard card)
        {
            Model1 m = new Model1();
            card = m.PaymentCard.FirstOrDefault(x => x.id == card.id);
            m.PaymentCard.Remove(card);
            m.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAddAddress(int id)
        {
            Model1 m = new Model1();
            PaymentCard card = m.PaymentCard.FirstOrDefault(x => x.id == id);
            return View("AddCard", card);
        }*/
    }
}
