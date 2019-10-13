using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrReportViewer.Relatorio
{
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("nome", typeof(string));
                dt.Columns.Add("endereco", typeof(string));
                dt.Columns.Add("nr_compra", typeof(int));
                dt.Columns.Add("desc_compra", typeof(string));
                dt.Columns.Add("vlr_compra", typeof(double));

                for (int i = 1; i <= 100; i++)
                {
                    //Gerar um número aleatório para não ter a mesma quantidade de item para todos
                    int randNum = new Random().Next(5);                    

                    for (int x = 1; x <= randNum; x++)
                    {
                        dt.Rows.Add(i, "Cliente " + i, "Rua  nº " + i, x, "Item Nº " + x, x * 100);
                    }
                }

                #region Impressão do relatório
                ReportDataSource RDS = new ReportDataSource("DataSetFuncionario", dt);
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.ReportPath = "Relatorio/Relatorio.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(RDS);
                ReportViewer1.LocalReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string deviceInfo =
                  "<DeviceInfo>" +
                  "  <OutputFormat>PDF</OutputFormat>" +
                  "  <PageWidth>21cm</PageWidth>" +
                  "  <PageHeight>29cm</PageHeight>" +
                  "  <MarginTop>0.1in</MarginTop>" +
                  "  <MarginLeft>0in</MarginLeft>" +
                  "  <MarginRight>0in</MarginRight>" +
                  "  <MarginBottom>0.1in</MarginBottom>" +
                  "</DeviceInfo>";


                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = mimeType;
                HttpContext.Current.Response.AddHeader("content-disposition", ("inline; filename=ExportedReport." + "PDF"));
                HttpContext.Current.Response.BinaryWrite(bytes);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}