using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Enums
{
    public enum ConsumedMessageHandling
    {
        /// <summary>
        /// When the message was (succesfully) consumed on no additional action needs to be performed.
        /// </summary>
        Done = 1,

        /// <summary>
        /// When the message needs to be resent, e.g. because it could not be consumed succesfully because of temporary reasons, e.g. a dependency being unavailable.
        /// </summary>
        Resend = 2,

        /// <summary>
        /// When the message could not be handled, and it should not be tried again.
        /// </summary>
        ThrowAway = 3,
    }
}
