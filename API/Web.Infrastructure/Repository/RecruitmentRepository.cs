using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;

namespace Web.Infrastructure.Repository
{
    public class RecruitmentRepository : BaseRepository<Recruitment>, IRecruitmentRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public RecruitmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}
