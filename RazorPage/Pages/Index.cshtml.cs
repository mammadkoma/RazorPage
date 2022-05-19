using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        public List<object> tests { get; set; }

        public void OnGet()
        {

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
}