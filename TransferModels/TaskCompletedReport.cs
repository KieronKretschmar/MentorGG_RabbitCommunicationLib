
using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    public class TaskCompletedReport : TransferModel, IMatchId
    {
        public long MatchId { get; set; }

        /// <summary>
        /// Whether the task was completed successfully.
        /// </summary>
        public bool Success { get; set; }

        public TaskCompletedReport(long matchId)
        {
            MatchId = matchId;
            Success = false;
        }
    }
}
