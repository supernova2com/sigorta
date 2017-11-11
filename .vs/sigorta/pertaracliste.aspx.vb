Public Partial Class pertaracliste
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'SIRALAMA SEÇENEKLERİNİ DOLDUR 
            DropDownList1.Items.Add(New ListItem("İlan Tarihi [Yeniden Eskiye]", "1"))
            DropDownList1.Items.Add(New ListItem("İlan Tarihi [Eskiden Yeniye]", "2"))
            DropDownList1.Items.Add(New ListItem("Piyasa Değeri [Pahalıdan Ucuza]", "3"))
            DropDownList1.Items.Add(New ListItem("Piyasa Değeri [Ucuzdan Pahalıya]", "1"))

            'SAYFALAMA SEÇENEKLERİ

            DropDownList2.Items.Add(New ListItem("5", "5"))
            DropDownList2.Items.Add(New ListItem("10", "10"))
            DropDownList2.Items.Add(New ListItem("50", "50"))
            DropDownList2.Items.Add(New ListItem("100", "100"))
            DropDownList2.Items.Add(New ListItem("TÜMÜ", "0"))

            'MARKALARI DOLDUR
            'araç markalarını doldur 
            DropDownList3.Items.Add(New ListItem("TÜMÜ", "0"))
            Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM
            Dim aracmarkalar As New List(Of CLASSARACMARKA)
            aracmarkalar = aracmarka_erisim.doldur_araccinsgore(DropDownList1.SelectedValue)
            For Each item As CLASSARACMARKA In aracmarkalar
                DropDownList3.Items.Add(New ListItem(item.markaad, CStr(item.pkey)))
            Next

            'LİSTELEME --------------------
            Dim pertarac_erisim As New CLASSPERTARAC_ERISIM

            HttpContext.Current.Session("ltip") = "TÜMÜ"

            HttpContext.Current.Session("pertaraclistesira") = "1"
            HttpContext.Current.Session("teksayfadakacadet") = "5"
            HttpContext.Current.Session("aracmarkapkey") = "0"
            labelaracliste.Text = pertarac_erisim.listeleblog()
            labelsayfalama.Text = pertarac_erisim.sayfalamayap

        End If
    End Sub

End Class