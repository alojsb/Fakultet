﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitBrojIndeksa
{
    public class StipendijaGodinaBrojIndeksa
    {
        public int Id { get; set; }
        public int StipendijaId { get; set; }
        public int Godina {  get; set; }
        public int Iznos { get; set; }
        public bool Aktivna { get; set; }

        public StipendijaBrojIndeksa Stipendija { get; set; }


        public override string ToString()
        {
            return Stipendija?.Naziv ?? $"Stipendija #{Id}";
        }

    }
}
