#pragma checksum "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09b5bf9cb9b443dc95a811c2e790ce6865896717"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_ShowSessionMarksOfStudent), @"mvc.1.0.view", @"/Views/Student/ShowSessionMarksOfStudent.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09b5bf9cb9b443dc95a811c2e790ce6865896717", @"/Views/Student/ShowSessionMarksOfStudent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_ShowSessionMarksOfStudent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LinkedList<Model.SessionMarkModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
  
    ViewData["Title"] = "Marks of student";
    int i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table id=""table"" class=""text-center table table-striped"">
    <thead class=""thead-light"">
    <th scope=""col"">№</th>
    <th scope=""col"">Mark</th>
    <th scope=""col"">With</th>
    <th scope=""col"">To</th>
    <th scope=""col"">Name</th>
    </thead>
    <tbody>
");
#nullable restore
#line 15 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
     foreach (var item in Model)
    {
        i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 20 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 23 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
           Write(item.Mark);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 26 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
           Write(item.With);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 29 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
           Write(item.To);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 32 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
           Write(item.NameCourse);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 35 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Student/ShowSessionMarksOfStudent.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LinkedList<Model.SessionMarkModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
