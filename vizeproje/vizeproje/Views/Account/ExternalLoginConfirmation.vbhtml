@ModelType ExternalLoginConfirmationViewModel
@Code
    ViewBag.Title = "Kaydol"
End Code

<h2>@ViewBag.Title.</h2>
<h3>@ViewBag.LoginProvider hesabınızı ilişkilendirin.</h3>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()

    @<text>
    <h4>İlişki Formu</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <p class="text-info">
        Şununla başarılı bir şekilde kimlik doğruladınız: <strong>@ViewBag.LoginProvider</strong>.
        Lütfen bu site için aşağıya bir kullanıcı adı girin ve oturum açmayı tamamlamak için
        Kaydolun düğmesine tıklayın.
    </p>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.Hometown, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Hometown, New With {.class = "form-control"})
        </div>
    </div>    
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" class="btn btn-default" value="Kaydol" />
        </div>
    </div>
    </text>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
