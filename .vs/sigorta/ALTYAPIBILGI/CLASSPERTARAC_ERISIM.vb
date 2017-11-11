Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSPERTARAC_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim pertarac As New CLASSpertarac
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal pertarac As CLASSPERTARAC) As CLADBOPRESULT

        Dim kaydedilenpkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("plaka", pertarac.plaka)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into pertarac values (@pkey," + _
            "@sirketpkey,@araccinspkey,@aracmarkapkey,@aracmodelpkey," + _
            "@plaka,@sasino,@motorno,@koltuksayi," + _
            "@motorgucu,@imalyil,@kazatarih,@odenenhasar," + _
            "@piyasadeger,@ilanbaslangictarih,@ilanbitistarih,@currencycodepkey," + _
            "@kayittarih,@guncellemetarih,@kullanicipkey,@hemensatisfiyat)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            kaydedilenpkey = pkeybul()
            param1.Value = kaydedilenpkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If pertarac.sirketpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = pertarac.sirketpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@araccinspkey", SqlDbType.Int)
            param3.Direction = ParameterDirection.Input
            If pertarac.araccinspkey = 0 Then
                param3.Value = 0
            Else
                param3.Value = pertarac.araccinspkey
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If pertarac.aracmarkapkey = 0 Then
                param4.Value = 0
            Else
                param4.Value = pertarac.aracmarkapkey
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@aracmodelpkey", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If pertarac.aracmodelpkey = 0 Then
                param5.Value = 0
            Else
                param5.Value = pertarac.aracmodelpkey
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@plaka", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If pertarac.plaka = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = pertarac.plaka
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@sasino", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If pertarac.sasino = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = pertarac.sasino
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@motorno", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If pertarac.motorno = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = pertarac.motorno
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@koltuksayi", SqlDbType.Int)
            param9.Direction = ParameterDirection.Input
            If pertarac.koltuksayi = 0 Then
                param9.Value = 0
            Else
                param9.Value = pertarac.koltuksayi
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@motorgucu", SqlDbType.Int)
            param10.Direction = ParameterDirection.Input
            If pertarac.motorgucu = 0 Then
                param10.Value = 0
            Else
                param10.Value = pertarac.motorgucu
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@imalyil", SqlDbType.Int)
            param11.Direction = ParameterDirection.Input
            If pertarac.imalyil = 0 Then
                param11.Value = 0
            Else
                param11.Value = pertarac.imalyil
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@kazatarih", SqlDbType.DateTime)
            param12.Direction = ParameterDirection.Input
            If pertarac.kazatarih Is Nothing Or pertarac.kazatarih = "00:00:00" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = pertarac.kazatarih
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@odenenhasar", SqlDbType.Decimal)
            param13.Direction = ParameterDirection.Input
            If pertarac.odenenhasar = 0 Then
                param13.Value = 0
            Else
                param13.Value = pertarac.odenenhasar
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@piyasadeger", SqlDbType.Decimal)
            param14.Direction = ParameterDirection.Input
            If pertarac.piyasadeger = 0 Then
                param14.Value = 0
            Else
                param14.Value = pertarac.piyasadeger
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@ilanbaslangictarih", SqlDbType.DateTime)
            param15.Direction = ParameterDirection.Input
            If pertarac.ilanbaslangictarih Is Nothing Or pertarac.ilanbaslangictarih = "00:00:00" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = pertarac.ilanbaslangictarih
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@ilanbitistarih", SqlDbType.DateTime)
            param16.Direction = ParameterDirection.Input
            If pertarac.ilanbitistarih Is Nothing Or pertarac.ilanbitistarih = "00:00:00" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = pertarac.ilanbitistarih
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
            param17.Direction = ParameterDirection.Input
            If pertarac.currencycodepkey = 0 Then
                param17.Value = 0
            Else
                param17.Value = pertarac.currencycodepkey
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
            param18.Direction = ParameterDirection.Input
            If pertarac.kayittarih Is Nothing Or pertarac.kayittarih = "00:00:00" Then
                param18.Value = System.DBNull.Value
            Else
                param18.Value = pertarac.kayittarih
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
            param19.Direction = ParameterDirection.Input
            If pertarac.guncellemetarih Is Nothing Or pertarac.guncellemetarih = "00:00:00" Then
                param19.Value = System.DBNull.Value
            Else
                param19.Value = pertarac.guncellemetarih
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
            param20.Direction = ParameterDirection.Input
            If pertarac.kullanicipkey = 0 Then
                param20.Value = 0
            Else
                param20.Value = pertarac.kullanicipkey
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@hemensatisfiyat", SqlDbType.Decimal)
            param21.Direction = ParameterDirection.Input
            If pertarac.hemensatisfiyat = 0 Then
                param21.Value = 0
            Else
                param21.Value = pertarac.hemensatisfiyat
            End If
            komut.Parameters.Add(param21)

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
        sqlstr = "select max(pkey) from pertarac"
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
    Function Duzenle(ByVal pertarac As CLASSPERTARAC) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update pertarac set " + _
        "sirketpkey=@sirketpkey," + _
        "araccinspkey=@araccinspkey," + _
        "aracmarkapkey=@aracmarkapkey," + _
        "aracmodelpkey=@aracmodelpkey," + _
        "plaka=@plaka," + _
        "sasino=@sasino," + _
        "motorno=@motorno," + _
        "koltuksayi=@koltuksayi," + _
        "motorgucu=@motorgucu," + _
        "imalyil=@imalyil," + _
        "kazatarih=@kazatarih," + _
        "odenenhasar=@odenenhasar," + _
        "piyasadeger=@piyasadeger," + _
        "ilanbaslangictarih=@ilanbaslangictarih," + _
        "ilanbitistarih=@ilanbitistarih," + _
        "currencycodepkey=@currencycodepkey," + _
        "kayittarih=@kayittarih," + _
        "guncellemetarih=@guncellemetarih," + _
        "kullanicipkey=@kullanicipkey," + _
        "hemensatisfiyat=@hemensatisfiyat" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pertarac.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sirketpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If pertarac.sirketpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = pertarac.sirketpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If pertarac.araccinspkey = 0 Then
            param3.Value = 0
        Else
            param3.Value = pertarac.araccinspkey
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If pertarac.aracmarkapkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = pertarac.aracmarkapkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@aracmodelpkey", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If pertarac.aracmodelpkey = 0 Then
            param5.Value = 0
        Else
            param5.Value = pertarac.aracmodelpkey
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@plaka", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If pertarac.plaka = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = pertarac.plaka
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@sasino", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If pertarac.sasino = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = pertarac.sasino
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@motorno", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If pertarac.motorno = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = pertarac.motorno
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@koltuksayi", SqlDbType.Int)
        param9.Direction = ParameterDirection.Input
        If pertarac.koltuksayi = 0 Then
            param9.Value = 0
        Else
            param9.Value = pertarac.koltuksayi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@motorgucu", SqlDbType.Int)
        param10.Direction = ParameterDirection.Input
        If pertarac.motorgucu = 0 Then
            param10.Value = 0
        Else
            param10.Value = pertarac.motorgucu
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@imalyil", SqlDbType.Int)
        param11.Direction = ParameterDirection.Input
        If pertarac.imalyil = 0 Then
            param11.Value = 0
        Else
            param11.Value = pertarac.imalyil
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@kazatarih", SqlDbType.DateTime)
        param12.Direction = ParameterDirection.Input
        If pertarac.kazatarih Is Nothing Or pertarac.kazatarih = "00:00:00" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = pertarac.kazatarih
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@odenenhasar", SqlDbType.Decimal)
        param13.Direction = ParameterDirection.Input
        If pertarac.odenenhasar = 0 Then
            param13.Value = 0
        Else
            param13.Value = pertarac.odenenhasar
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@piyasadeger", SqlDbType.Decimal)
        param14.Direction = ParameterDirection.Input
        If pertarac.piyasadeger = 0 Then
            param14.Value = 0
        Else
            param14.Value = pertarac.piyasadeger
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@ilanbaslangictarih", SqlDbType.DateTime)
        param15.Direction = ParameterDirection.Input
        If pertarac.ilanbaslangictarih Is Nothing Or pertarac.ilanbaslangictarih = "00:00:00" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = pertarac.ilanbaslangictarih
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@ilanbitistarih", SqlDbType.DateTime)
        param16.Direction = ParameterDirection.Input
        If pertarac.ilanbitistarih Is Nothing Or pertarac.ilanbitistarih = "00:00:00" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = pertarac.ilanbitistarih
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@currencycodepkey", SqlDbType.Int)
        param17.Direction = ParameterDirection.Input
        If pertarac.currencycodepkey = 0 Then
            param17.Value = 0
        Else
            param17.Value = pertarac.currencycodepkey
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param18.Direction = ParameterDirection.Input
        If pertarac.kayittarih Is Nothing Or pertarac.kayittarih = "00:00:00" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = pertarac.kayittarih
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@guncellemetarih", SqlDbType.DateTime)
        param19.Direction = ParameterDirection.Input
        If pertarac.guncellemetarih Is Nothing Or pertarac.guncellemetarih = "00:00:00" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = pertarac.guncellemetarih
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@kullanicipkey", SqlDbType.Int)
        param20.Direction = ParameterDirection.Input
        If pertarac.kullanicipkey = 0 Then
            param20.Value = 0
        Else
            param20.Value = pertarac.kullanicipkey
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@hemensatisfiyat", SqlDbType.Decimal)
        param21.Direction = ParameterDirection.Input
        If pertarac.hemensatisfiyat = 0 Then
            param21.Value = 0
        Else
            param21.Value = pertarac.hemensatisfiyat
        End If
        komut.Parameters.Add(param21)


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
            resultset.etkilenen = pertarac.pkey
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSpertarac

        Dim komut As New SqlCommand
        Dim donecekpertarac As New CLASSpertarac()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertarac.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekpertarac.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekpertarac.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                    donecekpertarac.aracmarkapkey = veri.Item("aracmarkapkey")
                End If

                If Not veri.Item("aracmodelpkey") Is System.DBNull.Value Then
                    donecekpertarac.aracmodelpkey = veri.Item("aracmodelpkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekpertarac.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("sasino") Is System.DBNull.Value Then
                    donecekpertarac.sasino = veri.Item("sasino")
                End If

                If Not veri.Item("motorno") Is System.DBNull.Value Then
                    donecekpertarac.motorno = veri.Item("motorno")
                End If

                If Not veri.Item("koltuksayi") Is System.DBNull.Value Then
                    donecekpertarac.koltuksayi = veri.Item("koltuksayi")
                End If

                If Not veri.Item("motorgucu") Is System.DBNull.Value Then
                    donecekpertarac.motorgucu = veri.Item("motorgucu")
                End If

                If Not veri.Item("imalyil") Is System.DBNull.Value Then
                    donecekpertarac.imalyil = veri.Item("imalyil")
                End If

                If Not veri.Item("kazatarih") Is System.DBNull.Value Then
                    donecekpertarac.kazatarih = veri.Item("kazatarih")
                End If

                If Not veri.Item("odenenhasar") Is System.DBNull.Value Then
                    donecekpertarac.odenenhasar = veri.Item("odenenhasar")
                End If

                If Not veri.Item("piyasadeger") Is System.DBNull.Value Then
                    donecekpertarac.piyasadeger = veri.Item("piyasadeger")
                End If

                If Not veri.Item("ilanbaslangictarih") Is System.DBNull.Value Then
                    donecekpertarac.ilanbaslangictarih = veri.Item("ilanbaslangictarih")
                End If

                If Not veri.Item("ilanbitistarih") Is System.DBNull.Value Then
                    donecekpertarac.ilanbitistarih = veri.Item("ilanbitistarih")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekpertarac.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekpertarac.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekpertarac.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekpertarac.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("hemensatisfiyat") Is System.DBNull.Value Then
                    donecekpertarac.hemensatisfiyat = veri.Item("hemensatisfiyat")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekpertarac

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM

        Dim varmi_pertaracresim As String = pertaracresim_erisim.pertaracvarmi(pkey)
        Dim varmi_teklif As String = teklif_erisim.pertaracvarmi(pkey)

        If varmi_pertaracresim = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araca resim kaydedilmiş. Önce aracın resimlerini siliniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi_teklif = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu araca verilen teklifler var.  " + _
            "Bu sebepten bu aracı silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from pertarac where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSpertarac)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekpertarac As New CLASSpertarac
        Dim pertaracler As New List(Of CLASSpertarac)
        komut.Connection = db_baglanti
        sqlstr = "select * from pertarac"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekpertarac.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                    donecekpertarac.sirketpkey = veri.Item("sirketpkey")
                End If

                If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                    donecekpertarac.araccinspkey = veri.Item("araccinspkey")
                End If

                If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                    donecekpertarac.aracmarkapkey = veri.Item("aracmarkapkey")
                End If

                If Not veri.Item("aracmodelpkey") Is System.DBNull.Value Then
                    donecekpertarac.aracmodelpkey = veri.Item("aracmodelpkey")
                End If

                If Not veri.Item("plaka") Is System.DBNull.Value Then
                    donecekpertarac.plaka = veri.Item("plaka")
                End If

                If Not veri.Item("sasino") Is System.DBNull.Value Then
                    donecekpertarac.sasino = veri.Item("sasino")
                End If

                If Not veri.Item("motorno") Is System.DBNull.Value Then
                    donecekpertarac.motorno = veri.Item("motorno")
                End If

                If Not veri.Item("koltuksayi") Is System.DBNull.Value Then
                    donecekpertarac.koltuksayi = veri.Item("koltuksayi")
                End If

                If Not veri.Item("motorgucu") Is System.DBNull.Value Then
                    donecekpertarac.motorgucu = veri.Item("motorgucu")
                End If

                If Not veri.Item("imalyil") Is System.DBNull.Value Then
                    donecekpertarac.imalyil = veri.Item("imalyil")
                End If

                If Not veri.Item("kazatarih") Is System.DBNull.Value Then
                    donecekpertarac.kazatarih = veri.Item("kazatarih")
                End If

                If Not veri.Item("odenenhasar") Is System.DBNull.Value Then
                    donecekpertarac.odenenhasar = veri.Item("odenenhasar")
                End If

                If Not veri.Item("piyasadeger") Is System.DBNull.Value Then
                    donecekpertarac.piyasadeger = veri.Item("piyasadeger")
                End If

                If Not veri.Item("ilanbaslangictarih") Is System.DBNull.Value Then
                    donecekpertarac.ilanbaslangictarih = veri.Item("ilanbaslangictarih")
                End If

                If Not veri.Item("ilanbitistarih") Is System.DBNull.Value Then
                    donecekpertarac.ilanbitistarih = veri.Item("ilanbitistarih")
                End If

                If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                    donecekpertarac.currencycodepkey = veri.Item("currencycodepkey")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekpertarac.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                    donecekpertarac.guncellemetarih = veri.Item("guncellemetarih")
                End If

                If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                    donecekpertarac.kullanicipkey = veri.Item("kullanicipkey")
                End If

                If Not veri.Item("hemensatisfiyat") Is System.DBNull.Value Then
                    donecekpertarac.hemensatisfiyat = veri.Item("hemensatisfiyat")
                End If

                pertaracler.Add(New CLASSPERTARAC(donecekpertarac.pkey, _
                donecekpertarac.sirketpkey, donecekpertarac.araccinspkey, donecekpertarac.aracmarkapkey, _
                donecekpertarac.aracmodelpkey, donecekpertarac.plaka, donecekpertarac.sasino, _
                donecekpertarac.motorno, donecekpertarac.koltuksayi, _
                donecekpertarac.motorgucu, donecekpertarac.imalyil, donecekpertarac.kazatarih, _
                donecekpertarac.odenenhasar, donecekpertarac.piyasadeger, donecekpertarac.ilanbaslangictarih, _
                donecekpertarac.ilanbitistarih, donecekpertarac.currencycodepkey, _
                donecekpertarac.kayittarih,donecekpertarac.guncellemetarih,donecekpertarac.kullanicipkey, _
                donecekpertarac.hemensatisfiyat))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return pertaracler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As CLASSRAPOR


        Dim rapor As New CLASSRAPOR
        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18 As String

        Dim tabloson, pager As String
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
        "<th>Araç Cinsi</th>" + _
        "<th>Araç Markası</th>" + _
        "<th>Araç Modeli</th>" + _
        "<th>Plaka</th>" + _
        "<th>Şasi No</th>" + _
        "<th>Motor No</th>" + _
        "<th>Koltuk Sayısı</th>" + _
        "<th>Motor Gücü</th>" + _
        "<th>İmal Yılı</th>" + _
        "<th>Kaza Tarihi</th>" + _
        "<th>Ödenen Hasar</th>" + _
        "<th>Piyasa Değeri</th>" + _
        "<th>Hemen Satış Fiyatı</th>" + _
        "<th>İlan Başlangıç Tarihi</th>" + _
        "<th>İlan Bitiş Tarihi</th>" + _
        "<th>Kayıt Bilgileri</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        Table.Columns.Add("Anahtar", GetType(String))
        Table.Columns.Add("Şirket", GetType(String))
        table.Columns.Add("Araç Cinsi", GetType(String))
        table.Columns.Add("Araç Markası", GetType(String))
        table.Columns.Add("Araç Modeli", GetType(String))
        table.Columns.Add("Plaka", GetType(String))
        table.Columns.Add("Şasi No", GetType(String))
        table.Columns.Add("Motor No", GetType(String))
        table.Columns.Add("Koltuk Sayısı", GetType(String))
        table.Columns.Add("Motor Gücü", GetType(String))
        table.Columns.Add("İmal Yılı", GetType(String))
        table.Columns.Add("Kaza Tarihi", GetType(String))
        table.Columns.Add("Ödenen Hasar", GetType(String))
        table.Columns.Add("Piyasa Değeri", GetType(String))
        table.Columns.Add("Hemen Satış Fiyatı", GetType(String))
        table.Columns.Add("İlan Başlangıç Tarihi", GetType(String))
        table.Columns.Add("İlan Bitiş Tarihi", GetType(String))
        table.Columns.Add("Kayıt Bilgileri", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(18)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Anahtar", fbaslik))
        pdftable.AddCell(New Phrase("Şirket", fbaslik))
        pdftable.AddCell(New Phrase("Araç Cinsi", fbaslik))
        pdftable.AddCell(New Phrase("Araç Markası", fbaslik))
        pdftable.AddCell(New Phrase("Araç Modeli", fbaslik))
        pdftable.AddCell(New Phrase("Plaka", fbaslik))
        pdftable.AddCell(New Phrase("Şasi No", fbaslik))
        pdftable.AddCell(New Phrase("Motor No", fbaslik))
        pdftable.AddCell(New Phrase("Koltuk Sayısı", fbaslik))
        pdftable.AddCell(New Phrase("Motor Gücü", fbaslik))
        pdftable.AddCell(New Phrase("İmal Yılı", fbaslik))
        pdftable.AddCell(New Phrase("Kaza Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Hasar", fbaslik))
        pdftable.AddCell(New Phrase("Piyasa Değeri", fbaslik))
        pdftable.AddCell(New Phrase("Hemen Satış Fiyatı", fbaslik))
        pdftable.AddCell(New Phrase("İlan Başlangıç Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("İlan Bitiş Tarihi", fbaslik))
        pdftable.AddCell(New Phrase("Kayıt Bilgileri", fbaslik))

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from pertarac order by plaka"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "sirket" Then
            sqlstr = "select * from pertarac where sirketpkey=@sirketpkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("sirketpkey")
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "pertarac_pkey" Then
            sqlstr = "select * from pertarac where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("pertarac_pkey")
            komut.Parameters.Add(param1)
        End If



        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, araccinspkey, aracmarkapkey, aracmodelpkey As String
        Dim plaka, sasino, motorno, koltuksayi, motorgucu, imalyil As String
        Dim kazatarih, ilanbaslangictarih, ilanbitistarih, currencycodepkey As String
        Dim odenenhasar, piyasadeger, hemensatisfiyat As Decimal
        Dim kayittarih, guncellemetarih, kullanicipkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim araccins As New CLASSARACCINS
        Dim araccins_erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM

        Dim resimlink, resimlink_ As String
        Dim tekliflink, tekliflink_ As String

        Dim teklif_erisim As New CLASSTEKLIF_ERISIM
        Dim teklifsayisi As Integer


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "pertarac.aspx?pkey=" + CStr(pkey) + "&op=duzenle"

                        teklifsayisi = teklif_erisim.teklifsayisi_aracbazinda(pkey)

                        resimlink_ = "pertaracresimpopup.aspx?pertaracpkey=" + CStr(pkey) + "&op=yenikayit"
                        resimlink = "<a class='iframeyenikayit' href=" + resimlink_ + ">" + _
                        "<span class='btn green btn-sm'>Resimleri</span>" + "</a>"

                        tekliflink_ = "pertaracteklifpopup.aspx?pertaracpkey=" + CStr(pkey)
                        tekliflink = "<a class='iframeyenikayit' href=" + tekliflink_ + ">" + _
                        "<span class='btn red btn-sm'>Verilen Teklifler (" + CStr(teklifsayisi) + ")" + "</span>" + "</a>"

                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "<br/><br/>" + _
                        resimlink + "<br/><br/>" + _
                        tekliflink + "</td>"



                        saf1 = pkey
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

                    If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                        araccinspkey = veri.Item("araccinspkey")
                        araccins = araccins_erisim.bultek(araccinspkey)
                        kol3 = "<td>" + araccins.cinsad + "</td>"
                        saf3 = araccins.cinsad
                    Else
                        kol3 = "<td>-</td>"
                        saf3 = "-"
                    End If

                    If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                        aracmarkapkey = veri.Item("aracmarkapkey")
                        aracmarka = aracmarka_erisim.bultek(aracmarkapkey)
                        kol4 = "<td>" + aracmarka.markaad + "</td>"
                        saf4 = aracmarka.markaad
                    Else
                        kol4 = "<td>-</td>"
                        saf4 = "-"
                    End If

                    If Not veri.Item("aracmodelpkey") Is System.DBNull.Value Then
                        aracmodelpkey = veri.Item("aracmodelpkey")
                        aracmodel = aracmodel_erisim.bultek(aracmodelpkey)
                        kol5 = "<td>" + aracmodel.modelad + "</td>"
                        saf5 = aracmodel.modelad
                    Else
                        kol5 = "<td>-</td>"
                        saf5 = "-"
                    End If

                    If Not veri.Item("plaka") Is System.DBNull.Value Then
                        plaka = veri.Item("plaka")
                        kol6 = "<td>" + plaka + "</td>"
                        saf6 = plaka
                    Else
                        kol6 = "<td>-</td>"
                        saf6 = "-"
                    End If

                    If Not veri.Item("sasino") Is System.DBNull.Value Then
                        sasino = veri.Item("sasino")
                        kol7 = "<td>" + sasino + "</td>"
                        saf7 = sasino
                    Else
                        kol7 = "<td>-</td>"
                        saf7 = "-"
                    End If

                    If Not veri.Item("motorno") Is System.DBNull.Value Then
                        motorno = veri.Item("motorno")
                        kol8 = "<td>" + motorno + "</td>"
                        saf8 = motorno
                    Else
                        kol8 = "<td>-</td>"
                        saf8 = "-"
                    End If

                    If Not veri.Item("koltuksayi") Is System.DBNull.Value Then
                        koltuksayi = veri.Item("koltuksayi")
                        kol9 = "<td>" + koltuksayi + "</td>"
                        saf9 = koltuksayi
                    Else
                        kol9 = "<td>-</td>"
                        saf9 = "-"
                    End If

                    If Not veri.Item("motorgucu") Is System.DBNull.Value Then
                        motorgucu = veri.Item("motorgucu")
                        kol10 = "<td>" + motorgucu + "</td>"
                        saf10 = motorgucu
                    Else
                        kol10 = "<td>-</td>"
                        saf10 = "-"
                    End If

                    If Not veri.Item("imalyil") Is System.DBNull.Value Then
                        imalyil = veri.Item("imalyil")
                        kol11 = "<td>" + imalyil + "</td>"
                        saf11 = imalyil
                    Else
                        kol11 = "<td>-</td>"
                        saf11 = "-"
                    End If

                    If Not veri.Item("kazatarih") Is System.DBNull.Value Then
                        kazatarih = veri.Item("kazatarih")
                        kol12 = "<td>" + kazatarih + "</td>"
                        saf12 = kazatarih
                    Else
                        kol12 = "<td>-</td>"
                        saf12 = "-"
                    End If

                    If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                        currencycodepkey = veri.Item("currencycodepkey")
                        currencycode = currencycode_erisim.bultek(currencycodepkey)
                    End If


                    If Not veri.Item("odenenhasar") Is System.DBNull.Value Then
                        odenenhasar = veri.Item("odenenhasar")
                        kol13 = "<td>" + Format(odenenhasar, "0.00") + " " + currencycode.aciklama + "</td>"
                        saf13 = Format(odenenhasar, "0.00") + " " + currencycode.aciklama
                    Else
                        kol13 = "<td>-</td>"
                        saf13 = "-"
                    End If

                    If Not veri.Item("piyasadeger") Is System.DBNull.Value Then
                        piyasadeger = veri.Item("piyasadeger")
                        kol14 = "<td>" + Format(piyasadeger, "0.00") + " " + currencycode.aciklama + "</td>"
                        saf14 = Format(piyasadeger, "0.00") + " " + currencycode.aciklama
                    Else
                        kol14 = "<td>-</td>"
                        saf14 = "-"
                    End If


                    If Not veri.Item("hemensatisfiyat") Is System.DBNull.Value Then
                        hemensatisfiyat = veri.Item("hemensatisfiyat")
                        kol15 = "<td>" + Format(hemensatisfiyat, "0.00") + " " + currencycode.aciklama + "</td>"
                        saf15 = Format(hemensatisfiyat, "0.00") + " " + currencycode.aciklama
                    Else
                        kol15 = "<td>-</td>"
                        saf15 = "-"
                    End If

                    If Not veri.Item("ilanbaslangictarih") Is System.DBNull.Value Then
                        ilanbaslangictarih = veri.Item("ilanbaslangictarih")
                        kol16 = "<td>" + ilanbaslangictarih + "</td>"
                        saf16 = ilanbaslangictarih
                    Else
                        kol16 = "<td>-</td>"
                        saf16 = "-"
                    End If

                    If Not veri.Item("ilanbitistarih") Is System.DBNull.Value Then
                        ilanbitistarih = veri.Item("ilanbitistarih")
                        kol17 = "<td>" + ilanbitistarih + "</td>"
                        saf17 = ilanbitistarih
                    Else
                        kol17 = "<td>-</td>"
                        saf17 = "-"
                    End If


                    If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                        kayittarih = veri.Item("kayittarih")
                    Else
                        kayittarih = "-"
                    End If
                    If Not veri.Item("guncellemetarih") Is System.DBNull.Value Then
                        guncellemetarih = veri.Item("guncellemetarih")
                    Else
                        guncellemetarih = "-"
                    End If
                    If Not veri.Item("kullanicipkey") Is System.DBNull.Value Then
                        kullanicipkey = veri.Item("kullanicipkey")
                        webuye = webuye_erisim.bultek(kullanicipkey)
                    End If
                    kol18 = "<td>" + "Kayıt Tarihi:" + "<b>" + kayittarih + "</b>" + "<br/>" + _
                    "Güncelleme Tarihi:" + "<b>" + guncellemetarih + "</b>" + "<br/>" + _
                    "Kaydeden:" + "<b>" + webuye.adsoyad + "</b>" + "</td></tr>"

                    saf18 = "Kayıt Tarihi:" + kayittarih + System.Environment.NewLine + _
                    "Güncelleme Tarihi:" + guncellemetarih + System.Environment.NewLine + _
                    "Kaydeden:" + webuye.adsoyad

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + _
                    kol11 + kol12 + kol13 + kol14 + kol15 + _
                    kol16 + kol17 + kol18

                    table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
                    saf6, saf7, saf8, saf9, saf10, saf11, saf12, saf13, saf14, _
                    saf15, saf16, saf17, saf18)

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
                    pdftable.AddCell(New Phrase(saf13, fdata))
                    pdftable.AddCell(New Phrase(saf14, fdata))
                    pdftable.AddCell(New Phrase(saf15, fdata))
                    pdftable.AddCell(New Phrase(saf16, fdata))
                    pdftable.AddCell(New Phrase(saf17, fdata))
                    pdftable.AddCell(New Phrase(saf18, fdata))

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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where " + tablecol + "=@kriter"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Function araccinsvarmi(ByVal araccinspkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where araccinspkey=@araccinspkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@araccinspkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = araccinspkey
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


    Function aracmarkavarmi(ByVal aracmarkapkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where aracmarkapkey=@aracmarkapkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aracmarkapkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aracmarkapkey
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


    Function aracmodelvarmi(ByVal aracmodelpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where aracmodelpkey=@aracmodelpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@aracmodelpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = aracmodelpkey
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


    Public Function grafikdata(ByVal neyegore As String) As List(Of CLASSGRAFIKBILGI)

        Dim komut As New SqlCommand
        Dim donecekgrafikbilgi As New CLASSGRAFIKBILGI
        Dim donecekgrafikbilgiler As New List(Of CLASSGRAFIKBILGI)
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirketpkey As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        If neyegore = "sirketoyadagilim" Then
            sqlstr = "select COUNT(*) as sayi,sirketpkey" + _
            " from oya group by sirketpkey order by sirketpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        donecekgrafikbilgi.seriad = sirket_erisim.bultek(sirketpkey).sirketad
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If


        If neyegore = "sirketoysdagilim" Then
            sqlstr = "select COUNT(*) as sayi,sirketpkey" + _
            " from oys group by sirketpkey order by sirketpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        donecekgrafikbilgi.seriad = sirket_erisim.bultek(sirketpkey).sirketad
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If


        If neyegore = "pertaraccinsdagilim" Then

            Dim aciklama As String
            Dim araccinspkey As String
            Dim araccins As New CLASSARACCINS
            Dim araccins_erisim As New CLASSARACCINS_ERISIM

            sqlstr = "select COUNT(*) as sayi,araccins.pkey" + _
            " from pertarac,araccins where pertarac.araccinspkey=araccins.pkey" + _
            " group by araccins.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("pkey") Is System.DBNull.Value Then
                            araccinspkey = veri.Item("pkey")
                            araccins = araccins_erisim.bultek(araccinspkey)
                            donecekgrafikbilgi.seriad = araccins.cinsad
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If


        If neyegore = "pertaracmarkadagilim" Then

            Dim aciklama As String
            Dim aracmarkapkey As String
            Dim aracmarka As New CLASSARACMARKA
            Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM


            sqlstr = "select COUNT(*) as sayi,aracmarka.pkey" + _
            " from pertarac,aracmarka where aracmarka.pkey=pertarac.aracmarkapkey" + _
            " group by aracmarka.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        aracmarkapkey = veri.Item("pkey")
                        donecekgrafikbilgi.seriad = aracmarka_erisim.bultek(aracmarkapkey).markaad
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If



        If neyegore = "sirketpertaracdagilim" Then

            Dim tarih As String

            sqlstr = "select COUNT(*) as sayi,CAST(kayittarih as DATE) as kayittarih" + _
            " from pertarac where " + _
            "kayittarih>=@kayittarih" + _
            " group by CAST(kayittarih AS DATE) order by kayittarih"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
            param1.Direction = ParameterDirection.Input
            param1.Value = DateTime.Now.AddDays(-6)
            komut.Parameters.Add(param1)


            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                            tarih = veri.Item("kayittarih")
                            donecekgrafikbilgi.seriad = tarih
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If



        If neyegore = "tekliftarihdagilim" Then

            Dim tarih As String

            sqlstr = "select COUNT(*) as sayi,CAST(tekliftarih as DATE) as tekliftarih" + _
            " from teklif where " + _
            "tekliftarih>=@tekliftarih" + _
            " group by CAST(tekliftarih AS DATE) order by tekliftarih"

            komut = New SqlCommand(sqlstr, db_baglanti)


            Dim param1 As New SqlParameter("@tekliftarih", SqlDbType.DateTime)
            param1.Direction = ParameterDirection.Input
            param1.Value = DateTime.Now.AddDays(-6)
            komut.Parameters.Add(param1)


            Try
                Using veri As SqlDataReader = komut.ExecuteReader()
                    While veri.Read()

                        If Not veri.Item("tekliftarih") Is System.DBNull.Value Then
                            tarih = veri.Item("tekliftarih")
                            donecekgrafikbilgi.seriad = tarih
                        End If

                        If Not veri.Item("sayi") Is System.DBNull.Value Then
                            donecekgrafikbilgi.sayi = veri.Item("sayi")
                        End If

                        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                        donecekgrafikbilgi.sayi))

                    End While
                End Using
            Catch ex As Exception
            End Try

        End If



        If neyegore = "sirketpertaracdagilim2" Then

            Dim sirket As New CLASSSIRKET

            sqlstr = "select COUNT(*) as sayi,sirketpkey" + _
            " from pertarac group by sirketpkey order by sirketpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        donecekgrafikbilgi.seriad = Mid(sirket.sirketad, 1, 9)
                    End If

                    If Not veri.Item("sayi") Is System.DBNull.Value Then
                        donecekgrafikbilgi.sayi = veri.Item("sayi")
                    End If

                    donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGI(donecekgrafikbilgi.seriad, _
                    donecekgrafikbilgi.sayi))

                End While
            End Using
        End If


        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return donecekgrafikbilgiler


    End Function


    '----------------------------------TOPLAM PERT ARAÇ SAYISI---------------------------------------
    Public Function toplamsayi() As Integer

        Dim sqlstr As String
        Dim toplam As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select count(*) from pertarac"
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



    '---------------------------------listele--------------------------------------
    Public Function listeleblog() As String

        'pagination---------------------------
        Dim nerde = 1
        Dim baslangic, bitis As Integer
        Dim teksayfadakacadet As Integer
        teksayfadakacadet = HttpContext.Current.Session("teksayfadakacadet")

        If teksayfadakacadet = 0 Then
            teksayfadakacadet = 99999999
        End If
        If IsNumeric(teksayfadakacadet) = False Then
            teksayfadakacadet = 5
        End If

        Dim sayfa As String
        sayfa = HttpContext.Current.Session("safya")

        If IsNumeric(sayfa) = False Or sayfa <= 0 Then
            sayfa = 1
        End If
        If sayfa = 1 Then
            baslangic = 1
        End If
        If sayfa > 1 Then
            baslangic = ((sayfa - 1) * teksayfadakacadet) + 1
        End If
        bitis = teksayfadakacadet * sayfa
        '-------------------------------------

        Dim p_aracmarkapkey As String
        p_aracmarkapkey = HttpContext.Current.Session("aracmarkapkey")
        If IsNumeric(p_aracmarkapkey) = False Then
            p_aracmarkapkey = "0"
        End If

        Dim recordcount As Integer = 0
        Dim satir As String
        Dim girdi As String
        Dim donecek As String

        donecek = ""

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim sqldevam As String
        If p_aracmarkapkey <> "0" Then
            sqldevam = " where aracmarkapkey=@aracmarkapkey"
        End If

        Dim ordersql As String

        If IsNumeric(HttpContext.Current.Session("pertaraclistesira")) = False Then
            ordersql = " order by ilanbaslangictarih desc"
        End If
        If HttpContext.Current.Session("pertaraclistesira") = "1" Then
            ordersql = " order by ilanbaslangictarih desc"
        End If
        If HttpContext.Current.Session("pertaraclistesira") = "2" Then
            ordersql = " order by ilanbaslangictarih asc"
        End If
        If HttpContext.Current.Session("pertaraclistesira") = "3" Then
            ordersql = " order by piyasadeger desc"
        End If
        If HttpContext.Current.Session("pertaraclistesira") = "4" Then
            ordersql = " order by piyasadeger asc"
        End If

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from pertarac  " + sqldevam + ordersql
            komut = New SqlCommand(sqlstr, db_baglanti)

            'araç markası seçilmiş ise
            If HttpContext.Current.Session("aracmarkapkey") <> "0" Then
                komut.Parameters.Add("@aracmarkapkey", SqlDbType.Int)
                komut.Parameters("@aracmarkapkey").Value = p_aracmarkapkey
            End If

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, sirketpkey, araccinspkey, aracmarkapkey, aracmodelpkey As String
        Dim kazatarih, ilanbaslangictarih, ilanbitistarih, currencycodepkey As String

        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM

        Dim araccins As New CLASSARACCINS
        Dim araccins_erisim As New CLASSARACCINS_ERISIM

        Dim aracmarka As New CLASSARACMARKA
        Dim aracmarka_erisim As New CLASSARACMARKA_ERISIM

        Dim aracmodel As New CLASSARACMODEL
        Dim aracmodel_erisim As New CLASSARACMODEL_ERISIM

        Dim currencycode As New CLASSCURRENCYCODE
        Dim currencycode_erisim As New CLASSCURRENCYCODE_ERISIM

        Dim webuye As New CLASSWEBUYE
        Dim webuye_erisim As New CLASSWEBUYE_ERISIM

        Dim resimlink, resimlink_ As String
        Dim tekliflink, tekliflink_ As String
        Dim hemenallink, hemenallink_ As String

        Dim pertarac As New CLASSPERTARAC
        Dim tekarachtml As String

        Dim pertaracresim_erisim As New CLASSPERTARACRESIM_ERISIM
        Dim anaresim As New CLASSPERTARACRESIM

        Dim tekresim As New CLASSTEKRESIM
        Dim tekresim_Erisim As New CLASSTEKRESIM_ERISIM

        Dim teklifsayisi As Integer
        Dim teklif_erisim As New CLASSTEKLIF_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "pertarac.aspx?pkey=" + CStr(pkey) + "&op=duzenle"

                        resimlink_ = "pertaracresimpopup.aspx?pertaracpkey=" + CStr(pkey) + "&op=yenikayit"
                        resimlink = "<a class='iframeyenikayit' href=" + resimlink_ + ">" + _
                        "<span class='btn green btn-sm'>Resimleri</span>" + "</a>"

                        tekliflink_ = "teklifver.aspx?pertaracpkey=" + CStr(pkey) + "&tekliftip=1"
                        tekliflink = "<a class='iframeyenikayit' href=" + tekliflink_ + ">" + _
                        "<span class='btn red btn-sm'>Verilen Teklifler</span>" + "</a>"

                        hemenallink_ = "teklifver.aspx?pertaracpkey=" + CStr(pkey) + "&tekliftip=2"
                        hemenallink = "<a class='iframeyenikayit' href=" + hemenallink_ + ">" + _
                        "<span class='btn yellow btn-sm'>Verilen Teklifler</span>" + "</a>"

                        pertarac = bultek(pkey)
                        anaresim = pertaracresim_erisim.bulanaresim(pkey)
                        webuye = webuye_erisim.bultek(pertarac.kullanicipkey)
                        teklifsayisi = teklif_erisim.teklifsayisi_aracbazinda(pkey)

                    End If

                    If Not veri.Item("sirketpkey") Is System.DBNull.Value Then
                        sirketpkey = veri.Item("sirketpkey")
                        sirket = sirket_erisim.bultek(sirketpkey)
                        tekresim = tekresim_Erisim.bultek(sirket.resimpkey)
                    End If

                    If Not veri.Item("araccinspkey") Is System.DBNull.Value Then
                        araccinspkey = veri.Item("araccinspkey")
                        araccins = araccins_erisim.bultek(araccinspkey)
                    End If

                    If Not veri.Item("aracmarkapkey") Is System.DBNull.Value Then
                        aracmarkapkey = veri.Item("aracmarkapkey")
                        aracmarka = aracmarka_erisim.bultek(aracmarkapkey)
                    End If

                    If Not veri.Item("aracmodelpkey") Is System.DBNull.Value Then
                        aracmodelpkey = veri.Item("aracmodelpkey")
                        aracmodel = aracmodel_erisim.bultek(aracmodelpkey)
                    End If

                    If Not veri.Item("currencycodepkey") Is System.DBNull.Value Then
                        currencycodepkey = veri.Item("currencycodepkey")
                        currencycode = currencycode_erisim.bultek(currencycodepkey)
                    End If

                    If nerde >= baslangic And nerde <= bitis Then
                        tekarachtml = "<div class=" + Chr(34) + "row" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<div class=" + Chr(34) + "col-md-4 blog-img blog-tag-data" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<img src=" + Chr(34) + "pertaracresim/" + anaresim.dosyaad + Chr(34) + " alt=" + Chr(34) + Chr(34) + " class=" + Chr(34) + "img-responsive" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<ul class=" + Chr(34) + "list-inline" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<li>" + System.Environment.NewLine + _
                        "<i class=" + Chr(34) + "fa fa-calendar" + Chr(34) + "></i>" + System.Environment.NewLine + _
                        "<a href=" + Chr(34) + "#" + Chr(34) + ">" + System.Environment.NewLine + _
                        pertarac.ilanbaslangictarih + System.Environment.NewLine + _
                        "</a>" + System.Environment.NewLine + _
                        "</li>" + System.Environment.NewLine + _
                        "<li>" + System.Environment.NewLine + _
                        "<i class=" + Chr(34) + "fa fa-comments" + Chr(34) + "></i>" + System.Environment.NewLine + _
                        "<a href=" + Chr(34) + "#" + Chr(34) + ">" + System.Environment.NewLine + _
                        CStr(teklifsayisi) + " Teklif" + System.Environment.NewLine + _
                        "</a>" + System.Environment.NewLine + _
                        "</li>" + System.Environment.NewLine + _
                        "</ul>" + System.Environment.NewLine + _
                        "<ul class=" + Chr(34) + "list-inline blog-tags" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<li>" + System.Environment.NewLine + _
                        "<i class=" + Chr(34) + "fa fa-tags" + Chr(34) + "></i>" + System.Environment.NewLine + _
                         "<a href=" + Chr(34) + "#" + Chr(34) + ">" + System.Environment.NewLine + _
                        pertarac.plaka + System.Environment.NewLine + _
                        "</a>" + System.Environment.NewLine + _
                        "<a href=" + Chr(34) + "#" + Chr(34) + ">" + System.Environment.NewLine + _
                        aracmarka.markaad + " " + aracmodel.modelad + System.Environment.NewLine + _
                        "</a>" + System.Environment.NewLine + _
                        "</li>" + System.Environment.NewLine + _
                        "</ul>" + System.Environment.NewLine + _
                        "</div>" + System.Environment.NewLine + _
                        "</img>" + System.Environment.NewLine + _
                        "<div class=" + Chr(34) + "col-md-4 blog-article" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<h3>" + System.Environment.NewLine + _
                        "<a href=" + Chr(34) + "page_blog_item.html" + Chr(34) + ">" + System.Environment.NewLine + _
                        CStr(pertarac.imalyil) + " model " + aracmarka.markaad + System.Environment.NewLine + _
                        "</a>" + System.Environment.NewLine + _
                        "</h3>" + System.Environment.NewLine + _
                        "<p>" + System.Environment.NewLine + _
                        "Kaza Tarihi: " + "<b>" + pertarac.kazatarih + "</b><br/>" + _
                        "Ödenen Hasar: " + "<b>" + Format(pertarac.odenenhasar, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                        "Piyasa Değeri: " + "<b>" + Format(pertarac.piyasadeger, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                        "Hemen Satış Fiyatı: " + "<b>" + Format(pertarac.hemensatisfiyat, "0.00") + " " + currencycode.kod + "</b><br/>" + _
                        System.Environment.NewLine + _
                        "</p>" + System.Environment.NewLine + _
                        "<a id=" + Chr(34) + "iframeyenikayit" + Chr(34) + " class=" + Chr(34) + "btn red" + Chr(34) + " href=" + Chr(34) + "pertaracresimpopup.aspx?pertaracpkey=" + CStr(pertarac.pkey) + Chr(34) + ">" + _
                        "İncele <i class=" + Chr(34) + "m-icon-swapright m-icon-white" + Chr(34) + "></i>" + _
                        "</a>" + _
                        "<a id=" + Chr(34) + "iframeyenikayit" + Chr(34) + " class=" + Chr(34) + "btn blue" + Chr(34) + " href=" + Chr(34) + tekliflink_ + Chr(34) + ">" + _
                        "Teklif Ver <i class=" + Chr(34) + "m-icon-swapright m-icon-white" + Chr(34) + "></i>" + _
                        "</a>" + _
                        "<p></p>" + _
                        "<a id=" + Chr(34) + "iframeyenikayit" + Chr(34) + " class=" + Chr(34) + "btn yellow" + Chr(34) + " href=" + Chr(34) + hemenallink_ + Chr(34) + ">" + _
                        "Hemen Satın Al <i class=" + Chr(34) + "m-icon-swapright m-icon-white" + Chr(34) + "></i>" + _
                        "</a>" + _
                        "</div>" + System.Environment.NewLine + _
                        "<div class=" + Chr(34) + "col-md-4 blog-article" + Chr(34) + ">" + System.Environment.NewLine + _
                        "<p>" + _
                        sirket.sirketad + "<br/>" + _
                        "<img src=" + Chr(34) + tekresim.dosyaad + Chr(34) + "</img><br/><br/>" + _
                        webuye.adsoyad + "<br/>" + _
                        webuye.telefon + "<br/>" + _
                        "<a href=" + Chr(34) + "mailto:" + webuye.eposta + Chr(34) + ">" + webuye.eposta + "</a><br/>" + _
                        "Bu ilan " + pertarac.ilanbitistarih + " tarihine kadar geçerlidir." + _
                        "</p>" + _
                        "</div>" + _
                        "</div>" + System.Environment.NewLine + _
                       "<hr>"

                        satir = satir + tekarachtml

                    End If

                    recordcount = recordcount + 1
                    nerde = nerde + 1

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        HttpContext.Current.Session("recordcount") = recordcount

        db_baglanti.Close()
        db_baglanti.Dispose()

        If recordcount > 0 Then
            Return satir
        End If

    End Function


    Public Function sayfalamayap() As String


        Dim bireksik, birfazla As Integer
        Dim sayfa As String
        sayfa = HttpContext.Current.Session("sayfa")
        If IsNumeric(sayfa) = False Or sayfa <= 0 Then
            sayfa = 1
        End If

        Dim sayfa_html As String
        Dim donecek, donecekbas, donecekson As String

        Dim i As Integer
        Dim kacsayfa_gosterilecek As Integer

        Dim teksayfadakacadet As Integer
        teksayfadakacadet = HttpContext.Current.Session("teksayfadakacadet")

        Dim aracmarkapkey As String
        aracmarkapkey = HttpContext.Current.Session("aracmarkapkey")

        If teksayfadakacadet = 0 Then
            teksayfadakacadet = 99999999
        End If
        If IsNumeric(teksayfadakacadet) = False Then
            teksayfadakacadet = 5
        End If

        kacsayfa_gosterilecek = Math.Ceiling(HttpContext.Current.Session("recordcount") / teksayfadakacadet)


        Dim ajaxlink, ajaxlinkbas, ajaxlinkson As String
        Dim pertaraclistesira As String
        pertaraclistesira = HttpContext.Current.Session("pertaraclistesira")

        If IsNumeric(pertaraclistesira) = False Then
            pertaraclistesira = "1"
        End If

        For i = 1 To kacsayfa_gosterilecek
            ajaxlink = "listele(" + CStr(i) + "," + CStr(pertaraclistesira) + "," + CStr(teksayfadakacadet) + "," + CStr(aracmarkapkey) + ")"
            sayfa_html = sayfa_html + "<li>" + _
            "<a onclick='" + ajaxlink + "' href=" + Chr(34) + "#" + Chr(34) + ">" + _
            CStr(i) + _
            "</a></li>"
        Next

        ajaxlinkbas = "listele(" + CStr(1) + "," + CStr(pertaraclistesira) + "," + CStr(teksayfadakacadet) + "," + CStr(aracmarkapkey) + ")"
        donecekbas = "<ul class=" + Chr(34) + "pagination pull-left" + Chr(34) + ">" + _
        "<li>" + _
        "<a onclick='" + ajaxlink + "' href=" + Chr(34) + "#" + Chr(34) + ">" + _
        "<i class=" + Chr(34) + "fa fa-angle-left" + Chr(34) + "></i>" + _
        "</a>" + _
        "</li>"

        ajaxlinkson = "listele(" + CStr(kacsayfa_gosterilecek) + "," + CStr(pertaraclistesira) + "," + CStr(teksayfadakacadet) + "," + CStr(aracmarkapkey) + ")"
        donecekson = "<li>" + _
        "<a onclick='" + ajaxlink + "' href=" + Chr(34) + "#" + Chr(34) + ">" + _
        "<i class=" + Chr(34) + "fa fa-angle-right" + Chr(34) + "></i>" + _
        "</a>" + _
        "</li>" + _
        "</ul>"

        If HttpContext.Current.Session("recordcount") > 0 Then
            donecek = donecekbas + sayfa_html + donecekson
        Else
            donecek = "Aradığınız özelliklerde herhangi bir kayıt bulunamadı."
        End If

        Return donecek

    End Function


    Function currencycodevarmi(ByVal currencycodepkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from pertarac where currencycodepkey=@currencycodepkey"

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


