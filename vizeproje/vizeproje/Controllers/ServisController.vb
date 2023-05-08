Imports System.Net
Imports System.Web.Http
Imports vizeproje.Models;




Namespace Controllers
 {
    Public Class ServisController : Inherits ApiController
      {
Public Sub New(db As Object)
            Me.Db1 = db
        End Sub

        db = New DB01Entities();
        
            [HttpGet]
            [Route("api/ogrenciliste")]
            Public List<OgrenciModel> OgrenciListe() 
Public Property Db1 As Object
            Get
                Return db
            End Get
            Set(value As Object)
                db = value
            End Set
        End Property

                    {
                   List<OgrenciModel> Liste=sb.Ogrenci.Select(x=>New OgrenciModel(){
                   ogrId=x.ogrId,
                   ogrAdsoyad=x.ogrAdsoyad,
                   ogrMail=x.ogrMail,
                   ogrYas=x.ogrYas
                   }).ToList();

                Return liste;
            }
        }
      
            Public Class Form1
            Private Sub btnOgrEkle_Click(sender As Object, e As EventArgs) Handles btnOgrEkle.Click
                If txtOgr.Text = "" Then
                    MsgBox("Öğrenci Giriniz!", MsgBoxStyle.Critical, "Hata")
                    Return
                End If
                For i = 0 To lbOgrenci.Items.Count - 1
                    If lbOgrenci.Items(i) = txtOgr.Text Then
                        MsgBox("Öğrenci Listede Mevcut!", MsgBoxStyle.Critical, "Hata")
                        Return
                    End If
                Next
                lbOgrenci.Items.Add(txtOgr.Text)
                txtOgr.Clear()
            End Sub

            Private Sub btnOdevEkle_Click(sender As Object, e As EventArgs) Handles btnOdevEkle.Click
                If txtOdev.Text = "" Then
                    MsgBox("Ödev Giriniz!", MsgBoxStyle.Critical, "Hata")
                    Return
                End If
                For i = 0 To lbOdev.Items.Count - 1
                    If lbOdev.Items(i) = txtOdev.Text Then
                        MsgBox("Ödev Listede Mevcut!", MsgBoxStyle.Critical, "Hata")
                        Return
                    End If
                Next
                lbOdev.Items.Add(txtOdev.Text)
                txtOdev.Clear()
            End Sub

            Private Sub lbOgrenci_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbOgrenci.MouseDoubleClick
                If lbOgrenci.Items.Count > 0 And lbOgrenci.SelectedIndex >= 0 Then
                    lbOgrenci.Items.RemoveAt(lbOgrenci.SelectedIndex)
                End If
            End Sub

            Private Sub lbOdev_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbOdev.MouseDoubleClick
                If lbOdev.Items.Count > 0 And lbOdev.SelectedIndex >= 0 Then
                    lbOdev.Items.RemoveAt(lbOdev.SelectedIndex)
                End If
            End Sub

            Private Sub btnDagit_Click(sender As Object, e As EventArgs) Handles btnDagit.Click
                While ogrenciler.Count > 0
                    Ogrenci = ogrenciler(0).ToString()
                    Dim rasgele As New Random()
                    Dim s As Integer = rasgele.Next(0, odevler.Count)
                    odev = odevler(s).ToString()
                    ogrenciler.RemoveAt(0)
                    odevler.RemoveAt(s)
                    dgDagitim.Rows.Add(Ogrenci, odev)
                End While
            End Sub
        End Class
 }
Public Overrides Function Equals(obj As Object) As Boolean
            Dim controller = TryCast(obj, ServisController)
            Return controller IsNot Nothing AndAlso
                   EqualityComparer(Of Object).Default.Equals(Db1, controller.Db1)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Dim hashCode As Long = 1461503683
            hashCode = (hashCode * -1521134295 + EqualityComparer(Of Object).Default.GetHashCode(Db1)).GetHashCode()
            Return hashCode
        End Function
    End Class
End Namespace