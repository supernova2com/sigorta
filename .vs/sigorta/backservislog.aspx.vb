Public Partial Class backservislog
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If

        'eğer super admin değilse bu sayfayı göremesin
        If Session("kullanici_rolpkey") <> "2" Then
            Response.Redirect("yetkisiz.aspx")
        End If


        If Not Page.IsPostBack Then
            Dim backservislog_erisim As New CLASSBACKSERVISLOG_ERISIM
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = backservislog_erisim.listele()



        End If


    End Sub

End Class