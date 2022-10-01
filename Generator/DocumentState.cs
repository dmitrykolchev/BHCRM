using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    public class DocumentState
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public byte State { get; set; }
        public int OrdinalPosition { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public byte[] OverlayImage { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
