using TesteIbmMQ.Domain.Entities;

namespace TesteIbmMQ.Domain.Repositories
{
    public interface IFilaTesteRepository
    {
        Task ProcessCredit(EstruturaFila message);
    }
}
