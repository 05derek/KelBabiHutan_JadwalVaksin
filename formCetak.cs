using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace UCP_1_Revisi
{
    public partial class formCetak : Form
    {
        private string connectionString = "Server=localhost;Database=db_vaksin;User Id=derek;Password=123;Encrypt=True;TrustServerCertificate=True;";

        private DataTable dtReport = new DataTable();
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        private int currentRow = 0;
        private int pageWidth = 0;
        private Font printFont = new Font("Consolas", 10);
        private Brush printBrush = Brushes.Black;

        public formCetak()
        {
            InitializeComponent();
            LoadReportData();

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void LoadReportData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReportBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tanggal_mulai", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tanggal_selesai", DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtReport.Clear();
                    da.Fill(dtReport);

                    dgvCetak.DataSource = dtReport;
                    lblTotal.Text = $"Total Data: {dtReport.Rows.Count}";

                    if (dtReport.Rows.Count == 0)
                    {
                        lblTotal.Text = "Tidak ada data untuk dicetak";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message);
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtReport.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            pageWidth = (int)(e.PageBounds.Width * 0.95);
            Graphics graphics = e.Graphics;
            Font headerFont = new Font("Consolas", 14, FontStyle.Bold);
            Font subHeaderFont = new Font("Consolas", 12, FontStyle.Bold);
            Font contentFont = new Font("Consolas", 10);
            int y = 40;

            graphics.DrawString("LAPORAN BOOKING VAKSIN", headerFont, printBrush, new PointF(20, y));
            y += 35;

            graphics.DrawString($"Tanggal Cetak: {DateTime.Now:dd MMMM yyyy HH:mm:ss}", subHeaderFont, printBrush, new PointF(20, y));
            y += 30;

            graphics.DrawString($"Total Data: {dtReport.Rows.Count}", subHeaderFont, printBrush, new PointF(20, y));
            y += 40;

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, 20, y, pageWidth, y);
            y += 10;

            string[] headers = { "ID", "Nama User", "NIK", "No HP", "Vaksin", "Tanggal", "Waktu", "Status" };
            int[] colWidth = { 40, 150, 120, 100, 120, 100, 80, 90 };
            int x = 20;

            graphics.DrawString("No", new Font("Consolas", 10, FontStyle.Bold), printBrush, new PointF(x, y));
            x += 35;

            for (int i = 0; i < headers.Length; i++)
            {
                graphics.DrawString(headers[i], new Font("Consolas", 10, FontStyle.Bold), printBrush, new PointF(x, y));
                x += colWidth[i];
            }

            y += 25;
            graphics.DrawLine(pen, 20, y, pageWidth, y);
            y += 5;

            int rowCount = 0;
            int totalPages = (int)Math.Ceiling((double)dtReport.Rows.Count / 30);

            for (int i = currentRow; i < dtReport.Rows.Count && i < currentRow + 30; i++)
            {
                DataRow row = dtReport.Rows[i];
                x = 20;

                graphics.DrawString((i + 1).ToString(), contentFont, printBrush, new PointF(x, y));
                x += 35;

                graphics.DrawString(row["booking_id"].ToString(), contentFont, printBrush, new PointF(x, y));
                x += colWidth[0];

                string nama = row["nama_user"].ToString();
                if (nama.Length > 15) nama = nama.Substring(0, 15) + "...";
                graphics.DrawString(nama, contentFont, printBrush, new PointF(x, y));
                x += colWidth[1];

                graphics.DrawString(row["nik"].ToString(), contentFont, printBrush, new PointF(x, y));
                x += colWidth[2];

                graphics.DrawString(row["no_hp"].ToString(), contentFont, printBrush, new PointF(x, y));
                x += colWidth[3];

                string vaksin = row["nama_vaksin"].ToString();
                if (vaksin.Length > 15) vaksin = vaksin.Substring(0, 15) + "...";
                graphics.DrawString(vaksin, contentFont, printBrush, new PointF(x, y));
                x += colWidth[4];

                graphics.DrawString(Convert.ToDateTime(row["tanggal"]).ToString("dd/MM/yyyy"), contentFont, printBrush, new PointF(x, y));
                x += colWidth[5];

                graphics.DrawString(row["waktu"].ToString().Substring(0, 5), contentFont, printBrush, new PointF(x, y));
                x += colWidth[6];

                graphics.DrawString(row["status"].ToString(), contentFont, printBrush, new PointF(x, y));

                y += 25;
                rowCount++;
            }

            y += 20;
            graphics.DrawLine(pen, 20, y, pageWidth, y);
            y += 10;

            int currentPage = (currentRow / 30) + 1;
            graphics.DrawString($"Halaman {currentPage} dari {totalPages}", contentFont, printBrush, new PointF(20, y));

            currentRow += rowCount;
            if (currentRow < dtReport.Rows.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                currentRow = 0;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DateTime mulai = dtpMulai.Value.Date;
                    DateTime selesai = dtpSelesai.Value.Date;

                    SqlCommand cmd = new SqlCommand("sp_ReportBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tanggal_mulai", mulai);
                    cmd.Parameters.AddWithValue("@tanggal_selesai", selesai);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtReport.Clear();
                    da.Fill(dtReport);

                    dgvCetak.DataSource = dtReport;
                    lblTotal.Text = $"Total Data: {dtReport.Rows.Count} (Filter: {mulai:dd/MM/yyyy} - {selesai:dd/MM/yyyy})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filter: " + ex.Message);
            }
        }
    }
}