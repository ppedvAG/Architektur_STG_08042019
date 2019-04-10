using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Annoy_o_tron.Model.ApiDTO
{
    public class ProcessDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }

    }
}
