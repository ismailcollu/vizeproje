@ModelType SendCodeViewModel
@Code
    ViewBag.Title = "Gönder"
End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("SendCode", "Account", New With { .ReturnUrl = Model.ReturnUrl }, FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
    @Html.AntiForgeryToken()
    @Html.Hidden("rememberMe", Model.RememberMe)
    @<text>
    <h4>Doğrulama kodunu girin</h4>
    <hr />
    <div class="row">
        <div class="col-md-8">
            İki Öğeli Kimlik Doğrulama Sağlayıcısını Seçin:
            @Html.DropDownListFor(Function(model) model.SelectedProvider, Model.Providers)
            <input type="submit" value="Gönder" class="btn btn-default" />
        </div>
    </div>
    </text>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
