#pragma checksum "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24634720b1dde89103301b6714ecbd2e42a42fdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PerusahaanAsuransi_Details), @"mvc.1.0.view", @"/Views/PerusahaanAsuransi/Details.cshtml")]
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
#line 1 "C:\Epolis\Epolis\Views\_ViewImports.cshtml"
using Epolis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Epolis\Epolis\Views\_ViewImports.cshtml"
using Epolis.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24634720b1dde89103301b6714ecbd2e42a42fdb", @"/Views/PerusahaanAsuransi/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8ba3b5d3877711fc25756b26393300fc2bd89cd", @"/Views/_ViewImports.cshtml")]
    public class Views_PerusahaanAsuransi_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Epolis.Models.Mperusahaanasuransi>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark pull-left"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""app-page-title"">
    <div class=""page-title-wrapper"">
        <div class=""page-title-heading"">
            <div class=""page-title-icon"">
                <i class=""pe-7s-medal icon-gradient bg-tempting-azure""></i>
            </div>
        </div>
        <div class=""page-title-heading"">DETAIL DATA PERUSAHAAN ASURANSI</div>
    </div>
</div>
<div class=""main-card card col-12"">
    <div class=""card-body"">
        <br />
        <dl class=""row"">
            <dt class=""col-sm-2"">
                ");
#nullable restore
#line 22 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.KODEPERUSAHAAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 25 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.KODEPERUSAHAAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 28 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NAMAPERUSAHAAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 31 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.NAMAPERUSAHAAN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 34 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.ALAMAT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 37 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.ALAMAT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 40 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NOTLP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 43 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.NOTLP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 46 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NOFAX));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 49 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.NOFAX));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 52 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.CONTACTPERSON));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 55 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.CONTACTPERSON));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 58 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
#nullable restore
#line 61 "C:\Epolis\Epolis\Views\PerusahaanAsuransi\Details.cshtml"
           Write(Html.DisplayFor(model => model.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24634720b1dde89103301b6714ecbd2e42a42fdb8832", async() => {
                WriteLiteral("Tutup");
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
            WriteLiteral("\r\n    <br />\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Epolis.Models.Mperusahaanasuransi> Html { get; private set; }
    }
}
#pragma warning restore 1591
