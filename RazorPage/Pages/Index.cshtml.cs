using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Templating.Core;
using RazorClassLibrary1.Views;
using z.Report.Binary;
using z.Report.Local;
using z.Report.Types;

namespace RazorPage.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {

    }


    public async Task<IActionResult> OnPost()
    {
        //var html = this.RenderViewAsync("Report1").Result;
        //Engine.Razor.RunCompile(File.ReadAllText(fullTemplateFilePath), templateName, null, model);
        var model = new Report1Model() { Name = "محمد کمائی" };
        var html = await RazorTemplateEngine.RenderAsync("~/Views/Index2.cshtml", model);

        var rs = new LocalReporting()
                .KillRunningReportProcesses()
                .UseBinary(ReportBinary.GetBinary())
                .Configure(cfg => cfg.AllowedLocalFilesAccess().FileSystemStore().BaseUrlAsWorkingDirectory())
                .AsUtility()
                .Create();
        var generatedPdf = await rs.RenderAsync(new RenderRequest
        {
            Template = new Template
            {
                Recipe = Recipe.ChromePdf,
                Engine = Engine.None,
                Content = html,
                Chrome = new Chrome
                {
                    MarginTop = "10",
                    MarginBottom = "10",
                    MarginLeft = "50",
                    MarginRight = "50"
                }
            }
        });
        return File(generatedPdf.Content, generatedPdf.Meta.ContentType, "GeneratedPdfFile.pdf");

        //return Content(html);
    }


    //public IEnumerable<object> GetMembers()
    //{
    //    var members = db.MembersTb
    //        .Select(m => new { Id = m.MemberId, FullName = m.FullName })
    //        .ToList();

    //    //foreach (var item in members)
    //    //{
    //    //    item.Id = item.Id + 1;
    //    //    item.FullName = item.FullName + " " + "*";
    //    //}

    //    return members;
    //}
}