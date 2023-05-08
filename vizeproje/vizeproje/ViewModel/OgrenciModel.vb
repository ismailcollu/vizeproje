Public Class OgrenciModel
    { 
        Public Integer ogrId{ Get; Set;}
        Public String ogrNo { Get; Set;}
        Public String ogrAdsoyad {Get; Set;}
        Public String ogrMail{ Get; Set;}
        Public Integer ogrYas{ Get; Set; }
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
End Class
