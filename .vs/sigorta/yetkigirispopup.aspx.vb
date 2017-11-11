Public Partial Class yetkigirispopup
    Inherits System.Web.UI.Page


    Dim yetki As New CLASSYETKI
    Dim yetki_erisim As New CLASSYETKI_ERISIM

    Dim kullanicirol As New CLASSKULLANICIROL
    Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM
    Dim tmoduller As New List(Of CLASSTMODUL)


    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("yetkigirispopup", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            Dim kullanicirolpkey As String
            kullanicirolpkey = Request.QueryString("kullanicirolpkey")

            kullanicirol = kullanicirol_erisim.bultek(kullanicirolpkey)
            Label1.Text = "İşlem yaptığınız kullanıcı rolü: " + kullanicirol.rolad


            Dim varmi As String
            varmi = yetki_erisim.kullanicirolvarmi(kullanicirolpkey)
            If varmi = "Evet" Then
                Labelinput.Text = yetki_erisim.inputlariolustur(kullanicirolpkey, "duzenle")
            End If

            If varmi = "Hayır" Then
                Labelinput.Text = yetki_erisim.inputlariolustur(kullanicirolpkey, "yenikayit")
            End If



        End If 'postback


    End Sub



    'kullanicirol modulleri kaydet...
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim kullanicirolpkey As String
        kullanicirolpkey = Request.QueryString("kullanicirolpkey")

        'önce tümünü sil---
        yetki_erisim.ilgilisil(kullanicirolpkey)
        tmoduller = tmodul_erisim.doldur

        For Each itemtmodul As CLASSTMODUL In tmoduller
            'tek satır kaydet

            Dim iyetki As New CLASSYETKI
            iyetki = yetki_erisim.temizle(iyetki)

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

                iyetki.kullanicirolpkey = kullanicirolpkey
                iyetki.tmodulpkey = itemtmodul.pkey

                If i = 1 Then
                    iyetki.insertyetki = chkdeger
                End If
                If i = 2 Then
                    iyetki.updateyetki = chkdeger
                End If
                If i = 3 Then
                    iyetki.deleteyetki = chkdeger
                End If
                If i = 4 Then
                    iyetki.readyetki = chkdeger
                End If
            Next

            yetki_erisim.Ekle(iyetki)
        Next

        Labelinput.Text = yetki_erisim.inputlariolustur(kullanicirolpkey, "duzenle")
        inn.Value = "1"



    End Sub



End Class