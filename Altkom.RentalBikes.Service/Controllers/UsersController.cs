using Altkom.RentalBikes.Interfaces;
using Altkom.RentalBikes.Models;
using Altkom.RentalBikes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Altkom.RentalBikes.Service.Controllers
{
    public class UsersController : BaseApiController<User, IUsersService, int>
    {
        public UsersController()
            : base(new MockUsersService())
        {

        }

    }
}
