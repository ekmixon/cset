using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSETWebCore.Business.Authorization;
using CSETWebCore.Interfaces.Helpers;
using CSETWebCore.Reports.Helper;
using CSETWebCore.Business.Reports;
using CSETWebCore.Interfaces.Reports;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CSETWebCore.Reports.Controllers
{
    public class EdmController : Controller
    {
        private readonly ITokenManager _token;
        private readonly IReportsDataBusiness _reports;
        private readonly IViewEngine _engine;

        public EdmController(ITokenManager token, IReportsDataBusiness reports, IViewEngine engine)
        {
            _token = token;
            _reports = reports;
            _engine = engine;
        }

        [HttpGet]
        [CsetAuthorize]
        [Route("getDeficiencyPdf")]
        public async Task<IActionResult> CreateDeficiencyReportPdf()
        {
            var assessmentId = _token.AssessmentForUser();
            _reports.SetReportsAssessmentId(assessmentId);

            var reportHtml = await RenderDeficiencyReport();

            var pdfRenderer = new IronPdf.ChromePdfRenderer();
            var pdf = await pdfRenderer.RenderHtmlAsPdfAsync(reportHtml);

            return File(pdf.BinaryData, "application/pdf", "deficiencyReport.pdf");
        }

        //TODO: Extract common features for this and CrrController to prevent code reuse
        private async Task<string> RenderDeficiencyReport()
        {
            // View model and data
            TempData["Links"] = UrlStringHelper.GetBaseUrl(Request);
            ViewData.Model = new MaturityBasicReportData
            {
                DeficienciesList = _reports.GetMaturityDeficiencies(),
                Information = _reports.GetInformation()
            };

            // Building the html string
            await using var sw = new StringWriter();
            var viewResult = _engine.FindView(ControllerContext, "DeficiencyReport", false);
            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData,
                TempData, sw, new HtmlHelperOptions());
            await viewResult.View.RenderAsync(viewContext);

            return sw.GetStringBuilder().ToString();
        }
    }
}
