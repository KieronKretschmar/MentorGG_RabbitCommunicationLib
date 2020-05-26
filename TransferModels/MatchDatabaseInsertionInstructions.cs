using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for MatchWriter to upload of a MatchDataSet into the MatchDb.
    /// </summary>
    public class MatchDatabaseInsertionInstructions : TransferModel, IMatchId
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
