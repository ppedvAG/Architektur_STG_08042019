namespace ppedv.Annoy_o_tron.Model
{
    public class Weekly : Template
    {
        public int WeekInterval { get; set; } = 1;
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}