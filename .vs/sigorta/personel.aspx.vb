Public Partial Class personel
    Inherits System.Web.UI.Page

    Dim personel_erisim As New CLASSPERSONEL_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "personel"
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
                kullanici_erisim.busayfayigormeyeyetkilimi("personel", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = personel_erisim.listele()

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" Then
            Button1.Visible = False
            iframeyenikayit.Visible = False
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
        Else
            Button2.Visible = True
        End If
        If yetki.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        HttpContext.Current.Session("ltip") = "personeladsoyad"
        HttpContext.Current.Session("kriter") = TextBox1.Text
        Label1.Text = personel_erisim.listele()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        HttpContext.Current.Session("ltip") = "kimlikno"
        HttpContext.Current.Session("kriter") = TextBox2.Text
        Label1.Text = personel_erisim.listele()

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        HttpContext.Current.Session("ltip") = "tpno"
        HttpContext.Current.Session("kriter") = TextBox3.Text
        Label1.Text = personel_erisim.listele()

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click

        HttpContext.Current.Session("ltip") = "onaylanmamislar"
        Label1.Text = personel_erisim.listele()

    End Sub

 
    Protected Sub Buttoneposta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttoneposta.Click

        Dim elist As String = ""
        Dim personeller As New List(Of CLASSPERSONEL)
        personeller = personel_erisim.doldur

        For Each item As CLASSPERSONEL In personeller
            If item.epostap <> "" Then
                elist = elist + item.epostap + ","
            End If
        Next

        If Len(elist) > 0 Then
            elist = Mid(elist, 1, Len(elist) - 1)
        End If

        Label1.Text = elist


    End Sub
End Class