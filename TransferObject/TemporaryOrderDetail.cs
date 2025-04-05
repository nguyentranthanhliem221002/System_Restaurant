namespace TransferObject
{
    public class TemporaryOrderDetail
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int TableId { get; set; }  // Mới thêm thuộc tính này
    }

}
