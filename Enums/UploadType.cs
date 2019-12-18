using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitTransfer.Enums
{
    public enum UploadType
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
