using PhatDat_FoodStore.Regex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PhatDat_FoodStore.Services
{
    internal class ValidRegister
    {
        UserRegex userRegex = new UserRegex();
        public bool CheckValid(string password)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(password, userRegex.PasswordPattern))
            {
                return true;
            }
            return false;
        }
    }
}
