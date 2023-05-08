@ModelType ManageLoginsViewModel
@Imports Microsoft.Owin.Security
@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "Dış oturum açma adlarınızı yönetin"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
    If loginProviders.Count = 0 Then
        @<div>
            <p>
                Yapılandırılmış dış kimlik doğrulaması hizmeti yok. Bu ASP.NET uygulamasını dış hizmetler üzerinden
                oturum açmayı destekleyecek şekilde ayarlamaya ilişkin ayrıntılar için <a href="https://go.microsoft.com/fwlink/?LinkId=313242">bu makaleye</a> bakın.
            </p>
        </div>
    Else
        If Model.CurrentLogins.Count > 0  Then
            @<h4>Kayıtlı Oturumlar</h4>
            @<table class="table">
                <tbody>
                    @For Each account As UserLoginInfo In Model.CurrentLogins
                        @<tr>
                            <td>@account.LoginProvider</td>
                            <td>
                                @If ViewBag.ShowRemoveButton
                                    @Using Html.BeginForm("RemoveLogin", "Manage")
                                        @Html.AntiForgeryToken()
                                        @<div>
                                            @Html.Hidden("loginProvider", account.LoginProvider)
                                            @Html.Hidden("providerKey", account.ProviderKey)
                                            <input type="submit" class="btn btn-default" value="Kaldır" title="Bu @account.LoginProvider oturum açma adını hesabınızdan kaldırın" />
                                        </div>
                                    End Using
                                Else
                                    @: &nbsp;
                                End If
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
        If Model.OtherLogins.Count > 0
            @<text>
            <h4>Oturum açmak için başka bir hizmet ekleyin.</h4>
            <hr />
            </text>
            @Using Html.BeginForm("LinkLogin", "Manage")
                @Html.AntiForgeryToken()
                @<div id="socialLoginList">
                <p>
                    @For Each p As AuthenticationDescription In Model.OtherLogins
                        @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="@p.Caption hesabınızı kullanarak oturum açın">@p.AuthenticationType</button>
                    Next
                </p>
                </div>
            End Using
        End If
    End If
End Code
