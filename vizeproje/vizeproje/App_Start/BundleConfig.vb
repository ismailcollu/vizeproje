Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin.
    Public Sub RegisterBundles(bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.unobtrusive*",
            "~/Scripts/jquery.validate*"))

        bundles.Add(New ScriptBundle("~/bundles/knockout").Include(
            "~/Scripts/knockout-{version}.js",
            "~/Scripts/knockout.validation.js"))

        bundles.Add(New ScriptBundle("~/bundles/app").Include(
            "~/Scripts/sammy-{version}.js",
            "~/Scripts/app/common.js",
            "~/Scripts/app/app.datamodel.js",
            "~/Scripts/app/app.viewmodel.js",
            "~/Scripts/app/home.viewmodel.js",
            "~/Scripts/app/_run.js"))

        ' Geliştirme yapmak ve öğrenmek için Modernizr'ın geliştirme sürümünü kullanın. Daha sonra,
        ' üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/Site.css"))
    End Sub
End Module
