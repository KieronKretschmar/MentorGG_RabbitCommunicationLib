using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.Enums
{
    public enum Source : byte
    {
        Unknown = 0,
        Valve = 1,
        Faceit = 2,
        ManualUpload = 3,
        Scrimmage = 4,
        HLTV = 5,
        Esea = 6,
        Cevo = 7,
    }
}
