﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitBrojIndeksa
{
    public class UniverzitetBrojIndeksa
    {
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public int DrzavaId { get; set; }

        public Drzava Drzava { get; set; }
    }
}
