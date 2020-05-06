#pragma checksum "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "866aeb391ae91cde31cff8032dd3bf7585c280f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Open), @"mvc.1.0.view", @"/Views/Home/Open.cshtml")]
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
#line 1 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\_ViewImports.cshtml"
using BrowserAdventures;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\_ViewImports.cshtml"
using BrowserAdventures.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"866aeb391ae91cde31cff8032dd3bf7585c280f9", @"/Views/Home/Open.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bc7a4efba6e2c602d56dbf6de1bf2b382d53fdb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Open : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ConsoleViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
  
    ViewData["Title"] = "Container";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Console</h1>\r\n\r\n<div class=\"console-container olde-font\">\r\n    <div class=\"log-events d-flex flex-column\">\r\n");
#nullable restore
#line 10 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
         foreach (FightLog entry in Model.Log)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"mt-2\">");
#nullable restore
#line 12 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
                          Write(entry.Entry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <span class=\"mt-2 text-center font-weight-bold\">. . .</span>\r\n");
#nullable restore
#line 14 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"screen-options mt-2 d-flex flex-column\">\r\n");
#nullable restore
#line 17 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
         if(Model.Chest.ItemsInside != null) { 
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
         foreach (KeyValuePair<int, Item> item in Model.Chest.ItemsInside)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
       Write(Html.ActionLink($"Take the {item.Value.ItemName}", "Take", new { inventoryItemID = item.Key, takenItemID = item.Value.ItemID, chestID = Model.Chest.ParentContainer.ItemID}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
                                                                                                                                                                                         
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
         
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 23 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Open.cshtml"
   Write(Html.ActionLink($"Close the {Model.Chest.ParentContainer.ItemName}", "Close", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<script>\r\nwindow.scrollTo(0, document.body.clientHeight);\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConsoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
