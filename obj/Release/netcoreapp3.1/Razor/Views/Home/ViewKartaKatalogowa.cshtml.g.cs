#pragma checksum "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3443546e41172de54fe19efd6ed738c4bf6a3bf3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewKartaKatalogowa), @"mvc.1.0.view", @"/Views/Home/ViewKartaKatalogowa.cshtml")]
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
#line 1 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\_ViewImports.cshtml"
using iPDP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\_ViewImports.cshtml"
using iPDP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3443546e41172de54fe19efd6ed738c4bf6a3bf3", @"/Views/Home/ViewKartaKatalogowa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"577958d7282aca9f4b39acd835bad74e0f67b7f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewKartaKatalogowa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<iPDP.Models.Uniwersalny>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
  
    ViewBag.Title = "ViewKartaKatalogowa";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3443546e41172de54fe19efd6ed738c4bf6a3bf34237", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3443546e41172de54fe19efd6ed738c4bf6a3bf34564", async() => {
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
                WriteLiteral(@"
    <title>KartaKatalogowa</title>

    <script src=""https://canvasjs.com/assets/script/canvasjs.min.js""></script>

    <script type=""text/javascript"">
        window.onload = function () {
            var chart = new CanvasJS.Chart(""chartContainer"",
                    {
                        animationEnabled: false,
                        theme: ""theme2"",
                            //title: {
                            //text: ""Charakterystyki pompy i układu""
                            //},
                        axisX: {
                            title: ""Q [m3/h]"",
                            lineColor: ""#4F81BC"",
                            tickColor: ""#4F81BC"",
                            labelFontColor: ""#4F81BC"",
                            titleFontColor: ""#4F81BC"",
                            gridThickness: 1,
                            lineThickness: 2,
                        },
                        axisY: {
                            title: ""H [m] "",
       ");
                WriteLiteral(@"                     lineColor: ""#4F81BC"",
                            tickColor: ""#4F81BC"",
                            labelFontColor: ""#4F81BC"",
                            titleFontColor: ""#4F81BC"",
                            lineThickness: 2,
                        },
                        axisY2: {
                            title: ""P [kW], e[%] "",
                            lineColor: ""#4F81BC"",
                            tickColor: ""#4F81BC"",
                            labelFontColor: ""#4F81BC"",
                            titleFontColor: ""#4F81BC"",
                            lineThickness: 2,
                        },
                        data: [
");
                WriteLiteral(@"                            {
                                type: ""spline"",
                                showInLegend: true,
                                name: ""Hu [m]"",
                                markerSize: 0,
                                dataPoints: ");
#nullable restore
#line 69 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                       Write(Model.doborNaPunkt.CharUkladu.char_Hu_Str);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            },
                            {
                                type: ""spline"",
                                showInLegend: true,
                                name: ""H [m]"",
                                markerSize: 0,
                                dataPoints: ");
#nullable restore
#line 76 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                       Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].char_H_Str);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            },
                            {
                                type: ""spline"",
                                showInLegend: true,
                                name: ""P [kW]"",
                                axisYType: ""secondary"",
                                markerSize: 0,
                                dataPoints: ");
#nullable restore
#line 84 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                       Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].char_P_Str);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            },
                            {
                                type: ""spline"",
                                showInLegend: true,
                                axisYType: ""secondary"",
                                name: ""e [%]"",
                                markerSize: 0,
                                dataPoints: ");
#nullable restore
#line 92 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                       Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].char_E_Str);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            }

                            ,
                            {
                                type: ""line"",
                                showInLegend: true,
                                name: ""pw"",
                                markerSize: 20,
                                dataPoints: ");
#nullable restore
#line 101 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                       Write(Model.doborNaPunkt.CharUkladu.pw_Str);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            }

                        ],
                        legend: {
                            cursor: ""pointer"",
                            itemclick: function (e) {
                                if (typeof (e.dataSeries.visible) === ""undefined"" || e.dataSeries.visible) {
                                    e.dataSeries.visible = false;
                                } else {
                                    e.dataSeries.visible = true;
                                }
                                chart.render();
                            }
                        }
                    });

            chart.render();

            }


    </script>

    <script type=""text/javascript"">

        function daj_Dane() {
            document.getElementById(""DANE"").hidden = false;
            document.getElementById(""PDF"").hidden = true;
            document.getElementById(""OPIS"").hidden = true;
            document.getElementById(""PUNKTY"").hidden");
                WriteLiteral(@" = true;

        }
        function daj_Rysunek() {
            document.getElementById(""DANE"").hidden = true;
            document.getElementById(""PDF"").hidden = false;
            document.getElementById(""OPIS"").hidden = true;
            document.getElementById(""PUNKTY"").hidden = true;
        }
        function daj_Opis() {
            document.getElementById(""DANE"").hidden = true;
            document.getElementById(""PDF"").hidden = true;
            document.getElementById(""OPIS"").hidden = false;
            document.getElementById(""PUNKTY"").hidden = true;
        }
        function daj_Punkty() {
            document.getElementById(""DANE"").hidden = false;
            document.getElementById(""PDF"").hidden = true;
            document.getElementById(""OPIS"").hidden = true;
            document.getElementById(""PUNKTY"").hidden = false;

        }
        function daj_Dobor() {
            document.getElementById(""DANE"").hidden = false;
            document.getElementById(""PDF"").hidde");
                WriteLiteral(@"n = true;
            document.getElementById(""OPIS"").hidden = true;
            document.getElementById(""PUNKTY"").hidden = false;
        }

    </script>

    <script type=""text/javascript"" src=""/assets/script/canvasjs.min.js""></script>
    <style>
        input[type=""number""] {
            font-size: 20px;
            font-weight: 600;
            text-align: right;
            border-color: #000080;
        }

        input[type=""text""] {
            background-color: rgb(240,240,240);
            text-align: right;
        }

        .ramka {
            border: 3px solid #000080;
        }
    </style>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"ramka\" style=\"padding: 10px;\">\r\n    <div>Producent: ");
#nullable restore
#line 183 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
               Write(Model.Producer_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n    <div>Adres: ");
#nullable restore
#line 184 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
           Write(Model.Producer_Adres);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n    <div>Strona internetowa: ");
#nullable restore
#line 185 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                        Write(Model.Producer_WWW);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n    <div>Mail: ");
#nullable restore
#line 186 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
          Write(Model.Producer_Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n    <div>Tel: ");
#nullable restore
#line 187 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
         Write(Model.Producer_Tel);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n</div>\r\n    <h4 style=\"text-align:center;\">Karta katalogowa</h4>\r\n    <div id=\"zakladki\">\r\n        <a id=\"Tree\"");
            BeginWriteAttribute("href", " href=", 7870, "", 7906, 1);
#nullable restore
#line 191 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
WriteAttributeValue("", 7876, Url.Action("ViewTreeKatalog"), 7876, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            <div style=""
        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(80,80,80);
        margin: 2%;"">
                COFNIJ
            </div>
        </a>
        <a id=""Dobor""");
            BeginWriteAttribute("href", " href=", 8210, "", 8240, 1);
#nullable restore
#line 203 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
WriteAttributeValue("", 8216, Url.Action("ViewDobor"), 8216, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(180, 180, 180);
        margin: 2%;"">
                COFNIJ
            </div>
        </a>
        <a id=""Prosty""");
            BeginWriteAttribute("href", " href=", 8548, "", 8579, 1);
#nullable restore
#line 214 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
WriteAttributeValue("", 8554, Url.Action("ViewProsty"), 8554, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(180, 180, 180);
        margin: 2%;"">
                COFNIJ
            </div>
        </a>
        <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(180, 180, 180);
        margin: 2%;""
             onclick=""daj_Dane()"">
            DANE
        </div>
        <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(180, 180, 180);
        margin: 2%;""
             onclick=""daj_Rysunek()"">
            RYSUNEK
        </div>
        <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
 ");
            WriteLiteral(@"       border: 3px solid rgb(180, 180, 180);
        margin: 2%;""
             onclick=""daj_Opis()"">
            OPIS
        </div>
        <div style=""        background-color: #000080;
        color: white;
        text-align: center;
        width: 16%;
        float: left;
        border: 3px solid rgb(180, 180, 180);
        margin: 2%;""
             onclick=""daj_Punkty()"">
            PUNKTY
        </div>

    </div>

    <div>
        <div id=""PDF"" hidden=""hidden"">
            <iframe");
            BeginWriteAttribute("src", " src=", 10121, "", 10188, 1);
#nullable restore
#line 270 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
WriteAttributeValue("", 10126, Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].G_PDF, 10126, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100%; height: 1000px;\"></iframe>\r\n        </div>\r\n        <div id=\"OPIS\" hidden=\"hidden\">\r\n            <iframe");
            BeginWriteAttribute("src", " src=", 10313, "", 10383, 1);
#nullable restore
#line 273 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
WriteAttributeValue("", 10318, Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Opis_PDF, 10318, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 100%; height: 1000px;\"></iframe>\r\n        </div>\r\n\r\n        <div id=\"DANE\" style=\" float: unset; \">\r\n\r\n            <br>\r\n\r\n            <div>\r\n                <h2 style=\"text-align:center\">");
#nullable restore
#line 281 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                         Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Nazwa);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
            </div>

            <div id=""chartContainer"" style=""height: 400px; width: 70%; margin: auto""></div>
            <div style=""text-align:center;"">Kliknij legendę aby wyłączyć lub włączyć charakterystykę</div>

            <!--<div id=""Wymagane"" class=""row"" style=""margin: 20px 10px;"">-->
            <div id=""Wymagane"" class=""ramka"" style=""margin: 20px 10px;"">
                <fieldset>
                    <legend style=""margin-left:5px;"">Wymagane parametry pompy   </legend>
                    <div style=""margin-left:15px;"">Wydajność [m3/h] = ");
#nullable restore
#line 291 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                 Write(Model.doborNaPunkt.CharUkladu.Qw);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Wysokość podnoszenia [m] = ");
#nullable restore
#line 292 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                         Write(Model.doborNaPunkt.CharUkladu.Hw);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Geometryczna Wysokość podnoszenia [m] = ");
#nullable restore
#line 293 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                                      Write(Model.doborNaPunkt.CharUkladu.Hg);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Zastosowanie = ");
#nullable restore
#line 294 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                             Write(Model.DajZastosowanie());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                </fieldset>
            </div>
            <div class=""ramka"" style=""margin: 20px 10px;"">
                <fieldset>
                    <legend style=""margin-left:5px;"">Nominalne parametry pompy  </legend>
                    <div style=""margin-left:15px;"">Wydajność [m3/h] = ");
#nullable restore
#line 300 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                 Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Qn);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Wysokość podnoszenia [m] = ");
#nullable restore
#line 301 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                         Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Hn);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Zasilanie = ");
#nullable restore
#line 302 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                          Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].M_Zas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Moc [kW] = ");
#nullable restore
#line 303 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                         Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Pn);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Masa [kg] = ");
#nullable restore
#line 304 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                          Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].G_Masa);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n");
            WriteLiteral(@"                </fieldset>
            </div>
            <div id=""Obliczone"" class=""ramka"" style=""margin: 20px 10px;"">
                <fieldset>
                    <legend style=""margin-left:5px;"">Obliczone parametry pracy przy współpracy z układem</legend>
                    <div style=""margin-left:15px;"">Wydajność rzeczywista [m3/h] = ");
#nullable restore
#line 314 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                             Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Qr);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Rzeczywista wysokość podnoszenia [m] = ");
#nullable restore
#line 315 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                                     Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Hr);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Moc pobierana z sieci przez pompę [kW] = ");
#nullable restore
#line 316 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                                       Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].Pr);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div style=\"margin-left:15px;\">Sprawność w punkcie pracy [%] = ");
#nullable restore
#line 317 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                                                              Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].ETAr_proc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </div>
                </fieldset>
            </div>
            <div id=""PUNKTY"" hidden=""hidden"" class=""ramka"" style=""margin: 20px 10px;"">
                <fieldset>
                    <legend style=""margin-left:5px;"">Punkty  </legend>
                    <table class=""table table-sm table-striped table-bordered"" cellpadding=""0"" style=""width: 50%;"">
                        <thead>
                            <tr>
                                <th>Lp.</th>
                                <th>Q [m<sup>3</sup>/h]</th>
                                <th>H [m]</th>
                                <th>P [kW]</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 333 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                              int i = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 334 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                             for (int j = 0; j < @Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].CharPompy.n_pt; j++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n");
#nullable restore
#line 337 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                      i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td> ");
#nullable restore
#line 338 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 339 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                    Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].CharPompy.TabQ[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 340 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                    Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].CharPompy.TabH[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    <td> ");
#nullable restore
#line 341 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                                    Write(Model.doborNaPunkt.listaPompZBazy.fLista[Model.NrPompy].CharPompy.TabP[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                </tr>\r\n");
#nullable restore
#line 343 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </fieldset>\r\n\r\n\r\n            </div>\r\n        </div>\r\n        <script>\r\n         if (");
#nullable restore
#line 352 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
        Write(ViewBag.Filter);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" == true) {
             document.getElementById(""Wymagane"").hidden = true;
             document.getElementById(""Obliczone"").hidden = true;
         }
         else
         {
             document.getElementById(""Wymagane"").hidden = false;
             document.getElementById(""Obliczone"").hidden = false;
         }

         if (");
#nullable restore
#line 362 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
        Write(ViewBag.Kafelek);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" == Tree) {
             document.getElementById(""Tree"").hidden = false;
             document.getElementById(""Dobor"").hidden = true;
             document.getElementById(""Prosty"").hidden = true;
         }
         else
         {
             if (");
#nullable restore
#line 369 "D:\aaMAREK\ASP\ASP.Test2\iPDP\iPDP\Views\Home\ViewKartaKatalogowa.cshtml"
            Write(ViewBag.Kafelek);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" == Dobor) {
                 document.getElementById(""Tree"").hidden = true;
                 document.getElementById(""Dobor"").hidden = false;
                 document.getElementById(""Prosty"").hidden = true;
             }
             else
             {
                 document.getElementById(""Tree"").hidden = true;
                 document.getElementById(""Dobor"").hidden = true;
                 document.getElementById(""Prosty"").hidden = false;
             }
         }


        </script>

    </div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<iPDP.Models.Uniwersalny> Html { get; private set; }
    }
}
#pragma warning restore 1591
