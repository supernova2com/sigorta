Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSOYA_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim oya As New CLASSOYA
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal oya As CLASSOYA) As CLADBOPRESULT

  
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into oya values (@pkey," + _
        "@sirketpkey,@acentepkey,@borcmiktar,@currencycodepkey," + _
        "@sure,@acentedurumpkey,@kayittarih,@guncellemetarih," + _
        "@kullanicipkey)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If oya.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = oya.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If oya.acentepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = oya.acentepkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@borcmiktar", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If oya.borcmiktar = 0 Then
            param4.Value = 0
        Else
            param4.Value = oya.borcmiktar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If oya.currencycodepkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = oya.currencycodepkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@sure", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If oya.sure = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = oya.sure
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@acentedurumpkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If oya.acentedurumpkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = oya.acentedurumpkey
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param8.Direction = ParameterDirection.Input
        If oya.kayittarih Is Nothing Or oya.kayittarih = "00:00:00" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = oya.kayittarih
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param9.Direction = ParameterDirection.Input
        If oya.guncellemetarih Is Nothing Or oya.guncellemetarih = "00:00:00" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = oya.guncellemetarih
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If oya.kullanicipkey = 0 Then
            param10.Value = 0
        Else
            param10.Value = oya.kullanicipkey
        End If
        komut.Parameters.Add(param10)

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
        sqlstr = "select max(pkey) from oya"
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
    Function Duzenle(ByVal oya As CLASSOYA) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update oya set " + _
        "sirketpkey=@sirketpkey," + _
        "acentepkey=@acentepkey," + _
        "borcmiktar=@borcmiktar," + _
        "currencycodepkey=@currencycodepkey," + _
        "sure=@sure," + _
        "acentedurumpkey=@acentedurumpkey," + _
        "kayittarih=@kayittarih," + _
        "guncellemetarih=@guncellemetarih," + _
        "kullanicipkey=@kullanicipkey" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = oya.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If oya.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = oya.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@acentepkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If oya.acentepkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = oya.acentepkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@borcmiktar", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If oya.borcmiktar = 0 Then
            param4.Value = 0
        Else
            param4.Value = oya.borcmiktar
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If oya.currencycodepkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = oya.currencycodepkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@sure", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If oya.sure = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = oya.sure
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@acentedurumpkey", SqlDbType.Int)
        param7.Direction = ParameterDirection.Input
        If oya.acentedurumpkey = 0 Then
            param7.Value = 0
        Else
            param7.Value = oya.acentedurumpkey
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param8.Direction = ParameterDirection.Input
        If oya.kayittarih Is Nothing Or oya.kayittarih = "00:00:00" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = oya.kayittarih
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param9.Direction = ParameterDirection.Input
        If oya.guncellemetarih Is Nothing Or oya.guncellemetarih = "00:00:00" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = oya.guncellemetarih
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If oya.kullanicipkey = 0 Then
            param10.Value = 0
        Else
            param10.Value = oya.kullanicipkey
        End If
        komut.Parameters.Add(param10)


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
    Function bultek(ByVal pkey As String) As CLASSOYA

        Dim komut As New SqlCommand
        Dim donecekoya As New CLASSOYA()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oya where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekoya.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekoya.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekoya.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("borcmiktar") Is System.DBNull.Value Then
                    donecekoya.borcmiktar = veri.Item("borcmiktar")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekoya.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("sure") Is System.DBNull.Value Then
                    donecekoya.sure = veri.Item("sure")
                End If

                If Not veri.Item("acentedurumpkey") Is System.DBNull.Value Then
                    donecekoya.acentedurumpkey = veri.Item("acentedurumpkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekoya.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekoya.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekoya.kullanicipkey = veri.Item("kullanicipkey")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekoya

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from oya where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSOYA)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekoya As New CLASSOYA
        Dim oyaler As New List(Of CLASSOYA)
        komut.Connection = db_baglanti
        sqlstr = "select * from oya"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekoya.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekoya.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                    donecekoya.acentepkey = veri.Item("acentepkey")
                End If

                If Not veri.Item("borcmiktar") Is System.DBNull.Value Then
                    donecekoya.borcmiktar = veri.Item("borcmiktar")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekoya.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("sure") Is System.DBNull.Value Then
                    donecekoya.sure = veri.Item("sure")
                End If

                If Not veri.Item("acentedurumpkey") Is System.DBNull.Value Then
                    donecekoya.acentedurumpkey = veri.Item("acentedurumpkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekoya.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekoya.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekoya.kullanicipkey = veri.Item("kullanicipkey")
                End If


                oyaler.Add(New CLASSOYA(donecekoya.pkey, _
                donecekoya.sirketpkey, donecekoya.acentepkey, donecekoya.borcmiktar, donecekoya.currencycodepkey, _
                donecekoya.sure, donecekoya.acentedurumpkey, donecekoya.kayittarih, donecekoya.guncellemetarih, _
                donecekoya.kullanicipkey))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return oyaler

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
        "<th>Acente Adı</th>" + _
        "<th>Yetkili Adı Soyadı</th>" + _
        "<th>Sicil No</th>" + _
        "<th>Borç Miktarı</th>" + _
        "<th>Borçlu Olduğu Süre</th>" + _
        "<th>Acente Durumu</th>" + _
        "<th>Kayıt Tarihi</th>" + _
        "<th>Güncelleme Tarih</th>" + _
        "<th>Kaydeden</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Anahtar", GetType(String))
        table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Acente Adı", GetType(String))
        table.Columns.Add("Yetkili Ad Soyadı", GetType(String))
        table.Columns.Add("Sicil No", GetType(String))
        table.Columns.Add("Borç Miktarı", GetType(String))
        table.Columns.Add("Borçlu Olduğu Süre", GetType(String))
        table.Columns.Add("Acente Durumu", GetType(String))
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
        pdftable.AddCell(New Phrase("Acente Adı", fbaslik))
        pdftable.AddCell(New Phrase("Yetkili Ad Soyadı", fbaslik))
        pdftable.AddCell(New Phrase("Sicil No", fbaslik))
        pdftable.AddCell(New Phrase("Borç Miktarı", fbaslik))
        pdftable.AddCell(New Phrase("Borçlu Olduğu Süre", fbaslik))
        pdftable.AddCell(New Phrase("Acente Durumu", fbaslik))
        pdftable.AddCell(New Phrase("Kayıt Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Güncelleme Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Kaydeden", fbaslik))


        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------


        If HttpContext.Current.Session("ltip") = "acentepkey" Then
            sqldevam = "acentepkey=@acentepkey"
            sqlstr = "select * from oya where " + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@acentepkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("acentepkey")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from oya order by sad"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        If HttpContext.Current.Session("ltip") = "TÜMÜŞİRKET" Then
            sqlstr = "select * from oya where sirketpkey=@sirketpkey order by sad "
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("webuye_sirketpkey")
            komut.Parameters.Add(param1)
        End If


        If HttpContext.Current.Session("ltip") = "oya_pkey" Then
            sqlstr = "select * from oya where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("oya_pkey")
            komut.Parameters.Add(param1)
        End If


        girdi = "0"
        Dim link As String
        Dim borcmiktar As Decimal
        Dim pkey, sirketpkey, acenteadsoyad, sicilno, adres, currencycodepkey, sure As String
        Dim acentedurumpkey, kayittarih, guncellemetarih, kullanicipkey As String
        Dim acentepkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

        Dim acentedurum As New CLASSACENTEDURUM
        Dim acentedurum_erisim As New CLASSACENTEDURUM_ERISIM


        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "oya.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
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

                    If Not veri.Item("acentepkey") Is System.DBNull.Value Then
                        acentepkey = veri.Item("acentepkey")
                    End If

                    acente = acente_erisim.bultek(acentepkey)


                    kol3 = "<td>" + acente.acentead + "</td>"
                    saf3 = acente.acentead


                    kol4 = "<td>" + acente.yetkiadsoyad + "</td>"
                    saf4 = acente.yetkiadsoyad


                    kol5 = "<td>" + acente.sicilno + "</td>"
                    saf5 = acente.sicilno


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

                    If Not veri.Item("acentedurumpkey") Is System.DBNull.Value Then
                        acentedurumpkey = veri.Item("acentedurumpkey")
                        acentedurum = acentedurum_erisim.bultek(acentedurumpkey)
                        kol8 = "<td>" + acentedurum.ad + "</td>"
                        saf8 = acentedurum.ad
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


    Function acentedurumvarmi(ByVal acentedurumpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from oya where acentedurumpkey=@acentedurumpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@acentedurumpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = acentedurumpkey
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


    '----------------------------------TOPLAM OYA SAYISI--------------------------------------
    Public Function toplamsayi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from oya"
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

        sqlstr = "select * from oya where currencycodepkey=@currencycodepkey"

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
