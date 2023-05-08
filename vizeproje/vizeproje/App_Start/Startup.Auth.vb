Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.DataProtection
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Partial Public Class Startup
    Private Shared _oAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _publicClientId As String

    ' OAuthAuthorization öğesini kullanmak için uygulamayı etkinleştirin. Sonrasında Web API'larınızı güvenli hale getirebilirsiniz
    Shared Sub New()
        PublicClientId = "web"

        OAuthOptions = New OAuthAuthorizationServerOptions() With {
            .TokenEndpointPath = New PathString("/Token"),
            .AuthorizeEndpointPath = New PathString("/Account/Authorize"),
            .Provider = New ApplicationOAuthProvider(PublicClientId),
            .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            .AllowInsecureHttp = True
        }
    End Sub

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _oAuthOptions
        End Get
        Private Set
            _oAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _publicClientId
        End Get
        Private Set
            _publicClientId = Value
        End Set
    End Property

    ' Kimlik doğrulamayı yapılandırma hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301864 adresini ziyaret edin.
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Veritabanı bağlamını ve kullanıcı yöneticisini ve oturum açma yöneticisini istek başına tek örnek kullanacak şekilde yapılandırın
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' Oturum açmış kullanıcı hakkında bilgi toplamak için uygulamada çerez kullanımını etkinleştirin
        ' ve üçüncü taraf bir oturum açma sağlayıcısı üzerinden oturum açan kullanıcı bilgilerini tanımlama bilgileri olarak saklamak için  veritabanı bağlamını ve kullanıcı yöneticisini yapılandırın
        ' Oturum açma tanımlama bilgilerini yapılandırın
        ' OnValidateIdentity, kullanıcı oturum açtığında uygulamanın güvenlik damgasını doğrulamasını sağlar.
        ' Bu, parola değiştirdiğinizde veya hesabınıza dış oturum eklediğinizde kullanılan bir güvenlik özelliğidir.
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' İki öğeli kimlik doğrulama işleminde ikinci öğeyi doğrulama sırasında uygulamanın, kullanıcı bilgilerini geçici olarak saklanmasını sağlar.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' Uygulamanın, telefon veya e-posta gibi ikinci oturum açma doğrulama öğesini hatırlamasını sağlar.
        ' Bu seçeneği işaretlerseniz, oturum açma işlemi sırasındaki ikinci doğrulama adımınız oturum açtığınız cihazda hatırlanır.
        ' Bu, oturum açarken kullandığınız Beni Hatırla seçeneğine benzer.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' Kullanıcıların kimliğini doğrulamak üzere uygulamanın taşıyıcı belirteçleri kullanmasını sağlayın
        app.UseOAuthBearerTokens(OAuthOptions)

        ' Üçüncü taraf oturum sağlayıcılarla oturum açmaya olanak tanımak için aşağıdaki satırlardan açıklamayı kaldırın
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '   consumerKey:="",
        '   consumerSecret:="")

        'app.UseFacebookAuthentication(
        '   appId:="",
        '   appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
