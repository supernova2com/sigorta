Public Partial Class policedetaysirket
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("policedetaysirket", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim FirmCode, ProductCode, AgencyCode As String
            Dim PolicyNumber, TecditNumber As String
            Dim ZeylCode, ZeylNo As String
            Dim ProductType As String

            FirmCode = Request.QueryString("FirmCode")
            ProductCode = Request.QueryString("ProductCode")
            AgencyCode = Request.QueryString("AgencyCode")
            PolicyNumber = Request.QueryString("PolicyNumber")
            TecditNumber = Request.QueryString("TecditNumber")
            ZeylCode = Request.QueryString("ZeylCode")
            ZeylNo = Request.QueryString("ZeylNo")
            ProductType = Request.QueryString("ProductType")


            Dim PolicyInfo_Erisim As New PolicyInfo_Erisim
            Dim DamageInfo_Erisim As New DamageInfo_Erisim

            Label1.Text = PolicyInfo_Erisim.tekpolice_tablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label2.Text = PolicyInfo_Erisim.tekpolice_aracbilgitablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label3.Text = PolicyInfo_Erisim.tekpolice_zeyiltablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, ProductType)

            Label4.Text = DamageInfo_Erisim.policeninhasari_tablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label5.Text = DamageInfo_Erisim.talepbilgi_tablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            'polis kullanısı ise talepi gösterme
            If Session("kullanici_rolpkey") = "9" Then
                Label5.Text = "-"
            End If

        End If


    End Sub

End Class