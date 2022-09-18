using Application.Features.ProLangs.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProLangs.Models
{
    public class ProLangListModel: BasePageableModel
    {
        public List<GetListProLangDto> Items { get; set; }
    }
}
