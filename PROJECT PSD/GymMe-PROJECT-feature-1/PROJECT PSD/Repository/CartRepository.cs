using PROJECT_PSD.Factory;
using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Repository
{
    public class CartRepository
    {
        static LocalDatabaseEntities db = Singleton.GetInstance();
        public static MsCart insertCart(int userID, int supplementID, int quantity)
        {
            MsCart newCart = CartFactory.insertCart(userID, supplementID, quantity);
            db.MsCarts.Add(newCart);
            db.SaveChanges();
            return newCart;
        }
    }
}