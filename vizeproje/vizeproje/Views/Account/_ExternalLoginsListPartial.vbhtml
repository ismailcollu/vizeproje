@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>Oturum açmak için başka bir hizmet kullanın.</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
          <p>
              Yapılandırılmış dış kimlik doğrulaması hizmeti yok. Bu ASP.NET uygulamasını dış hizmetler üzerinden
              oturum açmayı destekleyecek şekilde ayarlamaya ilişkin ayrıntılar için <a href="https://go.microsoft.com/fwlink/?LinkId=403804">bu makaleye</a> bakın.
          </p>
    </div>
Else
    @Using Html.BeginForm("ExternalLogin", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="@p.Caption hesabınızı kullanarak oturum açın">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
