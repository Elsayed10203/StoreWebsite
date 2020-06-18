using System;
using System.Collections.Generic;

namespace WebstoreAppCore.Models
{
    public partial class LaptopProperty
    {
        public int? ProdId { get; set; }
        public string ScreenSize { get; set; }
        public string ScreenType { get; set; }
        public string Ram { get; set; }
        public string CameraPropertry { get; set; }
        public string Battery { get; set; }
        public string ModeNo { get; set; }
        public string FingerPrint { get; set; }
        public string WaterResist { get; set; }
        public string Processor { get; set; }
        public string HardType { get; set; }
        public string HardStorage { get; set; }
        public string Genaration { get; set; }
        public string ExtraProperty { get; set; }

        public virtual Product Prod { get; set; }
    }
}
