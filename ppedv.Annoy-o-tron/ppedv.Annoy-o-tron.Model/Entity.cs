using System;
using System.Collections;

namespace ppedv.Annoy_o_tron.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}