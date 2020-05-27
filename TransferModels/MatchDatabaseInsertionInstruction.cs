using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for MatchWriter to upload of a MatchDataSet into the MatchDb.
    /// </summary>
    public class MatchDatabaseInsertionInstruction : TransferModel, IMatchId
    {
        /// <inheritdoc/>
        public long MatchId { get; set; }
    }
}
