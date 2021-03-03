
using S3Train.DTOs;
using System;

namespace S3Train.Web.Models
{
    public class SliderItemViewModel
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventUrl { get; set; }
        public string ImagePath { get; set; }
    }
}