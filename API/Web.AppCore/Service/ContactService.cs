using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        IContactRepository _contactRespository;
        public ContactService(IContactRepository contactRespository) : base(contactRespository)
        {
            _contactRespository = contactRespository;
        }
    }
}
