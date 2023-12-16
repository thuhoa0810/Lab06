using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Lab06.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lab06.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly MyeStoreContext _context;
        private readonly IConfiguration _configuration;

        public ReportController(IWebHostEnvironment webHostEnvironment, MyeStoreContext context, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetHangHoaListByLoai(int ID)
        {
            WebReport web = new WebReport();
            //Load the first report
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\HangHoatheoLoai.frx";
            web.Report.Load(path);

            //Passing connectionString in Fast Report
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var conn = mssqlDataConnection.ConnectionString;
            string tenloai = _context.Loais.Where(loai => loai.MaLoai == ID).FirstOrDefault().TenLoai;            

            web.Report.SetParameterValue("CONN", conn);
            web.Report.SetParameterValue("maloai", ID);
            web.Report.SetParameterValue("tenloai", tenloai);
            ViewBag.ID = ID;
            return View(web);
        }


        public IActionResult ExportPDF(int ID)
        {
            WebReport web = new WebReport();
            //Load the first report
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\HangHoatheoLoai.frx";
            web.Report.Load(path);

            //Passing connectionString in Fast Report
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var conn = mssqlDataConnection.ConnectionString;
            string tenloai = _context.Loais.Where(loai => loai.MaLoai == ID).FirstOrDefault().TenLoai;

            web.Report.SetParameterValue("CONN", conn);
            web.Report.SetParameterValue("maloai", ID);
            web.Report.SetParameterValue("tenloai", tenloai);

            web.Report.Prepare();
            // save file in stream
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;
            // return stream in browser
            return File(stream, "application/zip", "report.pdf");
        }

    }
}
