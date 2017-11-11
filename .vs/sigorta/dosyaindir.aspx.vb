Public Partial Class dosyaindir
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim dosya As New CLASSDOSYA
            Dim dosya_erisim As New CLASSDOSYA_ERISIM

            Dim pkey As String
            pkey = Request.QueryString("pkey")
            dosya = dosya_erisim.bultek(pkey)
            dosya_erisim.okunduyap(pkey)
            download(dosya)

        End If

    End Sub


    Protected Sub download(ByVal dosya As CLASSDOSYA)
        Dim bytes() As Byte = dosya.fileg
        Dim ifilename As String = Server.UrlPathEncode(dosya.filename)
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = dosya.contype
        Response.AddHeader("content-disposition", "attachment; filename=\" + ifilename)

        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub

End Class