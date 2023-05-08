Imports System.Net.Http
Imports System.Web.Http
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
        ' Web API yapılandırması ve hizmetleri
        ' Web API yapılandırmasını yalnızca taşıyıcı belirtecinin kimlik doğrulamasını kullanmak üzere yapın.
        config.SuppressDefaultHostAuthentication()
        config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

        ' JSON verileri için ortası büyük harf kullanın.
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = New CamelCasePropertyNamesContractResolver()

        ' Web API yolları
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
