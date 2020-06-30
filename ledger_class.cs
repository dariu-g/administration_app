using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AplicatieDisertatie
{
    public class ledger_class
    {
        public int id_reparatie { get; set; }

        public string nume { get; set; }

        public string prenume { get; set; }
        
        public string nr_telefon { get; set; }

        public string tip_telefon { get; set; }

        public string model { get; set; }

        public Int64 imei { get; set; }

        public Boolean garantie { get; set; }

        public string culoare { get; set; }

        public string cod_telefon { get; set; }

        public DateTime data_primirii { get; set; }

        public DateTime data_predarii { get; set; }

        public string defect_constatat { get; set; }

        public string piese_inlocuite { get; set; }

        public string observatii { get; set; }

        public decimal pret_achitat { get; set; }

        public decimal pret_avans { get; set; }

        public decimal pret_estimativ { get; set; }

        public string termen_rezolvare { get; set; }

        public string termen_garantie { get; set; }

        public string verdict_reparatie { get; set; }

        public string utilizator { get; set; }
    }
}
