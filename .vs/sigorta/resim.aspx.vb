Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Public Class resim
    Inherits System.Web.UI.Page


    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("resim", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
            Dim tekresim As New CLASSTEKRESIM

            Dim galeriana_erisim As New CLASSgaleriANA_ERISIM
            Dim galeriana As New CLASSGALERIANA
            Dim galeriler As New List(Of CLASSGALERIANA)

            ' ---------------------------------------
            galeriler = galeriana_erisim.doldur()
            For Each item As CLASSGALERIANA In galeriler
                DropDownList1.Items.Add(New ListItem(item.galeriadi, CStr(item.pkey)))
                DropDownList5.Items.Add(New ListItem(item.galeriadi, CStr(item.pkey)))
            Next

            DropDownList2.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList2.Items.Add(New ListItem("Hayır", "Hayır"))


            'TÜM GİRİLEN RESİMLERİ BUL
            'HttpContext.Current.Session("ltip") = "TÜMÜ"
            'Label1.Text = tekresim_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then
                Button1.Text = "Değişiklikleri Güncelle"
                Buttonsil.Visible = True

                tekresim = tekresim_erisim.bultek(Request.QueryString("pkey"))

                DropDownList1.SelectedValue = tekresim.galeripkey
                Textbox1.Text = tekresim.baslik
                Textbox2.Text = tekresim.resim_yukseklik
                Textbox3.Text = tekresim.resim_genislik
                DropDownList2.SelectedValue = tekresim.orjinalboyut
                Textbox4.Text = tekresim.ekkod


            End If


            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                DropDownList1.Focus()
            End If

            If Request.QueryString("op") = "" Then

                DropDownList1.Enabled = False
                FileUpload1.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False

            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String
        Dim contype As String

        durumlabelx.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------

        If DropDownList1.SelectedValue Is Nothing Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Resmin hangi galeri altında olduğunu girmediniz.<br/>"
        End If

        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Resim Başlığı girilmelidir.<br/>"
        End If

        If IsNumeric(Textbox2.Text) = False Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Resim yüksekliği rakamsal olmalıdır.<br/>"
        End If

        If IsNumeric(Textbox3.Text) = False Then
            Textbox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Resim genişliği rakamsal olmalıdır.<br/>"
        End If

        'İLK KAYITTA DOSYA SEÇMESİ ŞART -----
        If Request.QueryString("op") = "yenikayit" Then
            If FileUpload1.HasFile = False Then
                FileUpload1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Yüklemek istediğiniz resmi seçmediniz. Browse düğmesine basınız.<br/>"
            End If
        End If

        'YENİ KAYIT YADA DÜZENLEME OLSUN DOSYA ZARARLI OLMAMALI VE İSTEDİĞİMİZ TİPTE OLMALI
        If FileUpload1.HasFile = True Then
            contype = FileUpload1.PostedFile.ContentType.ToString
            If (contype <> "image/jpeg") And (contype <> "image/pjpeg") And (contype <> "image/bmp") And (contype <> "image/png") And (contype <> "image/gif") Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Sadece resim dosyalarını (jpg,gif,png) yükleyebilirsiniz.<br/>"
            End If
            If kullanici_erisim.dokumanzararlimi(System.IO.Path.GetFileName(FileUpload1.FileName)) = "Evet" Then
                hata = "1"
                hatamesajlari = hatamesajlari + "Dosya isminde boşluk veya zararlı bir uzantı olamaz.<br/>"
            End If
        End If


        If hata = "1" Then
            durumlabelx.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim root, yol, filename, tamyol, databaseyol As String

        Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
        Dim tekresim As New CLASSTEKRESIM

        If hata = "0" Then

            tekresim.baslik = Textbox1.Text
            tekresim.galeripkey = DropDownList1.SelectedValue

            If Request.QueryString("op") = "yenikayit" Then

                root = Server.MapPath("~/" + "galeri/" + filename + "/")
                yol = root

                If Directory.Exists(yol) = False Then
                    Directory.CreateDirectory(yol)
                End If

                filename = System.IO.Path.GetFileName(FileUpload1.FileName)
                tamyol = yol + filename
                databaseyol = "galeri/" + filename
                FileUpload1.SaveAs(yol + filename)

                tekresim.resim_yukseklik = Textbox2.Text
                tekresim.resim_genislik = Textbox3.Text
                tekresim.galeripkey = DropDownList1.SelectedValue
                tekresim.dosyaad = databaseyol
                tekresim.orjinalboyut = DropDownList2.SelectedValue
                tekresim.ekkod = Textbox4.Text

                If CheckBox1.Checked = True Then

                    Dim original As Image = Image.FromFile(tamyol)
                    Dim resized As Image = ResizeImage(original, New Size(800, 600))
                    original.Dispose()
                    'Dim memStream As MemoryStream = New MemoryStream()
                    'resized.Save(memStream, ImageFormat.Jpeg)
                    resized.Save(tamyol, ImageFormat.Jpeg)
                    resized.Dispose()

                End If

                result = tekresim_erisim.Ekle(tekresim)

            End If

            If Request.QueryString("op") = "duzenle" Then

                tekresim = tekresim_erisim.bultek(Request.QueryString("pkey"))

                If FileUpload1.HasFile = True Then

                    root = Server.MapPath("~/" + "galeri/" + filename + "/")
                    yol = root

                    If Directory.Exists(yol) = False Then
                        Directory.CreateDirectory(yol)
                    End If

                    filename = System.IO.Path.GetFileName(FileUpload1.FileName)
                    FileUpload1.SaveAs(yol + filename)
                    tamyol = yol + filename
                    databaseyol = "galeri/" + filename


                    If CheckBox1.Checked = True Then

                        Dim original As Image = Image.FromFile(tamyol)
                        Dim resized As Image = ResizeImage(original, New Size(800, 600))
                        original.Dispose()
                        'Dim memStream As MemoryStream = New MemoryStream()
                        'resized.Save(memStream, ImageFormat.Jpeg)
                        resized.Save(tamyol, ImageFormat.Jpeg)
                        resized.Dispose()

                    End If

                End If

                tekresim.resim_yukseklik = Textbox2.Text
                tekresim.resim_genislik = Textbox3.Text
                tekresim.galeripkey = DropDownList1.SelectedValue
                If FileUpload1.HasFile = True Then
                    tekresim.dosyaad = databaseyol
                End If
                tekresim.orjinalboyut = DropDownList2.SelectedValue
                tekresim.baslik = Textbox1.Text
                tekresim.ekkod = Textbox4.Text

                result = tekresim_erisim.Duzenle(tekresim)

            End If
            durumlabelx.Text = javascript.alertresult(result)

        End If


    End Sub



    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then
            Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
            Try
                result = tekresim_erisim.Sil(Request.QueryString("pkey"))
                durumlabelx.Text = javascript.alertresult(result)
            Catch ex As Exception
                durumlabelx.Text = javascript.alertresult(result)
            End Try
        End If


    End Sub



    Protected Sub Buttonyenikayit_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("resim.aspx?op=yenikayit")
        Button1.Text = "Kaydet"
        FileUpload1.Enabled = True
        Textbox1.Enabled = True
        DropDownList1.Enabled = True


    End Sub



    Public Shared Function ResizeImage(ByVal image As Image, _
      ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function



End Class