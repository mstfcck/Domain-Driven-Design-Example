using eCommerce.ApplicationLayer.History.Dtos;

namespace eCommerce.ApplicationLayer.History
{
    public interface IHistoryService
    {
        HistoryDto GetHistory();
    }
}