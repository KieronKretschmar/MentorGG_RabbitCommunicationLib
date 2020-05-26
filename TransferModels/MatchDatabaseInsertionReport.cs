using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Report regarding the upload of a MatchDataSet into the MatchDb.
    /// </summary>
    public class MatchDatabaseInsertionReport : TaskCompletedReport
    {
        /// <summary>
        /// The step during which the database upload failed, or null if it succeeded.
        /// </summary>
        public DemoAnalysisBlock? Block { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matchId"></param>
        public MatchDatabaseInsertionReport(long matchId) : base(matchId)
        {
            Block = null;
        }
    }
}
