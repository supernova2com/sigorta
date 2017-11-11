Public Partial Class aractarifepopup
    Inherits System.Web.UI.Page

    Dim aractarife As New CLASSARACTARIFE
    Dim aractarife_Erisim As New CLASSARACTARIFE_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM



    'yetkiler icin 
    Dim tabload As String = "aractarife"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("aractarife", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            TextBox1.Focus()

            If Request.QueryString("op") = "yenikayit" Then
                Button2.Visible = False

            End If

            If Request.QueryString("op") = "duzenle" Then

                Button2.Visible = True
                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                aractarife = aractarife_Erisim.bultek(Request.QueryString("pkey"))

                TextBox1.Text = aractarife.tarifekod
                TextBox2.Text = aractarife.tarifead

            End If


            'yetki kontrol ------------------------------
            Dim opy As String
            opy = Request.QueryString("op")
            tmodul = tmodul_erisim.bultabloadagore(tabload)
            yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
            If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
            If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
            If yetki.deleteyetki = "Hayır" Then
                Button2.Visible = False
            End If
            If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
                Button2.Visible = True
            End If
            If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
            yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
                Response.Redirect("yetkisiz.aspx")
            End If
            'yetki kontrol----------------------------------


        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'tarifkod
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Araç tarife kodunu girmediniz.</li>"
            inn.Value = "0"
        End If

        'tarifead
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Araç tarife adını girmediniz.</li>"
            inn.Value = "0"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        If hata = "0" Then

            hatamesajlari = ""


            aractarife.tarifekod = TextBox1.Text
            aractarife.tarifead = TextBox2.Text

            If Request.QueryString("op") = "yenikayit" Then
                result = aractarife_erisim.Ekle(aractarife)
            End If

            If Request.QueryString("op") = "duzenle" Then
                aractarife = aractarife_erisim.bultek(Request.QueryString("pkey"))

                aractarife.tarifekod = TextBox1.Text
                aractarife.tarifead = TextBox2.Text
                result = aractarife_erisim.Duzenle(aractarife)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If


            'Label1.Text = aractarife_erisim.listele("")
        End If

    End Sub



    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click


        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM

            result = aractarife_erisim.Sil(Request.QueryString("pkey"))
            durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"

            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub


End Class