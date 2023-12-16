using FastReport;
using Lab06.Models;
using Lab06.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace Lab06.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext ctx;
        private readonly IWebHostEnvironment _webHost;

        public HangHoaController(MyeStoreContext ctx, IWebHostEnvironment webHost)
        {
            this.ctx = ctx;
            _webHost = webHost;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var hangHoas = await ctx.HangHoas.ToListAsync();
            return View(hangHoas);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.Loais = new SelectList(ctx.Loais, "MaLoai", "TenLoai");
            ViewBag.NCCs = new SelectList(ctx.NhaCungCaps, "MaNcc", "TenCongTy");
            var hang = await ctx.HangHoas.FirstOrDefaultAsync(hh => hh.MaHh == id);
            return View(hang);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HangHoa hh)
        {
            if (hh.HinhFile != null && hh.HinhFile.Length > 0)
            {
                hh.Hinh = hh.HinhFile.FileName;
                string fileSavePath = Path.Combine(_webHost.WebRootPath, "Hinh", "HangHoa", hh.Hinh);
                using (var stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await hh.HinhFile.CopyToAsync(stream);
                }
            }
            ctx.Update(hh);
            await ctx.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var hh = await ctx.HangHoas.FirstOrDefaultAsync(hh => hh.MaHh == id);
            return View(hh);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Search(string? keyword, double? priceFrom, double? priceTo)
        {
            var data = ctx.HangHoas.AsQueryable();
            if(keyword != null)
            {
                data = data.Where(hh => hh.TenHh.Contains(keyword));
            }
            if(priceFrom != null)
            {
                data = data.Where(hh => hh.DonGia >= priceFrom);    
            }
            if(priceTo != null)
            {
                data = data.Where(hh => hh.DonGia <= priceTo);
            }
            var result = await data.Select(hh => new HangHoaVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia ?? 0,
                Hinh = hh.Hinh,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToListAsync();
            return View(result) ;
        }

        [HttpGet]
        public async Task<IActionResult> Statistic()
        {
            var model = ctx.HangHoas
                     .GroupBy(hh => hh.MaLoai)
                     .Select(g => new ThongKeViewModel
                     {
                         TenLoai = g.First().MaLoaiNavigation.TenLoai,
                         DoanhThu = (double)g.Sum(hh => hh.DonGia),
                         SoHH = g.Count(),
                         MinPrice = (double)g.Min(hh => hh.DonGia),
                         MaxPrice = (double)g.Max(hh => hh.DonGia),
                         AvgPrice = (double)g.Average(hh => hh.DonGia),
                     })
                     .ToList();
            model.ForEach(item =>
            {
                item.DoanhThu = Math.Round(item.DoanhThu, 3);
                item.MinPrice = Math.Round(item.MinPrice, 3);
                item.MaxPrice = Math.Round(item.MaxPrice, 3);
                item.AvgPrice = Math.Round(item.AvgPrice, 3);
            });
            return View(model);
        }

        /*public FileResult Report()
        {
            FastReport.Utils.Config.WebMode = true;
            Report rep = new Report();
            string path = Server.MapPath("~/KhachHang.frx");
            rep.Prepare(path);

            List<KhachHang> khachHangs = _context.KhachHangs.ToList();

            rep.RegisterData(khachHangs, "KhachHangRef");

            if (rep.Report.Prepare())
            {
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = "Subject Report";
                pdfExport.Title = "Report Title";
                System.IO.MemoryStream ms = new MemoryStream();
                rep.Report.Export(pdfExport, ms);
                rep.Dispose();
                pdfExport.Dispose();
                ms.Position = 0;

                return File(ms, "application/pdf", "khachhangreport.pdf");
            }

        }*/
    }
}
