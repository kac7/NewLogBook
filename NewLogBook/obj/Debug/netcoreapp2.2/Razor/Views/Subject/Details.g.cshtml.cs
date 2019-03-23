#pragma checksum "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "696575408fd2501e7160b2c2836255d6df6187be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject_Details), @"mvc.1.0.view", @"/Views/Subject/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Subject/Details.cshtml", typeof(AspNetCore.Views_Subject_Details))]
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
#line 1 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\_ViewImports.cshtml"
using NewLogBook;

#line default
#line hidden
#line 2 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\_ViewImports.cshtml"
using NewLogBook.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"696575408fd2501e7160b2c2836255d6df6187be", @"/Views/Subject/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfebe932a142ad86807bf42e6266e36b1aec8d98", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewLogBook.Entities.Subject>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-primary btn btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(122, 121, true);
            WriteLiteral("\n<h1>Details Subject</h1>\n\n<div>\n    <h4></h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
            EndContext();
            BeginContext(244, 40, false);
#line 15 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(284, 58, true);
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
            EndContext();
            BeginContext(343, 36, false);
#line 18 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(379, 15, true);
            WriteLiteral("\n        </dd>\n");
            EndContext();
#line 20 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
         foreach (var VARIABLE in Model.TeachersSubjects)
        {
            if (Model.Id == VARIABLE.SubjectId)
            {

#line default
#line hidden
            BeginContext(524, 147, true);
            WriteLiteral("                <dt class=\"col-sm-2\">\n                    Teacher\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
            EndContext();
            BeginContext(672, 26, false);
#line 28 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
               Write(VARIABLE.Teacher.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(698, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(700, 25, false);
#line 28 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
                                           Write(VARIABLE.Teacher.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(725, 23, true);
            WriteLiteral("\n                </dd>\n");
            EndContext();
#line 30 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(772, 144, true);
            WriteLiteral("\n    </dl>\n    <div class=\"row\">\n        <div class=\"col-sm-12\">\n            <h4>List Marks</h4>\n        </div>\n    </div>\n    <dl class=\"row\">\n");
            EndContext();
#line 40 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
         foreach (var VARIABLE in Model.TeachersSubjects)
        {
            if (Model.Id == VARIABLE.SubjectId)
            {
                foreach (var VAR in VARIABLE.Marks)
                {

#line default
#line hidden
            BeginContext(1116, 166, true);
            WriteLiteral("                    <dt class=\"col-sm-2\">\n                        Student\n                    </dt>\n                    <dd class=\"col-sm-4\">\n                        ");
            EndContext();
            BeginContext(1283, 21, false);
#line 50 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
                   Write(VAR.Student.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1304, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1306, 20, false);
#line 50 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
                                          Write(VAR.Student.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1326, 190, true);
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        Mark\n                    </dt>\n                    <dd class=\"col-sm-4\">\n                        ");
            EndContext();
            BeginContext(1517, 9, false);
#line 56 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
                   Write(VAR.Value);

#line default
#line hidden
            EndContext();
            BeginContext(1526, 27, true);
            WriteLiteral("\n                    </dd>\n");
            EndContext();
#line 58 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
                }

            }
        }

#line default
#line hidden
            BeginContext(1596, 28, true);
            WriteLiteral("\n    </dl>\n</div>\n<div>\n    ");
            EndContext();
            BeginContext(1625, 95, false);
#line 66 "C:\Users\kas\Desktop\AspNetMVC_Core_dz3Full\NewLogBook\Views\Subject\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }, new {@class = "btn-success btn btn-sm"}));

#line default
#line hidden
            EndContext();
            BeginContext(1720, 6, true);
            WriteLiteral(" \n    ");
            EndContext();
            BeginContext(1726, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "696575408fd2501e7160b2c2836255d6df6187be9387", async() => {
                BeginContext(1779, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1795, 8, true);
            WriteLiteral("\n</div>\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewLogBook.Entities.Subject> Html { get; private set; }
    }
}
#pragma warning restore 1591