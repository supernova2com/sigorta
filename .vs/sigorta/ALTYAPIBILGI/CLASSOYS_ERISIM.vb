Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSOYS_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim oys As New CLASSOYS
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal oys As CLASSOYS) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer

        etkilenen = 0
 
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into oys values (@pkey," + _
        "@sirketpkey,@sad,@ssoyad,@policeturpkey," + _
        "@borcmiktar,@currencycodepkey,@sure,@sigortalidurumpkey," + _
        "@kayittarih,@guncellemetarih,@kullanicipkey)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        kaydedilenpkey = pkeybul()
        param1.Value = kaydedilenpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If oys.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = oys.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If oys.sad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = oys.sad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ssoyad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If oys.ssoyad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = oys.ssoyad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@policeturpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If oys.policeturpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = oys.policeturpkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@borcmiktar", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If oys.borcmiktar = 0 Then
            param6.Value = 0
        Else
            param6.Value = oys.borcmiktar
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If oys.currencycodepkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = oys.currencycodepkey
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@sure", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If oys.sure = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = oys.sure
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@sigortalidurumpkey", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If oys.sigortalidurumpkey = 0 Then
            param9.Value = 0
        Else
            param9.Value = oys.sigortalidurumpkey
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param10.Direction = ParameterDirection.Input
        If oys.kayittarih Is Nothing Or oys.kayittarih = "00:00:00" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = oys.kayittarih
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param11.Direction = ParameterDirection.Input
        If oys.guncellemetarih Is Nothing Or oys.guncellemetarih = "00:00:00" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = oys.guncellemetarih
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If oys.kullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = oys.kullanicipkey
        End If
        komut.Parameters.Add(param12)

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
            resultset.etkilenen = kaydedilenpkey
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
        sqlstr = "select max(pkey) from oys"
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
    Function Duzenle(ByVal oys As CLASSOYS) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update oys set " + _
        "sirketpkey=@sirketpkey," + _
        "sad=@sad," + _
        "ssoyad=@ssoyad," + _
        "policeturpkey=@policeturpkey," + _
        "borcmiktar=@borcmiktar," + _
        "currencycodepkey=@currencycodepkey," + _
        "sure=@sure," + _
        "sigortalidurumpkey=@sigortalidurumpkey," + _
        "kayittarih=@kayittarih," + _
        "guncellemetarih=@guncellemetarih," + _
        "kullanicipkey=@kullanicipkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = oys.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If oys.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = oys.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@sad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If oys.sad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = oys.sad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@ssoyad", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If oys.ssoyad = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = oys.ssoyad
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@policeturpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If oys.policeturpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = oys.policeturpkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@borcmiktar", SqlDbType.Decimal)
        param6.Direction = ParameterDirection.Input
        If oys.borcmiktar = 0 Then
            param6.Value = 0
        Else
            param6.Value = oys.borcmiktar
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If oys.currencycodepkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = oys.currencycodepkey
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@sure", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If oys.sure = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = oys.sure
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@sigortalidurumpkey", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If oys.sigortalidurumpkey = 0 Then
            param9.Value = 0
        Else
            param9.Value = oys.sigortalidurumpkey
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param10.Direction = ParameterDirection.Input
        If oys.kayittarih Is Nothing Or oys.kayittarih = "00:00:00" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = oys.kayittarih
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param11.Direction = ParameterDirection.Input
        If oys.guncellemetarih Is Nothing Or oys.guncellemetarih = "00:00:00" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = oys.guncellemetarih
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        If oys.kullanicipkey = 0 Then
            param12.Value = 0
        Else
            param12.Value = oys.kullanicipkey
        End If
        komut.Parameters.Add(param12)


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
            resultset.etkilenen = oys.pkey
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSOYS

        Dim komut As New SqlCommand
        Dim donecekoys As New CLASSOYS()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oys where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekoys.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekoys.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("sad") Is System.DBNull.Value Then
                    donecekoys.sad = veri.Item("sad")
                End If

                If Not veri.Item("ssoyad") Is System.DBNull.Value Then
                    donecekoys.ssoyad = veri.Item("ssoyad")
                End If

                If Not veri.Item("policeturpkey") Is System.DBNull.Value Then
                    donecekoys.policeturpkey = veri.Item("policeturpkey")
                End If

                If Not veri.Item("borcmiktar") Is System.DBNull.Value Then
                    donecekoys.borcmiktar = veri.Item("borcmiktar")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekoys.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("sure") Is System.DBNull.Value Then
                    donecekoys.sure = veri.Item("sure")
                End If

                If Not veri.Item("sigortalidurumpkey") Is System.DBNull.Value Then
                    donecekoys.sigortalidurumpkey = veri.Item("sigortalidurumpkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekoys.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekoys.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekoys.kullanicipkey = veri.Item("kullanicipkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekoys

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from oys where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSOYS)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekoys As New CLASSOYS
        Dim oysler As New List(Of CLASSOYS)
        komut.Connection = db_baglanti
        sqlstr = "select * from oys"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekoys.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekoys.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("sad") Is System.DBNull.Value Then
                    donecekoys.sad = veri.Item("sad")
                End If

                If Not veri.Item("ssoyad") Is System.DBNull.Value Then
                    donecekoys.ssoyad = veri.Item("ssoyad")
                End If

                If Not veri.Item("policeturpkey") Is System.DBNull.Value Then
                    donecekoys.policeturpkey = veri.Item("policeturpkey")
                End If

                If Not veri.Item("borcmiktar") Is System.DBNull.Value Then
                    donecekoys.borcmiktar = veri.Item("borcmiktar")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekoys.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("sure") Is System.DBNull.Value Then
                    donecekoys.sure = veri.Item("sure")
                End If

                If Not veri.Item("sigortalidurumpkey") Is System.DBNull.Value Then
                    donecekoys.sigortalidurumpkey = veri.Item("sigortalidurumpkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekoys.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekoys.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekoys.kullanicipkey = veri.Item("kullanicipkey")
                End If


                oysler.Add(New CLASSOYS(donecekoys.pkey, _
                donecekoys.sirketpkey, donecekoys.sad, donecekoys.ssoyad, donecekoys.policeturpkey, _
                donecekoys.borcmiktar, donecekoys.currencycodepkey, donecekoys.sure, donecekoys.sigortalidurumpkey, _
                donecekoys.kayittarih, donecekoys.guncellemetarih, donecekoys.kullanicipkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return oysler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR


        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0


        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11, kol12 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, saf11, saf12 As String

        Dim sqldevam As String = ""
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
        "<th>Anahtar</th>" + _
        "<th>Şirket</th>" + _
        "<th>Sigortalı Adı</th>" + _
        "<th>Sigortalı Soyadı</th>" + _
        "<th>Poliçe Türü</th>" + _
        "<th>Borç Miktarı</th>" + _
        "<th>Borçlu Olduğu Süre</th>" + _
        "<th>Sigortalı Durumu</th>" + _
        "<th>Kayıt Tarihi</th>" + _
        "<th>Güncelleme Tarih</th>" + _
        "<th>Kaydeden</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Anahtar", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Sigortalı Adı", GetType(String))
        table.Columns.Add("Sigortalı Soyadı", GetType(String))
        table.Columns.Add("Poliçe Türü", GetType(String))
        table.Columns.Add("Borç Miktarı", GetType(String))
        table.Columns.Add("Borçlu Olduğu Süre", GetType(String))
        table.Columns.Add("Sigortalı Durumu", GetType(String))
        table.Columns.Add("Kayıt Tarihi", GetType(String))
        table.Columns.Add("Güncelleme Tarihi", GetType(String))
        table.Columns.Add("Kaydeden", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(11)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Anahtar", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Sigortalı Adı", fbaslik))
        pdftable.AddCell(New Phrase("Sigortalı Soyadı", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe Türü", fbaslik))
        pdftable.AddCell(New Phrase("Borç Miktarı", fbaslik))
        pdftable.AddCell(New Phrase("Borçlu Olduğu Süre", fbaslik))
        pdftable.AddCell(New Phrase("Sigortalı Durumu", fbaslik))
        pdftable.AddCell(New Phrase("Kayıt Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Güncelleme Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Kaydeden", fbaslik))


        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "adsoyad" Then

            sqldevam = " sad LIKE '%'+@sad+'%'" + " and ssoyad LIKE '%'+@ssoyad+'%'"
            sqlstr = "select * from oys where " + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@sad", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("sad")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@ssoyad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("ssoyad")
            komut.Parameters.Add(param2)

        End If

        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from oys order by sad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        If HttpContext.Current.Session("ltip") = "TÜMÜŞİRKET" Then
            sqlstr = "select * from oys where sirketpkey=@sirketpkey order by sad"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("webuye_sirketpkey")
            komut.Parameters.Add(param1)

        End If


        If HttpContext.Current.Session("ltip") = "oys_pkey" Then

            sqlstr = "select * from oys where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("oys_pkey")
            komut.Parameters.Add(param1)

        End If


        girdi = "0"
        Dim link As String
        Dim borcmiktar As Decimal
        Dim pkey, sirketpkey, sad, ssoyad, policeturpkey, currencycodepkey, sure As String
        Dim sigortalidurumpkey, kayittarih, guncellemetarih, kullanicipkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

        Dim sigortalidurum As New CLASSSIGORTALIDURUM
        Dim sigortalidurum_erisim As New CLASSSIGORTALIDURUM_ERISIM

        Dim policetur As New CLASSPOLICETUR
        Dim policetur_erisim As New CLASSPOLİCETUR_ERISIM

        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "oys.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                        saf1 = pkey
                    Else
                        kol1 = "<tr><td>-</td>"
                        saf1 = "-"
                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        kol2 = "<td>" + sirket.sirketad + "</td>"
                        saf2 = sirket.sirketad
                    Else
                        kol2 = "<td>-</td>"
                        saf2 = "-"
                    End If

                    If Not veri.Item("sad") Is System.DBNull.Value Then
                        sad = veri.Item("sad")
                        kol3 = "<td>" + sad + "</td>"
                        saf3 = sad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("ssoyad") Is System.DBNull.Value Then
                        ssoyad = veri.Item("ssoyad")
                        kol4 = "<td>" + ssoyad + "</td>"
                        saf4 = ssoyad
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("policeturpkey") Is System.DBNull.Value Then
                        policeturpkey = veri.Item("policeturpkey")
                        policetur = policetur_erisim.bultek(policeturpkey)
                        kol5 = "<td>" + policetur.ad + "</td>"
                        saf5 = policetur.ad
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                        currencycodepkey = veri.Item("currencycodepkey")
                    Else
                        currencycodepkey = "0"
                    End If

                    currencycode = currencycode_erisim.bultek(currencycodepkey)
                    If Not veri.Item("borcmiktar") Is System.DBNull.Value Then
                        borcmiktar = veri.Item("borcmiktar")
                        kol6 = "<td>" + Format(borcmiktar, "0.00") + " " + currencycode.aciklama + "</td>"
                        saf6 = Format(borcmiktar, "0.00") + " " + currencycode.aciklama
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If


                    If Not veri.Item("sure") Is System.DBNull.Value Then
                        sure = veri.Item("sure")
                        kol7 = "<td>" + sure + "</td>"
                        saf7 = sure
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("sigortalidurumpkey") Is System.DBNull.Value Then
                        sigortalidurumpkey = veri.Item("sigortalidurumpkey")
                        sigortalidurum = sigortalidurum_erisim.bultek(sigortalidurumpkey)
                        kol8 = "<td>" + sigortalidurum.ad + "</td>"
                        saf8 = sigortalidurum.ad
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If

                    If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                        kayittarih = veri.Item("kayittarih")
                        kol9 = "<td>" + kayittarih + "</td>"
                        saf9 = kayittarih
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If

                    If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                        guncellemetarih = veri.Item("guncellemetarih")
                        kol10 = "<td>" + guncellemetarih + "</td>"
                        saf10 = guncellemetarih
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If

                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        webuye = webuye_erisim.bultek(kullanicipkey)
                        kol11 = "<td>" + webuye.adsoyad + "</td></tr>"
                        saf11 = webuye.adsoyad
                    Else
                        kol11 = "<td>-</td></tr>"
                        saf11 = "-"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9, saf10, saf11)


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


                    recordcount = recordcount + 1


                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        If recordcount > 0 Then
            rapor.kacadet = recordcount
            rapor.tablo = table
            rapor.pdftablo = pdftable
            rapor.veri = basliklar + satir + tabloson + jvstring
        End If

        Return rapor

    End Function


    Function policeturvarmi(ByVal policeturpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oys where policeturpkey=@policeturpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@policeturpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = policeturpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function sigortalidurumvarmi(ByVal sigortalidurumpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oys where sigortalidurumpkey=@sigortalidurumpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sigortalidurumpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sigortalidurumpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    '----------------------------------TOPLAM OYS SAYISI---------------------------------------
    Public Function toplamsayi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from oys"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            toplam = 0
        Else
            toplam = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return toplam

    End Function


    Function currencycodevarmi(ByVal currencycodepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oys where currencycodepkey=@currencycodepkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = currencycodepkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function

 
End Class


