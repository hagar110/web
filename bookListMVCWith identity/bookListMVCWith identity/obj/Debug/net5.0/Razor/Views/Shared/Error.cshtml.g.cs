#pragma checksum "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a55291c32d164f913808a67c0bbca6a43edba6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\_ViewImports.cshtml"
using bookListMVCWith_identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\_ViewImports.cshtml"
using bookListMVCWith_identity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a55291c32d164f913808a67c0bbca6a43edba6", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"911f1d3e3ed812543dbe0891928e39cac6441b65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml"
 if (ViewBag.ErrorTitle == null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 class=\"text-danger\">Error.</h1>\r\n    <h2 class=\"text-danger\">An error occurred while processing your request.......</h2>\r\n");
#nullable restore
#line 7 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 class=\"text-danger\"> ");
#nullable restore
#line 10 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml"
                        Write(ViewBag.ErrorTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h2 class=\"text-danger\">");
#nullable restore
#line 11 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml"
                       Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 12 "C:\Users\Hager\source\repos\bookListMVCWith identity\bookListMVCWith identity\Views\Shared\Error.cshtml"
 
    
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591