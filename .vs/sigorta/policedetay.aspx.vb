Public Partial Class policedetay
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("policeara", Session("kullanici_rolpkey"))
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
            Dim logservis_Erisim As New CLASSLOGSERVIS_ERISIM

            Label1.Text = PolicyInfo_Erisim.tekpolice_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label2.Text = PolicyInfo_Erisim.tekpolice_aracbilgitablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label7.Text = PolicyInfo_Erisim.tekpolice_primtablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label3.Text = DamageInfo_Erisim.policeninhasari_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label4.Text = DamageInfo_Erisim.talepbilgi_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label5.Text = logservis_Erisim.listele_ilgilipolice(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

            Label6.Text = PolicyInfo_Erisim.tekpolice_zeyiltablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, ProductType)



        End If


    End Sub

End Class