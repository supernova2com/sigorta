Public Partial Class header
    Inherits System.Web.UI.UserControl

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init


        Dim javascript_erisim As New CLASSJAVASCRIPT
        Literalaktifjavascript.Text = javascript_erisim.menuaktiflestir()

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = True Then

            'kontrol et bakalım baglantisi kesilmişmi 
            Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM
            If baglantikes_erisim.baglantisikesilmisi(Session("kullanici_pkey")) = "Evet" Then
                Session("kullanici_pkey") = ""
                Session("kullanici_adsoyad") = ""
                Session("kullanici_rolpkey") = ""
                Session("kullanici_resimpkey") = ""
                Session("kullanici_sirketpkey") = ""
                Session("kullanici_acentepkey") = ""
                Session("kullanici_eposta") = ""
                Session("kullanici_aktifsirket") = ""
                Session("kullanici_mensup") = ""
                Session("kullanici_baglantikesildimi") = "Evet"
                Response.Redirect("yonetimgiris.aspx")
            Else
                Session("kullanici_baglantikesildimi") = "Hayır"
            End If

            Literalloginkullaniciad.Text = Session("kullanici_adsoyad")

            Dim resimhtml As String
            Dim resim As New CLASSTEKRESIM
            Dim resim_erisim As New CLASSTEKRESIM_ERISIM
            resimhtml = resim_erisim.loginresimolustur(Session("kullanici_resimpkey"))
            Literalloginresim.Text = resimhtml

            Dim msg_erisim As New CLASSMSG_ERISIM
            Dim okunmamismsjsayisi As Integer
            okunmamismsjsayisi = msg_erisim.okunmamismsgsayisi(Session("kullanici_pkey"))
            Labelokunmamismesajsayisi.Text = CStr(okunmamismsjsayisi)
            Labelokunmamismesajsayisi2.Text = CStr(okunmamismsjsayisi)
            Labelokunmamismesajsayisi3.Text = CStr(okunmamismsjsayisi)
            Labelmsgonizle.Text = msg_erisim.msgonizle(Session("kullanici_pkey"))

            Dim dosya_erisim As New CLASSDOSYA_ERISIM
            Dim okunmamisdosyasayisi As Integer
            okunmamisdosyasayisi = dosya_erisim.okunmamisdosyasayisi(Session("kullanici_pkey"))
            Labelokunmamisdosyasayisi.Text = CStr(okunmamisdosyasayisi)
            Labelokunmamisdosyasayisi2.Text = CStr(okunmamisdosyasayisi)
            Labeldosyaonizle.Text = dosya_erisim.dosyaonizle(Session("kullanici_pkey"))

            Dim errorlog_erisim As New CLASSERRORLOG_ERISIM
            Dim okunmamiserrorsayisi As Integer
            Labelokunmamiserrorsayi.Text = CStr(errorlog_erisim.okunmamiserrorsayisi)
            Labelokunmamiserrorsayi2.Text = CStr(errorlog_erisim.okunmamiserrorsayisi)
            labelerroronizle.text = errorlog_erisim.erroronizle()



            Dim menu_Erisim As New CLASSMENU_ERISIM
            Literalmenu.Text = menu_Erisim.menuyuolustur

        End If

    End Sub




End Class