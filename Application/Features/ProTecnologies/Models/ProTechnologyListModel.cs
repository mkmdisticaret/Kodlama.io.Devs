using Application.Features.ProTecnologies.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProTecnologies.Models
{
    public class ProTechnologyListModel : BasePageableModel
    {
        public List<GetListProTechnologyDto> Items { get; set; }
    }
}
