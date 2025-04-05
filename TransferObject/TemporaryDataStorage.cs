namespace TransferObject
{
    public class TemporaryDataStorage
    {
        public static Dictionary<int, List<TemporaryOrderDetail>> TemporaryOrderDetails { get; set; } = new Dictionary<int, List<TemporaryOrderDetail>>();

    }
}
