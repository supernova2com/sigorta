Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSKOSULFIELD_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kosulfield As New CLASSKOSULFIELD
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kosulfield As CLASSKOSULFIELD) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(kosulfield.raporpkey, kosulfield.kosultabload, kosulfield.fieldad, kosulfield.sira)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporda bu alan için zaten veritabanında kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti

            sqlstr = "insert into kosulfield values (@pkey," + _
            "@raporpkey,@fieldad,@sira,@runtime," + _
            "@kosulop,@deger,@bagmantikop,@fieldtype," + _
            "@kosultabload,@kullanilacaktablopkey,@arabirimlabel,@arabirimtip," + _
            "@dropdownlistpkey,@kosulgrupno,@grupmantikop,@sezonad)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If kosulfield.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = kosulfield.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If kosulfield.fieldad = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = kosulfield.fieldad
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@sira", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If kosulfield.sira = 0 Then
                param4.Value = 0
            Else
                param4.Value = kosulfield.sira
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@runtime", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If kosulfield.runtime = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = kosulfield.runtime
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@kosulop", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If kosulfield.kosulop = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = kosulfield.kosulop
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@deger", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If kosulfield.deger = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = kosulfield.deger
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@bagmantikop", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If kosulfield.bagmantikop = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = kosulfield.bagmantikop
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@fieldtype", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If kosulfield.fieldtype = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = kosulfield.fieldtype
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@kosultabload", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If kosulfield.kosultabload = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = kosulfield.kosultabload
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
            param11.Direction = ParameterDirection.Input
            If kosulfield.kullanilacaktablopkey = 0 Then
                param11.Value = 0
            Else
                param11.Value = kosulfield.kullanilacaktablopkey
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@arabirimlabel", SqlDbType.VarChar)
            param12.Direction = ParameterDirection.Input
            If kosulfield.arabirimlabel = "" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = kosulfield.arabirimlabel
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@arabirimtip", SqlDbType.VarChar)
            param13.Direction = ParameterDirection.Input
            If kosulfield.arabirimtip = "" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = kosulfield.arabirimtip
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@dropdownlistpkey", SqlDbType.Int)
            param14.Direction = ParameterDirection.Input
            If kosulfield.dropdownlistpkey = 0 Then
                param14.Value = 0
            Else
                param14.Value = kosulfield.dropdownlistpkey
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@kosulgrupno", SqlDbType.Int)
            param15.Direction = ParameterDirection.Input
            If kosulfield.kosulgrupno = 0 Then
                param15.Value = 0
            Else
                param15.Value = kosulfield.kosulgrupno
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@grupmantikop", SqlDbType.VarChar)
            param16.Direction = ParameterDirection.Input
            If kosulfield.grupmantikop = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = kosulfield.grupmantikop
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@sezonad", SqlDbType.VarChar)
            param17.Direction = ParameterDirection.Input
            If kosulfield.sezonad = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = kosulfield.sezonad
            End If
            komut.Parameters.Add(param17)


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
        sqlstr = "select max(pkey) from kosulfield"
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
    Function Duzenle(ByVal kosulfield As CLASSKOSULFIELD) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti

        sqlstr = "update kosulfield set " + _
        "raporpkey=@raporpkey," + _
        "fieldad=@fieldad," + _
        "sira=@sira," + _
        "runtime=@runtime," + _
        "kosulop=@kosulop," + _
        "deger=@deger," + _
        "bagmantikop=@bagmantikop," + _
        "fieldtype=@fieldtype," + _
        "kosultabload=@kosultabload," + _
        "kullanilacaktablopkey=@kullanilacaktablopkey," + _
        "arabirimlabel=@arabirimlabel," + _
        "arabirimtip=@arabirimtip," + _
        "dropdownlistpkey=@dropdownlistpkey," + _
        "kosulgrupno=@kosulgrupno," + _
        "grupmantikop=@grupmantikop," + _
        "sezonad=@sezonad" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kosulfield.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If kosulfield.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = kosulfield.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kosulfield.fieldad = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kosulfield.fieldad
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sira", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If kosulfield.sira = 0 Then
            param4.Value = 0
        Else
            param4.Value = kosulfield.sira
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@runtime", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If kosulfield.runtime = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = kosulfield.runtime
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@kosulop", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If kosulfield.kosulop = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = kosulfield.kosulop
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@deger", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If kosulfield.deger = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = kosulfield.deger
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@bagmantikop", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If kosulfield.bagmantikop = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = kosulfield.bagmantikop
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@fieldtype", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If kosulfield.fieldtype = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = kosulfield.fieldtype
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@kosultabload", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If kosulfield.kosultabload = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = kosulfield.kosultabload
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
        param11.Direction = ParameterDirection.Input
        If kosulfield.kullanilacaktablopkey = 0 Then
            param11.Value = 0
        Else
            param11.Value = kosulfield.kullanilacaktablopkey
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@arabirimlabel", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If kosulfield.arabirimlabel = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = kosulfield.arabirimlabel
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@arabirimtip", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If kosulfield.arabirimtip = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = kosulfield.arabirimtip
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@dropdownlistpkey", SqlDbType.Int)
        param14.Direction = ParameterDirection.Input
        If kosulfield.dropdownlistpkey = 0 Then
            param14.Value = 0
        Else
            param14.Value = kosulfield.dropdownlistpkey
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@kosulgrupno", SqlDbType.Int)
        param15.Direction = ParameterDirection.Input
        If kosulfield.kosulgrupno = 0 Then
            param15.Value = 0
        Else
            param15.Value = kosulfield.kosulgrupno
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@grupmantikop", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If kosulfield.grupmantikop = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = kosulfield.grupmantikop
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@sezonad", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If kosulfield.sezonad = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = kosulfield.sezonad
        End If
        komut.Parameters.Add(param17)

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
    Function bultek(ByVal pkey As String) As CLASSKOSULFIELD

        Dim komut As New SqlCommand
        Dim donecekkosulfield As New CLASSKOSULFIELD()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkosulfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkosulfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekkosulfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekkosulfield.sira = veri.Item("sira")
                End If

                If Not veri.Item("runtime") Is System.DBNull.Value Then
                    donecekkosulfield.runtime = veri.Item("runtime")
                End If

                If Not veri.Item("kosulop") Is System.DBNull.Value Then
                    donecekkosulfield.kosulop = veri.Item("kosulop")
                End If

                If Not veri.Item("deger") Is System.DBNull.Value Then
                    donecekkosulfield.deger = veri.Item("deger")
                End If

                If Not veri.Item("bagmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.bagmantikop = veri.Item("bagmantikop")
                End If

                If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                    donecekkosulfield.fieldtype = veri.Item("fieldtype")
                End If

                If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                    donecekkosulfield.kosultabload = veri.Item("kosultabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekkosulfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimlabel = veri.Item("arabirimlabel")
                End If

                If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimtip = veri.Item("arabirimtip")
                End If

                If Not veri.Item("dropdownlistpkey") Is System.DBNull.Value Then
                    donecekkosulfield.dropdownlistpkey = veri.Item("dropdownlistpkey")
                End If

                If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                    donecekkosulfield.kosulgrupno = veri.Item("kosulgrupno")
                End If

                If Not veri.Item("grupmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.grupmantikop = veri.Item("grupmantikop")
                End If


                If Not veri.Item("sezonad") Is System.DBNull.Value Then
                    donecekkosulfield.sezonad = veri.Item("sezonad")
                End If



            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkosulfield

    End Function



    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kosulfield where pkey=@pkey"
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


    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kosulfield where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
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
    Public Function doldur() As List(Of CLASSKOSULFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkosulfield As New CLASSKOSULFIELD
        Dim kosulfieldler As New List(Of CLASSKOSULFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from kosulfield"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkosulfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkosulfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekkosulfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekkosulfield.sira = veri.Item("sira")
                End If

                If Not veri.Item("runtime") Is System.DBNull.Value Then
                    donecekkosulfield.runtime = veri.Item("runtime")
                End If

                If Not veri.Item("kosulop") Is System.DBNull.Value Then
                    donecekkosulfield.kosulop = veri.Item("kosulop")
                End If

                If Not veri.Item("deger") Is System.DBNull.Value Then
                    donecekkosulfield.deger = veri.Item("deger")
                End If

                If Not veri.Item("bagmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.bagmantikop = veri.Item("bagmantikop")
                End If

                If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                    donecekkosulfield.fieldtype = veri.Item("fieldtype")
                End If

                If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                    donecekkosulfield.kosultabload = veri.Item("kosultabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekkosulfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimlabel = veri.Item("arabirimlabel")
                End If

                If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimtip = veri.Item("arabirimtip")
                End If

                If Not veri.Item("dropdownlistpkey") Is System.DBNull.Value Then
                    donecekkosulfield.dropdownlistpkey = veri.Item("dropdownlistpkey")
                End If

                If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                    donecekkosulfield.kosulgrupno = veri.Item("kosulgrupno")
                End If

                If Not veri.Item("grupmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.grupmantikop = veri.Item("grupmantikop")
                End If


                If Not veri.Item("sezonad") Is System.DBNull.Value Then
                    donecekkosulfield.sezonad = veri.Item("sezonad")
                End If

                kosulfieldler.Add(New CLASSKOSULFIELD(donecekkosulfield.pkey, _
                donecekkosulfield.raporpkey, donecekkosulfield.fieldad, donecekkosulfield.sira, donecekkosulfield.runtime, _
                donecekkosulfield.kosulop, donecekkosulfield.deger, donecekkosulfield.bagmantikop, donecekkosulfield.fieldtype, _
                donecekkosulfield.kosultabload, donecekkosulfield.kullanilacaktablopkey, donecekkosulfield.arabirimlabel, donecekkosulfield.arabirimtip, _
                donecekkosulfield.dropdownlistpkey, donecekkosulfield.kosulgrupno, donecekkosulfield.grupmantikop, _
                donecekkosulfield.sezonad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kosulfieldler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_ilgili(ByVal raporpkey As Integer) As List(Of CLASSKOSULFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkosulfield As New CLASSKOSULFIELD
        Dim kosulfieldler As New List(Of CLASSKOSULFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from kosulfield where raporpkey=@raporpkey order by sira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkosulfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkosulfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekkosulfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekkosulfield.sira = veri.Item("sira")
                End If

                If Not veri.Item("runtime") Is System.DBNull.Value Then
                    donecekkosulfield.runtime = veri.Item("runtime")
                End If

                If Not veri.Item("kosulop") Is System.DBNull.Value Then
                    donecekkosulfield.kosulop = veri.Item("kosulop")
                End If

                If Not veri.Item("deger") Is System.DBNull.Value Then
                    donecekkosulfield.deger = veri.Item("deger")
                End If

                If Not veri.Item("bagmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.bagmantikop = veri.Item("bagmantikop")
                End If

                If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                    donecekkosulfield.fieldtype = veri.Item("fieldtype")
                End If

                If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                    donecekkosulfield.kosultabload = veri.Item("kosultabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekkosulfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimlabel = veri.Item("arabirimlabel")
                End If

                If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimtip = veri.Item("arabirimtip")
                End If

                If Not veri.Item("dropdownlistpkey") Is System.DBNull.Value Then
                    donecekkosulfield.dropdownlistpkey = veri.Item("dropdownlistpkey")
                End If

                If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                    donecekkosulfield.kosulgrupno = veri.Item("kosulgrupno")
                End If

                If Not veri.Item("grupmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.grupmantikop = veri.Item("grupmantikop")
                End If

                If Not veri.Item("sezonad") Is System.DBNull.Value Then
                    donecekkosulfield.sezonad = veri.Item("sezonad")
                End If

                kosulfieldler.Add(New CLASSKOSULFIELD(donecekkosulfield.pkey, _
                donecekkosulfield.raporpkey, donecekkosulfield.fieldad, donecekkosulfield.sira, donecekkosulfield.runtime, _
                donecekkosulfield.kosulop, donecekkosulfield.deger, donecekkosulfield.bagmantikop, donecekkosulfield.fieldtype, _
                donecekkosulfield.kosultabload, donecekkosulfield.kullanilacaktablopkey, donecekkosulfield.arabirimlabel, donecekkosulfield.arabirimtip, _
                donecekkosulfield.dropdownlistpkey, donecekkosulfield.kosulgrupno, donecekkosulfield.grupmantikop, _
                donecekkosulfield.sezonad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kosulfieldler

    End Function


   
    '---------------------------------doldur-----------------------------------------
    Public Function doldur_ilgili_istenilengrup(ByVal raporpkey As Integer, _
    ByVal kosulgrupno As Integer) As List(Of CLASSKOSULFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkosulfield As New CLASSKOSULFIELD
        Dim kosulfieldler As New List(Of CLASSKOSULFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from kosulfield where raporpkey=@raporpkey and kosulgrupno=@kosulgrupno order by sira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kosulgrupno", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kosulgrupno
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkosulfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekkosulfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("fieldad") Is System.DBNull.Value Then
                    donecekkosulfield.fieldad = veri.Item("fieldad")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekkosulfield.sira = veri.Item("sira")
                End If

                If Not veri.Item("runtime") Is System.DBNull.Value Then
                    donecekkosulfield.runtime = veri.Item("runtime")
                End If

                If Not veri.Item("kosulop") Is System.DBNull.Value Then
                    donecekkosulfield.kosulop = veri.Item("kosulop")
                End If

                If Not veri.Item("deger") Is System.DBNull.Value Then
                    donecekkosulfield.deger = veri.Item("deger")
                End If

                If Not veri.Item("bagmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.bagmantikop = veri.Item("bagmantikop")
                End If

                If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                    donecekkosulfield.fieldtype = veri.Item("fieldtype")
                End If

                If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                    donecekkosulfield.kosultabload = veri.Item("kosultabload")
                End If

                If Not veri.Item("kullanilacaktablopkey") Is System.DBNull.Value Then
                    donecekkosulfield.kullanilacaktablopkey = veri.Item("kullanilacaktablopkey")
                End If

                If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimlabel = veri.Item("arabirimlabel")
                End If

                If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                    donecekkosulfield.arabirimtip = veri.Item("arabirimtip")
                End If

                If Not veri.Item("dropdownlistpkey") Is System.DBNull.Value Then
                    donecekkosulfield.dropdownlistpkey = veri.Item("dropdownlistpkey")
                End If

                If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                    donecekkosulfield.kosulgrupno = veri.Item("kosulgrupno")
                End If

                If Not veri.Item("grupmantikop") Is System.DBNull.Value Then
                    donecekkosulfield.grupmantikop = veri.Item("grupmantikop")
                End If

                If Not veri.Item("sezonad") Is System.DBNull.Value Then
                    donecekkosulfield.sezonad = veri.Item("sezonad")
                End If

                kosulfieldler.Add(New CLASSKOSULFIELD(donecekkosulfield.pkey, _
                donecekkosulfield.raporpkey, donecekkosulfield.fieldad, donecekkosulfield.sira, donecekkosulfield.runtime, _
                donecekkosulfield.kosulop, donecekkosulfield.deger, donecekkosulfield.bagmantikop, donecekkosulfield.fieldtype, _
                donecekkosulfield.kosultabload, donecekkosulfield.kullanilacaktablopkey, donecekkosulfield.arabirimlabel, donecekkosulfield.arabirimtip, _
                donecekkosulfield.dropdownlistpkey, donecekkosulfield.kosulgrupno, donecekkosulfield.grupmantikop, _
                donecekkosulfield.sezonad))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kosulfieldler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11, kol12, kol13, kol14, kol15, kol16 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim ajaxlinksil, dugmesil As String

        jvstring = "<script type='text/javascript'>" + _
              "$(document).ready(function() {" + _
                  "$('.button').button();" + _
              "});" + _
              "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Rapor</th>" + _
        "<th>Koşul Tablo Adı</th>" + _
        "<th>Alan Adı</th>" + _
        "<th>Alan Türü</th>" + _
        "<th>Sıra</th>" + _
        "<th>Run-Time</th>" + _
        "<th>Koşul Operatörü</th>" + _
        "<th>Değer</th>" + _
        "<th>Bağ Mantık Operatörü</th>" + _
        "<th>Arabirim Form Etiketi</th>" + _
        "<th>Arabirim Tipi</th>" + _
        "<th>Grup Numarası</th>" + _
        "<th>Grup Mantık Operatörü</th>" + _
        "<th>Sezon</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from kosulfield where raporpkey=@raporpkey order by kosulgrupno, sira"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim pkey, raporpkey, fieldad, sira, runtime, kosulop, deger, bagmantikop As String
        Dim kosultabload, fieldtype, arabirimlabel, arabirimtip As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim link As String
        Dim kosulgrupno, grupmantikop, sezonad As String


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(raporpkey) + _
                        "&op=duzenle" + _
                        "&kosulfieldop=duzenle" + _
                        "&kosulfieldpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If


                    If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                        kosultabload = veri.Item("kosultabload")
                        kol3 = "<td>" + kosultabload + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldad") Is System.DBNull.Value Then
                        fieldad = veri.Item("fieldad")
                        kol4 = "<td>" + fieldad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                        fieldtype = veri.Item("fieldtype")
                        kol5 = "<td>" + fieldtype + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("sira") Is System.DBNull.Value Then
                        sira = veri.Item("sira")
                        kol6 = "<td>" + sira + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("runtime") Is System.DBNull.Value Then
                        runtime = veri.Item("runtime")
                        kol7 = "<td>" + runtime + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("kosulop") Is System.DBNull.Value Then
                        kosulop = veri.Item("kosulop")
                        kol8 = "<td>" + kosulop + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("deger") Is System.DBNull.Value Then
                        deger = veri.Item("deger")
                        kol9 = "<td>" + deger + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("bagmantikop") Is System.DBNull.Value Then
                        bagmantikop = veri.Item("bagmantikop")
                        kol10 = "<td>" + bagmantikop + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If


                    If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                        arabirimlabel = veri.Item("arabirimlabel")
                        kol11 = "<td>" + arabirimlabel + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If


                    If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                        arabirimtip = veri.Item("arabirimtip")
                        kol12 = "<td>" + arabirimtip + "</td>"
                    Else
                        kol12 = "<td>-</td>"
                    End If

                    If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                        kosulgrupno = veri.Item("kosulgrupno")
                        kol13 = "<td>" + kosulgrupno + "</td>"
                    Else
                        kol13 = "<td>-</td>"
                    End If


                    If Not veri.Item("grupmantikop") Is System.DBNull.Value Then
                        grupmantikop = veri.Item("grupmantikop")
                        kol14 = "<td>" + grupmantikop + "</td>"
                    Else
                        kol14 = "<td>-</td>"
                    End If

                    If Not veri.Item("sezonad") Is System.DBNull.Value Then
                        sezonad = veri.Item("sezonad")
                        kol15 = "<td>" + sezonad + "</td>"
                    Else
                        kol15 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "kosulfieldsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='kosulfieldsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"

                    kol16 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + kol13 + _
                    kol14 + kol15 + kol16
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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal raporpkey As Integer, ByVal kosultabload As String, _
        ByVal fieldad As String, ByVal sira As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where raporpkey=@raporpkey and " + _
        "kosultabload=@kosultabload and fieldad=@fieldad and sira=@sira"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kosultabload", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = kosultabload
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@fieldad", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = fieldad
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sira", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        param4.Value = sira
        komut.Parameters.Add(param4)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function raporvarmi(ByVal raporpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function kullanilacaktablovarmi(ByVal raporpkey As Integer, ByVal kullanilacaktablopkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where raporpkey=@raporpkey and " + _
        "kullanilacaktablopkey=@kullanilacaktablopkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanilacaktablopkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanilacaktablopkey
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



    Function dropdownlistpkeyvarmi(ByVal dropdownlistpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where dropdownlistpkey=@dropdownlistpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@dropdownlistpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = dropdownlistpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function doldurkosulgruplari(ByVal raporpkey As String) As Integer()

        Dim i As Integer = 0

        Dim kosulgruparr(grupsayisibul(raporpkey) - 1) As Integer

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select distinct(kosulgrupno) from kosulfield where raporpkey=@raporpkey" + _
        " order by kosulgrupno"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                If Not veri.Item("kosulgrupno") Is System.DBNull.Value Then
                    kosulgruparr(i) = veri.Item("kosulgrupno")
                End If
                i = i + 1
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kosulgruparr

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function grupsayisibul(ByVal raporpkey As String) As Integer

        Dim i As Integer = 0
        Dim sqlstr As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select distinct(kosulgrupno) from kosulfield where raporpkey=@raporpkey" + _
        " order by kosulgrupno"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                i = i + 1
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return i

    End Function


    Function siranumarasivarmi(ByVal raporpkey As String, ByVal sirano As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kosulfield where sira=@sira and raporpkey=@raporpkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@sira", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = sirano
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = raporpkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function



    Public Function maksimumsiranumarasinasahipmi_ilgiligrupta(ByVal kosulfield As CLASSKOSULFIELD) As String

        Dim enbuyuksiranoyasahipkosulmu As String
        enbuyuksiranoyasahipkosulmu = "Evet"

        Dim ilgiligruptakikosullar As New List(Of CLASSKOSULFIELD)

        ilgiligruptakikosullar = doldur_ilgili_istenilengrup(kosulfield.raporpkey, kosulfield.kosulgrupno)

        For Each item As CLASSKOSULFIELD In ilgiligruptakikosullar
            If kosulfield.sira < item.sira Then
                enbuyuksiranoyasahipkosulmu = "Hayır"
            End If
        Next

        Return enbuyuksiranoyasahipkosulmu


    End Function



    '----------İLGİLİ RAPORDAKİ MAKSIMUM SIRA NUMARASINA SAHİP KAYDI BULUYORUZ---------------------------------------
    Public Function maksimumsirano(ByVal raporpkey As Integer) As Integer

        Dim sqlstr As String
        Dim max As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(sira) from kosulfield where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)


        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            max = 0
        Else
            max = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return max

    End Function



    Public Function listele_javascriptyardimci() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim kol10, kol11 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""



        jvstring = "<script type='text/javascript'>" + _
              "$(document).ready(function() {" + _
                  "$('.button').button();" + _
              "});" + _
              "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Rapor</th>" + _
        "<th>Koşul Tablo Adı</th>" + _
        "<th>Alan Adı</th>" + _
        "<th>Alan Türü</th>" + _
        "<th>Sıra</th>" + _
        "<th>Arabirim Label</th>" + _
        "<th>Arabirim Adı</th>" + _
        "<th>Arabirim ID</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        sqlstr = "select * from kosulfield where raporpkey=@raporpkey and runtime=@runtime" + _
        " order by kosulgrupno, sira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = HttpContext.Current.Session("raporpkey")
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@runtime", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Evet"
        komut.Parameters.Add(param2)

        girdi = "0"
        Dim pkey, raporpkey, fieldad, sira, runtime, kosulop As String
        Dim kosultabload, fieldtype, arabirimlabel, arabirimtip As String
        Dim arabirimid As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        Dim link As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        arabirimid = "ss" + CStr(veri.Item("pkey"))
                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(raporpkey) + _
                        "&op=duzenle" + _
                        "&kosulfieldop=duzenle" + _
                        "&kosulfieldpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    End If


                    If Not veri.Item("kosultabload") Is System.DBNull.Value Then
                        kosultabload = veri.Item("kosultabload")
                        kol3 = "<td>" + kosultabload + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldad") Is System.DBNull.Value Then
                        fieldad = veri.Item("fieldad")
                        kol4 = "<td>" + fieldad + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("fieldtype") Is System.DBNull.Value Then
                        fieldtype = veri.Item("fieldtype")
                        kol5 = "<td>" + fieldtype + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("sira") Is System.DBNull.Value Then
                        sira = veri.Item("sira")
                        kol6 = "<td>" + sira + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                  

                    If Not veri.Item("arabirimlabel") Is System.DBNull.Value Then
                        arabirimlabel = veri.Item("arabirimlabel")
                        kol9 = "<td>" + arabirimlabel + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If


                    If Not veri.Item("arabirimtip") Is System.DBNull.Value Then
                        arabirimtip = veri.Item("arabirimtip")
                        kol10 = "<td>" + arabirimtip + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If

                    kol11 = "<td>" + arabirimid + "</td></tr>"


                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

End Class

