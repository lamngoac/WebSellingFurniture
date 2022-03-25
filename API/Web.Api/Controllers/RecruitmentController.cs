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
    public class RecruitmentController : BaseController<Recruitment>
    {
        #region Property
        IRecruitmentService _recuimentService;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo contructor
        /// </summary>
        public RecruitmentController(IRecruitmentService recuimentService) : base(recuimentService)
        {
            _recuimentService = recuimentService;
        }
        #endregion
    }
}
