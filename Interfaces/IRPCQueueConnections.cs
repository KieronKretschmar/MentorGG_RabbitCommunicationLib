﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Interfaces
{
    public interface IRPCQueueConnections
    {
        IQueueConnection ConsumeConnection { get; set; }

        IQueueConnection ProduceConnection { get; set; }
    }
}
