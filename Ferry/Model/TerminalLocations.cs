using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ferry.Model
{
    [WsdotModel("terminals", "terminallocations")]
    public class TerminalLocations
   {
       [JsonProperty("TerminalID")]
        public int TerminalId { get; set; }
       [JsonProperty("TerminalSubjectID")]
        public int TerminalSubjectId { get; set; }
       [JsonProperty("RegionId")]
        public int RegionId { get; set; }
        public string TerminalName { get; set; }
        public string TerminalAbbrev { get; set; }
        public int SortSeq { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AddressLineOne { get; set; }
        public object AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string MapLink { get; set; }
        public string Directions { get; set; }
        public List<DispGISZoomLoc> DispGISZoomLoc { get; set; }
    }

}