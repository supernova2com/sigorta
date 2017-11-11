Public Partial Class gonderilenmesaj
    Inherits System.Web.UI.Page


    Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
    Dim msg_erisim As New CLASSMSG_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_Erisim.busayfayigormeyeyetkilimi("mesaj", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then
            'GÖNDERİLEN MESAJLARIMI LİSTELE
            Label1.Text = msg_erisim.gonderdigimmesajlarim(Session("kullanici_pkey"))
        End If

    End Sub


End Class