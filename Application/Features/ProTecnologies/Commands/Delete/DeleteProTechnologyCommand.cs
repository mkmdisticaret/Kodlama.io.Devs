using Application.Features.ProTecnologies.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProTecnologies.Commands.Delete
{
    public class DeleteProTechnologyCommand : IRequest<DeletedProTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteProTechnologyCommandHandler : IRequestHandler<DeleteProTechnologyCommand, DeletedProTechnologyDto>
        {
            private readonly IProTechnologyRepository _proTechnologyRepository;

            public DeleteProTechnologyCommandHandler(IProTechnologyRepository proTechnologyRepository)
            {
                _proTechnologyRepository = proTechnologyRepository;
            }

            public async Task<DeletedProTechnologyDto> Handle(DeleteProTechnologyCommand request, CancellationToken cancellationToken)
            {
                var deletedProTechnology = await _proTechnologyRepository.DeleteAsync(new ProTechnology { Id = request.Id });
                return new DeletedProTechnologyDto { Id = deletedProTechnology.Id, Name = deletedProTechnology.Name };
            }
        }
    }
}
