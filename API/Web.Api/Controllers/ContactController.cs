using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Services;

namespace Web.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ContactController : BaseController<Contact>
    {
        #region Property
        IContactService _contactService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public ContactController(IContactService contactService) : base(contactService)
        {
            _contactService = contactService;
        }
        #endregion
    }
}
