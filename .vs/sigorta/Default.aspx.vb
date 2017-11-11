Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("pano", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            If Session("kullanici_mensup") = "DİĞER" Then
                Response.Redirect("defaultsirket.aspx")
            End If

            Dim PolicyInfo_erisim As New PolicyInfo_Erisim
            Dim DamageInfo_erisim As New DamageInfo_Erisim
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim acente_Erisim As New CLASSACENTE_ERISIM


            Literaltoplampolice.Text = PolicyInfo_erisim.toplampolicesayisi().ToString("N0")
            Literaltoplamhasar.Text = DamageInfo_erisim.toplamhasarsayisi().ToString("N0")
            Literaltoplamsirket.Text = sirket_erisim.toplamsirketsayisi_tipegore("ŞİRKET").ToString("N0")
            Literaltoplamacente.Text = acente_Erisim.toplamacentesayisi().ToString("N0")

        End If


    End Sub

    Protected Sub raporolusturbutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles raporolusturbutton.Click

        Dim javascript As New CLASSJAVASCRIPT
        Dim degerlerdogrumu As String = "Evet"

        Dim validateresult As New CLADBOPRESULT
        validateresult.durum = "Kaydedildi"
        validateresult.etkilenen = 1
        validateresult.hatastr = ""

        Dim raporpkey As String
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        Dim deger As String
        raporpkey = HttpContext.Current.Session("raporpkey")
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)
        Dim link As String
        'DİNAMİK ARABİRİME GİRİLEN VERİLERİ ÇEK
        If kosullar.Count > 0 Then
            For Each kosulitem As CLASSKOSULFIELD In kosullar
                If kosulitem.runtime = "Evet" Then
                    deger = Request.Form("ss" + CStr(kosulitem.pkey))
                    HttpContext.Current.Session("ss" + CStr(kosulitem.pkey)) = deger
                    validateresult = dinamikrapor_erisim.validateinput(kosulitem.fieldtype, deger)
                    If validateresult.durum = "Kaydedilmedi" Then
                        degerlerdogrumu = "Hayır"
                    End If
                End If
            Next
        End If 'kosullar.count>0

        'eğer girilen değerler doğru ise
        If degerlerdogrumu = "Evet" Then
            link = "dinamikraporgoster.aspx?raporpkey=" + raporpkey
            Response.Redirect(link)
        End If

    End Sub



End Class