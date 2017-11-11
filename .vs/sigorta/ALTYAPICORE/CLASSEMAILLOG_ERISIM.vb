Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data

Public Class CLASSEMAILLOG_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim emaillog As New CLASSEMAILLOG
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal emaillog As CLASSEMAILLOG) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into emaillog values (@pkey," + _
        "@gondermetarih,@kime,@kimden,@subject," + _
        "@body,@sonuc,@hatatxt)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gondermetarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        If emaillog.gondermetarih Is Nothing Or emaillog.gondermetarih = "00:00:00" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = emaillog.gondermetarih
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@kime", SqlDbType.VarChar, 254)
        param3.Direction = ParameterDirection.Input
        If emaillog.kime = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = emaillog.kime
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@kimden", SqlDbType.VarChar, 254)
        param4.Direction = ParameterDirection.Input
        If emaillog.kimden = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = emaillog.kimden
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@subject", SqlDbType.Text)
        param5.Direction = ParameterDirection.Input
        If emaillog.subject = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = emaillog.subject
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@body", SqlDbType.Text)
        param6.Direction = ParameterDirection.Input
        If emaillog.body = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = emaillog.body
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@sonuc", SqlDbType.VarChar, 15)
        param7.Direction = ParameterDirection.Input
        If emaillog.sonuc = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = emaillog.sonuc
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@hatatxt", SqlDbType.Text)
        param8.Direction = ParameterDirection.Input
        If emaillog.hatatxt = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = emaillog.hatatxt
        End If
        komut.Parameters.Add(param8)

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
        sqlstr = "select max(pkey) from emaillog"
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

End Class
