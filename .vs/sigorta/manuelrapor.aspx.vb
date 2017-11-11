Public Partial Class manuelrapor
    Inherits System.Web.UI.Page

    Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol -------------------------------------------
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            End If
            If Session("kullanici_rolpkey") <> "2" Then
                Response.Redirect("yetkisiz.aspx")
            End If
            'login kontrol -----------------------------------------

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = manuelrapor_erisim.listele

            'MANUEL RAPORLARI DOLDUR

            Dim manuelraporlar As New List(Of CLASSMANUELRAPOR)
            manuelraporlar = manuelrapor_erisim.doldur
            For Each item As CLASSMANUELRAPOR In manuelraporlar
                DropDownList1.Items.Add(New ListItem(item.ad, item.pkey))
                DropDownList2.Items.Add(New ListItem(item.ad, item.pkey))
            Next

        End If

    End Sub

    Protected Sub Unnamed1_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim javascript As New CLASSJAVASCRIPT
        Dim result As New CLADBOPRESULT

        Dim manuelraporpkey As String
        manuelraporpkey = DropDownList1.SelectedValue
        result = manuelrapor_erisim.testcalistir(manuelraporpkey)
        durumvalidatelabel.Text = javascript.alertresult(result)


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim javascript As New CLASSJAVASCRIPT
        Dim donen As String

        Dim hata As String
        hata = "0"
        Dim raporpkey As String
        raporpkey = DropDownList2.SelectedValue

        If raporpkey = "0" Then
            hata = "1"
            durumvalidatelabel.Text = javascript.alert("Hangi raprorun kopyasının oluşturulacağını seçmediniz. ", "danger", 5, "warning")
        End If

        'KOPYASINI OLUŞTURMAYA BAŞLA 

        If hata = "0" Then
            donen = manuelrapor_erisim.kopyasiniolustur(raporpkey)
            durumvalidatelabel.Text = javascript.alert(donen, "success", 60, "check")

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = manuelrapor_erisim.listele


        End If
    End Sub
End Class