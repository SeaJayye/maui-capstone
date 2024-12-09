namespace maui_capstone.Models
{
    public class TimerModel
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get; set; }
    }
}