#pragma checksum "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\Privacy\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1b926bdd57a1b0103cda023fe5c0cee98eda7a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Privacy_Index), @"mvc.1.0.view", @"/Views/Privacy/Index.cshtml")]
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
#line 1 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\_ViewImports.cshtml"
using LimakAz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\_ViewImports.cshtml"
using LimakAz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\_ViewImports.cshtml"
using LimakAz.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1b926bdd57a1b0103cda023fe5c0cee98eda7a5", @"/Views/Privacy/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd6f2a77d9e2a36d17a1c2a347a193f5f1f0bc81", @"/Views/_ViewImports.cshtml")]
    public class Views_Privacy_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Privacy>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"        <div class=""main-container"">
            <!-- Privacy Start -->
            <section class=""privacy"">
                <div class=""block"">
                    <div class=""block-header"">
                        <h2 class=""block-title"">Gizlilik şərtləri</h2>
                        <ul class=""breadcrumb"">
                            <li class=""breadcrumb-item"">
                                <a href=""index.html"">Ana səhifə</a>
                            </li>
                            <li class=""breadcrumb-item active"">
                                <span>Gizlilik şərtləri</span>
                            </li>
                        </ul>
                    </div>
                    <div class=""block-body"">
");
#nullable restore
#line 18 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\Privacy\Index.cshtml"
                         foreach (Privacy privacy in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"card card-privacy\">\r\n                                <div class=\"card-body\">\r\n                                    <div class=\"card-text\">\r\n                                        <h5>");
#nullable restore
#line 23 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\Privacy\Index.cshtml"
                                       Write(privacy.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        <br>\r\n                                        ");
#nullable restore
#line 25 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\Privacy\Index.cshtml"
                                   Write(Html.Raw(privacy.Desc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 29 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Views\Privacy\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </section>\r\n            <!-- Privacy End -->\r\n        </div>\r\n   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Privacy>> Html { get; private set; }
    }
}
#pragma warning restore 1591
