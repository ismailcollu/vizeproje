Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' ApplicationUser sınıfınıza daha fazla özellik ekleyerek kullanıcıya profil verileri ekleyebilirsiniz. Daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkID=317594 adresini ziyaret edin.
Public Class ApplicationUser
    Inherits IdentityUser

    Public Property Hometown As String

    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Not authenticationType türü CookieAuthenticationOptions.AuthenticationType öğesinde tanımlanmış bir türle mutlaka eşleşmelidir
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Buradan özel kullanıcı taleplerini ekleyin
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DB01Entities", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function
End Class
