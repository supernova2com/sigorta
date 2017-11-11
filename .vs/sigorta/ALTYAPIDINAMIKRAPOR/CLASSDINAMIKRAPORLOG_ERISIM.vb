Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSDINAMIKRAPORLOG_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim dinamikraporlog As New CLASSDINAMIKRAPORLOG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal dinamikraporlog As CLASSDINAMIKRAPORLOG) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into dinamikraporlog values (@pkey," + _
        "@raporpkey,@csql,@clog,@ctarih)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If dinamikraporlog.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = dinamikraporlog.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@csql", SqlDbType.Text)
        param3.Direction = ParameterDirection.Input
        If dinamikraporlog.csql = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = dinamikraporlog.csql
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@clog", SqlDbType.Text)
        param4.Direction = ParameterDirection.Input
        If dinamikraporlog.clog = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = dinamikraporlog.clog
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@ctarih", SqlDbType.DateTime)
        param5.Direction = ParameterDirection.Input
        If dinamikraporlog.ctarih Is Nothing Or dinamikraporlog.ctarih = "00:00:00" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = dinamikraporlog.ctarih
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
        sqlstr = "select max(pkey) from dinamikraporlog"
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

    

    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSDINAMIKRAPORLOG

        Dim komut As New SqlCommand
        Dim donecekdinamikraporlog As New CLASSDINAMIKRAPORLOG()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from dinamikraporlog where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekdinamikraporlog.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekdinamikraporlog.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("csql") Is System.DBNull.Value Then
                    donecekdinamikraporlog.csql = veri.Item("csql")
                End If

                If Not veri.Item("clog") Is System.DBNull.Value Then
                    donecekdinamikraporlog.clog = veri.Item("clog")
                End If

                If Not veri.Item("ctarih") Is System.DBNull.Value Then
                    donecekdinamikraporlog.ctarih = veri.Item("ctarih")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekdinamikraporlog

    End Function

   
    
    '---------------------------------listele--------------------------------------
    Public Function listele(ByVal p_raporpkey As Integer) As String


        Dim donecek As String
        donecek = ""

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        sqlstr = "select top(1) * from dinamikraporlog where raporpkey=@raporpkey order by ctarih desc"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = p_raporpkey
        komut.Parameters.Add(param1)

        Dim dinamikraporlog As New CLASSDINAMIKRAPORLOG
        Dim pkey As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        dinamikraporlog = bultek(pkey)
                    End If

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        donecek = "<div class='note note-success'>" + _
        "<h4 class='block'>Çalıştırılan SQL</h4>" + _
        "<p>" + dinamikraporlog.csql + "</p>" + _
        "</div>" + _
        "<div class='note note-info'>" + _
        "<h4 class='block'>Alınanan Değerler</h4>" + _
        "<p>" + dinamikraporlog.clog + "</p>" + _
        "</div>"

        Return donecek

    End Function


End Class