Public Partial Class hasariptalgoster
    Inherits System.Web.UI.Page

    Dim damagecancel As New CLASSDAMAGECANCEL
    Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("hasariptalgoster", Session("kullanici_rolpkey"))
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

            Label1.Text = damagecancel_erisim.hasariptal_tablo(FirmCode, ProductCode, _
            AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)

        End If



    End Sub

End Class