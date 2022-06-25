using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templater.Miner.Models
{
    public class ExpressionFM
    {
        public string FoundText { get; set; }
        public int IndexStart { get; set; }
        public int IndexEnd { get; set; }

        public Guid GeneratedId { get; set; }
    }
}