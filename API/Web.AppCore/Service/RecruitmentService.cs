using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class RecruitmentService : BaseService<Recruitment>, IRecruitmentService
    {
        IRecruitmentRepository _recruitmentRepository;
        public RecruitmentService(IRecruitmentRepository recruitmentRepository) : base(recruitmentRepository)
        {
            _recruitmentRepository = recruitmentRepository;
        }
    }
}
