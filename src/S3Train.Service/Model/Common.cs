using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Model
{
    public class Common
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();
        public static ApplicationDbContext db
        {
            get { return Common._db; }
            set { Common._db = value; }
        }
    }
}
