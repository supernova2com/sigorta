Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Public Class pertaracresimpopup
    Inherits System.Web.UI.Page

    'yetkiler icin 
    Dim tabload As String = "pertaracresim"
    Dim yetkibilgi_erisim As New CLASSYETKIBILGI_ERISIM
    Dim yetkibilgi As New CLASSYETKIBILGI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Dim webuye As New CLASSWEBUYE
    Dim webuye_erisim As New CLASSWEBUYE_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetkibilgi = yetkibilgi_erisim.bul_ilgili(Session("webuye_rolpkey"), tmodul.pkey)
        If yetkibilgi.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button3.Visible = False

        End If
        If yetkibilgi.insertyetki = "Evet" And opy = "yenikayit" Then
            Button3.Visible = True
        End If

        If yetkibilgi.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If

        If yetkibilgi.insertyetki = "Hayır" And yetkibilgi.updateyetki = "Hayır" And _
        yetkibilgi.deleteyetki = "Hayır" And yetkibilgi.readyetki = "Hayır" Then
            Response.Redirect("yetkisizbilgi.aspx")
        End If
        'yetki kontrol----------------------------------

        If Not Page.IsPostBack Then

            Dim pertaracpkey As String
            pertaracpkey = Request.QueryString("pertaracpkey")


            Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM

            If IsNumeric(pertaracpkey) = True Then
                Label1.Text = pertaracresim_erisim.listele(pertaracpkey)


                'ARAÇ BİLGİLERİNİ BUL
                Dim pertarac As New CLASSPERTARAC
                Dim pertarac_erisim As New CLASSPERTARAC_ERISIM
                pertarac = pertarac_erisim.bultek(pertaracpkey)

                'GİZLEMELERİ YAP 
                If Session("webuye_sirketpkey") = pertarac.sirketpkey Then
                    slideraccordion.Visible = False
                    resimeklemeaccordion.Visible = True
                    resimgridaccordion.Visible = True
                End If

                If Session("webuye_sirketpkey") <> pertarac.sirketpkey Then
                    Literalslide.Text = pertaracresim_erisim.bxslideryap(pertarac.pkey)
                    slideraccordion.Visible = True
                    resimeklemeaccordion.Visible = False
                    resimgridaccordion.Visible = False
                End If


                Dim aracbilgiyazi1 As String
                Dim aracbilgiyazi2 As String
                Dim araccins As New CLASSARACCINS
                Dim araccins_erisim As New CLASSARACCINS_ERISIM

                Dim sirket As New CLASSSIRKET
                Dim sirket_erisim As New CLASSSIRKET_ERISIM

                Dim aracmodel As New CLASSARACMODEL
                Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

                Dim aracmarka As New CLASSARACMARKA
                Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

                Dim currencycode As New CLASSCURRENCYCODE
                Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

                sirket = sirket_erisim.bultek(pertarac.sirketpkey)

                araccins = araccins_erisim.bultek(pertarac.araccinspkey)
                aracmarka = aracmarka_erisim.bultek(pertarac.aracmarkapkey)
                aracmodel = aracmodel_erisim.bultek(pertarac.aracmodelpkey)
                currencycode = currencycode_erisim.bultek(pertarac.currencycodepkey)
                webuye = webuye_erisim.bultek(pertarac.kullanicipkey)


                Labelaracbilgi1.Text = _
                "Şirket: " + "<b>" + sirket.sirketad + "</b><br/>" + _
                "Araç Cinsi: " + "<b>" + araccins.cinsad + "</b><br/>" + _
                "Araç Markası: " + "<b>" + aracmarka.markaad + "</b><br/>" + _
                "Araç Modeli: " + "<b>" + aracmodel.modelad + "</b><br/>" + _
                "Plaka: " + "<b>" + pertarac.plaka + "</b><br/>" + _
                "Şasi No: " + "<b>" + pertarac.sasino + "</b><br/>" + _
                "Motor No: " + "<b>" + pertarac.motorno + "</b><br/>" + _
                "Kapı Sayısı: " + "<b>" + CStr(pertarac.koltuksayi) + "</b>"

                Labelaracbilgi2.Text = _
                "Motor Gücü: " + "<b>" + CStr(pertarac.motorgucu) + "</b><br/>" + _
                "İmal Yılı: " + "<b>" + CStr(pertarac.imalyil) + "</b><br/>" + _
                "Kaza Tarihi: " + "<b>" + pertarac.kazatarih + "</b><br/>" + _
                "Ödenen Hasar: " + "<b>" + Format(pertarac.odenenhasar, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                "Piyasa Değeri: " + "<b>" + Format(pertarac.piyasadeger, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                "İlan Başlangıç Tarihi: " + "<b>" + pertarac.ilanbaslangictarih + "</b><br/>" + _
                "İlan Bitiş Tarihi: " + "<b>" + pertarac.ilanbitistarih + "</b><br/>" + _
                "Kayıt Yapan: " + "<b>" + webuye.adsoyad + "</b>"

            End If


        End If 'postback


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim result As New CLADBOPRESULT
        Dim hata, hatamesajlari As String
        Dim contype As String
        hata = "0"


        If Request.QueryString("op") = "yenikayit" Then

            If FileUpload1.HasFile = False Then
                FileUpload1.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "Yüklemek istediğiniz resmi seçmediniz. Browse düğmesine basınız.<br/>"
            End If


            If FileUpload1.HasFile = True Then
                contype = FileUpload1.PostedFile.ContentType.ToString
                If (contype <> "image/jpeg") And (contype <> "image/pjpeg") And (contype <> "image/bmp") And (contype <> "image/png") And (contype <> "image/gif") Then
                    hata = "1"
                    hatamesajlari = hatamesajlari + "Sadece resim dosyalarını (jpg,gif,png) yükleyebilirsiniz.<br/>"
                End If
            End If

        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        Dim root, yol, filename, tamyol, databaseyol As String

        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM
        Dim pertaracresim As New CLASSPERTARACRESIM


        If hata = "0" Then

            Dim dogrufilename As String
            Dim pertaracpkey As String
            pertaracpkey = Request.QueryString("pertaracpkey")

            filename = System.IO.Path.GetFileName(FileUpload1.FileName)

            dogrufilename = CStr(pertaracpkey) + "-" + _
            CStr(pertaracresim_erisim.aracinkacresmivar(pertaracpkey) + 1) + _
            GetRandomPasswordUsingGUID(5) + _
            Mid(filename, InStr(filename, ".", CompareMethod.Text), Len(filename))


            If Request.QueryString("op") = "yenikayit" Then

                root = Server.MapPath("~/" + "pertaracresim/")
                yol = root

                If Directory.Exists(yol) = False Then
                    Directory.CreateDirectory(yol)
                End If

                filename = System.IO.Path.GetFileName(FileUpload1.FileName)
                tamyol = yol + dogrufilename
                databaseyol = "pertaracresim/" + dogrufilename
                FileUpload1.SaveAs(yol + dogrufilename)
                Dim original As Image = Image.FromFile(tamyol)
                Dim resized As Image = ResizeImage(original, New Size(800, 600))
                original.Dispose()
                resized.Save(tamyol, ImageFormat.Jpeg)
                resized.Dispose()

                pertaracresim.dosyaad = dogrufilename
                pertaracresim.pertaracpkey = pertaracpkey
                'ilk kaydedilen resim ise otomatik olarak ana resim yap.
                If pertaracresim_erisim.aracinkacresmivar(pertaracpkey) >= 1 Then
                    pertaracresim.anaresim = "Hayır"
                Else
                    pertaracresim.anaresim = "Evet"
                End If

                result = pertaracresim_erisim.Ekle(pertaracresim)

            End If

           
            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/>" + _
                "</p></div>"

                If IsNumeric(pertaracpkey) = True Then
                    Label1.Text = pertaracresim_erisim.listele(pertaracpkey)
                End If

            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

        End If


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


    Public Function GetRandomPasswordUsingGUID(ByVal length As Integer) As String
        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()

        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)

        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If

        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function

End Class