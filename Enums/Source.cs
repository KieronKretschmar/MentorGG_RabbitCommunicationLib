using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Enums
{

    /// <summary>
    /// Copied from MatchEntities. Keep in sync when applying changes to either of them.
    /// </summary>
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
