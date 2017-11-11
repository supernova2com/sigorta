Public Partial Class anagaleripopup
    Inherits System.Web.UI.Page


    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("galeri", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        Button1.Attributes.Add("onkeypress", "return clickButton(event,'" + Button1.ClientID + "')")

        Dim galeriana_erisim As New CLASSGALERIANA_ERISIM
        Dim galeriana As New CLASSGALERIANA

        If Not Page.IsPostBack Then

            TextBox10.Focus()
            'TÜM GİRİLEN icerikleri bul

            If Request.QueryString("op") = "duzenle" Then

                Button2.Visible = True
                Button1.Text = "Değişiklikleri Güncelle"
                galeriana = galeriana_erisim.bultek(Request.QueryString("pkey"))
                TextBox10.Text = galeriana.galeriadi
            End If

            If Request.QueryString("op") = "yenikayit" Then
                Button2.Visible = False
                TextBox10.Focus()
            End If

            If Request.QueryString("op") = "" Then
                TextBox10.Enabled = False
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata As String
        Dim hatatext As String

        durumlabel.Text = ""

        hata = "0"

        ' galeri adini kontrol et ---------------------------
        If TextBox10.Text = "" Then
            hatatext = hatatext + "<li>Galeri adını girmediniz.</li>"
            TextBox10.Focus()
            hata = "1"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + hatatext + "</ol></div>"
        End If

        Dim galeriana As New CLASSGALERIANA
        Dim galeriana_erisim As New CLASSgaleriANA_ERISIM


        If hata = "0" Then

            galeriana.galeriadi = TextBox10.Text

            If Request.QueryString("op") = "yenikayit" Then
                galeriana_erisim.ekle(galeriana)
            End If

            If Request.QueryString("op") = "duzenle" Then
                galeriana = galeriana_erisim.bultek(Request.QueryString("pkey"))
                galeriana.galeriadi = TextBox10.Text
                galeriana_erisim.Duzenle(galeriana)

            End If

            durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"

            'Label1.Text = galeriana_erisim.listele("")
        End If

    End Sub




    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim galeriana_erisim As New CLASSgaleriANA_ERISIM

            Try
                result = galeriana_erisim.Sil(Request.QueryString("pkey"))

                If result.durum = "Kaydedildi" Then
                    durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                End If

                If result.hatastr <> "" Then
                    durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                    "<li>" + result.hatastr + "</li></ol></div>"
                End If

            Catch ex As Exception
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>Bu kayıdı silemezsiniz çünkü başka kayıtlarla ilişiklidir.</li></ol></div>"
            End Try
        End If


        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If

    End Sub

End Class