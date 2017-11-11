Public Partial Class yetkigirispopupbilgi
    Inherits System.Web.UI.Page

    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM

    Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI
    Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM

    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM
    Dim tmoduller As New List(Of CLASSTMODUL)

    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'eğer admin değilse
        If Session("webuye_uyetip") <> 1 Then
            Response.Redirect("bilgiyonetimgiris.aspx")
        End If

        If Not Page.IsPostBack Then

            Dim kullanicirolbilgipkey As String
            kullanicirolbilgipkey = Request.QueryString("kullanicirolpkey")

            kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(kullanicirolbilgipkey)
            Label1.Text = "İşlem yaptığınız kullanıcı rolü: " + kullanicirolbilgi.rolad

            Dim varmi As String
            varmi = yetkibilgi_erisim.kullanicirolvarmi(kullanicirolbilgipkey)
            If varmi = "Evet" Then
                Labelinput.Text = yetkibilgi_erisim.inputlariolustur(kullanicirolbilgipkey, "duzenle")
            End If

            If varmi = "Hayır" Then
                Labelinput.Text = yetkibilgi_erisim.inputlariolustur(kullanicirolbilgipkey, "yenikayit")
            End If


        End If 'postback


    End Sub



    'kullanicirolbilgi modulleri kaydet...
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim kullanicirolbilgipkey As String
        kullanicirolbilgipkey = Request.QueryString("kullanicirolpkey")

        'önce tümünü sil---
        yetkibilgi_erisim.ilgilisil(kullanicirolbilgipkey)
        tmoduller = tmodul_erisim.doldur

        For Each itemtmodul As CLASSTMODUL In tmoduller
            'tek satır kaydet

            Dim iyetkibilgi As New CLASSYETKIBILGI
            iyetkibilgi = yetkibilgi_erisim.temizle(iyetkibilgi)

            For i = 1 To 4
                Dim chkdeger As String
                Dim oi As String
                oi = "A" + CStr(itemtmodul.pkey) + "_" + CStr(i)

                chkdeger = Request.Form(oi)
                If chkdeger = "on" Then
                    chkdeger = "Evet"
                Else
                    chkdeger = "Hayır"
                End If

                iyetkibilgi.kullanicirolpkey = kullanicirolbilgipkey
                iyetkibilgi.tmodulpkey = itemtmodul.pkey

                If i = 1 Then
                    iyetkibilgi.insertyetki = chkdeger
                End If
                If i = 2 Then
                    iyetkibilgi.updateyetki = chkdeger
                End If
                If i = 3 Then
                    iyetkibilgi.deleteyetki = chkdeger
                End If
                If i = 4 Then
                    iyetkibilgi.readyetki = chkdeger
                End If
            Next

            yetkibilgi_erisim.Ekle(iyetkibilgi)
        Next

        Labelinput.Text = yetkibilgi_erisim.inputlariolustur(kullanicirolbilgipkey, "duzenle")
        inn.Value = "1"



    End Sub

 
End Class