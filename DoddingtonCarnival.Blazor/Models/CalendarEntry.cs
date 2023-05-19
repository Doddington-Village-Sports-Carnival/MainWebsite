namespace DoddingtonCarnival.Blazor.Models
{
    public class CalendarEntry : BaseClass
    {
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Descriptions { get; set; }
        public string LocationId { get; set; }
        public List<string> Tags { get; set; }

        public string Link { get; set; }

        public string EventDates
        {
            get
            {
                if (this.Start.Date == this.End.Date)
                {
                    return $"{this.Start.ToString("yyyy MMMM dd")}";
                }

                if (this.Start.Date.Month == this.End.Date.Month)
                {
                    return $"{this.Start.ToString("yyyy MMMM dd")} to {this.End.ToString("dd")}";
                }

                return $"{this.Start.ToString("yyyy MMMM dd")} to {this.End.ToString("yyyy MMMM dd")}";
            }
        }

        public string EventTimes
        {
            get
            {
                if (this.Start.Date == this.End.Date)
                {
                    if (this.Start.TimeOfDay == this.End.TimeOfDay)
                    {
                        if (this.Start.TimeOfDay.Hours == 0 && this.Start.TimeOfDay.Minutes == 0)
                        {
                            return string.Empty;
                        }

                        return $"{this.Start.ToString("HH:mm")}";
                    }

                    return $"{this.Start.ToString("HH:mm")} to {this.End.ToString("HH:mm")}";
                }

                return string.Empty;
            }
        }

        public bool IsDone
        {
            get
            {
                if (this.End.Date < DateTime.Now)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
