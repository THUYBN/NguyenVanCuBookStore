using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S3Train.Domain
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string HoTen { get; set; }
        public string QuocGia { get; set; }
        public string ThanhPho { get; set; }
        public string Quan { get; set; }
        public string Phuong { get; set; }
        public string DiaChi { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public bool TrangThai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}