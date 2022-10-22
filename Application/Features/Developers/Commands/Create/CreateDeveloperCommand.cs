using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Commands.Create
{
    public class CreateDeveloperCommand : IRequest<CreatedDeveloperDto>
    {
        public int UserId { get; set; }
        public string GitHubAddres { get; set; }

        public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, CreatedDeveloperDto>
        {
            private readonly IDeveloperRepository _developerRepository;
            private readonly DeveloperBusinessRules _developerBusinessRules;

            public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, DeveloperBusinessRules developerBusinessRules)
            {
                _developerRepository = developerRepository;
                _developerBusinessRules = developerBusinessRules;
            }

            public async Task<CreatedDeveloperDto> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.UserMustExist(request.UserId);
                var createdDeveloper = await _developerRepository.AddAsync(new Developer
                {
                    UserId = request.UserId,
                    GitHubAddres = request.GitHubAddres
                });
                return new CreatedDeveloperDto { GitHubAddress = createdDeveloper.GitHubAddres, Id = createdDeveloper.Id, UserId = createdDeveloper.Id };
            }
        }
    }
}
