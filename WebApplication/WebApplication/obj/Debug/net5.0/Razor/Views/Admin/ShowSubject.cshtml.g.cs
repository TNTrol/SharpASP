#pragma checksum "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8766fdb3f862b1b01e363f6555a059f9de9a63f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ShowSubject), @"mvc.1.0.view", @"/Views/Admin/ShowSubject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8766fdb3f862b1b01e363f6555a059f9de9a63f", @"/Views/Admin/ShowSubject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ShowSubject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication.Utils.PaginatedList<Model.SubjectModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/AddSubject"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowSubject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
  
    ViewData["Title"] = "Student";
    int i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-inline\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8766fdb3f862b1b01e363f6555a059f9de9a63f4758", async() => {
                WriteLiteral(@"
        <div class=""form-group mx-sm-3 mb-2"">
            <label for=""name"" class=""sr-only"" >Name of subject</label>
            <input type=""text"" class=""form-control"" id=""name"" name = ""name"" placeholder=""Name"">
        </div>
        <button type=""submit"" class=""btn btn-primary mb-2"">Add subject</button>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
    <div id=""editor"" class=""form-inline"">
    
        <div class=""form-group mx-sm-3 mb-2"">
            <label for=""new_name"" class=""sr-only"" >Name of subject</label>
            <input type=""text"" class=""form-control"" id=""new_name"" name = ""new_name"" placeholder=""Name"">
        </div>
        <button type=""submit"" class=""btn btn-primary mb-2"" onclick=""send_post()"">Change name subject</button>
        <label class=""sr-only""  id = ""status""></label>
    </div>
</div>
<table id=""table"" class=""text-center table table-striped"">
        <thead class=""thead-light"">
        <th scope=""col"">№</th>
        <th scope=""col"">Name</th>
        <th scope=""col"">Count of course</th>
        <th scope=""col"">Action</th>
        </thead>
        <tbody>
");
#nullable restore
#line 33 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
         foreach (var item in Model)
        {
            i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 38 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 41 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                                    ");
#nullable restore
#line 44 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
                               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                <td>\n                    <button type=\"button\" class=\"fill-modal btn btn-outline-primary\" data-toggle=\"modal\"");
            BeginWriteAttribute("value", " value=\"", 1734, "\"", 1750, 1);
#nullable restore
#line 47 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
WriteAttributeValue("", 1742, item.Id, 1742, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#addingModal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1778, "\"", 1808, 5);
            WriteAttributeValue("", 1788, "toggle(", 1788, 7, true);
#nullable restore
#line 47 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
WriteAttributeValue("", 1795, i, 1795, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1797, ",", 1797, 1, true);
#nullable restore
#line 47 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
WriteAttributeValue(" ", 1798, item.Id, 1799, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1807, ")", 1807, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\n                        Edit\n                    </button>\n                    \n                </td>\n            </tr>\n");
#nullable restore
#line 53 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n");
#nullable restore
#line 56 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
          
            var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
            var nextDisabled = !Model.HasNextPage ? "disabled" : "";
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8766fdb3f862b1b01e363f6555a059f9de9a63f10945", async() => {
                WriteLiteral("\n          Pervios\n          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
             WriteLiteral(Model.PageIndex-1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2223, "btn", 2223, 3, true);
            AddHtmlAttributeValue(" ", 2226, "btn-default", 2227, 12, true);
#nullable restore
#line 62 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
AddHtmlAttributeValue(" ", 2238, prevDisabled, 2239, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8766fdb3f862b1b01e363f6555a059f9de9a63f13703", async() => {
                WriteLiteral("\n          Next\n          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
             WriteLiteral(Model.PageIndex+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2383, "btn", 2383, 3, true);
            AddHtmlAttributeValue(" ", 2386, "btn-default", 2387, 12, true);
#nullable restore
#line 67 "/home/tntrol/RiderProjects/WebApplication/WebApplication/Views/Admin/ShowSubject.cshtml"
AddHtmlAttributeValue(" ", 2398, nextDisabled, 2399, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
document.getElementById('editor').style.display = ""none"";
var index = -1;
var _id = -1;

function toggle(n, id) {
    _id = id;
    if (index === n){
            document.getElementById('editor').style.display = ""none"";
            index = -1;
            return;
        }
    index = n;
    document.getElementById('editor').style.display = """";
    $(""#new_name"").val(document.getElementById(""table"").rows[n].cells[1].innerHTML);
    //$(""#new_name"").attr(""placeholder"", document.getElementById(""table"").rows[n].cells[1].innerHTML);
}

function send_post()
{
    var name = $(""#new_name"").val();
    name = name.replace(/ +/g, ' ').trim();
    
    $.post( '/Admin/EditSubject?name=' + name + ""&id="" + _id, {data: ""name""},function( data, status ) {
    		    if(status == 'success')
    		    {
                    console.log(""ok"");
                    document.getElementById(""table"").rows[index].cells[1].innerHTML = name;
                    toggle(index, _id);
                    $(""#status"").val("""");
    ");
            WriteLiteral("            }else{\n                    console.log(\"bad\")\n                    $(\"#status\").val(\"bad name\");\n                }\n            });\n}\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication.Utils.PaginatedList<Model.SubjectModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
