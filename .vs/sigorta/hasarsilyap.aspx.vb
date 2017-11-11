Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class hasarsilyap
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
            Dim damageinfo As New DamageInfo
            Dim damageinfo_erisim As New DamageInfo_Erisim

            Dim FirmCode, ProductCode, AgencyCode As String
            Dim PolicyNumber, TecditNumber, FileNo As String
            Dim RequestNo, ProductType As String

            FirmCode = Request.QueryString("FirmCode")
            ProductCode = Request.QueryString("ProductCode")
            AgencyCode = Request.QueryString("AgencyCode")
            PolicyNumber = Request.QueryString("PolicyNumber")
            TecditNumber = Request.QueryString("TecditNumber")
            FileNo = Request.QueryString("FileNo")
            RequestNo = Request.QueryString("RequestNo")
            ProductType = Request.QueryString("ProductType")

            damageinfo = damageinfo_erisim.bultek(FirmCode, ProductCode, FileNo, RequestNo, ProductType)

            donecekxml = damageinfo_erisim.xmlolustur(damageinfo)

            TextBox1.Text = donecekxml

        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT


        Dim FirmCode, ProductCode, AgencyCode As String
        Dim PolicyNumber, TecditNumber, FileNo As String
        Dim RequestNo, ProductType As String

        FirmCode = Request.QueryString("FirmCode")
        ProductCode = Request.QueryString("ProductCode")
        AgencyCode = Request.QueryString("AgencyCode")
        PolicyNumber = Request.QueryString("PolicyNumber")
        TecditNumber = Request.QueryString("TecditNumber")
        FileNo = Request.QueryString("FileNo")
        RequestNo = Request.QueryString("RequestNo")
        ProductType = Request.QueryString("ProductType")

        Dim damageinfo_erisim As New DamageInfo_Erisim
        result = damageinfo_erisim.sil(FirmCode, ProductCode, AgencyCode, _
        PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)

        durumlabel.Text = result.durum + " " + result.hatastr

        If result.durum = "Kaydedildi" Then

            Dim silinen As New CLASSSİLİNEN
            Dim silinen_erisim As New CLASSSİLİNEN_ERISIM

            silinen.ne = "Hasar"
            silinen.tarih = DateTime.Now
            silinen.xmlstr = TextBox1.Text
            silinen.kimpkey = Session("kullanici_pkey")
            silinen_erisim.Ekle(silinen)


        End If


    End Sub
End Class