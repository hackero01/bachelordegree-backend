using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PortalStudenti.Models.ModelUtilizatori;

namespace PortalStudenti.Servicies
{
    public class UserServicies
    {
        public static ModelUtilizatori userLogin(string email, string pass)
        {

            UserRepository up = new UserRepository();
            ModelUtilizatori user = up.checkUserLogin(email, pass);
            if (user.statusConectare == "Conectare cu succes")
            {
                up.updateLogin(user.idUtilizator, true);

            }
            return user;
        }
        public  ModelUtilizatori getAllUserInformation(int idUtilizator)
        {
            UserRepository up = new UserRepository();
            ModelUtilizatori user = null;
            user = up.getAllUserInformation(idUtilizator);
            return user;
        }
        public void checkIfConnected(int idUtilizator)
        {
            UserRepository us = new UserRepository();
            string result = us.checkIfConnected(idUtilizator);
            if (result == "con")
            {
                us.updateLogin(idUtilizator, false);

            }

        }
        
        public string updateData(ModelUtilizatori user)
        {

            UserRepository up = new UserRepository();
            string testing1 = up.updateData(user);
            return testing1;

        }
    }
}