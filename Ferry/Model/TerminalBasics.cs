using Newtonsoft.Json;

namespace Ferry.Model
{
    [WsdotModel("terminals", "terminalbasics")]
    public class TerminalBasics
    {
        [JsonProperty("TerminalID")]
        public int TerminalId { get; set; }
        [JsonProperty("TerminalSubjectID")]
        public int TerminalSubjectId { get; set; }
        [JsonProperty("RegionID")]
        public int RegionId{ get; set; }
        public string TerminalName { get; set; }
        public string TerminalAbbrev { get; set; }
        public int SortSeq { get; set; }
        public bool OverheadPassengerLoading { get; set; }
        public bool Elevator { get; set; }
        public bool WaitingRoom { get; set; }
        public bool FoodService { get; set; }
        public bool Restroom { get; set; }

    }
}