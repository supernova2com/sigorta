Public Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then


            'ÖNCE LOGLA 
            Dim loggenel As New CLASSLOGGENEL
            Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM

            loggenel = New CLASSLOGGENEL(0, DateTime.Now, Session("kullanici_pkey"), "", _
             "kullanici", "Çıkış", "", "", 0, "Hayır", Session("kullanici_adsoyad"), "", "Web")
            loggenel_erisim.Ekle(loggenel)

            Session.Clear()
            Session.Abandon()
            Session.RemoveAll()

            Response.Redirect("yonetimgiris.aspx")
        End If


    End Sub

End Class