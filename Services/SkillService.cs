using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobberApp.Contracts;
using JobberApp.Data.Models;
using JobberApp.Repositories;
using JobberApp.ViewModels;

namespace JobberApp.Services
{
    public class SkillService : ISkillService<SkillViewModel>
    {
        private IGenericRepository _skillRepository;
        private readonly IMapper _mapper;
        public SkillService(IGenericRepository skillRepository, IMapper mapper)
        {         
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _mapper = mapper;
        }
        public async Task<IEnumerable<SkillViewModel>> GetSkills()
        {
            var skills = await _skillRepository.GetAsync<Skill>();
        
            return  _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillViewModel>>(skills);
        }
    }
}