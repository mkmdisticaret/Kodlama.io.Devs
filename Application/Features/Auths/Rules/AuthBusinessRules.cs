﻿using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailCanNotBeDuplicateWhenRegistered(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");
        }

    }
}
