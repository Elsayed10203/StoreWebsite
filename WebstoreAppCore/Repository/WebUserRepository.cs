using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Repository
{
    public interface IWebUserRepository
    {


        public WebUsers getWebUser(int id);


    }
    public class WebUserRepository : IWebUserRepository
    {
        readonly private StoreWebsiteContext _Context;

        public WebUserRepository(StoreWebsiteContext Context)
        {
            _Context = Context;
        }
        public WebUsers getWebUser(int id)
        {
            WebUsers webuser = (from user in _Context.WebUsers
                                where user.UserId == id
                                select user).FirstOrDefault();
            return webuser;
        }
    }
}
