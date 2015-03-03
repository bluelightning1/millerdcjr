using Generic‎.Common‎.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎
{
    public class VendorFacility
    {
        public string Vendor { get; private set; }
        public string FacilityName { get; private set; }
        public string FacilityNumber { get; private set; }
        public string ListenerDNS { get; private set; }

        public VendorFacility()
        {
            Load();
        }

        private void Load()
        {
            var vendor = ApplicationConfiguration.GetVendorFacility();
            if (string.IsNullOrEmpty(vendor))
            {

            }
            else
            {
                var arr = vendor.Split(ApplicationConfiguration.GetDefaultSplitter(), StringSplitOptions.None);
                this.Vendor = arr[0];
                this.FacilityName = arr[1];
                this.FacilityNumber = arr[2];
                this.ListenerDNS = arr[3];
            }
        }
    }
}
