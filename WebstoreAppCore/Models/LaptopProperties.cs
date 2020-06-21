using System;
using System.Collections.Generic;

namespace WebStoreAppCore.Models
{
    public partial class LaptopProperties
    {
        public int ProductId { get; set; }
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

        public virtual Products Product { get; set; }
    }
}
