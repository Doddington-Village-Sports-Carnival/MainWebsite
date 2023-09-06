namespace DoddingtonCarnival.Blazor.Models
{
    public class CalendarEntry : BaseClass
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public List<string>? Description { get; set; }
        public string? Venue { get; set; }
        public string? WebLink { get; set; }
        public List<string>? Tags { get; set; }
        public string? Organiser { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsCancelled { get; set; }



        
        //public string LocationId { get; set; }
        //public string Link { get; set; }

        public string EventDates
        {
            get
            {
                if (this.StartDateTime.Date == this.EndDateTime.Date)
                {
                    return $"{this.StartDateTime.ToString("yyyy MMMM dd")}";
                }

                if (this.StartDateTime.Date.Month == this.EndDateTime.Date.Month)
                {
                    return $"{this.StartDateTime.ToString("yyyy MMMM dd")} to {this.EndDateTime.ToString("dd")}";
                }

                return $"{this.StartDateTime.ToString("yyyy MMMM dd")} to {this.EndDateTime.ToString("yyyy MMMM dd")}";
            }
        }

        public string EventTimes
        {
            get
            {
                if (this.StartDateTime.Date == this.EndDateTime.Date)
                {
                    if (this.StartDateTime.TimeOfDay == this.EndDateTime.TimeOfDay)
                    {
                        if (this.StartDateTime.TimeOfDay.Hours == 0 && this.StartDateTime.TimeOfDay.Minutes == 0)
                        {
                            return string.Empty;
                        }

                        return $"{this.StartDateTime.ToString("HH:mm")}";
                    }

                    return $"{this.StartDateTime.ToString("HH:mm")} to {this.EndDateTime.ToString("HH:mm")}";
                }

                return string.Empty;
            }
        }

        public bool IsDone
        {
            get
            {
                if (this.EndDateTime.Date < DateTime.Now)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
