Public Partial Class servisrapor
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim ozelrapor_erisim As New CLASSOZELRAPOR_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ozelrapor", Session("kullanici_rolpkey"))
        End If
        'login kontrol ----------------------------------------------
        If Session("kullanici_rolpkey") <> "2" Then
            Response.Redirect("yetkisiz.aspx")
        End If


        If Not Page.IsPostBack Then

            Dim ozelraporlog_erisim As New CLASSOZELRAPORLOG_ERISIM
            Label1.Text = ozelraporlog_erisim.listele

        End If


    End Sub




End Class