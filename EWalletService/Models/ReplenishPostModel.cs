namespace EWalletService.Models
{
    /// <summary>
    /// Модель данных для пополнения счета
    /// </summary>
    public class ReplenishPostModel
    {
        /// <summary>
        /// счет
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public double Amount { get; set; }
    }
}
