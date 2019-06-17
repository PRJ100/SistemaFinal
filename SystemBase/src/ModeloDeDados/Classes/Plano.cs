﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModeloDeDados.Classes
{
    public class Plano
    {
        [Key]
        public int PlanoId { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Numero { get; set; }
    }
}
