using System.Threading.Tasks;

namespace Shop.DomainEvents.Sample.ApplicationService.Interfaces
{
    public interface ICreateOrderUseCase
    {
        Task Create(string userId);
    }
}