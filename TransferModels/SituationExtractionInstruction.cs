using RabbitCommunicationLib.TransferModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for SituationOperator to extract situations and upload them to the SituationDb.
    /// </summary>
    public class SituationExtractionInstruction : TransferModel, IMatchId
    {
        /// <inheritdoc/>
        public long MatchId { get; set; }
    }
}
