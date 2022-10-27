using System;

namespace Root.TmpData
{
    /// <summary>
    /// Класс для хранения модели данных учетной записи
    /// </summary>
    public class AccountHistory
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int AccointId { get; set; }

        /// <summary>
        /// Время операции
        /// </summary>
        public DateTime OperationTime { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public double Amount { get; set; }
    }
}
