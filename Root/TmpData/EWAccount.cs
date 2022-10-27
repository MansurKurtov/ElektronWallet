namespace Root.TmpData
{
    /// <summary>
    /// Класс для хранения модели данных учетной записи
    /// </summary>
    public class EWAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Имя владельца
        /// </summary>
        public string HolderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IssueDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Balance { get; set; }
    }
}
