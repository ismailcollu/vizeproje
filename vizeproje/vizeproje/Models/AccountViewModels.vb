Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="E-posta")>
    Public Property Email As String

    <Display(Name:="Memleket")>
    Public Property Hometown As String
End Class

Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String

    <Required>
    <Display(Name:="Kod")>
    Public Property Code As String

    Public Property ReturnUrl As String

    <Display(Name:="Bu tarayıcı hatırlansın mı?")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="E-posta")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="E-posta")>
    <EmailAddress>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Parola")>
    Public Property Password As String

    <Display(Name:="Beni anımsa?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="E-posta")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Parola")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="Parolayı onayla")>
    <Compare("Password", ErrorMessage:="Parola ve onay parolası eşleşmiyor.")>
    Public Property ConfirmPassword As String

    <Display(Name:="Memleket")>
    Public Property Hometown As String
End Class

Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="E-posta")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="{0} en az {2} karakter uzunluğunda olmalıdır.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Parola")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="Parolayı onayla")>
    <Compare("Password", ErrorMessage:="Parola ve onay parolası eşleşmiyor.")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="E-posta")>
    Public Property Email() As String
End Class
