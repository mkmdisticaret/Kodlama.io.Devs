using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Developers.Commands.Update
{
    public class UpdateDeveloperCommand : IRequest<UpdatedDeveloperDto>
    {
        public int DeveloperId { get; set; }
        public int UserId { get; set; }
        public string GitHubAddress { get; set; }

        public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand, UpdatedDeveloperDto>
        {
            private readonly DeveloperBusinessRules _developerBusinessRules;
            private readonly IDeveloperRepository _developerRepository;

            public UpdateDeveloperCommandHandler(DeveloperBusinessRules developerBusinessRules, IDeveloperRepository developerRepository)
            {
                _developerBusinessRules = developerBusinessRules;
                _developerRepository = developerRepository;
            }

            public async Task<UpdatedDeveloperDto> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _developerBusinessRules.UserMustExist(request.UserId);

                var developer = await _developerRepository.GetAsync(d => d.Id == request.DeveloperId);
                await _developerBusinessRules.DeveloperMustExist(developer);

                developer.UserId = request.UserId;
                developer.GitHubAddres = request.GitHubAddress;

                var updateDeveloper = _developerRepository.Update(developer);

                return new UpdatedDeveloperDto
                {
                    GitHubAddress = updateDeveloper.GitHubAddres,
                    Id = updateDeveloper.Id,
                    UserId = updateDeveloper.UserId
                };
            }
        }
    }
}
