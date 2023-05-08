@Code
    ViewBag.Title = "E-posta Onayı"
End Code

<h2>@ViewBag.Title.</h2>
<div>
    <p>
        E-postanızı onayladığınız için teşekkürler. @Html.ActionLink("Oturum açmak için buraya tıklayın", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
