using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.TransferModels
{
    public class RedisTaskCompletedTransferModel : TaskCompletedTransferModel
    {
        public string RedisKey { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
