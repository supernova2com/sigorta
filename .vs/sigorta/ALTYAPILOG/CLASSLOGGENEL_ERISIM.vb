Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSLOGGENEL_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim loggenel As New CLASSloggenel
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal loggenel As CLASSLOGGENEL) As CLADBOPRESULT

        etkilenen = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into loggenel values (@pkey," + _
        "@tarih,@kullanicipkey,@op,@tablo," + _
        "@islem,@aramaneyegore,@aramakriter,@refpkey," + _
        "@yanlissifrereset,@dkullaniciad,@dsifre,@ortam)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If loggenel.tarih Is Nothing Or loggenel.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = loggenel.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If loggenel.kullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = loggenel.kullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@op", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If loggenel.op = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = loggenel.op
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tablo", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If loggenel.tablo = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = loggenel.tablo
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@islem", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If loggenel.islem = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = loggenel.islem
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@aramaneyegore", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If loggenel.aramaneyegore = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = loggenel.aramaneyegore
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@aramakriter", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If loggenel.aramakriter = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = loggenel.aramakriter
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@refpkey", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If loggenel.refpkey = 0 Then
            param9.Value = 0
        Else
            param9.Value = loggenel.refpkey
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@yanlissifrereset", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If loggenel.yanlissifrereset = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = loggenel.yanlissifrereset
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@dkullaniciad", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If loggenel.dkullaniciad = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = loggenel.dkullaniciad
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@dsifre", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If loggenel.dsifre = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = loggenel.dsifre
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@ortam", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If loggenel.ortam = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = loggenel.ortam
        End If
        komut.Parameters.Add(param13)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from loggenel"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return pkey

    End Function

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal loggenel As CLASSLOGGENEL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update loggenel set " + _
        "tarih=@tarih," + _
        "kullanicipkey=@kullanicipkey," + _
        "op=@op," + _
        "tablo=@tablo," + _
        "islem=@islem," + _
        "aramaneyegore=@aramaneyegore," + _
        "aramakriter=@aramakriter," + _
        "refpkey=@refpkey," + _
        "yanlissifrereset=@yanlissifrereset," + _
        "dkullaniciad=@dkullaniciad," + _
        "dsifre=@dsifre," + _
        "ortam=@ortam" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = loggenel.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If loggenel.tarih Is Nothing Or loggenel.tarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = loggenel.tarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If loggenel.kullanicipkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = loggenel.kullanicipkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@op", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If loggenel.op = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = loggenel.op
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tablo", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If loggenel.tablo = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = loggenel.tablo
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@islem", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If loggenel.islem = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = loggenel.islem
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@aramaneyegore", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If loggenel.aramaneyegore = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = loggenel.aramaneyegore
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@aramakriter", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If loggenel.aramakriter = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = loggenel.aramakriter
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@refpkey", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If loggenel.refpkey = 0 Then
            param9.Value = 0
        Else
            param9.Value = loggenel.refpkey
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@yanlissifrereset", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If loggenel.yanlissifrereset = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = loggenel.yanlissifrereset
        End If
        komut.Parameters.Add(param10)


        Dim param11 As New SqlParameter("@dkullaniciad", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If loggenel.dkullaniciad = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = loggenel.dkullaniciad
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@dsifre", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If loggenel.dsifre = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = loggenel.dsifre
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@ortam", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If loggenel.ortam = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = loggenel.ortam
        End If
        komut.Parameters.Add(param13)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSloggenel

        Dim komut As New SqlCommand
        Dim donecekloggenel As New CLASSloggenel()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from loggenel where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekloggenel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekloggenel.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekloggenel.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("op") Is System.DBNull.Value Then
                    donecekloggenel.op = veri.Item("op")
                End If

                If Not veri.Item("tablo") Is System.DBNull.Value Then
                    donecekloggenel.tablo = veri.Item("tablo")
                End If

                If Not veri.Item("islem") Is System.DBNull.Value Then
                    donecekloggenel.islem = veri.Item("islem")
                End If

                If Not veri.Item("aramaneyegore") Is System.DBNull.Value Then
                    donecekloggenel.aramaneyegore = veri.Item("aramaneyegore")
                End If

                If Not veri.Item("aramakriter") Is System.DBNull.Value Then
                    donecekloggenel.aramakriter = veri.Item("aramakriter")
                End If

                If Not veri.Item("refpkey") Is System.DBNull.Value Then
                    donecekloggenel.refpkey = veri.Item("refpkey")
                End If

                If Not veri.Item("yanlissifrereset") Is System.DBNull.Value Then
                    donecekloggenel.yanlissifrereset = veri.Item("yanlissifrereset")
                End If

                If Not veri.Item("dkullaniciad") Is System.DBNull.Value Then
                    donecekloggenel.dkullaniciad = veri.Item("dkullaniciad")
                End If

                If Not veri.Item("dsifre") Is System.DBNull.Value Then
                    donecekloggenel.dsifre = veri.Item("dsifre")
                End If

                If Not veri.Item("ortam") Is System.DBNull.Value Then
                    donecekloggenel.ortam = veri.Item("ortam")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekloggenel

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from loggenel where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
   
        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSloggenel)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekloggenel As New CLASSloggenel
        Dim loggeneller As New List(Of CLASSloggenel)
        komut.Connection = db_baglanti
        sqlstr = "select * from loggenel"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekloggenel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    donecekloggenel.tarih = veri.Item("tarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekloggenel.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("op") Is System.DBNull.Value Then
                    donecekloggenel.op = veri.Item("op")
                End If

                If Not veri.Item("tablo") Is System.DBNull.Value Then
                    donecekloggenel.tablo = veri.Item("tablo")
                End If

                If Not veri.Item("islem") Is System.DBNull.Value Then
                    donecekloggenel.islem = veri.Item("islem")
                End If

                If Not veri.Item("aramaneyegore") Is System.DBNull.Value Then
                    donecekloggenel.aramaneyegore = veri.Item("aramaneyegore")
                End If

                If Not veri.Item("aramakriter") Is System.DBNull.Value Then
                    donecekloggenel.aramakriter = veri.Item("aramakriter")
                End If

                If Not veri.Item("refpkey") Is System.DBNull.Value Then
                    donecekloggenel.refpkey = veri.Item("refpkey")
                End If

                If Not veri.Item("yanlissifrereset") Is System.DBNull.Value Then
                    donecekloggenel.yanlissifrereset = veri.Item("yanlissifrereset")
                End If

                If Not veri.Item("dkullaniciad") Is System.DBNull.Value Then
                    donecekloggenel.dkullaniciad = veri.Item("dkullaniciad")
                End If

                If Not veri.Item("dsifre") Is System.DBNull.Value Then
                    donecekloggenel.dsifre = veri.Item("dsifre")
                End If

                If Not veri.Item("ortam") Is System.DBNull.Value Then
                    donecekloggenel.ortam = veri.Item("ortam")
                End If

                loggeneller.Add(New CLASSLOGGENEL(donecekloggenel.pkey, _
                donecekloggenel.tarih, donecekloggenel.kullanicipkey, donecekloggenel.op, _
                donecekloggenel.tablo, donecekloggenel.islem, _
                donecekloggenel.aramaneyegore, donecekloggenel.aramakriter, _
                donecekloggenel.refpkey, donecekloggenel.yanlissifrereset, _
                donecekloggenel.dkullaniciad, donecekloggenel.dsifre, _
                donecekloggenel.ortam))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return loggeneller

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12 As String

        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Ortam</th>" + _
        "<th>Şirket</th>" + _
        "<th>Acente</th>" + _
        "<th>Tarih</th>" + _
        "<th>Kullanıcı</th>" + _
        "<th>Operasyon</th>" + _
        "<th>Tablo</th>" + _
        "<th>İşlem</th>" + _
        "<th>Arama Bilgileri</th>" + _
        "<th>Arama Kriter</th>" + _
        "<th>Denenen Kullanıcı Adı</th>" + _
        "<th>Denenen Şifre</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Ortam", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Acente", GetType(String))
        table.Columns.Add("Tarih", GetType(String))
        table.Columns.Add("Kullanıcı", GetType(String))
        table.Columns.Add("Operasyon", GetType(String))
        table.Columns.Add("Tablo", GetType(String))
        table.Columns.Add("İşlem", GetType(String))
        table.Columns.Add("Arama Bilgileri", GetType(String))
        table.Columns.Add("Arama Kriter", GetType(String))
        table.Columns.Add("Denenen Kullanıcı Adı", GetType(String))
        table.Columns.Add("Denenen Şifre", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(12)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Ortam", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Acente", fbaslik))
        pdftable.AddCell(New Phrase("Tarih", fbaslik))
        pdftable.AddCell(New Phrase("Kullanıcı", fbaslik))
        pdftable.AddCell(New Phrase("Operasyon", fbaslik))
        pdftable.AddCell(New Phrase("Tablo", fbaslik))
        pdftable.AddCell(New Phrase("İşlem", fbaslik))
        pdftable.AddCell(New Phrase("Arama Bilgileri", fbaslik))
        pdftable.AddCell(New Phrase("Arama Kriter", fbaslik))
        pdftable.AddCell(New Phrase("Denenen Kullanıcı Adı", fbaslik))
        pdftable.AddCell(New Phrase("Denenen Şifre", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim sqldevam As String = ""


        'sirket secilmişse
        If HttpContext.Current.Session("sirket") <> "0" Then
            sqldevam = sqldevam + kullanici_erisim.sirketinkullanicisqlolustur(HttpContext.Current.Session("sirket"))
            'bu şirketin hiçbir kullanıcısı yok.
            If sqldevam = "" Then
                sqldevam = " and 1=2"
            End If
        End If

        'acente secilmişse
        If HttpContext.Current.Session("acente") <> "0" Then
            sqldevam = sqldevam + kullanici_erisim.acenteninkullanicisqlolustur(HttpContext.Current.Session("acente"))
            'bu acentenin hiçbir kullanıcısı yok.
            If sqldevam = "" Then
                sqldevam = " and 1=2"
            End If
        End If

        'ortam secilmisse
        If HttpContext.Current.Session("ortam") <> "0" Then
            sqldevam = sqldevam + " and ortam=@ortam"
        End If

        'kullanici secilmisse
        If HttpContext.Current.Session("kullanici") <> "0" Then
            sqldevam = sqldevam + " and kullanicipkey=@kullanicipkey"
        End If

        'islem seçilmişse
        If HttpContext.Current.Session("islem") <> "0" Then
            sqldevam = sqldevam + " and islem=@islem"
        End If

        sqlstr = "select * from loggenel where " + _
        "(Convert(DATE,tarih)>=@baslangic and Convert(DATE,tarih)<=@bitis)" + _
        sqldevam + " order by tarih desc"


        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = HttpContext.Current.Session("bitis")


        If HttpContext.Current.Session("ortam") <> "0" Then
            komut.Parameters.Add("@ortam", SqlDbType.VarChar)
            komut.Parameters("@ortam").Value = HttpContext.Current.Session("ortam")
        End If

        If HttpContext.Current.Session("kullanici") <> "0" Then
            komut.Parameters.Add("@kullanicipkey", SqlDbType.Int)
            komut.Parameters("@kullanicipkey").Value = HttpContext.Current.Session("kullanici")
        End If

        If HttpContext.Current.Session("islem") <> "0" Then
            komut.Parameters.Add("@islem", SqlDbType.VarChar)
            komut.Parameters("@islem").Value = HttpContext.Current.Session("islem")
        End If

        girdi = "0"

        Dim tarih, kullanicipkey, op As String
        Dim tablo, islem, aramaneyegore, aramakriter As String

        Dim kullanici As New CLASSKULLANICI


        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim acente As New CLASSACENTE

        Dim sirketpkey, acentepkey As String
        Dim dkullaniciad, dsifre As String
        Dim ortam As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                    Else
                        kullanicipkey = "0"
                    End If


                    If Not veri.Item("ortam") Is System.DBNull.Value Then
                        ortam = veri.Item("ortam")
                        kol1 = "<tr><td>" + ortam + "</td>"
                        saf1 = ortam
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If kullanicipkey <> "0" Then
                        sirket = sirket_erisim.bultek(kullanici.sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                        saf2 = sirket.sirketad
                        acente = acente_erisim.bultek(kullanici.acentepkey)
                        kol3 = "<td>" + acente.acentead + "</td>"
                        saf3 = acente.acentead
                    Else
                        kol2 = "<td>" + "-" + "</td>"
                        saf2 = "-"
                        kol3 = "<td>" + "-" + "</td>"
                        saf3 = "-"
                    End If


                    If Not veri.Item("tarih") Is System.DBNull.Value Then
                        tarih = veri.Item("tarih")
                        kol4 = "<td>" + tarih + "</td>"
                        saf4 = CStr(tarih)
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If


                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        kullanici = kullanici_erisim.bultek(kullanicipkey)
                        kol5 = "<td>" + kullanici.adsoyad + "</td>"
                        saf5 = kullanici.adsoyad
                    Else
                        kol5 = "<td>" + "-" + "</td>"
                        saf5 = "-"
                    End If


                    If Not veri.Item("op") Is System.DBNull.Value Then
                        op = veri.Item("op")
                        kol6 = "<td>" + op + "</td>"
                        saf6 = op
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("tablo") Is System.DBNull.Value Then
                        tablo = veri.Item("tablo")
                        kol7 = "<td>" + tablo + "</td>"
                        saf7 = tablo
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("islem") Is System.DBNull.Value Then
                        islem = veri.Item("islem")
                        kol8 = "<td>" + islem + "</td>"
                        saf8 = islem
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If

                    If Not veri.Item("aramaneyegore") Is System.DBNull.Value Then
                        aramaneyegore = veri.Item("aramaneyegore")
                        kol9 = "<td>" + aramaneyegore + "</td>"
                        saf9 = aramaneyegore
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If

                    If Not veri.Item("aramakriter") Is System.DBNull.Value Then
                        aramakriter = veri.Item("aramakriter")
                        kol10 = "<td>" + aramakriter + "</td>"
                        saf10 = aramakriter
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If

                    If Not veri.Item("dkullaniciad") Is System.DBNull.Value Then
                        dkullaniciad = veri.Item("dkullaniciad")
                        kol11 = "<td>" + dkullaniciad + "</td>"
                        saf11 = dkullaniciad
                    Else
                        kol11 = "<td>-</td>"
                        saf11 = "-"
                    End If

                    If Not veri.Item("dsifre") Is System.DBNull.Value Then
                        dsifre = veri.Item("dsifre")
                        kol12 = "<td>" + dsifre + "</td></tr>"
                        saf12 = dsifre
                    Else
                        kol12 = "<td>-</td>"
                        saf12 = "-"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9, saf10, saf11, saf12)

                    pdftable.AddCell(New Phrase(saf1, fdata))
                    pdftable.AddCell(New Phrase(saf2, fdata))
                    pdftable.AddCell(New Phrase(saf3, fdata))
                    pdftable.AddCell(New Phrase(saf4, fdata))
                    pdftable.AddCell(New Phrase(saf5, fdata))
                    pdftable.AddCell(New Phrase(saf6, fdata))
                    pdftable.AddCell(New Phrase(saf7, fdata))
                    pdftable.AddCell(New Phrase(saf8, fdata))
                    pdftable.AddCell(New Phrase(saf9, fdata))
                    pdftable.AddCell(New Phrase(saf10, fdata))
                    pdftable.AddCell(New Phrase(saf11, fdata))
                    pdftable.AddCell(New Phrase(saf12, fdata))

                    recordcount = recordcount + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function



    '---------------KULLANICI ŞİFRESİNİ SIFIRLA------------------------------------
    Function hatalisifresifirla(ByVal kullanicipkey As String) As CLADBOPRESULT

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
        kullanici = kullanici_Erisim.bultek(kullanicipkey)

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update loggenel set " + _
        "yanlissifrereset=@yanlissifrereset" + _
        " where islem=@islem and " + _
        "dkullaniciad=@dkullaniciad"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@yanlissifrereset", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Evet"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@islem", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Hatalı Giriş"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@dkullaniciad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = kullanici.kullaniciad
        komut.Parameters.Add(param3)
      
        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen >= 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    Public Function songiristarihibul(ByVal kullanicipkey) As DateTime

        Dim tarih As DateTime

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select tarih=max(tarih),islem from loggenel group by" + _
        " kullanicipkey,islem having kullanicipkey=@kullanicipkey and " + _
        " islem=@islem"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@islem", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Giriş"
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    tarih = veri.Item("tarih")
                Else
                    tarih = ""
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()



        Return tarih

    End Function



    Public Function soncikistarihibul(ByVal kullanicipkey) As DateTime

        Dim tarih As DateTime

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select tarih=max(tarih),islem from loggenel group by" + _
        " kullanicipkey,islem having kullanicipkey=@kullanicipkey and " + _
        " islem=@islem"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicipkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@islem", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Çıkış"
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("tarih") Is System.DBNull.Value Then
                    tarih = veri.Item("tarih")
                Else
                    tarih = ""
                End If

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()


        Return tarih

    End Function

End Class

