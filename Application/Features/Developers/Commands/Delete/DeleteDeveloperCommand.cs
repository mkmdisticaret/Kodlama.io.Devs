using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.Developers.Commands.Delete
{
    public class DeleteDeveloperCommand : IRequest<DeletedDeveloperDto>
    {
        public int DeveloperId { get; set; }

        public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, DeletedDeveloperDto>
        {
            private readonly DeveloperBusinessRules _developerBusinessRules;
            private readonly IDeveloperRepository _developerRepository;

            public DeleteDeveloperCommandHandler(DeveloperBusinessRules developerBusinessRules, IDeveloperRepository developerRepository)
            {
                _developerBusinessRules = developerBusinessRules;
                _developerRepository = developerRepository;
            }

            public async Task<DeletedDeveloperDto> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
            {
                var developer = await _developerRepository.GetAsync(d => d.Id == request.DeveloperId);
                await _developerBusinessRules.DeveloperMustExist(developer);

                var deletedDeveloper = await _developerRepository.DeleteAsync(developer);
                return new DeletedDeveloperDto
                {
                    GitHubAddress = deletedDeveloper.GitHubAddres,
                    Id = deletedDeveloper.Id,
                    UserId = deletedDeveloper.UserId
                };
            }
        }
    }
}
