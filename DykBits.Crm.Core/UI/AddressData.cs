using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.UI
{
    public class AddressData
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Street) && string.IsNullOrWhiteSpace(City) && string.IsNullOrWhiteSpace(PostalCode) && string.IsNullOrWhiteSpace(Region) && string.IsNullOrWhiteSpace(Country);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(this.Street))
            {
                sb.Append(this.Street.Replace("\n", "\r\n"));
                sb.AppendLine();
            }
            if (!string.IsNullOrWhiteSpace(this.City) || !string.IsNullOrWhiteSpace(this.PostalCode))
            {
                if (!string.IsNullOrWhiteSpace(this.City))
                {
                    sb.Append((string)this.City);
                    if (!string.IsNullOrWhiteSpace(this.PostalCode))
                        sb.Append(", ");
                    else
                        sb.AppendLine();
                }
                if (!string.IsNullOrWhiteSpace(this.PostalCode))
                {
                    sb.Append(this.PostalCode);
                    sb.AppendLine();
                }
            }
            if (!string.IsNullOrWhiteSpace(this.Region))
            {
                sb.Append(this.Region);
                sb.AppendLine();
            }
            if (!string.IsNullOrWhiteSpace(this.Country))
            {
                sb.Append(this.Country);
            }
            return sb.ToString();
        }
    }
}
