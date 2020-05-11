#pragma checksum "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7af91d469b776a07ddc152351c4b619bb7dbae6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Console), @"mvc.1.0.view", @"/Views/Home/Console.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7af91d469b776a07ddc152351c4b619bb7dbae6d", @"/Views/Home/Console.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bc7a4efba6e2c602d56dbf6de1bf2b382d53fdb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Console : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ConsoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/BannertFinale.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
  
    ViewData["Title"] = Model.Screen.ScreenName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"game-banner\">\r\n        <center>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7af91d469b776a07ddc152351c4b619bb7dbae6d3786", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</center>\r\n    </div>\r\n\r\n<div class=\"console-container olde-font\">\r\n    <div class=\"log-events d-flex flex-column\">\r\n");
#nullable restore
#line 12 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
         foreach (FightLog entry in Model.Log)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"mt-2 text-center font-weight-bold\">. . .</span>\r\n            <p");
            BeginWriteAttribute("class", " class=\"", 432, "\"", 461, 2);
            WriteAttributeValue("", 440, "mt-2", 440, 4, true);
#nullable restore
#line 15 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
WriteAttributeValue(" ", 444, entry.EntryType, 445, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                        Write(Html.Raw(entry.Entry));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 16 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"screen-options mt-2 d-flex flex-column\">\r\n");
#nullable restore
#line 19 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
         if (Model.Screen.ScreenEnemies != null)
        {
            foreach (ScreenEnemy e in Model.Screen.ScreenEnemies)
            {
                if (Model.User.WeaponEquipped) {
                    Item weapon = new Item();
                    foreach (Item item in Model.User.Inventory)
                    {
                        if (item.ItemID == Model.User.WeaponID) weapon = item;
                    }
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
               Write(Html.ActionLink(e.ScreenEnemyAction + $" with your {weapon.ItemName}", "Attack", new { screenEnemyID = e.ScreenEnemyID }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                                                                                                                              
                } else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>You can\'t attack without a weapon.</span>\r\n");
#nullable restore
#line 33 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                }
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
         foreach (AccessPoint p in Model.AccessPoints)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
       Write(Html.ActionLink(p.Description, "Travel", new { screenID = p.To }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                                                              
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
         if (Model.Screen.ScreenInventory != null)
        {
            foreach (ScreenItem s in Model.Screen.ScreenInventory)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
           Write(Html.ActionLink(s.ScreenItemAction, s.Item.Container ? "Open" : "Take", new { inventoryItemID = 0, itemID = s.ItemID, chestID = 0 }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                                                                                                                                     
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<div class=\"inv-view d-flex flex-column olde-font\">\r\n    <div class=\"stats-container d-flex\">\r\n        <div class=\"stats-char d-flex flex-column\">\r\n            <span class=\"stats-name\">");
#nullable restore
#line 54 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                Write(Model.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <span class=\"stats-hp\">HP: ");
#nullable restore
#line 55 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                  Write(Model.User.Health);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <span class=\"stats-exp\">Exp: ");
#nullable restore
#line 56 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                    Write(Model.User.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n        <div class=\"stats-level\">\r\n            ");
#nullable restore
#line 59 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
       Write(Model.User.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <span class=\"inv-title\">Inventory:</span>\r\n    <div class=\"inv-items d-flex flex-column\">\r\n");
#nullable restore
#line 64 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
         foreach (Item item in Model.User.Inventory)
        {
            // TODO: If consumable (ItemType == 4), create action link
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
             if (item.ItemTypeID == 4)
            {
                int quant = 1;
                foreach (InventoryItem invItem in Model.User.InventoryItems)
                {
                    if (invItem.ItemID == item.ItemID) quant = invItem.Quantity;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"inv-item\">");
#nullable restore
#line 74 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                  Write(Html.ActionLink(item.ItemName + $"{(quant > 1 ? $" ({quant})" : "")}", "Eat", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 75 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"inv-item\">");
#nullable restore
#line 78 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
                                  Write(item.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 79 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\James\Source\Repos\BrowserAdventures\BrowserAdventures\Views\Home\Console.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<script>\r\nwindow.scrollTo(0, document.body.clientHeight);\r\n</script>\r\n\r\n");
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
