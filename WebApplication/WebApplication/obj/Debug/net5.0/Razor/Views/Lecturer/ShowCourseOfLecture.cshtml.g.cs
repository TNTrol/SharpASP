#pragma checksum "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b13cadafb72eb593a978488122f200f6f9ad09ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lecturer_ShowCourseOfLecture), @"mvc.1.0.view", @"/Views/Lecturer/ShowCourseOfLecture.cshtml")]
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
#nullable restore
#line 1 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
using Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b13cadafb72eb593a978488122f200f6f9ad09ae", @"/Views/Lecturer/ShowCourseOfLecture.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Lecturer_ShowCourseOfLecture : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LinkedList<Model.CourseLecturerModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Lecturer/AddCourse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fill-modal btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
  
    ViewData["Title"] = "Course of Lecturer";
    int i = 0;
    int id = (int) ViewData["idLecturer"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"form-inline\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae5059", async() => {
                WriteLiteral("\n        <input name=\"idLecturer\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 296, "\"", 327, 1);
#nullable restore
#line 12 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
WriteAttributeValue("", 304, ViewData["idLecturer"], 304, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n        <select id=\"typeFilter1\" class=\"form-control\" name=\"idSubject\">\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae5852", async() => {
                    WriteLiteral("Select subject");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 15 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
             foreach (var subject in ViewData["subject"] as LinkedList<SubjectModel>)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae7389", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 17 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                                        Write(subject.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                   WriteLiteral(subject.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 18 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </select>\n                <select id=\"typeFilter2\" class=\"form-control\" name=\"idSemester\">\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae9639", async() => {
                    WriteLiteral("Select semester");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 22 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                     foreach (var subject in ViewData["semester"] as LinkedList<SemesterModel>)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae11203", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 24 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                                                Write(subject.With);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 24 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                                                                Write(subject.To);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                           WriteLiteral(subject.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 25 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\n        <button type=\"submit\" class=\"btn btn-primary mb-2\">Add mark</button>\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<table id=""table"" class=""text-center table table-striped"">
    <thead class=""thead-light"">
    <th scope=""col"">№</th>
    <th scope=""col"">Name</th>
    <th scope=""col"">With</th>
    <th scope=""col"">To</th>
    <th scope=""col"">Action</th>
    </thead>
    <tbody>
");
#nullable restore
#line 40 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
     foreach (var item in Model)
    {
        i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 45 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 48 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 51 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
           Write(item.With);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 54 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
           Write(item.To);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                <button type=\"button\" class=\"fill-modal btn btn-outline-primary\" data-toggle=\"modal\"");
            BeginWriteAttribute("value", " value=\"", 1838, "\"", 1854, 1);
#nullable restore
#line 57 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
WriteAttributeValue("", 1846, item.Id, 1846, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#addingModal\">\n                    Edit\n                </button>\n            \n");
            WriteLiteral("            \n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae17637", async() => {
                WriteLiteral("\n                    Students\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2217, "~/Lecturer/ShowFollowingStudent/?idCourse=", 2217, 42, true);
#nullable restore
#line 65 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
AddHtmlAttributeValue("", 2259, item.Id, 2259, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2267, "&idLecturer=", 2267, 12, true);
#nullable restore
#line 65 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
AddHtmlAttributeValue("", 2279, id, 2279, 3, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13cadafb72eb593a978488122f200f6f9ad09ae19630", async() => {
                WriteLiteral("\n                    Delete\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2403, "~/Lecturer/DeleteCourse/?idCourse=", 2403, 34, true);
#nullable restore
#line 68 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
AddHtmlAttributeValue("", 2437, item.Id, 2437, 8, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2445, "&idLecturer=", 2445, 12, true);
#nullable restore
#line 68 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
AddHtmlAttributeValue("", 2457, id, 2457, 3, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n            </td>\n        </tr>\n");
#nullable restore
#line 74 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Lecturer/ShowCourseOfLecture.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LinkedList<Model.CourseLecturerModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
