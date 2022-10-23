using Application.Features.ProLangs.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.ProLangs.Rules
{
    public class ProLangBusinessRules
    {
        private readonly IProLangRepository _proLangRepository;

        public ProLangBusinessRules(IProLangRepository proLangRepository)
        {
            _proLangRepository = proLangRepository;
        }

        public async Task ProLangNameCanNotBeDuplicateWhenAdded(string name)
        {
            var proLang = await _proLangRepository.GetAsync(p => p.Name == name);
            if (proLang != null)
            {
                throw new BusinessException(ProLangMessages.Exists);
            }
        }

        public async Task ProLangNameCanNotBeDuplicateWhenUpdated(ProLang proLang)
        {
            var proLangAtDb = await _proLangRepository.GetAsync(p => p.Name == proLang.Name);
            if (proLangAtDb != null && proLangAtDb.Id != proLang.Id)
            {
                throw new BusinessException(ProLangMessages.Exists);
            }
        }

        public void ProLangShouldExists(ProLang proLang)
        {
            if (proLang == null)
            {
                throw new BusinessException(ProLangMessages.NotExists);
            }
        }
    }
}
