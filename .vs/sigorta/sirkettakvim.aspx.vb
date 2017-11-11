Public Partial Class sirkettakvim
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("sirkettakvim", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'aktif şirket seçilmemişse döndür.
            If kullanici_erisim.aktifsirketsecilmismi = "Hayır" Then
                Response.Redirect("profile.aspx")
            End If

        End If 'postback

    End Sub
  
End Class