Public Partial Class defaultsirket
    Inherits System.Web.UI.Page


    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("pano", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            'doğru yönlendir
            Dim kullanicirol As New CLASSKULLANICIROL
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            kullanicirol = kullanicirol_erisim.bultek(Session("kullanici_rolpkey"))
            If InStr(HttpContext.Current.Request.Url.AbsolutePath, kullanicirol.yonsayfa, 0) <= 0 Then
                Response.Redirect(kullanicirol.yonsayfa)
            End If

            Dim PolicyInfo_erisim As New PolicyInfo_Erisim
            Dim DamageInfo_erisim As New DamageInfo_Erisim
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim acente_Erisim As New CLASSACENTE_ERISIM

            'GENEL RAKAMLARI GÖSTER
            Literaltoplampolice.Text = PolicyInfo_erisim.toplampolicesayisi().ToString("N0")
            Literaltoplamhasar.Text = DamageInfo_erisim.toplamhasarsayisi().ToString("N0")
            Literaltoplamsirket.Text = sirket_erisim.toplamsirketsayisi_tipegore("ŞİRKET").ToString("N0")
            Literaltoplamacente.Text = acente_Erisim.toplamacentesayisi().ToString("N0")



            'ŞİRKETE ÖZEL RAKAMLARI GÖSTER
            If Session("kullanici_aktifsirket") <> "" Then
                Dim sirketinacenteleri As New List(Of CLASSACENTE)
                Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
                Literaltoplampolice_sirketicin.Text = CStr(PolicyInfo_erisim.toplampolicesayisi_sirketicin(Session("kullanici_aktifsirket")))
                Literaltoplamhasar_sirketicin.Text = CStr(DamageInfo_erisim.toplamhasarsayisi_sirketicin(Session("kullanici_aktifsirket")))
                Literaltoplamsirket_sirketicin.Text = "1"
                sirketinacenteleri = sirketacentebag_erisim.doldursirketinacenteleri_acentetipinde(Session("kullanici_aktifsirket"))
                Literaltoplamacente_sirketicin.Text = CStr(sirketinacenteleri.Count)
            End If


        End If


    End Sub


End Class