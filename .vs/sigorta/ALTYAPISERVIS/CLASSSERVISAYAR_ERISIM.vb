Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSSERVİSAYAR_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim servisayar As New CLASSservisayar
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal servisayar As CLASSSERVİSAYAR) As CLADBOPRESULT

   
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into servisayar values (@pkey," + _
        "@bazfiyatdikkat,@ipdikkat,@tarifekodkontrol,@sinirkapitakvimkontrol," + _
        "@sonzeyilbitistarihkontrol,@eksurucukontrol,@duzenlemebitiskontrol," + _
        "@plakasinirkapikontrol,@plakaticariarackontrol,@plakakiralikarackontrol," + _
        "@plakakktckontrol,@plakarumkontrol,@rzeyilkontrol,@damagekimlikkontrol)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatdikkat", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If servisayar.bazfiyatdikkat = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = servisayar.bazfiyatdikkat
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If servisayar.ipdikkat = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = servisayar.ipdikkat
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tarifekodkontrol", SqlDbType.VarChar, 50)
        param4.Direction = ParameterDirection.Input
        If servisayar.tarifekodkontrol = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = servisayar.tarifekodkontrol
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@sinirkapitakvimkontrol", SqlDbType.VarChar, 50)
        param5.Direction = ParameterDirection.Input
        If servisayar.sinirkapitakvimkontrol = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = servisayar.sinirkapitakvimkontrol
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@sonzeyilbitistarihkontrol", SqlDbType.VarChar, 50)
        param6.Direction = ParameterDirection.Input
        If servisayar.sonzeyilbitistarihkontrol = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = servisayar.sonzeyilbitistarihkontrol
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@eksurucukontrol", SqlDbType.VarChar, 50)
        param7.Direction = ParameterDirection.Input
        If servisayar.eksurucukontrol = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = servisayar.eksurucukontrol
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@duzenlemebitiskontrol", SqlDbType.VarChar, 50)
        param8.Direction = ParameterDirection.Input
        If servisayar.duzenlemebitiskontrol = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = servisayar.duzenlemebitiskontrol
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@plakasinirkapikontrol", SqlDbType.VarChar, 50)
        param9.Direction = ParameterDirection.Input
        If servisayar.plakasinirkapikontrol = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = servisayar.plakasinirkapikontrol
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@plakakiralikarackontrol", SqlDbType.VarChar, 50)
        param10.Direction = ParameterDirection.Input
        If servisayar.plakakiralikarackontrol = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = servisayar.plakakiralikarackontrol
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@plakaticariarackontrol", SqlDbType.VarChar, 50)
        param11.Direction = ParameterDirection.Input
        If servisayar.plakaticariarackontrol = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = servisayar.plakaticariarackontrol
        End If
        komut.Parameters.Add(param11)


        Dim param12 As New SqlParameter("@plakakktckontrol", SqlDbType.VarChar, 50)
        param12.Direction = ParameterDirection.Input
        If servisayar.plakakktckontrol = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = servisayar.plakakktckontrol
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@plakarumkontrol", SqlDbType.VarChar, 50)
        param13.Direction = ParameterDirection.Input
        If servisayar.plakarumkontrol = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = servisayar.plakarumkontrol
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@rzeyilkontrol", SqlDbType.VarChar, 50)
        param14.Direction = ParameterDirection.Input
        If servisayar.rzeyilkontrol = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = servisayar.rzeyilkontrol
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@damagekimlikkontrol", SqlDbType.VarChar, 50)
        param15.Direction = ParameterDirection.Input
        If servisayar.damagekimlikkontrol = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = servisayar.damagekimlikkontrol
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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from servisayar"
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
    Function Duzenle(ByVal servisayar As CLASSSERVİSAYAR) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update servisayar set " + _
        "bazfiyatdikkat=@bazfiyatdikkat," + _
        "ipdikkat=@ipdikkat," + _
        "tarifekodkontrol=@tarifekodkontrol," + _
        "sinirkapitakvimkontrol=@sinirkapitakvimkontrol," + _
        "sonzeyilbitistarihkontrol=@sonzeyilbitistarihkontrol," + _
        "eksurucukontrol=@eksurucukontrol," + _
        "duzenlemebitiskontrol=@duzenlemebitiskontrol," + _
        "plakasinirkapikontrol=@plakasinirkapikontrol," + _
        "plakakiralikarackontrol=@plakakiralikarackontrol," + _
        "plakaticariarackontrol=@plakaticariarackontrol," + _
        "plakakktckontrol=@plakakktckontrol," + _
        "plakarumkontrol=@plakarumkontrol," + _
        "rzeyilkontrol=@rzeyilkontrol," + _
        "damagekimlikkontrol=@damagekimlikkontrol" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = servisayar.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@bazfiyatdikkat", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If servisayar.bazfiyatdikkat = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = servisayar.bazfiyatdikkat
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ipdikkat", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If servisayar.ipdikkat = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = servisayar.ipdikkat
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@tarifekodkontrol", SqlDbType.VarChar, 50)
        param4.Direction = ParameterDirection.Input
        If servisayar.tarifekodkontrol = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = servisayar.tarifekodkontrol
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@sinirkapitakvimkontrol", SqlDbType.VarChar, 50)
        param5.Direction = ParameterDirection.Input
        If servisayar.sinirkapitakvimkontrol = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = servisayar.sinirkapitakvimkontrol
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@sonzeyilbitistarihkontrol", SqlDbType.VarChar, 50)
        param6.Direction = ParameterDirection.Input
        If servisayar.sonzeyilbitistarihkontrol = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = servisayar.sonzeyilbitistarihkontrol
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@eksurucukontrol", SqlDbType.VarChar, 50)
        param7.Direction = ParameterDirection.Input
        If servisayar.eksurucukontrol = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = servisayar.eksurucukontrol
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@duzenlemebitiskontrol", SqlDbType.VarChar, 50)
        param8.Direction = ParameterDirection.Input
        If servisayar.duzenlemebitiskontrol = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = servisayar.duzenlemebitiskontrol
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@plakasinirkapikontrol", SqlDbType.VarChar, 50)
        param9.Direction = ParameterDirection.Input
        If servisayar.plakasinirkapikontrol = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = servisayar.plakasinirkapikontrol
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@plakakiralikarackontrol", SqlDbType.VarChar, 50)
        param10.Direction = ParameterDirection.Input
        If servisayar.plakakiralikarackontrol = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = servisayar.plakakiralikarackontrol
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@plakaticariarackontrol", SqlDbType.VarChar, 50)
        param11.Direction = ParameterDirection.Input
        If servisayar.plakaticariarackontrol = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = servisayar.plakaticariarackontrol
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@plakakktckontrol", SqlDbType.VarChar, 50)
        param12.Direction = ParameterDirection.Input
        If servisayar.plakakktckontrol = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = servisayar.plakakktckontrol
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@plakarumkontrol", SqlDbType.VarChar, 50)
        param13.Direction = ParameterDirection.Input
        If servisayar.plakarumkontrol = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = servisayar.plakarumkontrol
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@rzeyilkontrol", SqlDbType.VarChar, 50)
        param14.Direction = ParameterDirection.Input
        If servisayar.rzeyilkontrol = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = servisayar.rzeyilkontrol
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@damagekimlikkontrol", SqlDbType.VarChar, 50)
        param15.Direction = ParameterDirection.Input
        If servisayar.damagekimlikkontrol = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = servisayar.damagekimlikkontrol
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
    Function bultek(ByVal pkey As String) As CLASSservisayar

        Dim komut As New SqlCommand
        Dim donecekservisayar As New CLASSservisayar()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Using db_baglanti As New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "select * from servisayar where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)


            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        donecekservisayar.pkey = veri.Item("pkey")
                    End If

                    If Not veri.Item("bazfiyatdikkat") Is System.DBNull.Value Then
                        donecekservisayar.bazfiyatdikkat = veri.Item("bazfiyatdikkat")
                    End If

                    If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                        donecekservisayar.ipdikkat = veri.Item("ipdikkat")
                    End If

                    If Not veri.Item("tarifekodkontrol") Is System.DBNull.Value Then
                        donecekservisayar.tarifekodkontrol = veri.Item("tarifekodkontrol")
                    End If

                    If Not veri.Item("sinirkapitakvimkontrol") Is System.DBNull.Value Then
                        donecekservisayar.sinirkapitakvimkontrol = veri.Item("sinirkapitakvimkontrol")
                    End If

                    If Not veri.Item("sonzeyilbitistarihkontrol") Is System.DBNull.Value Then
                        donecekservisayar.sonzeyilbitistarihkontrol = veri.Item("sonzeyilbitistarihkontrol")
                    End If

                    If Not veri.Item("eksurucukontrol") Is System.DBNull.Value Then
                        donecekservisayar.eksurucukontrol = veri.Item("eksurucukontrol")
                    End If

                    If Not veri.Item("duzenlemebitiskontrol") Is System.DBNull.Value Then
                        donecekservisayar.duzenlemebitiskontrol = veri.Item("duzenlemebitiskontrol")
                    End If

                    If Not veri.Item("plakasinirkapikontrol") Is System.DBNull.Value Then
                        donecekservisayar.plakasinirkapikontrol = veri.Item("plakasinirkapikontrol")
                    End If

                    If Not veri.Item("plakakiralikarackontrol") Is System.DBNull.Value Then
                        donecekservisayar.plakakiralikarackontrol = veri.Item("plakakiralikarackontrol")
                    End If

                    If Not veri.Item("plakaticariarackontrol") Is System.DBNull.Value Then
                        donecekservisayar.plakaticariarackontrol = veri.Item("plakaticariarackontrol")
                    End If

                    If Not veri.Item("plakakktckontrol") Is System.DBNull.Value Then
                        donecekservisayar.plakakktckontrol = veri.Item("plakakktckontrol")
                    End If

                    If Not veri.Item("plakarumkontrol") Is System.DBNull.Value Then
                        donecekservisayar.plakarumkontrol = veri.Item("plakarumkontrol")
                    End If

                    If Not veri.Item("rzeyilkontrol") Is System.DBNull.Value Then
                        donecekservisayar.rzeyilkontrol = veri.Item("rzeyilkontrol")
                    End If

                    If Not veri.Item("damagekimlikkontrol") Is System.DBNull.Value Then
                        donecekservisayar.damagekimlikkontrol = veri.Item("damagekimlikkontrol")
                    End If


                End While
            End Using

            komut.Dispose()
            db_baglanti.Close()
            db_baglanti.Dispose()

        End Using

        Return donecekservisayar

    End Function

 
    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSservisayar)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekservisayar As New CLASSservisayar
        Dim servisayarler As New List(Of CLASSservisayar)
        komut.Connection = db_baglanti
        sqlstr = "select * from servisayar"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekservisayar.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("bazfiyatdikkat") Is System.DBNull.Value Then
                    donecekservisayar.bazfiyatdikkat = veri.Item("bazfiyatdikkat")
                End If

                If Not veri.Item("ipdikkat") Is System.DBNull.Value Then
                    donecekservisayar.ipdikkat = veri.Item("ipdikkat")
                End If

                If Not veri.Item("tarifekodkontrol") Is System.DBNull.Value Then
                    donecekservisayar.tarifekodkontrol = veri.Item("tarifekodkontrol")
                End If

                If Not veri.Item("sinirkapitakvimkontrol") Is System.DBNull.Value Then
                    donecekservisayar.sinirkapitakvimkontrol = veri.Item("sinirkapitakvimkontrol")
                End If

                If Not veri.Item("sonzeyilbitistarihkontrol") Is System.DBNull.Value Then
                    donecekservisayar.sonzeyilbitistarihkontrol = veri.Item("sonzeyilbitistarihkontrol")
                End If

                If Not veri.Item("eksurucukontrol") Is System.DBNull.Value Then
                    donecekservisayar.eksurucukontrol = veri.Item("eksurucukontrol")
                End If

                If Not veri.Item("duzenlemebitiskontrol") Is System.DBNull.Value Then
                    donecekservisayar.duzenlemebitiskontrol = veri.Item("duzenlemebitiskontrol")
                End If

                If Not veri.Item("plakasinirkapikontrol") Is System.DBNull.Value Then
                    donecekservisayar.plakasinirkapikontrol = veri.Item("plakasinirkapikontrol")
                End If

                If Not veri.Item("plakakiralikarackontrol") Is System.DBNull.Value Then
                    donecekservisayar.plakakiralikarackontrol = veri.Item("plakakiralikarackontrol")
                End If

                If Not veri.Item("plakaticariarackontrol") Is System.DBNull.Value Then
                    donecekservisayar.plakaticariarackontrol = veri.Item("plakaticariarackontrol")
                End If

                If Not veri.Item("plakakktckontrol") Is System.DBNull.Value Then
                    donecekservisayar.plakakktckontrol = veri.Item("plakakktckontrol")
                End If

                If Not veri.Item("plakarumkontrol") Is System.DBNull.Value Then
                    donecekservisayar.plakarumkontrol = veri.Item("plakarumkontrol")
                End If

                If Not veri.Item("rzeyilkontrol") Is System.DBNull.Value Then
                    donecekservisayar.rzeyilkontrol = veri.Item("rzeyilkontrol")
                End If

                If Not veri.Item("damagekimlikkontrol") Is System.DBNull.Value Then
                    donecekservisayar.damagekimlikkontrol = veri.Item("damagekimlikkontrol")
                End If

          
                servisayarler.Add(New CLASSSERVISAYAR(donecekservisayar.pkey, _
                donecekservisayar.bazfiyatdikkat, donecekservisayar.ipdikkat, _
                donecekservisayar.tarifekodkontrol, donecekservisayar.sinirkapitakvimkontrol, _
                donecekservisayar.sonzeyilbitistarihkontrol, donecekservisayar.eksurucukontrol, _
                donecekservisayar.duzenlemebitiskontrol, donecekservisayar.plakasinirkapikontrol, _
                donecekservisayar.plakakiralikarackontrol, donecekservisayar.plakaticariarackontrol, _
                donecekservisayar.plakakktckontrol, donecekservisayar.plakarumkontrol, _
                donecekservisayar.rzeyilkontrol, donecekservisayar.damagekimlikkontrol))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return servisayarler

    End Function


    '--- KAYIT SAYISI -------------------------------------------------------
    Function kayitsayisibul() As Integer

        Dim kayitsayisi As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select max(pkey) from servisayar"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitsayisi

    End Function

  
End Class