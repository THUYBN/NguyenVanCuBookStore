using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using S3Train.Domain;
using S3Train.Service;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class CustomerRoleProvider : RoleProvider
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public override string[] GetRolesForUser(string username)
        {
            NhanVien user = db.NhanViens.Single(x => x.Id.Equals(username));
            if (user != null)
            {
                return new String[] { user.NhomNguoiDung.TenNhom };

            }
            else
            {
                return new String[] { };
            }
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}