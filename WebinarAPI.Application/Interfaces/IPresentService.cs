using System.Threading.Tasks;
using WebinarAPI.Application.ViewModels.Presents;

namespace WebinarAPI.Application.Interfaces
{
    public interface IPresentService
    {
        Task<PresentsVm> GetAllPresents();
        Task<PresentDto> GetPresentById(int id);
        Task AddNewPresent(CreatePresentDto newPresent);
        Task DeletePresent(int id);
        Task UpdatePresnet(UpdatePresentDto updatePresent);
        Task<PresentsVm> GetPresentsByQuery(string query);
    }
}
