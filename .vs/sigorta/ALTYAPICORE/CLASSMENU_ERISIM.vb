Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMENU_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim menu As New CLASSMENU
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal menu As CLASSMENU) As CLADBOPRESULT

        etkilenen = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti

        sqlstr = "insert into menu values (@pkey," + _
        "@baslik,@babaid,@sira,@tip," + _
        "@anamenupkey,@iconclass,@anaclass,@idismi," + _
        "@ekhtml,@link,@hakkolon,@baslikmi," + _
        "@neredeacilsin,@modulpkey,@herzamangozuksunmu)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslik", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If menu.baslik = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = menu.baslik
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@babaid", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If menu.babaid = 0 Then
            param3.Value = 0
        Else
            param3.Value = menu.babaid
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sira", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If menu.sira = 0 Then
            param4.Value = 0
        Else
            param4.Value = menu.sira
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tip", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If menu.tip = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = menu.tip
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If menu.anamenupkey = 0 Then
            param6.Value = 0
        Else
            param6.Value = menu.anamenupkey
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@iconclass", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If menu.iconclass = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = menu.iconclass
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@anaclass", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If menu.anaclass = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = menu.anaclass
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@idismi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If menu.idismi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = menu.idismi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@ekhtml", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If menu.ekhtml = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = menu.ekhtml
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@link", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If menu.link = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = menu.link
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@hakkolon", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If menu.hakkolon = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = menu.hakkolon
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@baslikmi", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If menu.baslikmi = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = menu.baslikmi
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@neredeacilsin", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If menu.neredeacilsin = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = menu.neredeacilsin
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@modulpkey", SqlDbType.Int)
        param15.Direction = ParameterDirection.Input
        If menu.modulpkey = 0 Then
            param15.Value = 0
        Else
            param15.Value = menu.modulpkey
        End If
        komut.Parameters.Add(param15)


        Dim param16 As New SqlParameter("@herzamangozuksunmu", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If menu.tip = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = menu.herzamangozuksunmu
        End If
        komut.Parameters.Add(param16)


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
        sqlstr = "select max(pkey) from menu"
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
    Function Duzenle(ByVal menu As CLASSMENU) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update menu set " + _
        "baslik=@baslik," + _
        "babaid=@babaid," + _
        "sira=@sira," + _
        "tip=@tip," + _
        "anamenupkey=@anamenupkey," + _
        "iconclass=@iconclass," + _
        "anaclass=@anaclass," + _
        "idismi=@idismi," + _
        "ekhtml=@ekhtml," + _
        "link=@link," + _
        "hakkolon=@hakkolon," + _
        "baslikmi=@baslikmi," + _
        "neredeacilsin=@neredeacilsin," + _
        "modulpkey=@modulpkey," + _
        "herzamangozuksunmu=@herzamangozuksunmu" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = menu.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@baslik", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If menu.baslik = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = menu.baslik
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@babaid", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        If menu.babaid = 0 Then
            param3.Value = 0
        Else
            param3.Value = menu.babaid
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@sira", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If menu.sira = 0 Then
            param4.Value = 0
        Else
            param4.Value = menu.sira
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@tip", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If menu.tip = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = menu.tip
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If menu.anamenupkey = 0 Then
            param6.Value = 0
        Else
            param6.Value = menu.anamenupkey
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@iconclass", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If menu.iconclass = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = menu.iconclass
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@anaclass", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If menu.anaclass = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = menu.anaclass
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@idismi", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If menu.idismi = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = menu.idismi
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@ekhtml", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If menu.ekhtml = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = menu.ekhtml
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@link", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If menu.link = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = menu.link
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@hakkolon", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If menu.hakkolon = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = menu.hakkolon
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@baslikmi", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If menu.baslikmi = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = menu.baslikmi
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@neredeacilsin", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If menu.neredeacilsin = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = menu.neredeacilsin
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@modulpkey", SqlDbType.Int)
        param15.Direction = ParameterDirection.Input
        If menu.modulpkey = 0 Then
            param15.Value = 0
        Else
            param15.Value = menu.modulpkey
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@herzamangozuksunmu", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If menu.tip = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = menu.herzamangozuksunmu
        End If
        komut.Parameters.Add(param16)

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
    Function bultek(ByVal pkey As String) As CLASSMENU

        Dim komut As New SqlCommand
        Dim donecekmenu As New CLASSMENU()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from menu where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmenu.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecekmenu.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("babaid") Is System.DBNull.Value Then
                    donecekmenu.babaid = veri.Item("babaid")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekmenu.sira = veri.Item("sira")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmenu.tip = veri.Item("tip")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekmenu.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("iconclass") Is System.DBNull.Value Then
                    donecekmenu.iconclass = veri.Item("iconclass")
                End If

                If Not veri.Item("anaclass") Is System.DBNull.Value Then
                    donecekmenu.anaclass = veri.Item("anaclass")
                End If

                If Not veri.Item("idismi") Is System.DBNull.Value Then
                    donecekmenu.idismi = veri.Item("idismi")
                End If

                If Not veri.Item("ekhtml") Is System.DBNull.Value Then
                    donecekmenu.ekhtml = veri.Item("ekhtml")
                End If

                If Not veri.Item("link") Is System.DBNull.Value Then
                    donecekmenu.link = veri.Item("link")
                End If

                If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                    donecekmenu.hakkolon = veri.Item("hakkolon")
                End If

                If Not veri.Item("baslikmi") Is System.DBNull.Value Then
                    donecekmenu.baslikmi = veri.Item("baslikmi")
                End If

                If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                    donecekmenu.neredeacilsin = veri.Item("neredeacilsin")
                End If

                If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                    donecekmenu.modulpkey = veri.Item("modulpkey")
                End If

                If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                    donecekmenu.herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmenu

    End Function

    Function bulsayfaadagore(ByVal sayfaad As String) As CLASSMENU

        Dim komut As New SqlCommand
        Dim donecekmenu As New CLASSMENU()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)

        Try
            db_baglanti.Open()
        Catch ex As Exception
            HttpContext.Current.Session("hata") = ex.Message
            HttpContext.Current.Response.Redirect("fatal.aspx")
        End Try


        sqlstr = "select * from menu where link LIKE @link+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@link", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = sayfaad
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmenu.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecekmenu.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("babaid") Is System.DBNull.Value Then
                    donecekmenu.babaid = veri.Item("babaid")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekmenu.sira = veri.Item("sira")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmenu.tip = veri.Item("tip")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekmenu.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("iconclass") Is System.DBNull.Value Then
                    donecekmenu.iconclass = veri.Item("iconclass")
                End If

                If Not veri.Item("anaclass") Is System.DBNull.Value Then
                    donecekmenu.anaclass = veri.Item("anaclass")
                End If

                If Not veri.Item("idismi") Is System.DBNull.Value Then
                    donecekmenu.idismi = veri.Item("idismi")
                End If

                If Not veri.Item("ekhtml") Is System.DBNull.Value Then
                    donecekmenu.ekhtml = veri.Item("ekhtml")
                End If

                If Not veri.Item("link") Is System.DBNull.Value Then
                    donecekmenu.link = veri.Item("link")
                End If

                If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                    donecekmenu.hakkolon = veri.Item("hakkolon")
                End If

                If Not veri.Item("baslikmi") Is System.DBNull.Value Then
                    donecekmenu.baslikmi = veri.Item("baslikmi")
                End If

                If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                    donecekmenu.neredeacilsin = veri.Item("neredeacilsin")
                End If

                If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                    donecekmenu.modulpkey = veri.Item("modulpkey")
                End If

                If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                    donecekmenu.herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                End If

            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekmenu

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim resultset As New CLADBOPRESULT
        Dim varmi As String = "Hayır"
        Dim babaninaltindakiler As New List(Of CLASSMENU)
        Dim silinecekmenu As New CLASSMENU
        silinecekmenu = bultek(pkey)
        babaninaltindakiler = doldurilgilibabaninaltindakiler(silinecekmenu.pkey, silinecekmenu.anamenupkey)

        If babaninaltindakiler.Count > 0 Then
            varmi = "Evet"
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu menunun altında alt menuler olduğundan bu menuyu silemezsiniz." + _
            "Önce bu menu altındaki alt başlıkları siliniz."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            sqlstr = "delete from menu where pkey=@pkey"
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
    Public Function doldur() As List(Of CLASSMENU)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmenu As New CLASSMENU
        Dim menuler As New List(Of CLASSMENU)
        komut.Connection = db_baglanti
        sqlstr = "select * from menu order by sira"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmenu.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecekmenu.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("babaid") Is System.DBNull.Value Then
                    donecekmenu.babaid = veri.Item("babaid")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekmenu.sira = veri.Item("sira")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmenu.tip = veri.Item("tip")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekmenu.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("iconclass") Is System.DBNull.Value Then
                    donecekmenu.iconclass = veri.Item("iconclass")
                End If

                If Not veri.Item("anaclass") Is System.DBNull.Value Then
                    donecekmenu.anaclass = veri.Item("anaclass")
                End If

                If Not veri.Item("idismi") Is System.DBNull.Value Then
                    donecekmenu.idismi = veri.Item("idismi")
                End If

                If Not veri.Item("ekhtml") Is System.DBNull.Value Then
                    donecekmenu.ekhtml = veri.Item("ekhtml")
                End If

                If Not veri.Item("link") Is System.DBNull.Value Then
                    donecekmenu.link = veri.Item("link")
                End If

                If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                    donecekmenu.hakkolon = veri.Item("hakkolon")
                End If

                If Not veri.Item("baslikmi") Is System.DBNull.Value Then
                    donecekmenu.baslikmi = veri.Item("baslikmi")
                End If

                If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                    donecekmenu.neredeacilsin = veri.Item("neredeacilsin")
                End If

                If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                    donecekmenu.modulpkey = veri.Item("modulpkey")
                End If

                If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                    donecekmenu.herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                End If


                menuler.Add(New CLASSMENU(donecekmenu.pkey, _
                donecekmenu.baslik, donecekmenu.babaid, donecekmenu.sira, donecekmenu.tip, _
                donecekmenu.anamenupkey, donecekmenu.iconclass, donecekmenu.anaclass, donecekmenu.idismi, _
                donecekmenu.ekhtml, donecekmenu.link, donecekmenu.hakkolon, donecekmenu.baslikmi, _
                donecekmenu.neredeacilsin, donecekmenu.modulpkey, donecekmenu.herzamangozuksunmu))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return menuler

    End Function

    '---------------------------------doldur sadece babalar-----------------------------------------
    Public Function doldursadecebaba(ByVal anamenupkey As String) As List(Of CLASSMENU)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmenu As New CLASSMENU
        Dim menuler As New List(Of CLASSMENU)
        komut.Connection = db_baglanti
        sqlstr = "select * from menu where babaid=@babaid and anamenupkey=@anamenupkey order by sira"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@babaid", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 0
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = anamenupkey
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmenu.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecekmenu.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("babaid") Is System.DBNull.Value Then
                    donecekmenu.babaid = veri.Item("babaid")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekmenu.sira = veri.Item("sira")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmenu.tip = veri.Item("tip")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekmenu.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("iconclass") Is System.DBNull.Value Then
                    donecekmenu.iconclass = veri.Item("iconclass")
                End If

                If Not veri.Item("anaclass") Is System.DBNull.Value Then
                    donecekmenu.anaclass = veri.Item("anaclass")
                End If

                If Not veri.Item("idismi") Is System.DBNull.Value Then
                    donecekmenu.idismi = veri.Item("idismi")
                End If

                If Not veri.Item("ekhtml") Is System.DBNull.Value Then
                    donecekmenu.ekhtml = veri.Item("ekhtml")
                End If

                If Not veri.Item("link") Is System.DBNull.Value Then
                    donecekmenu.link = veri.Item("link")
                End If

                If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                    donecekmenu.hakkolon = veri.Item("hakkolon")
                End If

                If Not veri.Item("baslikmi") Is System.DBNull.Value Then
                    donecekmenu.baslikmi = veri.Item("baslikmi")
                End If

                If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                    donecekmenu.neredeacilsin = veri.Item("neredeacilsin")
                End If

                If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                    donecekmenu.modulpkey = veri.Item("modulpkey")
                End If

                If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                    donecekmenu.herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                End If


                menuler.Add(New CLASSMENU(donecekmenu.pkey, _
                donecekmenu.baslik, donecekmenu.babaid, donecekmenu.sira, donecekmenu.tip, _
                donecekmenu.anamenupkey, donecekmenu.iconclass, donecekmenu.anaclass, donecekmenu.idismi, _
                donecekmenu.ekhtml, donecekmenu.link, donecekmenu.hakkolon, donecekmenu.baslikmi, _
                donecekmenu.neredeacilsin, donecekmenu.modulpkey, donecekmenu.herzamangozuksunmu))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return menuler

    End Function


    '--------doldur ilgili babanin altındakiler-----------------------------------------
    Public Function doldurilgilibabaninaltindakiler(ByVal babaid As String, _
    ByVal anamenupkey As String) As List(Of CLASSMENU)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekmenu As New CLASSMENU
        Dim menuler As New List(Of CLASSMENU)
        komut.Connection = db_baglanti
        sqlstr = "select * from menu where" + _
        " babaid=@babaid " + _
        " and anamenupkey=@anamenupkey order by sira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@baslikmi", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Hayır"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@babaid", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = babaid
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param3.Direction = ParameterDirection.Input
        param3.Value = anamenupkey
        komut.Parameters.Add(param3)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekmenu.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("baslik") Is System.DBNull.Value Then
                    donecekmenu.baslik = veri.Item("baslik")
                End If

                If Not veri.Item("babaid") Is System.DBNull.Value Then
                    donecekmenu.babaid = veri.Item("babaid")
                End If

                If Not veri.Item("sira") Is System.DBNull.Value Then
                    donecekmenu.sira = veri.Item("sira")
                End If

                If Not veri.Item("tip") Is System.DBNull.Value Then
                    donecekmenu.tip = veri.Item("tip")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekmenu.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("iconclass") Is System.DBNull.Value Then
                    donecekmenu.iconclass = veri.Item("iconclass")
                End If

                If Not veri.Item("anaclass") Is System.DBNull.Value Then
                    donecekmenu.anaclass = veri.Item("anaclass")
                End If

                If Not veri.Item("idismi") Is System.DBNull.Value Then
                    donecekmenu.idismi = veri.Item("idismi")
                End If

                If Not veri.Item("ekhtml") Is System.DBNull.Value Then
                    donecekmenu.ekhtml = veri.Item("ekhtml")
                End If

                If Not veri.Item("link") Is System.DBNull.Value Then
                    donecekmenu.link = veri.Item("link")
                End If

                If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                    donecekmenu.hakkolon = veri.Item("hakkolon")
                End If

                If Not veri.Item("baslikmi") Is System.DBNull.Value Then
                    donecekmenu.baslikmi = veri.Item("baslikmi")
                End If

                If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                    donecekmenu.neredeacilsin = veri.Item("neredeacilsin")
                End If

                If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                    donecekmenu.modulpkey = veri.Item("modulpkey")
                End If

                If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                    donecekmenu.herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                End If


                menuler.Add(New CLASSMENU(donecekmenu.pkey, _
                donecekmenu.baslik, donecekmenu.babaid, donecekmenu.sira, donecekmenu.tip, _
                donecekmenu.anamenupkey, donecekmenu.iconclass, donecekmenu.anaclass, donecekmenu.idismi, _
                donecekmenu.ekhtml, donecekmenu.link, donecekmenu.hakkolon, donecekmenu.baslikmi, _
                donecekmenu.neredeacilsin,donecekmenu.modulpkey, donecekmenu.herzamangozuksunmu))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return menuler

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10, kol11, kol12 As String
        Dim kol13, kol14, kol15 As String
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
        "<th>Düzenle</th>" + _
        "<th>Anahtar</th>" + _
        "<th>Hangi Menu Elemanı?</th>" + _
        "<th>Başlık</th>" + _
        "<th>Father ID</th>" + _
        "<th>Sıra</th>" + _
        "<th>Tip</th>" + _
        "<th>Ikon Sınıfı</th>" + _
        "<th>Sınıfı</th>" + _
        "<th>ID İsmi</th>" + _
        "<th>Gideceği Link</th>" + _
        "<th>Yetki Kolonu</th>" + _
        "<th>Bağlı Modülü</th>" + _
        "<th>Nerede Açılacak?</th>" + _
        "<th>Her Zaman Gözükecek mi?</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from menu order by sira"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If

        If HttpContext.Current.Session("ltip") = "sadecebaba" Then
            sqlstr = "select * from menu where anamenupkey=@anamenupkey and " + _
            " baslikmi=@baslikmi order by sira"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@anamenupkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("anamenupkey")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@baslikmi", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = "Evet"
            komut.Parameters.Add(param2)
        End If


        If HttpContext.Current.Session("ltip") = "altbaslik" Then
            sqlstr = "select * from menu where anamenupkey=@anamenupkey and " + _
            " babaid=@babaid order by sira"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@anamenupkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("anamenupkey")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@babaid", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            param2.Value = HttpContext.Current.Session("babaid")
            komut.Parameters.Add(param2)
        End If

        girdi = "0"
        Dim link As String
        Dim pkey, baslik, babaid, sira, tip, anamenupkey, iconclass, anaclass, idismi, ekhtml As String
        Dim herzamangozuksunmu As String
        Dim linkg, hakkolon As String
        Dim neredeacilsin As String
        Dim modulpkey As String

        Dim anamenu As New CLASSANAMENU
        Dim anamenu_erisim As New CLASSANAMENU_ERISIM

        Dim tmodul As New CLASSTMODUL
        Dim tmodul_erisim As New CLASSTMODUL_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "menu.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol2 = "<td>" + pkey + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                        anamenupkey = veri.Item("anamenupkey")
                        anamenu = anamenu_erisim.bultek(anamenupkey)
                        kol3 = "<td>" + anamenu.ad + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("baslik") Is System.DBNull.Value Then
                        baslik = veri.Item("baslik")
                        kol4 = "<td>" + baslik + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("babaid") Is System.DBNull.Value Then
                        babaid = veri.Item("babaid")
                        kol5 = "<td>" + babaid + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("sira") Is System.DBNull.Value Then
                        sira = veri.Item("sira")
                        kol6 = "<td>" + sira + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("tip") Is System.DBNull.Value Then
                        tip = veri.Item("tip")
                        kol7 = "<td>" + tip + "</td>"
                    Else
                        kol7 = "<td>-</td>"
                    End If

                    If Not veri.Item("iconclass") Is System.DBNull.Value Then
                        iconclass = veri.Item("iconclass")
                        kol8 = "<td>" + iconclass + "</td>"
                    Else
                        kol8 = "<td>-</td>"
                    End If

                    If Not veri.Item("anaclass") Is System.DBNull.Value Then
                        anaclass = veri.Item("anaclass")
                        kol9 = "<td>" + anaclass + "</td>"
                    Else
                        kol9 = "<td>-</td>"
                    End If

                    If Not veri.Item("idismi") Is System.DBNull.Value Then
                        idismi = veri.Item("idismi")
                        kol10 = "<td>" + idismi + "</td>"
                    Else
                        kol10 = "<td>-</td>"
                    End If

                    If Not veri.Item("link") Is System.DBNull.Value Then
                        link = veri.Item("link")
                        kol11 = "<td>" + link + "</td>"
                    Else
                        kol11 = "<td>-</td>"
                    End If

                    If Not veri.Item("hakkolon") Is System.DBNull.Value Then
                        hakkolon = veri.Item("hakkolon")
                        kol12 = "<td>" + hakkolon + "</td>"
                    Else
                        kol12 = "<td>-</td>"
                    End If


                    If Not veri.Item("modulpkey") Is System.DBNull.Value Then
                        modulpkey = veri.Item("modulpkey")
                        tmodul = tmodul_erisim.bultek(modulpkey)
                        kol13 = "<td>" + tmodul.ad + "</td>"
                    Else
                        kol13 = "<td>-</td>"
                    End If


                    If Not veri.Item("neredeacilsin") Is System.DBNull.Value Then
                        neredeacilsin = veri.Item("neredeacilsin")
                        kol14 = "<td>" + neredeacilsin + "</td>"
                    Else
                        kol14 = "<td>-</td>"
                    End If


                    If Not veri.Item("herzamangozuksunmu") Is System.DBNull.Value Then
                        herzamangozuksunmu = veri.Item("herzamangozuksunmu")
                        kol15 = "<td>" + herzamangozuksunmu + "</td></tr>"
                    Else
                        kol15 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
                    kol6 + kol7 + kol8 + kol9 + kol10 + kol11 + kol12 + kol13 + _
                    kol14 + kol15

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from menu where " + tablecol + "=@kriter"

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
        Return varmi

    End Function


    '--- MENUYU OLUŞTUR -------------------------------------------------------

    Function menuyuolustur() As String

        Dim eklenecek As String = ""
        Dim eklenecekclass As String = ""
        Dim donecek As String = ""
        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        Dim anamenupkey As String

        Dim menuler As New List(Of CLASSMENU)
        Dim submenuler As New List(Of CLASSMENU)
        Dim kullanici_rolpkey As String
        Dim nerdeacilsinhtml As String

        kullanici_rolpkey = HttpContext.Current.Session("kullanici_rolpkey")

        kullanicirol = kullanicirol_erisim.bultek(HttpContext.Current.Session("kullanici_rolpkey"))
        anamenupkey = kullanicirol.anamenupkey
        menuler = doldursadecebaba(anamenupkey)


        'SADECE BABALARI DOLDURDUK--------------------------------------------------------------------
        For Each itemmenu As CLASSMENU In menuler

            'yetkililer içinde dolaş
            If menuyetkilimi(itemmenu, kullanici_rolpkey) = "Evet" Then

                '-----------------------------------------------------------------------
                submenuler = doldurilgilibabaninaltindakiler(itemmenu.pkey, itemmenu.anamenupkey)
                If submenuler.Count > 0 Then
                    eklenecek = "<span class=" + Chr(34) + "arrow open" + Chr(34) + ">" + _
                                "</span>"
                Else
                    eklenecek = ""
                End If

                '----------------------------------------------------------------------
                eklenecekclass = ""
                If itemmenu.anaclass <> "" Then
                    eklenecekclass = " class=" + Chr(34) + itemmenu.anaclass + Chr(34)
                Else
                    eklenecekclass = ""
                End If

                '----------------------------------------------------------------------
                If itemmenu.neredeacilsin = "Yeni Sayfada" Then
                    nerdeacilsinhtml = " target=" + Chr(34) + "_blank" + Chr(34)
                Else
                    nerdeacilsinhtml = ""
                End If

                donecek = donecek + _
                "<li id=" + Chr(34) + itemmenu.idismi + Chr(34) + eklenecekclass + ">" + System.Environment.NewLine + _
                "<a" + nerdeacilsinhtml + " href=" + Chr(34) + itemmenu.link + Chr(34) + ">" + System.Environment.NewLine + _
                "<i class=" + Chr(34) + itemmenu.iconclass + Chr(34) + "></i>" + System.Environment.NewLine + _
                "<span class=" + Chr(34) + "title" + Chr(34) + ">" + System.Environment.NewLine + _
                itemmenu.baslik + System.Environment.NewLine + _
                "</span>" + System.Environment.NewLine + _
                eklenecek + System.Environment.NewLine + _
                itemmenu.ekhtml + System.Environment.NewLine + _
                "</a>" + System.Environment.NewLine + _
                submenuolustur(submenuler) + _
                "</li>" + System.Environment.NewLine

            End If

        Next

        Return donecek

    End Function

    Function submenuolustur(ByVal altmenuler As List(Of CLASSMENU)) As String

        Dim donecek, donecekbas, donecekorta, donecekson As String
        donecekbas = "<ul class=" + Chr(34) + "sub-menu" + Chr(34) + ">" + System.Environment.NewLine

        Dim kullanici_rolpkey As String
        kullanici_rolpkey = HttpContext.Current.Session("kullanici_rolpkey")
        Dim nerdeacilsinhtml As String

        For Each itemaltmenu As CLASSMENU In altmenuler
            'yetkililer içinde dolaş

            '----------------------------------------------------------------------
            If itemaltmenu.neredeacilsin = "Yeni Sayfada" Then
                nerdeacilsinhtml = " target=" + Chr(34) + "_blank" + Chr(34)
            Else
                nerdeacilsinhtml = ""
            End If

            If menuyetkilimi(itemaltmenu, kullanici_rolpkey) = "Evet" Then

                donecekorta = donecekorta + "<li id=" + Chr(34) + itemaltmenu.idismi + Chr(34) + ">" + System.Environment.NewLine + _
                "<a href=" + Chr(34) + itemaltmenu.link + Chr(34) + nerdeacilsinhtml + ">" + System.Environment.NewLine + _
                "<i class=" + Chr(34) + itemaltmenu.iconclass + Chr(34) + "></i>" + System.Environment.NewLine + _
                itemaltmenu.ekhtml + System.Environment.NewLine + _
                itemaltmenu.baslik + System.Environment.NewLine + _
                "</a>" + System.Environment.NewLine + _
                "</li>"

            End If
        Next

        donecekson = "</ul>" + System.Environment.NewLine

        If altmenuler.Count > 0 Then
            donecek = donecekbas + donecekorta + donecekson
        Else
            donecek = ""
        End If

        Return donecek

    End Function


    '---  -------------------------------------------------------
    Function menuyetkilimi(ByVal menu As CLASSMENU, ByVal kullanicirolpkey As Integer) As String

        Dim deger As String

        If menu.herzamangozuksunmu = "Evet" Then
            deger = "Evet"
            Return deger
        End If

        If helpermenuyetkilimi(menu.pkey, kullanicirolpkey) = "Evet" Then
            deger = "Evet"
            Return deger
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select " + menu.hakkolon + " from kullanicirol where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirolpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item(menu.hakkolon) Is System.DBNull.Value Then
                    deger = veri.Item(menu.hakkolon)
                End If

            End While
        End Using
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return deger

    End Function


    Public Function helpermenuyetkilimi(ByVal menupkey As String, ByVal kullanicirolpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim deger As String

        sqlstr = "select * from menu,tmodul,yetki where menu.pkey=@menupkey " + _
        "and tmodul.pkey=menu.modulpkey and yetki.kullanicirolpkey=@kullanicirolpkey " + _
        "and yetki.tmodulpkey=tmodul.pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@menupkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = menupkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@kullanicirolpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = kullanicirolpkey
        komut.Parameters.Add(param2)


        Dim insertyetki, updateyetki, deleteyetki, readyetki As String

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("insertyetki") Is System.DBNull.Value Then
                    insertyetki = veri.Item("insertyetki")
                End If

                If Not veri.Item("updateyetki") Is System.DBNull.Value Then
                    updateyetki = veri.Item("updateyetki")
                End If

                If Not veri.Item("deleteyetki") Is System.DBNull.Value Then
                    deleteyetki = veri.Item("deleteyetki")
                End If

                If Not veri.Item("readyetki") Is System.DBNull.Value Then
                    readyetki = veri.Item("readyetki")
                End If

            End While
        End Using

        If insertyetki = "Evet" Or updateyetki = "Evet" Or deleteyetki = "Evet" Or readyetki = "Evet" Then
            deger = "Evet"
        Else
            deger = "Hayır"
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return deger

    End Function


    Function siralamagosterrecursive(ByVal anamenupkey As Integer, ByVal pkey As Integer) As String

        Dim istring, sqls As String
        Dim baslik As String
        Dim solhtml As String
        Dim hepsi, link As String
        Dim x As System.DBNull

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim db_baglanti As SqlConnection

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim girdi As Integer

        girdi = 0

        Dim sabitbas As String
        Dim sabitson As String

        sqls = "select * from menu where anamenupkey=" + CStr(anamenupkey) + _
        " and babaid=" + CStr(pkey) + " order by sira"
        komut = New SqlCommand(sqls, db_baglanti)

        veri = komut.ExecuteReader
        solhtml = ""

        While veri.Read()
            girdi = 1

            If Not veri.Item("anamenupkey") Is x.Value Then
                anamenupkey = veri.Item("anamenupkey")
            End If

            If Not veri.Item("pkey") Is x.Value Then
                pkey = veri.Item("pkey")
            End If

            If Not veri.Item("baslik") Is x.Value Then
                baslik = veri.Item("baslik")
                solhtml = solhtml + "<li id=" + CStr(pkey) + "><a href=#>" + baslik + "</a>"
            End If

            solhtml = solhtml + siralamagosterrecursive(anamenupkey, pkey)

            solhtml = solhtml + "</li>"

        End While '1. loop

        If girdi = 1 Then
            sabitbas = "<ul class=sortable>"
            sabitson = "</ul>"
        End If


        db_baglanti.Close()
        db_baglanti.Dispose()

        hepsi = hepsi + sabitbas + solhtml + sabitson

        Return hepsi
    End Function


    Public Function siralamayap(ByVal anamenupkey As Integer, ByVal degerler As String) As String

        Dim sqlstr As String
        Dim i As String
        Dim x As Integer
        Dim varmi As Integer

        varmi = InStr(degerler, ",", CompareMethod.Text)
        Dim words As String() = degerler.Split(New Char() {","c})

        Dim kactane As String = kactanevar(anamenupkey)

        Dim siralar(kactane) As String

        i = 0
        Dim word As String
        For Each word In words
            siralar(i) = word
            i = i + 1
        Next

        Dim istring As String
        Dim db_baglanti As SqlConnection
        Dim db_baglanti2 As SqlConnection

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        db_baglanti2 = New SqlConnection(istring)
        db_baglanti2.Open()

        Dim komut As SqlCommand
        Dim komut2 As SqlCommand
        Dim veri As SqlDataReader
        Dim pkey, baslik, sira As String
        Dim str As String

        sqlstr = "select * from menu where babaid=0 " + _
        " order by sira"

        komut = New SqlCommand(sqlstr, db_baglanti)
        veri = komut.ExecuteReader

        x = 0

        For Each word In words

            sqlstr = "update menu set " + _
            "sira=@sira" + _
            " where pkey=@pkey"

            komut2 = New SqlCommand(sqlstr, db_baglanti2)

            komut2.Parameters.Add("@sira", SqlDbType.Int)
            komut2.Parameters("@sira").Value = x

            komut2.Parameters.Add("@pkey", SqlDbType.Int)
            komut2.Parameters("@pkey").Value = word

            komut2.ExecuteNonQuery()
            x = x + 1

        Next

        db_baglanti.Close()
        db_baglanti2.Close()

    End Function



    Private Function kactanevar(ByVal anamenupkey As Integer) As Integer

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from menu where anamenupkey=@anamenupkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = anamenupkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kactane = 0
        Else
            kactane = maxkayit1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kactane

    End Function


    Function anamenuvarmi(ByVal anamenupkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from menu where anamenupkey=@anamenupkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = anamenupkey
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


