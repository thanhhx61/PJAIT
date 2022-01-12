Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/umd/popper.js",
                  "~/Scripts/bootstrap.js"))

        bundles.Add(New ScriptBundle("~/bundles/scripts").Include(
                  "~/Scripts/moment.min.js",
                  "~/Scripts/bootstrap-datepicker.min.js",
                  "~/Scripts/locales/bootstrap-datepicker.ja.min.js",
                  "~/Scripts/common/common.js",
                  "~/Scripts/datatable/colResizable-1.6.min.js",
                  "~/Scripts/jquery.fileDownload.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.min.css",
                  "~/Content/font-awesome.css",
                  "~/Content/font-awesome.min.css",
                  "~/Content/bootstrap-datepicker.min.css",
                  "~/Content/styles.css"))
    End Sub
End Module

