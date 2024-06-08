using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Store.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ReportController: Controller
    {
        [AllowAnonymous]
        public ActionResult ShowReportOrder(int NumberOrder = 1)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.SizeToReportContent = true;
            reportViewer.ZoomMode = ZoomMode.FullPage;
            reportViewer.Width = 10000;
            reportViewer.Height = Unit.Percentage(100);

            reportViewer.ShowParameterPrompts = false;
            reportViewer.ShowToolBar = true;
            reportViewer.ShowPrintButton = true;
            reportViewer.ShowFindControls = true;
            reportViewer.ShowRefreshButton = true;
            reportViewer.ShowPageNavigationControls = true;
            reportViewer.ShowBackButton = true;
            reportViewer.ShowExportControls = true;

            reportViewer.AsyncRendering = true;

            reportViewer.ServerReport.ReportServerUrl = new Uri("http://laptop-fo5qin3i:4848/ReportServer");
            reportViewer.ServerReport.ReportPath = "/Order2";

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("NumberOrder", NumberOrder.ToString()));
            reportViewer.ServerReport.SetParameters(parameters);
            reportViewer.ServerReport.Refresh();
            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}