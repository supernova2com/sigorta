Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSMENU2_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim menu As New CLASSMENU
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

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

    '---  -------------------------------------------------------
    Public Function menuyetkilimi(ByVal anamenupkey As String, _
    ByVal menupkey As String, ByVal kullanicirolpkey As String) As String

        Dim donecek As String = "Hayır"

        Dim menu As New CLASSMENU
        Dim menu_Erisim As New CLASSMENU_ERISIM

        menu = menu_Erisim.bultek(menupkey)

        'BU MENU BAŞLIKSA
        If menu.baslikmi = "Evet" Then
            Dim altmenuler As New List(Of CLASSMENU)
            altmenuler = menu_Erisim.doldurilgilibabaninaltindakiler(menupkey, anamenupkey)
            For Each itemmenu As CLASSMENU In altmenuler
                If helpermenuyetkilimi(itemmenu.pkey, kullanicirolpkey) = "Evet" Then
                    donecek = "Evet"
                    Exit For
                End If
            Next
            If helpermenuyetkilimi(menupkey, kullanicirolpkey) = "Evet" Then
                donecek = "Evet"
            End If
        End If


        'BU MENU BAŞLIK DEĞİLSE
        If menu.baslikmi = "Hayır" Then
            If helpermenuyetkilimi(menupkey, kullanicirolpkey) = "Evet" Then
                donecek = "Evet"
            Else
                donecek = "Hayır"
            End If
        End If

        If menu.herzamangozuksunmu = "Evet" Then
            donecek = "Evet"
        End If


        Return donecek

    End Function


    Public Function helpermenuyetkilimi(ByVal menupkey As String, ByVal kullanicirolpkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim deger As String

        sqlstr = "select * from menu,tmodul,yetkibilgi where menu.pkey=@menupkey " + _
        "and tmodul.pkey=menu.modulpkey and yetkibilgi.kullanicirolpkey=@kullanicirolpkey " + _
        "and yetkibilgi.tmodulpkey=tmodul.pkey"

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


    Function menuyuolustur() As String

        Dim eklenecek As String = ""
        Dim eklenecekclass As String = ""
        Dim donecek As String = ""

        Dim webuyerolpkey As String
        Dim kullanicirolbilgi As New CLASSKULLANICIROLBILGI
        Dim kullanicirolbilgi_erisim As New CLASSKULLANICIROLBILGI_ERISIM
        Dim anamenupkey As String

        Dim menuler As New List(Of CLASSMENU)
        Dim submenuler As New List(Of CLASSMENU)
        Dim nerdeacilsinhtml As String

        webuyerolpkey = HttpContext.Current.Session("webuye_rolpkey")
        kullanicirolbilgi = kullanicirolbilgi_erisim.bultek(webuyerolpkey)
        anamenupkey = kullanicirolbilgi.anamenupkey
        menuler = doldursadecebaba(anamenupkey)


        'SADECE BABALARI DOLDURDUK--------------------------------------------------------------------
        For Each itemmenu As CLASSMENU In menuler

            'yetkililer içinde dolaş
            If menuyetkilimi(anamenupkey, itemmenu.pkey, webuyerolpkey) = "Evet" Then

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

        Dim webuyerolpkey As String
        webuyerolpkey = HttpContext.Current.Session("webuye_rolpkey")
        Dim nerdeacilsinhtml As String

        For Each itemaltmenu As CLASSMENU In altmenuler
            'yetkiler içinde dolaş
            '----------------------------------------------------------------------
            If itemaltmenu.neredeacilsin = "Yeni Sayfada" Then
                nerdeacilsinhtml = " target=" + Chr(34) + "_blank" + Chr(34)
            Else
                nerdeacilsinhtml = ""
            End If

            If menuyetkilimi(itemaltmenu.babaid, itemaltmenu.pkey, webuyerolpkey) = "Evet" Then

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


End Class
