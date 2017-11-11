Public Partial Class vtablogirispopup
    Inherits System.Web.UI.Page

    Dim vtablo_erisim As New CLASSVTABLO_ERISIM

    'yetkiler icin 
    Dim tabload As String = "vkolon"
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

        Dim op As String

        If Not Page.IsPostBack Then

            op = Request.QueryString("op")


            If op = "yenikayit" Then
                Labelinput.Text = vtablo_erisim.inputlariolustur("yenikayit")
            End If

            If op = "duzenle" Then
                Labelinput.Text = vtablo_erisim.inputlariolustur("duzenle")
            End If

        End If 'postback




    End Sub


   
    'tablo açıklamalarını kaydet
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click


        'önce tümünü sil---
        vtablo_erisim.tumunusil()

        Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
        Dim tablolar As New List(Of CLASSVERITABANI)
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)
        tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)


        For Each itemtablo As CLASSVERITABANI In tablolar
            'tek satır kaydet
            Dim ivtablo As New CLASSVTABLO
            ivtablo = vtablo_erisim.temizle(ivtablo)
            For i = 1 To 1
                Dim aciklama As String
                Dim oi As String
                oi = "A" + CStr(itemtablo.ilgiliad) + "_" + CStr(i)

                Try
                    aciklama = Request.Form(oi)
                Catch ex As Exception
                    aciklama = ""
                End Try

                ivtablo.aciklama = aciklama
                If i = 1 Then
                    ivtablo.tabload = itemtablo.ilgiliad
                End If
               
            Next
            vtablo_erisim.Ekle(ivtablo)
        Next

        Labelinput.Text = vtablo_erisim.inputlariolustur("duzenle")

    End Sub

End Class