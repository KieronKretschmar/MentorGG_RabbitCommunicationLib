using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    public class RedisUploadReport : TaskCompletedReport
    {
        public string RedisKey { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
