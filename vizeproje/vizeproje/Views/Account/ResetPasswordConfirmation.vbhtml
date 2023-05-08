@Code
    ViewBag.Title = "Parola onayını sıfırla"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title.</h1>
</hgroup>
<div>
    <p>
        Parolanız sıfırlandı. Lütfen @Html.ActionLink("oturum açmak için buraya tıklayın", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
