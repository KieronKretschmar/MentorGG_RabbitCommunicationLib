using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    public class RedisLocalizationInstruction : TransferModel, IMatchId
    {
        /// <inheritdoc/>
        public long MatchId { get; set; }

        /// <summary>
        /// Redis key to locate the resource
        /// </summary>
        public string RedisKey { get; set; }

        /// <summary>
        /// Date of expiry for this resource
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
