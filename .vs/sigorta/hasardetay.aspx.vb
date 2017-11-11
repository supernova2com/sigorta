Public Partial Class hasardetay
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasarara", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

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

            Dim hasarinpoliceleri As New List(Of PolicyInfo)
            Dim PolicyInfo_Erisim As New PolicyInfo_Erisim
            Dim DamageInfo_Erisim As New DamageInfo_Erisim
            Dim logservis_Erisim As New CLASSLOGSERVIS_ERISIM

            Label1.Text = PolicyInfo_Erisim.hasarinpoliceleri_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label2.Text = PolicyInfo_Erisim.policearacbilgi_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label3.Text = DamageInfo_Erisim.policeninhasari_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label4.Text = DamageInfo_Erisim.talepbilgi_tablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label5.Text = logservis_Erisim.listele_ilgilihasar(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)

            Label6.Text = PolicyInfo_Erisim.tekpolice_zeyiltablo(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, ProductType)

        End If
    End Sub


End Class