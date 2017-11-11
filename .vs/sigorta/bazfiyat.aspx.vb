Public Partial Class bazfiyat
    Inherits System.Web.UI.Page

    Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "bazfiyat"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("bazfiyat", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR---------------------------------------
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = bazfiyat_erisim.listele()

        End If


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)

        If yetki.insertyetki = "Hayır" Then
            iframeyenikayit.Visible = False
        Else
            iframeyenikayit.Visible = True
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

        HttpContext.Current.Session("ltip") = "sirketpkey"
        HttpContext.Current.Session("kriter") = DropDownList1.SelectedValue
        Label1.Text = bazfiyat_erisim.listele()

    End Sub

End Class