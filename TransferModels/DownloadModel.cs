using System;
using System.Collections.Generic;
using System.Text;

    public class DownloadModel : DC2DFWModel
    {
        public DownloadModel(DC2DFWModel parent,long uploader,byte upload_type):base(parent)
        {
            this.UploaderID = uploader;
            this.UploadType = upload_type;
        }
        public long UploaderID { get; set;}
        
        public byte UploadType{ get; set; }
        
    }

