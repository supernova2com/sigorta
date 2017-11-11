Public Partial Class hasardetaysirket
    Inherits System.Web.UI.Page

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasardetaysirket", Session("kullanici_rolpkey"))
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

            Label1.Text = PolicyInfo_Erisim.hasarinpoliceleri_tablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

            Label2.Text = PolicyInfo_Erisim.policearacbilgi_tablo_sirketicin(FirmCode, _
            ProductCode, AgencyCode, PolicyNumber, TecditNumber, ProductType)

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