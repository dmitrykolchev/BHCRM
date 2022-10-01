using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DykBits.Crm.UI
{
    public enum ApplicationImageId
    {
        LowImportance,
        HighImportance,
        PhoneCall,
        MeetingRequest,
        MailMessage,
        IncomingDirection,
        OutgoingDirection,
        CustomFlag,
        GroupRow,
        Accepted,
        TotalSum,
        Rejected,
        Submitted,
        Draft,
        Attachment
    }

    public static class ApplicationImages
    {
        private static readonly Dictionary<ApplicationImageId, BitmapImage> Images = new Dictionary<ApplicationImageId, BitmapImage>();

        private static BitmapImage GetApplicationImage(ApplicationImageId id)
        {
            BitmapImage image;
            if (!Images.TryGetValue(id, out image))
            {
                Uri imageUri = GetBitmapUri(id);
                image = new BitmapImage(imageUri);
                Images.Add(id, image);
            }
            return image;
        }

        private static Uri GetBitmapUri(ApplicationImageId id)
        {
            switch (id)
            {
                case ApplicationImageId.LowImportance:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/LowImportance.png", UriKind.Absolute);
                case ApplicationImageId.HighImportance:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/HighImportance.png", UriKind.Absolute);
                case ApplicationImageId.MailMessage:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/MailMessage.png", UriKind.Absolute);
                case ApplicationImageId.MeetingRequest:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/MeetingRequest.png", UriKind.Absolute);
                case ApplicationImageId.PhoneCall:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/PhoneCall.png", UriKind.Absolute);
                case ApplicationImageId.IncomingDirection:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/IncomingDirection.png", UriKind.Absolute);
                case ApplicationImageId.OutgoingDirection:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/OutgoingDirection.png", UriKind.Absolute);
                case ApplicationImageId.CustomFlag:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/CustomFlag.png", UriKind.Absolute);
                case ApplicationImageId.GroupRow:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/GroupRow.png", UriKind.Absolute);
                case ApplicationImageId.Accepted:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Accepted.png", UriKind.Absolute);
                case ApplicationImageId.Rejected:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Rejected.png", UriKind.Absolute);
                case ApplicationImageId.Submitted:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Submitted.png", UriKind.Absolute);
                case ApplicationImageId.TotalSum:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/TotalSum.png", UriKind.Absolute);
                case ApplicationImageId.Draft:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Draft.png", UriKind.Absolute);
                case ApplicationImageId.Attachment:
                    return new Uri("pack://application:,,,/Dykbits.Crm.Core;component/Images/16x16/Attachment.png", UriKind.Absolute);
            }
            throw new ArgumentOutOfRangeException("id");
        }
        public static BitmapImage Attachment
        {
            get { return GetApplicationImage(ApplicationImageId.Attachment); }
        }
        public static BitmapImage Draft
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.Draft);
            }
        }
        public static BitmapImage Submitted
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.Submitted);
            }
        }
        public static BitmapImage Rejected
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.Rejected);
            }
        }
        public static BitmapImage TotalSum
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.TotalSum);
            }
        }
        public static BitmapImage Accepted
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.Accepted);
            }
        }
        public static BitmapImage GroupRow
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.GroupRow);
            }
        }
        public static BitmapImage CustomFlag
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.CustomFlag);
            }
        }
        public static BitmapImage IncomingDirection
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.IncomingDirection);
            }
        }
        public static BitmapImage OutgoingDirection
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.OutgoingDirection);
            }
        }

        public static BitmapImage ImportanceLow
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.LowImportance);
            }
        }
        public static BitmapImage ImportanceHigh
        {
            get
            {
                return GetApplicationImage(ApplicationImageId.HighImportance);
            }
        }

        public static BitmapImage MailMessage
        {
            get { return GetApplicationImage(ApplicationImageId.MailMessage); }
        }

        public static BitmapImage MeetingRequest
        {
            get { return GetApplicationImage(ApplicationImageId.MeetingRequest); }
        }

        public static BitmapImage PhoneCall
        {
            get { return GetApplicationImage(ApplicationImageId.PhoneCall); }
        }


    }
}
