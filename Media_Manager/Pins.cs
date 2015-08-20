namespace Media_Manager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pins
    {
        [Key]
        public int PinId { get; set; }

        public byte[] Image { get; set; }

        public string ImageLink { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        [StringLength(128)]
        public string WhoPinned_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
