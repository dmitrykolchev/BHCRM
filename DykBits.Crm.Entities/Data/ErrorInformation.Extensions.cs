using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DykBits.Crm.Data
{
    partial class ErrorInformation: IErrorInformation
    {
        private string _filePath;

        string IErrorInformation.Message
        {
            get
            {
                return this.FileAs;
            }
            set
            {
                this.FileAs = value;
            }
        }

        string IErrorInformation.Details
        {
            get
            {
                return this.Comments;
            }
            set
            {
                this.Comments = value;
            }
        }

        string IErrorInformation.FilePath
        {
            get { return this._filePath; }
            set
            {
                this._filePath = value;
                if (File.Exists(value))
                {
                    this.Attachments.Add(AttachmentItem.CreateInstance(value));
                }
            }
        }
    }
}
