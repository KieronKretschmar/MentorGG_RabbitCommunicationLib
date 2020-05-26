using System;
using System.Collections.Generic;
using System.Text;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels.Interfaces;

namespace RabbitCommunicationLib.TransferModels
{
    /// <summary>
    /// Instructions for MatchWriter to remove a MatchDataSet from the MatchDb.
    /// </summary>
    public class DemoRemovalInstruction : TransferModel, IMatchId
    {
        public long MatchId { get ; set; }
    }
}
