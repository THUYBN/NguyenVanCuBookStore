using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
