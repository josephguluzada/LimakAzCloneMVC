#pragma checksum "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cb142b9285bfdfe21e195ad8ba0e2f2281d7ab3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\_ViewImports.cshtml"
using LimakAz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\_ViewImports.cshtml"
using LimakAz.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cb142b9285bfdfe21e195ad8ba0e2f2281d7ab3", @"/Areas/Manage/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb95716c284d46820be0c83eccd209e1313eb223", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addcourier", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
   int index = 0; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content-wrapper pb-0"">
    <div class=""py-2"">
        <div class=""d-flex justify-content-between align-items-center mb-3"">
            <h1>Orders:</h1>
        </div>
        <table id=""example"" class=""table  table-hover table-bordered "" cellspacing=""0"">
            <thead>
                <tr>
                    <th scope=""col"">No</th>
                    <th scope=""col"">Full Name</th>
                    <th scope=""col"">Shop Name</th>
                    <th scope=""col"">Item count</th>
                    <th scope=""col"">Price</th>
                    <th scope=""col"">Order Time</th>
                    <th scope=""col"">Status</th>
                    <th scope=""col"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 28 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                 foreach (Order order in Model)
                {
                    index++;


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 33 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(order.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(order.ShopName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(order.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(order.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("₼</td>\r\n                    <td>");
#nullable restore
#line 38 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                   Write(order.CreatedAt.AddHours(4).ToString("dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 40 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                         if (order.Status == LimakAz.Models.Enums.OrderStatus.Anbarda)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5><span style=\"padding: 5px; background-color: green; border-radius: 3px; display: inline-block; margin-top: 2px; color: white; font-weight: 600; font-size: 1rem; min-width: 90px; text-align: center\">Accepted</span></h5>\r\n");
#nullable restore
#line 43 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                        }
                        else if (order.Status == LimakAz.Models.Enums.OrderStatus.İmtina)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5><span style=\"padding: 5px; background-color: red; border-radius: 3px; display: inline-block; margin-top: 2px; color: white; font-weight: 600; font-size: 1rem; min-width: 90px;text-align:center\">Rejected</span></h5>\r\n");
#nullable restore
#line 47 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <h5><span style=""padding: 5px; background-color: lightslategrey; border-radius: 3px; display: inline-block; margin-top: 2px; color: white; font-weight: 600; font-size: 1rem; min-width: 90px;text-align:center"">Pending</span></h5>
");
#nullable restore
#line 51 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n\r\n\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cb142b9285bfdfe21e195ad8ba0e2f2281d7ab310066", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                                               WriteLiteral(order.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cb142b9285bfdfe21e195ad8ba0e2f2281d7ab312353", async() => {
                WriteLiteral("Add Courier");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                                                     WriteLiteral(order.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 60 "C:\Users\asus\Desktop\AllProject\LimakAzCloneMVC\LimakAz\LimakAz\Areas\Manage\Views\Order\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
