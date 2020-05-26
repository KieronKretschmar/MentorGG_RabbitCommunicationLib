using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.TransferModels
{
    public class SituationExtractionReport : TransferModel
    {
        /// <summary>
        /// Id of the Match which was attempted to be analyzed by SituationOperator.
        /// </summary>
        public long MatchId { get; set; }

        /// <summary>
        /// The outcome of the attemped analysis.
        /// </summary>
        public DemoAnalysisBlock Block { get; set; }

        /// <summary>
        /// Indicates if the download was succsesful
        /// </summary>
        public bool Success { get; set; }

        public SituationExtractionReport(long matchId)
        {
            MatchId = matchId;
            Block = DemoAnalysisBlock.UnknownSituationOperator;
            Success = false;
        }
    }
}
