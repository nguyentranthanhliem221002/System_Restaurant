using DataLayer.IRepository;
using System.Collections.Generic;
using TransferObject;

namespace BusinessLayer.Service
{
    public class TableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        // Phương thức để lấy tất cả các bàn ăn
        public List<Table> GetAllTables()
        {
            return _tableRepository.GetAllTables();
        }
        public void UpdateTableStatus(int tableId, TableStatus status)
        {
            _tableRepository.UpdateTableStatus(tableId, status);
        }
        public TableStatus GetLatestTableStatus(int tableId)
        {
            return _tableRepository.GetLatestTableStatus(tableId);
        }
        public void CompletePayment(int tableId)
        {
            _tableRepository.CompletePayment(tableId);
        }
        public void SwapTable(int tableId1, int tableId2)
        {
            _tableRepository.SwapTable(tableId1, tableId2);
        }
    }
}
