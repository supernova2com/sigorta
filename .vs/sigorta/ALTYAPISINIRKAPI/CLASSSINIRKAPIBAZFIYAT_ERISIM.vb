Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO

Public Class CLASSSINIRKAPIBAZFIYAT_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim SINIRKAPIBAZFIYAT As New CLASSSINIRKAPIBAZFIYAT
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal SINIRKAPIBAZFIYAT As CLASSSINIRKAPIBAZFIYAT) As CLADBOPRESULT

        Dim p_pkey As Integer
        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(SINIRKAPIBAZFIYAT.kayitno)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kayıt numarası için kayıt vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into sinirkapibazfiyat values (@pkey," + _
            "@baslangictarih,@kayittarih,@kayitno)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            p_pkey = pkeybul()
            param1.Value = p_pkey
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
            param2.Direction = ParameterDirection.Input
            If SINIRKAPIBAZFIYAT.baslangictarih Is Nothing Or SINIRKAPIBAZFIYAT.baslangictarih = "00:00:00" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = SINIRKAPIBAZFIYAT.baslangictarih
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
            param3.Direction = ParameterDirection.Input
            If SINIRKAPIBAZFIYAT.kayittarih Is Nothing Or SINIRKAPIBAZFIYAT.kayittarih = "00:00:00" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = SINIRKAPIBAZFIYAT.kayittarih
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@kayitno", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If SINIRKAPIBAZFIYAT.kayitno = 0 Then
                param4.Value = 0
            Else
                param4.Value = SINIRKAPIBAZFIYAT.kayitno
            End If
            komut.Parameters.Add(param4)
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
                resultset.etkilenen = p_pkey
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
        sqlstr = "select max(pkey) from sinirkapibazfiyat"
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
    Function Duzenle(ByVal SINIRKAPIBAZFIYAT As CLASSSINIRKAPIBAZFIYAT) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update sinirkapibazfiyat set " + _
        "baslangictarih=@baslangictarih," + _
        "kayittarih=@kayittarih," + _
        "kayitno=@kayitno" + _
        " where pkey=@pkey"


        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = SINIRKAPIBAZFIYAT.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If SINIRKAPIBAZFIYAT.baslangictarih Is Nothing Or SINIRKAPIBAZFIYAT.baslangictarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = SINIRKAPIBAZFIYAT.baslangictarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kayittarih", SqlDbType.DateTime)
        param3.Direction = ParameterDirection.Input
        If SINIRKAPIBAZFIYAT.kayittarih Is Nothing Or SINIRKAPIBAZFIYAT.kayittarih = "00:00:00" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = SINIRKAPIBAZFIYAT.kayittarih
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kayitno", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If SINIRKAPIBAZFIYAT.kayitno = 0 Then
            param4.Value = 0
        Else
            param4.Value = SINIRKAPIBAZFIYAT.kayitno
        End If
        komut.Parameters.Add(param4)


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
    Function bultek(ByVal pkey As String) As CLASSSINIRKAPIBAZFIYAT

        Dim komut As New SqlCommand
        Dim donecekSINIRKAPIBAZFIYAT As New CLASSSINIRKAPIBAZFIYAT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapibazfiyat where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayitno = veri.Item("kayitno")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekSINIRKAPIBAZFIYAT

    End Function


    Function bul_kayitnogore(ByVal kayitno As Integer) As CLASSSINIRKAPIBAZFIYAT

        Dim komut As New SqlCommand
        Dim donecekSINIRKAPIBAZFIYAT As New CLASSSINIRKAPIBAZFIYAT()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapibazfiyat where kayitno=@kayitno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kayitno", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kayitno
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayitno = veri.Item("kayitno")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekSINIRKAPIBAZFIYAT

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "delete from sinirkapibazfiyat where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSSINIRKAPIBAZFIYAT)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekSINIRKAPIBAZFIYAT As New CLASSSINIRKAPIBAZFIYAT
        Dim SINIRKAPIBAZFIYATler As New List(Of CLASSSINIRKAPIBAZFIYAT)
        komut.Connection = db_baglanti
        sqlstr = "select * from sinirkapibazfiyat"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.baslangictarih = veri.Item("baslangictarih")
                End If

                If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayittarih = veri.Item("kayittarih")
                End If

                If Not veri.Item("kayitno") Is System.DBNull.Value Then
                    donecekSINIRKAPIBAZFIYAT.kayitno = veri.Item("kayitno")
                End If


                SINIRKAPIBAZFIYATler.Add(New CLASSSINIRKAPIBAZFIYAT(donecekSINIRKAPIBAZFIYAT.pkey, _
                donecekSINIRKAPIBAZFIYAT.baslangictarih, donecekSINIRKAPIBAZFIYAT.kayittarih, donecekSINIRKAPIBAZFIYAT.kayitno))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return SINIRKAPIBAZFIYATler

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
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
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Kayıt Tarihi</th>" + _
        "<th>Kayıt No</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from sinirkapibazfiyat"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, baslangictarih, kayittarih, kayitno As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "sinirkapibazfiyatgirispopup.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td><span class='iframeyenikayit' href=" + link + ">" + javascript.editbuttonyarat(link) + "</a></td>"
                    End If


                    If Not veri.Item("baslangictarih") Is System.DBNull.Value Then
                        baslangictarih = veri.Item("baslangictarih")
                        kol2 = "<td>" + baslangictarih + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("kayittarih") Is System.DBNull.Value Then
                        kayittarih = veri.Item("kayittarih")
                        kol3 = "<td>" + kayittarih + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("kayitno") Is System.DBNull.Value Then
                        kayitno = veri.Item("kayitno")
                        kol4 = "<td>" + kayitno + "</td></tr>"
                    Else
                        kol4 = "<td>-</td></tr>"
                    End If


                    satir = satir + kol1 + kol2 + kol3 + kol4
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

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal kayitno As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapibazfiyat where kayitno=@kayitno"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kayitno", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kayitno
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

    '----------------------------KAYIT NUMARASINI BUL---------------------------------------
    Public Function kayitnobul() As Integer

        Dim sqlstr As String
        Dim kayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from sinirkapibazfiyat"
        komut = New SqlCommand(sqlstr, db_baglanti)

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitno = 1
        Else
            kayitno = maxkayit1 + 1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitno

    End Function


    '----------------------------KAYIT NUMARASINI BUL---------------------------------------
    Public Function ensonkayitnobul() As Integer

        Dim sqlstr As String
        Dim kayitno As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(kayitno) from sinirkapibazfiyat"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitno = 0
        Else
            kayitno = maxkayit1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitno

    End Function



    Function kayitnovarmi(ByVal kayitno As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from sinirkapibazfiyat where kayitno=@kayitno"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kayitno", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kayitno
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




End Class
