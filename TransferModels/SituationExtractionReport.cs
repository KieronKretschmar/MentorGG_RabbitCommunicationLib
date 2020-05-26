using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for SituationOperator to extract Situations from a MatchDataSet and upload them.
    /// </summary>
    public class SituationExtractionReport : TaskCompletedReport
    {
        /// <summary>
        /// The step during which the database upload failed, or null if it succeeded.
        /// </summary>
        public DemoAnalysisBlock? Block { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchId"></param>
        public SituationExtractionReport(long matchId) : base(matchId)
        {
            Block = null;
        }
    }
}
