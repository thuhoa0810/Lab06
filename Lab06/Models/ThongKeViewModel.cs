using System.ComponentModel.DataAnnotations;

namespace Lab06.Models
{
    public class ThongKeViewModel
    {
        public string? TenLoai { get; set; }
        [DataType(DataType.Currency)]
        public double DoanhThu { get; set; }
        public int SoHH { get; set; }
        [DataType(DataType.Currency)]
        public double MinPrice { get; set; }
        [DataType(DataType.Currency)]
        public double MaxPrice { get; set; }
        [DataType(DataType.Currency)]
        public double AvgPrice { get; set; }
    }
}
