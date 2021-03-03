using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace S3Train.Domain
{
    public class HasPermission : AuthorizeAttribute
    {
        //Khai báo chức năng
        public string TenCN { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Lấy thông tin người dùng lưu trong session
            NhanVien nv = (NhanVien)HttpContext.Current.Session["tendn"];
            if(nv != null)
            {
                Guid roleID = nv.MaNhom;
                CapQuyen cq = null;
                try
                {
                    //cq = Common.
                }
                catch
                {

                }
            }
            return false;
        }
    }
}
