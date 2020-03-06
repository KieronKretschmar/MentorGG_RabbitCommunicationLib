using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Enums
{
    public enum ConsumedMessageHandling
    {
        Done=1,
        Resend=2,
        ThrowAway =3,
    }
}
