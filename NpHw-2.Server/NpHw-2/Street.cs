using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpHw_2
{
    public class Street
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PostIndex { get; set; }
        public string Name { get; set; }
    }
}
