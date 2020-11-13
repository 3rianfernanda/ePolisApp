using Epolis.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epolis.Reports
{
    public class SertifikatReport
    {
        private IWebHostEnvironment _oHostEnvironment;
        private readonly EpolisContext _context;

        public SertifikatReport(EpolisContext context, IWebHostEnvironment oHostEnvironment)
        {
            _context = context;
            _oHostEnvironment = oHostEnvironment;
        }

        #region Declaration

        int _maxColumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        #endregion

        public byte[] Report(Tpenutupan oSertifikats)
        {
            List<Tpenutupan> penutupan = _context.Tpenutupan.Where(x => x.ID == oSertifikats.ID).ToList();
            List<Tpenutupandetil> penutupandetil = _context.Tpenutupandetil.ToList();
            List<Tkontrakasuransi> kontrakasuransi = _context.Tkontrakasuransi.ToList();
            List<Mperusahaanasuransi> perusahaanasuransi = _context.Mperusahaanasuransi.ToList();
            List<Mjenisasuransi> jenisasuransi = _context.Mjenisasuransi.ToList();
            List<Tnasabah> nasabah = _context.Tnasabah.ToList();
            List<Tperluasan> perluasan = _context.Tperluasan.ToList();
            List<Tpertanggungan> pertanggungan = _context.Tpertanggungan.ToList();
            List<Mokupasi> okupasi = _context.Mokupasi.ToList();
            List<Mlookup> lookup = _context.Mlookup.ToList();

            var result = from a in penutupan
            join b in penutupandetil on a.ID equals b.TPENUTUPANID
            join c in kontrakasuransi on b.TKONTRAKASURANSIID equals c.ID
            join d in perusahaanasuransi on c.MPERUSAHAANASURANSIID equals d.ID
            join e in jenisasuransi on c.MJENISASURANSIID equals e.ID
            join f in perluasan on b.ID equals f.TPENUTUPANDETILID
            join g in nasabah on a.tnasabahID equals g.ID
            join h in pertanggungan on b.ID equals h.TPENUTUPANDETILID
            join i in okupasi on c.MOKUPASIID equals i.ID
            join j in lookup on c.RESIKO equals j.ID
            
                         select new AllrelationVm
                         {
                             Tpenutupan = a,
                             Tpenutupandetil = b,
                             Tkontrakasuransi = c,
                             Mperusahaanasuransi = d,
                             Mjenisasuransi = e,
                             Tperluasan = f,
                             Tnasabah = g,
                             Tpertanggungan = h,
                             Mokupasi = i,
                             Mlookup = j
                             
                         };

            foreach (var item in result)
            {
                var tperluasan = item.Tperluasan;
                var tpenutupan = item.Tpenutupan;
                var tpenutupandetil = item.Tpenutupandetil;
                var tkontrakasuransi = item.Tkontrakasuransi;
                var mperusahaanasuransi = item.Mperusahaanasuransi;
                var mjenisasuransi = item.Mjenisasuransi;
                var tnasabah = item.Tnasabah;
                var tpertanggungan = item.Tpertanggungan;
                var mokupasi = item.Mokupasi;
                var mlookup = item.Mlookup;

                _document = new Document();
                _document.SetPageSize(PageSize.A4);

                _pdfTable.WidthPercentage = 90;
                _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

                PdfWriter docWrite = PdfWriter.GetInstance(_document, _memoryStream);

                _document.Open();

                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 90;
                //0=Left, 1=Centre, 2=Right
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                Image image = Image.GetInstance(_oHostEnvironment.WebRootPath + "/Images/Tripa.jpg");
                image.ScaleAbsolute(200, 150);
                cell.AddElement(image);
                table.AddCell(cell);

                _document.Add(table);

                Chunk chunk = new Chunk("IKHTISAR PERTANGGUNGAN", FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.Black));
                _document.Add(chunk);

                //Horizontal Line
                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 90.0F, BaseColor.Black, Element.ALIGN_LEFT, 1)));
                _document.Add(line);

                Chunk chunk3 = new Chunk("Polis Standar Asuransi Indonesia", FontFactory.GetFont("Arial", 15, Font.BOLD, BaseColor.Black));
                _document.Add(chunk3);

                table = new PdfPTable(2);
                table.WidthPercentage = 90;
                //0=Left, 1=Centre, 2=Right
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                chunk = new Chunk("Nomor Polis", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("" + tpenutupan.NOPOLIS, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Policy Number", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                
                
                    chunk = new Chunk("Nama Tertanggung", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("" + tnasabah.NAMA, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Insured Name", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                chunk = new Chunk("Alamat", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + mperusahaanasuransi.ALAMAT, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Address", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Jangka Waktu Mulai", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Mulai dari tanggal " + tpenutupan.JANGKAWAKTUMULAI, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Start Period", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Jangka Waktu Selesai", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Sampai dengan " + tpenutupan.JANGKAWAKTUSELESAI, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("End Period", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Tanggal Order", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + tpenutupan.TGLINPUT.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Order Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Nomor Perjanjian Sekarang", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + tpenutupan.NOSKKNOW, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Agreement Number", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Nomor Perjanjian Terakhir", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + tpenutupan.NOSKK, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Current Agreement Number", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Jangka Waktu Tertanggung", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + tpenutupan.PERIODEBULAN + " Bulan", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Period of Insured", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                    chunk = new Chunk("Lokasi Resiko", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("" + tpenutupandetil.LOKASIOBJEKTERTANGGUNG, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Risk Location", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Jumlah Pertanggungan", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("" + tpenutupandetil.JUMLAHPERTANGGUNGAN, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Sum Insured", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);
                

                    chunk = new Chunk("Resiko", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("" + mlookup.VALUE, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Risk", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Kode Perluasan", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("" + tperluasan.KODEPERLUASAN, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Expansion Code", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    chunk = new Chunk("Kode Okupasi", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                chunk = new Chunk("" + mokupasi.KODEOKUPASI + "- " + mokupasi.NAMAOKUPASI, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);


                chunk = new Chunk("Occupation Code", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);

                    //Cell no 2
                    chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                    cell = new PdfPCell();
                    cell.Border = 0;
                    cell.AddElement(chunk);
                    table.AddCell(cell);


                chunk = new Chunk("Pembayaran", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                chunk.SetUnderline(BaseColor.Black, 0, 0, 6, -1, 1);
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("" + tpenutupan.PEMBAYARAN, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Payment", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                _document.Add(table);

                table = new PdfPTable(1);
                table.WidthPercentage = 90;
                //0=Left, 1=Centre, 2=Right
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                Chunk chunk1 = new Chunk("Dengan Kesaksian Yang Bertanda Tangan di bawah ini yang diberi wewenang sepatutnya oleh Penanggung dan atas nama Penanggung telah membubuhkan tanda tangannya.", FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.Black));
                _document.Add(chunk1);

                Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 90.0F, BaseColor.Black, Element.ALIGN_LEFT, 1)));
                _document.Add(line1);

                Chunk chunk2 = new Chunk("In witness whereof the Undersigned being duty authorized by the Insurers and on behalf of the Insurers has (have) hereunto set his (their) hand(s).", FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.Black));
                _document.Add(chunk2);

                _document.Add(table);

                table = new PdfPTable(3);
                table.WidthPercentage = 90;
                //0=Left, 1=Centre, 2=Right
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                chunk = new Chunk("   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("Bea Materai Lunas", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                chunk = new Chunk("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                //Cell no 2
                chunk = new Chunk("Jakarta, " + DateTime.Now.ToString("dd MMMM yyyy"), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.Black));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);

                _document.Add(table);

                _document.Close();
            }

            return _memoryStream.ToArray();

        }

    }
}
