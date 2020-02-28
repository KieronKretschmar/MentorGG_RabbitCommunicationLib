using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCommunicationLib.Enums
{
    /// <summary>
    /// The Method used to obtain a Demo.
    /// </summary>
    public enum UploadType : byte
    {
        Unknown = 0,
        Extension = 1,
        Uploader = 2,
        FaceitMatchGatherer = 3,
        ManualUserUpload = 4,
        ManualAdminUpload = 5,
        EventUpload = 6,
        SharingCodeGatherer = 7,
    }
}
