Public Partial Class vtablo
    Inherits System.Web.UI.Page


    Dim vtablo_erisim As New CLASSVTABLO_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "vtablo"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            'VERİTABANI TABLOLARI DOLDUR---------------------------------------
            Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
            Dim tablolar As New List(Of CLASSVERITABANI)
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)

            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            For Each item As CLASSVERITABANI In tablolar
                DropDownList1.Items.Add(New ListItem(item.ilgiliad, CStr(item.ilgiliad)))
            Next

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = vtablo_erisim.listele()

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

        HttpContext.Current.Session("ltip") = "tabload"
        HttpContext.Current.Session("tabload") = DropDownList1.SelectedValue
        Label1.Text = vtablo_erisim.listele()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        HttpContext.Current.Session("tabload") = DropDownList1.SelectedValue
        Label1.Text = vtablo_erisim.listele()

    End Sub
End Class