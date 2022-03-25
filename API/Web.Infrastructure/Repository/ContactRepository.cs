using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;

namespace Web.Infrastructure.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public ContactRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
