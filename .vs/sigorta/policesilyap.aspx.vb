Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class policesilyap
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasariptalyap", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim donecekxml As String
            Dim policyinfo As New PolicyInfo
            Dim policyinfo_erisim As New PolicyInfo_Erisim

            Dim FirmCode, ProductCode, AgencyCode As String
            Dim PolicyNumber, TecditNumber, ZeylCode As String
            Dim ZeylNo As String
            Dim ProductType As String

            FirmCode = Request.QueryString("FirmCode")
            ProductCode = Request.QueryString("ProductCode")
            AgencyCode = Request.QueryString("AgencyCode")
            PolicyNumber = Request.QueryString("PolicyNumber")
            TecditNumber = Request.QueryString("TecditNumber")
            ZeylCode = Request.QueryString("ZeylCode")
            ZeylNo = Request.QueryString("ZeylNo")
            ProductType = Request.QueryString("ProductType")

            policyinfo = policyinfo_erisim.bultek(FirmCode, ProductCode, AgencyCode, PolicyNumber, _
            TecditNumber, ZeylCode, ZeylNo,ProductType)

            donecekxml = policyinfo_erisim.xmlolustur(policyinfo)

            TextBox1.Text = donecekxml

        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT
        Dim hata As String = "0"

        Dim FirmCode, ProductCode, AgencyCode As String
        Dim PolicyNumber, TecditNumber, ZeylCode As String
        Dim ZeylNo As String
        Dim ProductType As String

        FirmCode = Request.QueryString("FirmCode")
        ProductCode = Request.QueryString("ProductCode")
        AgencyCode = Request.QueryString("AgencyCode")
        PolicyNumber = Request.QueryString("PolicyNumber")
        TecditNumber = Request.QueryString("TecditNumber")
        ZeylCode = Request.QueryString("ZeylCode")
        ZeylNo = Request.QueryString("ZeylNo")
        ProductType = Request.QueryString("ProductType")

        'BAK BAKALIM BU POLİÇENİN ALTINDA HASAR KAYDI VAR MI.
        Dim damageinfolar As New List(Of DamageInfo)
        Dim damageinfo_erisim As New DamageInfo_Erisim
        damageinfolar = damageinfo_erisim.hasardoldur_ilgilipolice(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ProductType)
        If damageinfolar.Count > 0 Then
            durumlabel.Text = "Bu poliçenin altında hasar kayıtları olduğundan bu poliçeyi silemezsiniz."
            hata = "1"
        End If

        If hata = "0" Then

            Dim policyinfo_erisim As New PolicyInfo_Erisim
            result = policyinfo_erisim.sil(FirmCode, ProductCode, AgencyCode, _
            PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            durumlabel.Text = result.durum + " " + result.hatastr

            If result.durum = "Kaydedildi" Then

                Dim silinen As New CLASSSİLİNEN
                Dim silinen_erisim As New CLASSSİLİNEN_ERISIM

                silinen.ne = "Poliçe"
                silinen.tarih = DateTime.Now
                silinen.xmlstr = TextBox1.Text
                silinen.kimpkey = Session("kullanici_pkey")
                silinen_erisim.Ekle(silinen)

            End If

        End If 'hata=0



    End Sub

End Class