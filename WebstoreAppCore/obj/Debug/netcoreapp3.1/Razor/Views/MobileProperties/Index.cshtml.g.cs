#pragma checksum "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17dfd4f220b7b2b28b62916b7a8a7753be6085d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MobileProperties_Index), @"mvc.1.0.view", @"/Views/MobileProperties/Index.cshtml")]
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
#line 1 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\_ViewImports.cshtml"
using WebStoreAppCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\_ViewImports.cshtml"
using WebStoreAppCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17dfd4f220b7b2b28b62916b7a8a7753be6085d0", @"/Views/MobileProperties/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b25608123c8ce321b4a9ffb0241436accb3c5e07", @"/Views/_ViewImports.cshtml")]
    public class Views_MobileProperties_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<Products>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/customer/gallery.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/item3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: #334467; background-color: lightgrey;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" <!--import to get HTML Helper-->\n");
            WriteLiteral("\n\n");
#nullable restore
#line 7 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "17dfd4f220b7b2b28b62916b7a8a7753be6085d07201", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral(@"
<h1>Mobiles</h1>

<div class=""maindiv"">

    <div class=""sidebar"">
        <p>Brand Filter</p>
        <table>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Apple</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Samsung</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Oppo</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Nokia</span></td>
            </tr>
        </table>


        <p>Price Filter</p>

        <input type=""range"" min=""500"" max=""23,000"" value=""1000"" />



        <p>Memory Size Filter</p>
        <table>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>8GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>1");
            WriteLiteral(@"6GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>32GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>64GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>128GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>256GB</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>512GB</span></td>
            </tr>
        </table>


        <p>Color Filter</p>
        <table>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Black</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>White</span></td>
            </tr>
            <tr>
  ");
            WriteLiteral(@"              <td><input type=""checkbox"" /></td>
                <td><span>Red</span></td>
            </tr>
            <tr>
                <td><input type=""checkbox"" /></td>
                <td><span>Rose Gold</span></td>
            </tr>
        </table>

    </div>

");
            WriteLiteral("    <div class=\"mainitems\">\n       <div>\n           <table class=\"table table-borderless\">\n               <tr>\n                   <td>\n");
#nullable restore
#line 107 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                        foreach (var item in Model)
                       {

#line default
#line hidden
#nullable disable
            WriteLiteral("                   <div id=\"portfolio\" class=\"column1\">\n                       <div class=\"box\">\n                           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17dfd4f220b7b2b28b62916b7a8a7753be6085d011449", async() => {
                WriteLiteral("\n                               ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "17dfd4f220b7b2b28b62916b7a8a7753be6085d011734", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                           ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                                                     WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                           <h3>");
#nullable restore
#line 114 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                          Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                           <p>");
#nullable restore
#line 115 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                         Write(item.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17dfd4f220b7b2b28b62916b7a8a7753be6085d015475", async() => {
                WriteLiteral("More info");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 116 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                                                                                      WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                           <a href=\"#\" class=\"btn btn-sm btn-primary\">Add to Favorites</a>\n                       </div>\n                   </div>");
#nullable restore
#line 119 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
                         }

#line default
#line hidden
#nullable disable
            WriteLiteral("                   </td>\n               </tr>\n           </table>\n       </div>\n\n\n        <!-- paging control for navigation to the previous page, next page, etc -->\n        ");
#nullable restore
#line 127 "D:\_Disktop\_1DisckTop\WebStore\webstore\WebstoreAppCore\Views\MobileProperties\Index.cshtml"
   Write(Html.PagedListPager(Model, page => Url.Action("Index", new { page = page }),
                                             new X.PagedList.Mvc.Core.Common.PagedListRenderOptions
                                             {
                                                 DisplayItemSliceAndTotal = true,
                                                 ContainerDivClasses = new[] { "navigation" },
                                                 LiElementClasses = new[] { "page-item" },
                                                 PageClasses = new[] { "page-link" },
                                             }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
            WriteLiteral("\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
    // Workaround to fix style of text for showing items .. through ..
        // Problem related to Boostrap 4 according to issue in link below
        // https://github.com/dncuug/X.PagedList/issues/127
        $(document).ready(function () {
            $('ul.pagination > li.disabled > a').addClass('page-link');
        });</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591
