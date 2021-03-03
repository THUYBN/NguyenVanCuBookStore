using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3Train.Domain
{
    public class ManHinhTrangChu : EntityBase
    {
        public Guid MaSP { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventUrl{ get; set; }
        public string ImagePath { get; set; }
        public ProductAdvertisementType AdType { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

    }
}