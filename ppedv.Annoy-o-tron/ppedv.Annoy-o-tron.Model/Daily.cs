namespace ppedv.Annoy_o_tron.Model
{
    public class Daily : Template
    {
        public bool OnlyWorkdays { get; set; } //else DayIntervall
        public int DayInterval { get; set; } = 1;
    }
}