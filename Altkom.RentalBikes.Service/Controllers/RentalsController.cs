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
    public class RentalsController : BaseApiController<Rental, IRentalsService, int>
    {
        public RentalsController(IRentalsService service) : base(service)
        {
        }
    }
}
