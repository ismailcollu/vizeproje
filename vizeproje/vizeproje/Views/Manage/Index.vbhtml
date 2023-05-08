@ModelType IndexViewModel
@Code
    ViewBag.Title = "Yönet"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
<div>
    <h4>Hesap ayarlarınızı değiştirin</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>Parola:</dt>
        <dd>
            [
            @If Model.HasPassword Then
                @Html.ActionLink("Parolanızı değiştirin", "ChangePassword")
            Else
                @Html.ActionLink("Oluştur", "SetPassword")
            End If
            ]
        </dd>
        <dt>Dış Oturum Açmalar:</dt>
        <dd>
            @Model.Logins.Count [
            @Html.ActionLink("Yönet", "ManageLogins") ]
        </dd>
        @*
            Telefon Numaraları, iki öğeli kimlik doğrulama sisteminde ikinci öğe olarak kullanılabilir.
             
             Bu ASP.NET uygulamasını SMS kullanarak iki öğeli kimlik doğrulamayı destekleyecek şekilde
                        ayarlama konusunda ayrıntılı bilgi için <a href="https://go.microsoft.com/fwlink/?LinkId=403804">bu makaleye</a> bakın.
             
             İki öğeli kimlik doğrulamayı ayarladıktan sonra aşağıdaki blokları açıklama durumundan çıkarın
        *@
        @* 
            <dt>Telefon Numarası:</dt>
            <dd>
                @(If(Model.PhoneNumber, "Yok"))
                @If (Model.PhoneNumber <> Nothing) Then
                    @<br />
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Değiştir", "AddPhoneNumber")&nbsp;&nbsp;]</text>
                    @Using Html.BeginForm("RemovePhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                        @Html.AntiForgeryToken
                        @<text>[<input type="submit" value="Kaldır" class="btn-link" />]</text>
                    End Using
                Else
                    @<text>[&nbsp;&nbsp;@Html.ActionLink("Ekle", "AddPhoneNumber") &nbsp;&nbsp;]</text>
                End If
            </dd>
        *@
        <dt>İki Öğeli Kimlik Doğrulama:</dt>
        <dd>
            <p>
                Yapılandırılmış iki öğeli kimlik doğrulama sağlayıcısı yok. Bu ASP.NET uygulamasını iki öğeli kimlik doğrulamayı destekleyecek şekilde ayarlama
                konusunda ayrıntılı bilgi için <a href="https://go.microsoft.com/fwlink/?LinkId=403804">bu makaleye</a>bakın.
            </p>
            @*
                @If Model.TwoFactor Then
                    @Using Html.BeginForm("DisableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      Etkin
                      <input type="submit" value="Devre Dışı Bırak" class="btn btn-link" />
                      </text>
                    End Using
                Else
                    @Using Html.BeginForm("EnableTwoFactorAuthentication", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
                      @Html.AntiForgeryToken()
                      @<text>
                      Devre dışı
                      <input type="submit" value="Etkinleştir" class="btn btn-link" />
                      </text>
                    End Using
                End If
	     *@
        </dd>
    </dl>
</div>
