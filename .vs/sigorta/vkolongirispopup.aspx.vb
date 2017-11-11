Public Partial Class vkolongirispopup
    Inherits System.Web.UI.Page


    Dim vkolon_erisim As New CLASSVKOLON_ERISIM

    'yetkiler icin 
    Dim tabload As String = "vtablo"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then
            Dim tabload As String
            tabload = Request.QueryString("tabload")
            Labelinput.Text = vkolon_erisim.inputlariolustur(tabload)
        End If




    End Sub



    'tablo açıklamalarını kaydet
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim tabload As String
        tabload = Request.QueryString("tabload")
 
        'önce tümünü sil---
        vkolon_erisim.ilgilitablosil(tabload)

      

        Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
        Dim kolonlar As New List(Of CLASSVERITABANI)
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)
        kolonlar = sqlveritabani_erisim.bulkolonadlari(site.sistemveritabaniad, tabload)


        For Each itemkolon As CLASSVERITABANI In kolonlar
            'tek satır kaydet
            Dim ivkolon As New CLASSVKOLON
            ivkolon = vkolon_erisim.temizle(ivkolon)
            For i = 1 To 1
                Dim kolonaciklama As String
                Dim oi As String
                oi = "A" + CStr(itemkolon.ilgiliad) + "_" + CStr(i)

                Try
                    kolonaciklama = Request.Form(oi)
                Catch ex As Exception
                    kolonaciklama = ""
                End Try


                ivkolon.tabload = tabload
                ivkolon.kolonad = itemkolon.ilgiliad

                If i = 1 Then
                    ivkolon.kolonaciklama = kolonaciklama
                End If

            Next
            vkolon_erisim.Ekle(ivkolon)
        Next

        Labelinput.Text = vkolon_erisim.inputlariolustur(tabload)

    End Sub

End Class