Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSPERSONEL_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim personel As New CLASSpersonel
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal personel As CLASSPERSONEL) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("personeladsoyad", personel.personeladsoyad)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu isimli personel halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        varmi = ciftkayitkontrol("kimlikno", personel.kimlikno)
        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kimlik numaralı personel halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If


        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into personel values (@pkey," + _
            "@personeladsoyad,@kimlikno,@teknikpersonelmi,@tpno," + _
            "@ceptel,@adres,@bolge,@egitimekatildimi," + _
            "@egitimno,@onaylanmismi,@verildigitarih,@belgetarih," + _
            "@islemkullanicipkey,@epostap)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@personeladsoyad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If personel.personeladsoyad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = personel.personeladsoyad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If personel.kimlikno = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = personel.kimlikno
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@teknikpersonelmi", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If personel.teknikpersonelmi = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = personel.teknikpersonelmi
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@tpno", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If personel.tpno = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = personel.tpno
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@ceptel", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If personel.ceptel = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = personel.ceptel
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@adres", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If personel.adres = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = personel.adres
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@bolge", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If personel.bolge = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = personel.bolge
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@egitimekatildimi", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If personel.egitimekatildimi = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = personel.egitimekatildimi
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@egitimno", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If personel.egitimno = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = personel.egitimno
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@onaylanmismi", SqlDbType.VarChar)
            param11.Direction = ParameterDirection.Input
            If personel.onaylanmismi = "" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = personel.onaylanmismi
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@verildigitarih", SqlDbType.Date)
            param12.Direction = ParameterDirection.Input
            If personel.verildigitarih Is Nothing Or personel.verildigitarih = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = personel.verildigitarih
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@belgetarih", SqlDbType.Date)
            param13.Direction = ParameterDirection.Input
            If personel.belgetarih Is Nothing Or personel.belgetarih = "00:00:00" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = personel.belgetarih
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@islemkullanicipkey", SqlDbType.Int)
            param14.Direction = ParameterDirection.Input
            If personel.islemkullanicipkey = 0 Then
                param14.Value = 0
            Else
                param14.Value = personel.islemkullanicipkey
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@epostap", SqlDbType.VarChar, 254)
            param15.Direction = ParameterDirection.Input
            If personel.epostap = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = personel.epostap
            End If
            komut.Parameters.Add(param15)


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

        End If
        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from personel"
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
    Function Duzenle(ByVal personel As CLASSPERSONEL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update personel set " + _
        "personeladsoyad=@personeladsoyad," + _
        "kimlikno=@kimlikno," + _
        "teknikpersonelmi=@teknikpersonelmi," + _
        "tpno=@tpno," + _
        "ceptel=@ceptel," + _
        "adres=@adres," + _
        "bolge=@bolge," + _
        "egitimekatildimi=@egitimekatildimi," + _
        "egitimno=@egitimno," + _
        "onaylanmismi=@onaylanmismi," + _
        "verildigitarih=@verildigitarih," + _
        "belgetarih=@belgetarih," + _
        "islemkullanicipkey=@islemkullanicipkey," + _
        "epostap=@epostap" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = personel.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@personeladsoyad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If personel.personeladsoyad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = personel.personeladsoyad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If personel.kimlikno = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = personel.kimlikno
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@teknikpersonelmi", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If personel.teknikpersonelmi = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = personel.teknikpersonelmi
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tpno", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If personel.tpno = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = personel.tpno
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@ceptel", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If personel.ceptel = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = personel.ceptel
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@adres", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If personel.adres = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = personel.adres
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@bolge", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If personel.bolge = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = personel.bolge
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@egitimekatildimi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If personel.egitimekatildimi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = personel.egitimekatildimi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@egitimno", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If personel.egitimno = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = personel.egitimno
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@onaylanmismi", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If personel.onaylanmismi = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = personel.onaylanmismi
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@verildigitarih", SqlDbType.Date)
        param12.Direction = ParameterDirection.Input
        If personel.verildigitarih Is Nothing Or personel.verildigitarih = "00:00:00" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = personel.verildigitarih
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@belgetarih", SqlDbType.Date)
        param13.Direction = ParameterDirection.Input
        If personel.belgetarih Is Nothing Or personel.belgetarih = "00:00:00" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = personel.belgetarih
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@islemkullanicipkey", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If personel.islemkullanicipkey = 0 Then
            param14.Value = 0
        Else
            param14.Value = personel.islemkullanicipkey
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@epostap", SqlDbType.VarChar, 254)
        param15.Direction = ParameterDirection.Input
        If personel.epostap = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = personel.epostap
        End If
        komut.Parameters.Add(param15)


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
    Function bultek(ByVal pkey As String) As CLASSpersonel

        Dim komut As New SqlCommand
        Dim donecekpersonel As New CLASSpersonel()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from personel where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpersonel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                    donecekpersonel.personeladsoyad = veri.Item("personeladsoyad")
                End If

                If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                    donecekpersonel.kimlikno = veri.Item("kimlikno")
                End If

                If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                    donecekpersonel.teknikpersonelmi = veri.Item("teknikpersonelmi")
                End If

                If Not veri.Item("tpno") Is System.DBNull.Value Then
                    donecekpersonel.tpno = veri.Item("tpno")
                End If

                If Not veri.Item("ceptel") Is System.DBNull.Value Then
                    donecekpersonel.ceptel = veri.Item("ceptel")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekpersonel.adres = veri.Item("adres")
                End If

                If Not veri.Item("bolge") Is System.DBNull.Value Then
                    donecekpersonel.bolge = veri.Item("bolge")
                End If

                If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                    donecekpersonel.egitimekatildimi = veri.Item("egitimekatildimi")
                End If

                If Not veri.Item("egitimno") Is System.DBNull.Value Then
                    donecekpersonel.egitimno = veri.Item("egitimno")
                End If

                If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                    donecekpersonel.onaylanmismi = veri.Item("onaylanmismi")
                End If

                If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                    donecekpersonel.verildigitarih = veri.Item("verildigitarih")
                End If

                If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                    donecekpersonel.belgetarih = veri.Item("belgetarih")
                End If

                If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                    donecekpersonel.islemkullanicipkey = veri.Item("islemkullanicipkey")
                End If

                If Not veri.Item("epostap") Is System.DBNull.Value Then
                    donecekpersonel.epostap = veri.Item("epostap")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpersonel

    End Function


    Function bul_tpnogore(ByVal tpno As String, ByVal teknikpersonelmi As String) As CLASSPERSONEL

        Dim komut As New SqlCommand
        Dim donecekpersonel As New CLASSPERSONEL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from personel where tpno=@tpno and teknikpersonelmi=@teknikpersonelmi"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tpno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tpno
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@teknikpersonelmi", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = teknikpersonelmi
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpersonel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                    donecekpersonel.personeladsoyad = veri.Item("personeladsoyad")
                End If

                If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                    donecekpersonel.kimlikno = veri.Item("kimlikno")
                End If

                If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                    donecekpersonel.teknikpersonelmi = veri.Item("teknikpersonelmi")
                End If

                If Not veri.Item("tpno") Is System.DBNull.Value Then
                    donecekpersonel.tpno = veri.Item("tpno")
                End If

                If Not veri.Item("ceptel") Is System.DBNull.Value Then
                    donecekpersonel.ceptel = veri.Item("ceptel")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekpersonel.adres = veri.Item("adres")
                End If

                If Not veri.Item("bolge") Is System.DBNull.Value Then
                    donecekpersonel.bolge = veri.Item("bolge")
                End If

                If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                    donecekpersonel.egitimekatildimi = veri.Item("egitimekatildimi")
                End If

                If Not veri.Item("egitimno") Is System.DBNull.Value Then
                    donecekpersonel.egitimno = veri.Item("egitimno")
                End If

                If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                    donecekpersonel.onaylanmismi = veri.Item("onaylanmismi")
                End If

                If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                    donecekpersonel.verildigitarih = veri.Item("verildigitarih")
                End If

                If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                    donecekpersonel.belgetarih = veri.Item("belgetarih")
                End If

                If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                    donecekpersonel.islemkullanicipkey = veri.Item("islemkullanicipkey")
                End If

                If Not veri.Item("epostap") Is System.DBNull.Value Then
                    donecekpersonel.epostap = veri.Item("epostap")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpersonel

    End Function


    Function bultpnovekimliknogore(ByVal tpno As String, ByVal kimlikno As String) As CLASSPERSONEL

        Dim komut As New SqlCommand
        Dim donecekpersonel As New CLASSPERSONEL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from personel where tpno=@tpno and kimlikno=@kimlikno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tpno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tpno
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kimlikno
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpersonel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                    donecekpersonel.personeladsoyad = veri.Item("personeladsoyad")
                End If

                If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                    donecekpersonel.kimlikno = veri.Item("kimlikno")
                End If

                If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                    donecekpersonel.teknikpersonelmi = veri.Item("teknikpersonelmi")
                End If

                If Not veri.Item("tpno") Is System.DBNull.Value Then
                    donecekpersonel.tpno = veri.Item("tpno")
                End If

                If Not veri.Item("ceptel") Is System.DBNull.Value Then
                    donecekpersonel.ceptel = veri.Item("ceptel")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekpersonel.adres = veri.Item("adres")
                End If

                If Not veri.Item("bolge") Is System.DBNull.Value Then
                    donecekpersonel.bolge = veri.Item("bolge")
                End If

                If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                    donecekpersonel.egitimekatildimi = veri.Item("egitimekatildimi")
                End If

                If Not veri.Item("egitimno") Is System.DBNull.Value Then
                    donecekpersonel.egitimno = veri.Item("egitimno")
                End If

                If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                    donecekpersonel.onaylanmismi = veri.Item("onaylanmismi")
                End If

                If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                    donecekpersonel.verildigitarih = veri.Item("verildigitarih")
                End If

                If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                    donecekpersonel.belgetarih = veri.Item("belgetarih")
                End If

                If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                    donecekpersonel.islemkullanicipkey = veri.Item("islemkullanicipkey")
                End If

                If Not veri.Item("epostap") Is System.DBNull.Value Then
                    donecekpersonel.epostap = veri.Item("epostap")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpersonel

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim varmi As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        varmi = kullanici_erisim.personelvarmi(pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu personel için tanımlanmış bir kullanıcı var. " + _
            "Bu sebepten bu personeli silemezsiniz."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from personel where pkey=@pkey"
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

        End If

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSpersonel)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekpersonel As New CLASSpersonel
        Dim personeller As New List(Of CLASSpersonel)
        komut.Connection = db_baglanti
        sqlstr = "select * from personel order by personeladsoyad"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpersonel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                    donecekpersonel.personeladsoyad = veri.Item("personeladsoyad")
                End If

                If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                    donecekpersonel.kimlikno = veri.Item("kimlikno")
                End If

                If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                    donecekpersonel.teknikpersonelmi = veri.Item("teknikpersonelmi")
                End If

                If Not veri.Item("tpno") Is System.DBNull.Value Then
                    donecekpersonel.tpno = veri.Item("tpno")
                End If

                If Not veri.Item("ceptel") Is System.DBNull.Value Then
                    donecekpersonel.ceptel = veri.Item("ceptel")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekpersonel.adres = veri.Item("adres")
                End If

                If Not veri.Item("bolge") Is System.DBNull.Value Then
                    donecekpersonel.bolge = veri.Item("bolge")
                End If

                If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                    donecekpersonel.egitimekatildimi = veri.Item("egitimekatildimi")
                End If

                If Not veri.Item("egitimno") Is System.DBNull.Value Then
                    donecekpersonel.egitimno = veri.Item("egitimno")
                End If

                If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                    donecekpersonel.onaylanmismi = veri.Item("onaylanmismi")
                End If

                If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                    donecekpersonel.verildigitarih = veri.Item("verildigitarih")
                End If

                If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                    donecekpersonel.belgetarih = veri.Item("belgetarih")
                End If

                If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                    donecekpersonel.islemkullanicipkey = veri.Item("islemkullanicipkey")
                End If

                If Not veri.Item("epostap") Is System.DBNull.Value Then
                    donecekpersonel.epostap = veri.Item("epostap")
                Else
                    donecekpersonel.epostap = ""
                End If

                personeller.Add(New CLASSPERSONEL(donecekpersonel.pkey, _
                donecekpersonel.personeladsoyad, donecekpersonel.kimlikno, donecekpersonel.teknikpersonelmi, _
                donecekpersonel.tpno, donecekpersonel.ceptel, donecekpersonel.adres, donecekpersonel.bolge, _
                donecekpersonel.egitimekatildimi, donecekpersonel.egitimno, _
                donecekpersonel.onaylanmismi, donecekpersonel.verildigitarih, _
                donecekpersonel.belgetarih,donecekpersonel.islemkullanicipkey, _
                donecekpersonel.epostap))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return personeller

    End Function


    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSPERSONEL)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekpersonel As New CLASSPERSONEL
        Dim personeller As New List(Of CLASSPERSONEL)
        komut.Connection = db_baglanti
        sqlstr = "select * from personel where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpersonel.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                    donecekpersonel.personeladsoyad = veri.Item("personeladsoyad")
                End If

                If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                    donecekpersonel.kimlikno = veri.Item("kimlikno")
                End If

                If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                    donecekpersonel.teknikpersonelmi = veri.Item("teknikpersonelmi")
                End If

                If Not veri.Item("tpno") Is System.DBNull.Value Then
                    donecekpersonel.tpno = veri.Item("tpno")
                End If

                If Not veri.Item("ceptel") Is System.DBNull.Value Then
                    donecekpersonel.ceptel = veri.Item("ceptel")
                End If

                If Not veri.Item("adres") Is System.DBNull.Value Then
                    donecekpersonel.adres = veri.Item("adres")
                End If

                If Not veri.Item("bolge") Is System.DBNull.Value Then
                    donecekpersonel.bolge = veri.Item("bolge")
                End If

                If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                    donecekpersonel.egitimekatildimi = veri.Item("egitimekatildimi")
                End If

                If Not veri.Item("egitimno") Is System.DBNull.Value Then
                    donecekpersonel.egitimno = veri.Item("egitimno")
                End If

                If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                    donecekpersonel.onaylanmismi = veri.Item("onaylanmismi")
                End If

                If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                    donecekpersonel.verildigitarih = veri.Item("verildigitarih")
                End If

                If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                    donecekpersonel.belgetarih = veri.Item("belgetarih")
                End If

                If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                    donecekpersonel.islemkullanicipkey = veri.Item("islemkullanicipkey")
                End If

                If Not veri.Item("epostap") Is System.DBNull.Value Then
                    donecekpersonel.epostap = veri.Item("epostap")
                End If

                personeller.Add(New CLASSPERSONEL(donecekpersonel.pkey, _
                donecekpersonel.personeladsoyad, donecekpersonel.kimlikno, donecekpersonel.teknikpersonelmi, _
                donecekpersonel.tpno, donecekpersonel.ceptel, donecekpersonel.adres, donecekpersonel.bolge, _
                donecekpersonel.egitimekatildimi, donecekpersonel.egitimno, donecekpersonel.onaylanmismi, _
                donecekpersonel.verildigitarih, donecekpersonel.belgetarih,donecekpersonel.islemkullanicipkey, _
                donecekpersonel.epostap))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return personeller

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9, kol10, kol11 As String

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
        "<th>Adı Soyadı</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>E-Posta</th>" + _
        "<th>Teknik Personel mi?</th>" + _
        "<th>Teknik Personel No</th>" + _
        "<th>Eğitim Bilgileri</th>" + _
        "<th>Belge Tarihi</th>" + _
        "<th>Onaylanmış mı?</th>" + _
        "<th>Cep Tel</th>" + _
        "<th>İşlem Kullanıcısı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from personel"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "personeladsoyad" Then
            sqlstr = "select * from personel where personeladsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "tpno" Then
            sqlstr = "select * from personel where tpno LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "kimlikno" Then
            sqlstr = "select * from personel where kimlikno LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "onaylanmamislar" Then
            sqlstr = "select * from personel where onaylanmismi=@onaylanmismi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@onaylanmismi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Hayır"
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, personeladsoyad, kimlikno, teknikpersonelmi As String
        Dim tpno, ceptel, onaylanmismi, epostap As String

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim ajaxlinkonayla As String
        Dim dugmeonayla As String
        Dim egitimekatildimi, egitimno, verildigitarih As String
        Dim egitimbilgistr As String

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim belgetarih, islemkullanicipkey As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        ajaxlinkonayla = "onayla(" + CStr(pkey) + ")"
                        dugmeonayla = "<a onclick='" + ajaxlinkonayla + "' class='btn red'>" + _
                        "<i class='fa fa-gavel'></i> Onayla </a>"

                        link = "personelgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></span>" + _
                         "<br/><br/>" + dugmeonayla + _
                        "</td>"
                    End If

                    If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                        personeladsoyad = veri.Item("personeladsoyad")
                        kol2 = "<td>" + personeladsoyad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                        kimlikno = veri.Item("kimlikno")
                        kol3 = "<td>" + kimlikno + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("epostap") Is System.DBNull.Value Then
                        epostap = veri.Item("epostap")
                        kol4 = "<td>" + epostap + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                        teknikpersonelmi = veri.Item("teknikpersonelmi")
                        kol5 = "<td>" + teknikpersonelmi + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("tpno") Is System.DBNull.Value Then
                        tpno = veri.Item("tpno")
                        kol6 = "<td>" + tpno + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    'eğitim bilgileri 
                    If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                        egitimekatildimi = veri.Item("egitimekatildimi")
                    Else
                        egitimekatildimi = "-"
                    End If
                    If Not veri.Item("egitimno") Is System.DBNull.Value Then
                        egitimno = veri.Item("egitimno")
                    Else
                        egitimno = "-"
                    End If
                    If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                        verildigitarih = veri.Item("verildigitarih")
                    Else
                        verildigitarih = "-"
                    End If
                    egitimbilgistr = "Eğitime Katıldı mı?<strong>" + egitimekatildimi + "</strong><br/>" + _
                    "Eğitim No:<strong>" + egitimno + "</strong><br/>" + _
                    "Verildiği Tarih:<strong>" + verildigitarih + "</strong>"
                    kol7 = "<td>" + egitimbilgistr + "</td>"


                    If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                        belgetarih = veri.Item("belgetarih")
                        kol8 = "<td>" + belgetarih + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If


                    If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                        onaylanmismi = veri.Item("onaylanmismi")
                        kol9 = "<td>" + onaylanmismi + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

            
                    If Not veri.Item("ceptel") Is System.DBNull.Value Then
                        ceptel = veri.Item("ceptel")
                        kol10 = "<td>" + ceptel + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If


                    If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                        islemkullanicipkey = veri.Item("islemkullanicipkey")
                        kullanici = kullanici_erisim.bultek(islemkullanicipkey)
                        kol11 = "<td>" + kullanici.adsoyad + "</td></tr>"
                    Else
                        kol11 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + kol11

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from personel where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
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

    Function sirketinpersonellerinilistele(ByVal sirketpkey As String) As String

        Dim donecek As String = ""
        Dim basliklar, tabloson, satir As String

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Adı Soyadı</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>Çalıştığı Acente</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim personeller As New List(Of CLASSPERSONEL)
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
        sirketacentebaglar = sirketacentebag_erisim.doldur_sirketinacenteleri(sirketpkey)
        For Each sirketacentebagitem As CLASSSIRKETACENTEBAG In sirketacentebaglar
            'personeller = personel_erisim.doldur_ilgiliacente(sirketacentebagitem.acentepkey)
            For Each itempersonel As CLASSPERSONEL In personeller

                Dim calistigiacente As New CLASSACENTE
                Dim acente_erisim As New CLASSACENTE_ERISIM
                'calistigiacente = acente_erisim.bultek(itempersonel.acentepkey)
                satir = satir + "<tr><td>" + itempersonel.personeladsoyad + "</td>" + _
                "<td>" + itempersonel.kimlikno + "</td>" + _
                "<td>" + calistigiacente.acentead + "</td></tr>"
            Next
        Next

        donecek = basliklar + satir + tabloson
        Return donecek

    End Function

    Public Function teknikpersonelbelgeolustur(ByVal teknikpersonelpkeystring As String, ByVal verildigitarih As Date)

        Dim words As String() = teknikpersonelpkeystring.Split(New Char() {","c})
        Dim rapor_erisim As New CLASSRAPOR_ERISIM
        Dim personel As New CLASSPERSONEL


        Dim yaratilacak_pdfdosyaad As String
        yaratilacak_pdfdosyaad = rapor_erisim.rapordosyaadiolustur("Pdf")


        Dim imageFilePath As String = HttpContext.Current.Server.MapPath(".") + "\belgeresim\tpbelge.png"
        Dim jpg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageFilePath)
        jpg.ScaleAbsolute(842, 595)
        jpg.SetAbsolutePosition(0, 0)
        Dim doc As Document = New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
        doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
        Dim w = PdfWriter.GetInstance(doc, New FileStream(HttpContext.Current.Request.PhysicalApplicationPath + _
                              "\" + yaratilacak_pdfdosyaad, FileMode.Create))
        doc.Open()

        For Each Item As String In words


            personel = bultek(Item)

            doc.NewPage()

            'RESMİ EKLE---------------------------------------------------
            doc.Add(jpg)

            'YAZIYI EKLE -----------------------------------------------
            Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
            Dim fontsize As Single = 18.0
            Dim p1 As New Paragraph
            Dim p2 As New Paragraph
            Dim p3 As New Paragraph
            Dim p4 As New Paragraph
            Dim p5 As New Paragraph
            Dim p6 As New Paragraph
            Dim pilce As New Paragraph
            Dim p7 As New Paragraph


            Dim cb = w.DirectContent
            Dim col1 As New ColumnText(cb)
            Dim col2 As New ColumnText(cb)
            Dim col3 As New ColumnText(cb)
            Dim col4 As New ColumnText(cb)
            Dim col5 As New ColumnText(cb)
            Dim col6 As New ColumnText(cb)
            Dim colilce As New ColumnText(cb)
            Dim col7 As New ColumnText(cb)



            'lowerleftx, lowerlefty, upperleftx, upperlefty
            col1.SetSimpleColumn(450, 120, 650, 370)
            p1.Add(New Chunk(personel.personeladsoyad, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col1.AddText(p1)
            col1.Go()

            'TP NO
            col2.SetSimpleColumn(450, 120, 650, 335)
            p2.Add(New Chunk(personel.tpno, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col2.AddText(p2)
            col2.Go()

            'PERSONEL AD SOYAD
            col3.SetSimpleColumn(185, 30, 650, 133)
            p3.Add(New Chunk(personel.personeladsoyad, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col3.AddText(p3)
            col3.Go()

            'KİMLİK NO
            col4.SetSimpleColumn(185, 30, 650, 110)
            p4.Add(New Chunk(personel.kimlikno, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col4.AddText(p4)
            col4.Go()

            'ADRES
            col5.SetSimpleColumn(185, 30, 650, 89)
            p5.Add(New Chunk(personel.adres, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col5.AddText(p5)
            col5.Go()

            'İLÇE 
            colilce.SetSimpleColumn(185, 30, 650, 69)
            pilce.Add(New Chunk(personel.bolge, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            colilce.AddText(pilce)
            colilce.Go()

            'VERİLDİĞİ TARİH
            If personel.verildigitarih Is Nothing Then
                col7.SetSimpleColumn(185, 45, 1250, 0)
                p7.Add(New Chunk(CStr(verildigitarih), New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                col7.AddText(p7)
                col7.Go()
            End If
            If Not personel.verildigitarih Is Nothing Then
                'col6.SetSimpleColumn(185, 30, 650, 46)
                'p6.Add(New Chunk(personel.verildigitarih, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                'col6.AddText(p6)
                'col6.Go()
            End If

            'BELGE TARİH
            If Not personel.belgetarih Is Nothing Then
                col6.SetSimpleColumn(185, 30, 650, 46)
                p6.Add(New Chunk(personel.belgetarih, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                col6.AddText(p6)
                col6.Go()
            End If

        Next

        doc.Close()
        HttpContext.Current.Response.Redirect("~/" + yaratilacak_pdfdosyaad)

    End Function



    Public Function katilimbelgeolustur(ByVal teknikpersonelpkeystring As String, ByVal verildigitarih As Date)

        Dim words As String() = teknikpersonelpkeystring.Split(New Char() {","c})
        Dim rapor_erisim As New CLASSRAPOR_ERISIM
        Dim personel As New CLASSPERSONEL

        Dim yaratilacak_pdfdosyaad As String
        yaratilacak_pdfdosyaad = rapor_erisim.rapordosyaadiolustur("Pdf")


        Dim imageFilePath As String = HttpContext.Current.Server.MapPath(".") + "\belgeresim\katilim.png"
        Dim jpg As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imageFilePath)
        jpg.ScaleAbsolute(842, 595)
        jpg.SetAbsolutePosition(0, 0)
        Dim doc As Document = New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
        doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
        Dim w = PdfWriter.GetInstance(doc, New FileStream(HttpContext.Current.Request.PhysicalApplicationPath + _
                              "\" + yaratilacak_pdfdosyaad, FileMode.Create))
        doc.Open()

        For Each Item As String In words


            personel = bultek(Item)

            doc.NewPage()

            'RESMİ EKLE---------------------------------------------------
            doc.Add(jpg)

            'YAZIYI EKLE -----------------------------------------------
            Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
            Dim fontsize As Single = 18.0
            Dim p1 As New Paragraph
            Dim p2 As New Paragraph
            Dim p3 As New Paragraph
            Dim p4 As New Paragraph
            Dim p5 As New Paragraph


            Dim cb = w.DirectContent
            Dim col1 As New ColumnText(cb)
            Dim col2 As New ColumnText(cb)
            Dim col3 As New ColumnText(cb)
            Dim col4 As New ColumnText(cb)
            Dim col5 As New ColumnText(cb)


            'lowerleftx, lowerlefty, upperleftx, upperlefty
            'AD SOYAD
            col1.SetSimpleColumn(450, 120, 650, 370)
            p1.Add(New Chunk(personel.personeladsoyad, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col1.AddText(p1)
            col1.Go()

            'KİMLİK
            col2.SetSimpleColumn(450, 120, 650, 335)
            p2.Add(New Chunk(personel.kimlikno, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col2.AddText(p2)
            col2.Go()

            'NO
            col3.SetSimpleColumn(185, 30, 650, 69)
            p3.Add(New Chunk(personel.egitimno, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
            col3.AddText(p3)
            col3.Go()

            'VERİLDİĞİ TARİH
            If Not personel.verildigitarih Is Nothing Then
                col4.SetSimpleColumn(185, 30, 650, 46)
                p4.Add(New Chunk(personel.verildigitarih, New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                col4.AddText(p4)
                col4.Go()
            End If
            If personel.verildigitarih Is Nothing Then
                col5.SetSimpleColumn(185, 45, 1250, 0)
                p5.Add(New Chunk(CStr(verildigitarih), New Font(BF, fontsize, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.GRAY)))
                col5.AddText(p5)
                col5.Go()
            End If

        Next

        doc.Close()
        HttpContext.Current.Response.Redirect("~/" + yaratilacak_pdfdosyaad)

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listelebelgeicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9 As String

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
        "<th>Belge İçin Seç</th>" + _
        "<th>Adı Soyadı</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>Teknik Personel mi?</th>" + _
        "<th>Teknik Personel No</th>" + _
        "<th>Eğitim No</th>" + _
        "<th>Cep Tel</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from personel where teknikpersonelmi=@teknikpersonelmi and onaylanmismi=@onaylanmismi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@teknikpersonelmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Evet"
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@onaylanmismi", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = "Evet"
            komut.Parameters.Add(param2)

        End If


        If HttpContext.Current.Session("ltip") = "personeladsoyad" Then

            sqlstr = "select * from personel where teknikpersonelmi=@teknikpersonelmi and personeladsoyad like '%'+@personeladsoyad+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@teknikpersonelmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Evet"
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@personeladsoyad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("personeladsoyad")
            komut.Parameters.Add(param2)

        End If

        girdi = "0"
        Dim pkey, personeladsoyad, kimlikno, teknikpersonelmi As String
        Dim tpno, ceptel As String
        Dim secinput As String
        Dim egitimno As String

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        secinput = "<input type=" + Chr(34) + "checkbox" + Chr(34) + _
                         " id=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                         " name=" + Chr(34) + "A_" + CStr(pkey) + Chr(34) + _
                         "/>"
                        kol1 = "<tr><td>" + secinput + "</td>"
                    End If


                    If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                        personeladsoyad = veri.Item("personeladsoyad")
                        kol2 = "<td>" + personeladsoyad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                        kimlikno = veri.Item("kimlikno")
                        kol3 = "<td>" + kimlikno + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                        teknikpersonelmi = veri.Item("teknikpersonelmi")
                        kol4 = "<td>" + teknikpersonelmi + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("tpno") Is System.DBNull.Value Then
                        tpno = veri.Item("tpno")
                        kol5 = "<td>" + tpno + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("egitimno") Is System.DBNull.Value Then
                        egitimno = veri.Item("egitimno")
                        kol6 = "<td>" + egitimno + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If


                    If Not veri.Item("ceptel") Is System.DBNull.Value Then
                        ceptel = veri.Item("ceptel")
                        kol7 = "<td>" + ceptel + "</td></tr>"
                    Else
                        kol7 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7
                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


    Function tpnovekimliknovarmi(ByVal tpno As String, ByVal kimlikno As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from personel where tpno=@tpno and kimlikno=@kimlikno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tpno", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = tpno
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kimlikno", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kimlikno
        komut.Parameters.Add(param2)

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


    '---------------------------------listele--------------------------------------
    Public Function listelebirlikpersoneliicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9, kol10, kol11 As String

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
        "<th>Adı Soyadı</th>" + _
        "<th>Kimlik No</th>" + _
        "<th>Teknik Personel mi?</th>" + _
        "<th>Teknik Personel No</th>" + _
        "<th>Eğitim Bilgileri</th>" + _
        "<th>Belge Tarihi</th>" + _
        "<th>Onaylanmış mı?</th>" + _
        "<th>Cep Tel</th>" + _
        "<th>İşlem Kullanıcısı</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from personel"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "personeladsoyad" Then
            sqlstr = "select * from personel where personeladsoyad LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "tpno" Then
            sqlstr = "select * from personel where tpno LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "kimlikno" Then
            sqlstr = "select * from personel where kimlikno LIKE '%'+@kriter+'%'"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "onaylanmamislar" Then
            sqlstr = "select * from personel where onaylanmismi=@onaylanmismi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@onaylanmismi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Hayır"
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, personeladsoyad, kimlikno, teknikpersonelmi As String
        Dim tpno, ceptel, onaylanmismi As String

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim ajaxlinkonayla As String
        Dim dugmeonayla As String
        Dim egitimekatildimi, egitimno, verildigitarih As String
        Dim egitimbilgistr As String

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim belgetarih, islemkullanicipkey As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))

                        ajaxlinkonayla = "onayla(" + CStr(pkey) + ")"
                        dugmeonayla = "<a onclick='" + ajaxlinkonayla + "' class='btn red'>" + _
                        "<i class='fa fa-gavel'></i> Onayla </a>"

                        link = "birlikpersonelgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></span>" + _
                         "<br/><br/>" + _
                        "</td>"
                    End If


                    If Not veri.Item("personeladsoyad") Is System.DBNull.Value Then
                        personeladsoyad = veri.Item("personeladsoyad")
                        kol2 = "<td>" + personeladsoyad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kimlikno") Is System.DBNull.Value Then
                        kimlikno = veri.Item("kimlikno")
                        kol3 = "<td>" + kimlikno + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("teknikpersonelmi") Is System.DBNull.Value Then
                        teknikpersonelmi = veri.Item("teknikpersonelmi")
                        kol4 = "<td>" + teknikpersonelmi + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("tpno") Is System.DBNull.Value Then
                        tpno = veri.Item("tpno")
                        kol5 = "<td>" + tpno + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If


                    'eğitim bilgileri 
                    If Not veri.Item("egitimekatildimi") Is System.DBNull.Value Then
                        egitimekatildimi = veri.Item("egitimekatildimi")
                    Else
                        egitimekatildimi = "-"
                    End If
                    If Not veri.Item("egitimno") Is System.DBNull.Value Then
                        egitimno = veri.Item("egitimno")
                    Else
                        egitimno = "-"
                    End If
                    If Not veri.Item("verildigitarih") Is System.DBNull.Value Then
                        verildigitarih = veri.Item("verildigitarih")
                    Else
                        verildigitarih = "-"
                    End If

                    egitimbilgistr = "Eğitime Katıldı mı?<strong>" + egitimekatildimi + "</strong><br/>" + _
                    "Eğitim No:<strong>" + egitimno + "</strong><br/>" + _
                    "Verildiği Tarih:<strong>" + verildigitarih + "</strong>"
                    kol6 = "<td>" + egitimbilgistr + "</td>"


                    If Not veri.Item("belgetarih") Is System.DBNull.Value Then
                        belgetarih = veri.Item("belgetarih")
                        kol7 = "<td>" + belgetarih + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If


                    If Not veri.Item("onaylanmismi") Is System.DBNull.Value Then
                        onaylanmismi = veri.Item("onaylanmismi")
                        kol8 = "<td>" + onaylanmismi + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If


                    If Not veri.Item("ceptel") Is System.DBNull.Value Then
                        ceptel = veri.Item("ceptel")
                        kol9 = "<td>" + ceptel + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("islemkullanicipkey") Is System.DBNull.Value Then
                        islemkullanicipkey = veri.Item("islemkullanicipkey")
                        kullanici = kullanici_erisim.bultek(islemkullanicipkey)
                        kol10 = "<td>" + kullanici.adsoyad + "</td></tr>"
                    Else
                        kol10 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + _
                    kol5 + kol6 + kol7 + kol8 + kol9 + kol10
                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


End Class