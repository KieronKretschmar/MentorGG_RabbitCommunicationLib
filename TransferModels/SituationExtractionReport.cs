using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.TransferModels
{
    public class SituationExtractionReport : TaskCompletedReport
    {
        /// <summary>
        /// The outcome of the attemped analysis.
        /// </summary>
        public DemoAnalysisBlock? Block { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchId"></param>
        public SituationExtractionReport(long matchId)
        {
            MatchId = matchId;
            Block = null;
            Success = false;
        }
    }
}
