using TransferObject;

namespace DataLayer.IRepository
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        void UpdateTableStatus(int tableId, TableStatus status);
        TableStatus GetLatestTableStatus(int tableId);
        void CompletePayment(int tableId);
        void SwapTable(int tableId1, int tableId2);

    }
}
