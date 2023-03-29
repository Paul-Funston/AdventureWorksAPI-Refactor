using System.ComponentModel.DataAnnotations;

namespace Lab3.Model
{
    public class StopSchedule
    {
        [Key]
        public int ID { get; set; }
        public Stop Stop { get; set; }
        public Route Route { get; set; }
        public DateTime ScheduledArrival { get; set; }
    }
}
