using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Expensa
    {
        public int Mes { get; set; }
        public int Año { get; set; }
        public decimal GastoTotal { get; set; }
        public decimal ExpensasPorUnidad { get; set; }
        public int unidades { get; set; }
    }
}
