using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue_JS_Template_AspNet_Core_3._1_Web_API1.Model;

namespace Vue_JS_Template_AspNet_Core_3._1_Web_API1.LogicFunction
{
    public class UserLogicFunction
    {

        public static List<Object> SimpleUsers(List<User> queryResult)
        {
            List<Object> list = new List<Object>();
            foreach (User result in queryResult)
            {
                var simpleUser = new { id = result.Id, name = result.Name, LastName = result.LastName };
                list.Add(simpleUser);
            }

            return list;
        }


    }
}
