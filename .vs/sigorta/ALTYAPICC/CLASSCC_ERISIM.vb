Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data


Public Class CLASSCC_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim cc As New CLASSCC
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal cc As CLASSCC) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into cc values (@pkey," + _
        "@tuzukaractippkey,@baslangicc,@bitiscc,@oran)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If cc.tuzukaractippkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = cc.tuzukaractippkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangicc", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If cc.baslangicc = 0 Then
            param3.Value = 0
        Else
            param3.Value = cc.baslangicc
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitiscc", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If cc.bitiscc = 0 Then
            param4.Value = 0
        Else
            param4.Value = cc.bitiscc
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@oran", SqlDbType.Decimal)
        param5.Direction = ParameterDirection.Input
        If cc.oran = 0 Then
            param5.Value = 0
        Else
            param5.Value = cc.oran
        End If
        komut.Parameters.Add(param5)

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
        sqlstr = "select max(pkey) from cc"
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
    Function Duzenle(ByVal cc As CLASSCC) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update cc set " + _
        "tuzukaractippkey=@tuzukaractippkey," + _
        "baslangicc=@baslangicc," + _
        "bitiscc=@bitiscc," + _
        "oran=@oran" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = cc.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If cc.tuzukaractippkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = cc.tuzukaractippkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@baslangicc", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If cc.baslangicc = 0 Then
            param3.Value = 0
        Else
            param3.Value = cc.baslangicc
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@bitiscc", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If cc.bitiscc = 0 Then
            param4.Value = 0
        Else
            param4.Value = cc.bitiscc
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@oran", SqlDbType.Decimal)
        param5.Direction = ParameterDirection.Input
        If cc.oran = 0 Then
            param5.Value = 0
        Else
            param5.Value = cc.oran
        End If
        komut.Parameters.Add(param5)


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
    Function bultek(ByVal pkey As String) As CLASSCC

        Dim komut As New SqlCommand
        Dim donecekcc As New CLASSCC()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from cc where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekcc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecekcc.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("baslangicc") Is System.DBNull.Value Then
                    donecekcc.baslangicc = veri.Item("baslangicc")
                End If

                If Not veri.Item("bitiscc") Is System.DBNull.Value Then
                    donecekcc.bitiscc = veri.Item("bitiscc")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekcc.oran = veri.Item("oran")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekcc

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from cc where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSCC)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekcc As New CLASSCC
        Dim ccler As New List(Of CLASSCC)
        komut.Connection = db_baglanti
        sqlstr = "select * from cc"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekcc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecekcc.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("baslangicc") Is System.DBNull.Value Then
                    donecekcc.baslangicc = veri.Item("baslangicc")
                End If

                If Not veri.Item("bitiscc") Is System.DBNull.Value Then
                    donecekcc.bitiscc = veri.Item("bitiscc")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekcc.oran = veri.Item("oran")
                End If


                ccler.Add(New CLASSCC(donecekcc.pkey, _
                donecekcc.tuzukaractippkey, donecekcc.baslangicc, donecekcc.bitiscc, donecekcc.oran))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ccler

    End Function


    Public Function doldurilgili(ByVal tuzukaractippkey As String) As List(Of CLASSCC)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekcc As New CLASSCC
        Dim ccler As New List(Of CLASSCC)
        komut.Connection = db_baglanti
        sqlstr = "select * from cc where tuzukaractippkey=@tuzukaractippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekcc.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                    donecekcc.tuzukaractippkey = veri.Item("tuzukaractippkey")
                End If

                If Not veri.Item("baslangicc") Is System.DBNull.Value Then
                    donecekcc.baslangicc = veri.Item("baslangicc")
                End If

                If Not veri.Item("bitiscc") Is System.DBNull.Value Then
                    donecekcc.bitiscc = veri.Item("bitiscc")
                End If

                If Not veri.Item("oran") Is System.DBNull.Value Then
                    donecekcc.oran = veri.Item("oran")
                End If


                ccler.Add(New CLASSCC(donecekcc.pkey, _
                donecekcc.tuzukaractippkey, donecekcc.baslangicc, donecekcc.bitiscc, donecekcc.oran))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ccler

    End Function
   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
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
        "<th>Tüzükteki Araç Tipi</th>" + _
        "<th>Başlangıç CC</th>" + _
        "<th>Bitiş CC</th>" + _
        "<th>CC Zammı Oranı</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from cc"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, tuzukaractippkey, baslangicc, bitiscc As String
        Dim oran As Decimal

        Dim tuzukaractip As New CLASSTUZUKARACTIP
        Dim tuzukaractip_erisim As New CLASSTUZUKARACTIP_ERISIM

   
        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "cc.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("tuzukaractippkey") Is System.DBNull.Value Then
                        tuzukaractippkey = veri.Item("tuzukaractippkey")
                        tuzukaractip = tuzukaractip_erisim.bultek(tuzukaractippkey)
                        kol2 = "<td>" + tuzukaractip.tuzukaractipad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("baslangicc") Is System.DBNull.Value Then
                        baslangicc = veri.Item("baslangicc")
                        kol3 = "<td>" + baslangicc + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("bitiscc") Is System.DBNull.Value Then
                        bitiscc = veri.Item("bitiscc")
                        kol4 = "<td>" + bitiscc + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("oran") Is System.DBNull.Value Then
                        oran = veri.Item("oran")
                        kol5 = "<td>" + Format(oran, "0.00") + "</td></tr>"
                    Else
                        kol5 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5
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


    Function varmituzukaractip(ByVal tuzukaractippkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from cc where tuzukaractippkey=@tuzukaractippkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@tuzukaractippkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = tuzukaractippkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function



End Class
