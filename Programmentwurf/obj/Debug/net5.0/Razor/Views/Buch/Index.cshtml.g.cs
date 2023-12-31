#pragma checksum "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc695700010813df3f013920390328dced1c4844"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Buch_Index), @"mvc.1.0.view", @"/Views/Buch/Index.cshtml")]
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
#line 1 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\_ViewImports.cshtml"
using Buecherverwaltung;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\_ViewImports.cshtml"
using Buecherverwaltung.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc695700010813df3f013920390328dced1c4844", @"/Views/Buch/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0dd08120fc45c340d278b2483d95944054954b82", @"/Views/_ViewImports.cshtml")]
    public class Views_Buch_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BuchModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Buecher aus den Datenbanktabellen:</h2>\r\n\r\n");
            WriteLiteral(@"<div style=""width:45%; display: inline-block"">
    <h3>Aktuelle Buecher</h3>
    <table class=""table table-hover mb-0"">

        <thead>
            <tr>
                <td>Titel</td>
                <td>Autor</td>
                <td>Verschieben in andere Tabelle</td>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 19 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
             foreach (var buch in Model.AktuelleBuecherList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 23 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(buch.Titel);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 26 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(buch.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 29 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(Html.ActionLink("Verschieben", "VerschiebeNachArchiviert", "Buch", buch));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 32 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n\r\n    </table>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div style=""width:45%; display: inline-block"">
    <h3>Archivierte Buecher</h3>
    <table class=""table table-hover mb-0"">

        <thead>
            <tr>
                <td>Titel</td>
                <td>Autor</td>
                <td>Verschieben in andere Tabelle</td>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 52 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
             foreach (var buch in Model.ArchivierteBuecherList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(buch.Titel);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(buch.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
                   Write(Html.ActionLink("Verschieben", "VerschiebeNachAktuell", "Buch", buch));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 65 "C:\DHBW\4. Semester\C#-Visual Studio\Programmentwurf\Views\Buch\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BuchModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
