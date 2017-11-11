Public Partial Class acente
    Inherits System.Web.UI.Page

    Dim acente_erisim As New CLASSACENTE_ERISIM

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "acente"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("acente", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            Dim acente_erisim As New CLASSACENTE_ERISIM
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = acente_erisim.listele

        End If


        'yetki kontrol ------------------------------
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" Then
            iframeyenikayit.Visible = False
        End If
        If yetki.readyetki = "Hayır" Then
            Label1.Visible = False
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        If yetki.updateyetki = "Hayır" Then
            Buttonaktifyap.Visible = False
            Buttonpasifyap.Visible = False
            Buttonaktifvepasif.Visible = False
        End If
        'yetki kontrol-------------------------------

    End Sub

    Protected Sub Buttonaktifyap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonaktifyap.Click

        Dim tumacenteler As New List(Of CLASSACENTE)

        Dim inp As String
        Dim secim As String

        Dim acentepkeystring As String = ""
        tumacenteler = acente_erisim.doldur()

        For Each acenteitem As CLASSACENTE In tumacenteler

            inp = "A_" + CStr(acenteitem.pkey)
            secim = Request.Form(inp)
            If secim = "on" Then
                acentepkeystring = acentepkeystring + CStr(acenteitem.pkey) + ","
                acente_erisim.aktifyap(acenteitem.pkey)
            End If
        Next

        If Len(acentepkeystring) <= 0 Then
            Labeluyari.Text = "<div class='alert alert-danger'>" + _
            "Herhangi bir kayıt seçmediniz." + _
            "</div>"
        End If

        If Len(acentepkeystring) > 0 Then
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = acente_erisim.listele
        End If



    End Sub

    Protected Sub Buttonpasifyap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpasifyap.Click

        Dim tumacenteler As New List(Of CLASSACENTE)
        Dim inp As String
        Dim secim As String

        Dim acentepkeystring As String = ""
        tumacenteler = acente_erisim.doldur()

        For Each acenteitem As CLASSACENTE In tumacenteler

            inp = "A_" + CStr(acenteitem.pkey)
            secim = Request.Form(inp)
            If secim = "on" Then
                acentepkeystring = acentepkeystring + CStr(acenteitem.pkey) + ","
                acente_erisim.pasifyap(acenteitem.pkey)
            End If
        Next

        If Len(acentepkeystring) <= 0 Then
            Labeluyari.Text = "<div class='alert alert-danger'>" + _
            "Herhangi bir kayıt seçmediniz." + _
            "</div>"
        End If

        If Len(acentepkeystring) > 0 Then
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = acente_erisim.listele
        End If

    End Sub


    Protected Sub Buttonaktifvepasif_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonaktifvepasif.Click

        Dim tumacenteler As New List(Of CLASSACENTE)
        Dim inp As String
        Dim secim As String

        Dim acentepkeystring As String = ""
        tumacenteler = acente_erisim.doldur()

        For Each acenteitem As CLASSACENTE In tumacenteler

            inp = "A_" + CStr(acenteitem.pkey)
            secim = Request.Form(inp)
            If secim = "on" Then
                acentepkeystring = acentepkeystring + CStr(acenteitem.pkey) + ","
                acente_erisim.aktifyap(acenteitem.pkey)
            End If
            If secim <> "on" Then
                acente_erisim.pasifyap(acenteitem.pkey)
            End If
        Next

        If Len(acentepkeystring) <= 0 Then
            Labeluyari.Text = "<div class='alert alert-danger'>" + _
            "Herhangi bir kayıt seçmediniz." + _
            "</div>"
        End If

        If Len(acentepkeystring) > 0 Then
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = acente_erisim.listele
        End If
    End Sub



    Protected Sub Buttonpasifgoster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpasifgoster.Click

        HttpContext.Current.Session("ltip") = "PASİF"
        Label1.Text = acente_erisim.listele

    End Sub

    Protected Sub Buttonaktifgoster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonaktifgoster.Click

        HttpContext.Current.Session("ltip") = "AKTİF"
        Label1.Text = acente_erisim.listele

    End Sub

 
End Class