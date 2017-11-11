Public Class CLASSJAVASCRIPT

    Function listele_datatable() As String

        Dim donecek As String

        donecek = "<script>" + _
        "jQuery(document).ready(function() {" + _
        "TableManaged.init();" + _
        "getfancy();" + _
        "$('.button').button();" + _
        "});" + _
        "</script>"

        Return donecek

    End Function

    'tip success,danger,warning,info
    'icon warning,check,user
    Function alert(ByVal mesaj As String, ByVal tip As String, _
    ByVal saniye As Integer, ByVal icon As String) As String

        Dim donecek As String

        donecek = "<script>" + _
        "jQuery(document).ready(function() {" + _
          "App.alert({" + _
            "container: '#validationresult', " + _
            "place: 'prepend'," + _
            "type: '" + tip + "'," + _
            "message: '" + Replace(mesaj, "'", "") + "'," + _
            "closeInSeconds:" + CStr(saniye) + "," + _
            "icon: '" + icon + "'" + _
          "});" + _
        "});" + _
        "</script>"

        Return donecek

    End Function


    'tip success,danger,warning,info
    'icon warning,check,user
    Function alert_istedigimyere(ByVal divid As String, ByVal mesaj As String, _
    ByVal tip As String, ByVal saniye As Integer, ByVal icon As String) As String

        Dim donecek As String

        donecek = "<script>" + _
        "jQuery(document).ready(function() {" + _
        "App.alert({" + _
          "container: '#" + divid + "', " + _
          "place: 'append'," + _
          "type: '" + tip + "'," + _
          "message: '" + Replace(mesaj, "'", "") + "'," + _
          "close: '" + "1" + "'," + _
          "closeInSeconds:" + CStr(saniye) + "," + _
          "icon: '" + icon + "'" + _
        "});" + _
      "});" + _
      "</script>"

        Return donecek

    End Function




    'tip success,danger,warning,info
    'icon warning,check,user
    Function alertresult(ByVal result As CLADBOPRESULT) As String

        Dim donecek As String

        If result.durum = "Kaydedildi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#validationresult', " + _
                "place: 'prepend'," + _
                "type: 'success'," + _
                "message: '" + result.durum + "'," + _
                "icon: 'check'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        If result.durum = "Kayıt yapılamadı." Or result.durum = "Kaydedilmedi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#validationresult', " + _
                "place: 'prepend'," + _
                "type: 'danger'," + _
                "message: '" + Replace(result.hatastr, "'", "'") + "'," + _
                "icon: 'warning'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        Return donecek

    End Function


    'tip success,danger,warning,info
    'icon warning,check,user
    Function alertresultmail(ByVal result As CLADBOPRESULT) As String

        Dim donecek As String

        If result.durum = "Kaydedildi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#validationresult2', " + _
                "place: 'prepend'," + _
                "type: 'success'," + _
                "message: '" + "E-Posta Gönderildi." + "'," + _
                "icon: 'check'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        If result.durum = "Kayıt yapılamadı." Or result.durum = "Kaydedilmedi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#validationresult2', " + _
                "place: 'prepend'," + _
                "type: 'danger'," + _
                "message: '" + Replace(result.hatastr, "'", "'") + "'," + _
                "icon: 'warning'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        Return donecek

    End Function

    Function editbuttonyarat(ByVal url As String)

        Dim donecek As String

        donecek = "<a href='" + url + "' class='btn yellow'>" + _
        "<i class='fa fa-pencil'></i> Düzenle" + _
        "</a>"

        Return donecek

    End Function

    Function editbuttonyaratozel(ByVal url As String, ByVal label As String)

        Dim donecek As String

        donecek = "<a href='" + url + "' class='btn yellow'>" + _
        "<i class='fa fa-pencil'></i> " + label + _
        "</a>"

        Return donecek

    End Function


    Function yetkibuttonyarat(ByVal url As String)

        Dim donecek As String

        donecek = "<a id='iframeyenikayit' href='" + url + "' class='btn red'>" + _
        "<i class='fa fa-gavel'></i> Yetkiler" + _
        "</a>"

        Return donecek

    End Function

    Function yetkibuttonyaratozel(ByVal url As String, ByVal label As String)

        Dim donecek As String

        donecek = "<a id='iframeyenikayit' href='" + url + "' class='btn red'>" + _
        "<i class='fa fa-gavel'></i> " + label + _
        "</a>"

        Return donecek

    End Function


    'tip success,danger,warning,info
    'icon warning,check,user
    Function alertresult_istedigimyere(ByVal divid As String, ByVal result As CLADBOPRESULT) As String

        Dim donecek As String

        If result.durum = "Kaydedildi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#" + divid + "', " + _
                "place: 'prepend'," + _
                "type: 'success'," + _
                "message: '" + result.durum + "'," + _
                "icon: 'check'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        If result.durum = "Kayıt yapılamadı." Or result.durum = "Kaydedilmedi" Then
            donecek = "<script>" + _
            "jQuery(document).ready(function() {" + _
              "App.alert({" + _
                "container: '#" + divid + "', " + _
                "place: 'prepend'," + _
                "type: 'danger'," + _
                "message: '" + Replace(result.hatastr, "'", "'") + "'," + _
                "icon: 'warning'" + _
            "});" + _
            "});" + _
            "</script>"
        End If

        Return donecek

    End Function




    Function buttonyaratozel(ByVal renk As String, ByVal icon As String, ByVal url As String, ByVal label As String)

        Dim donecek As String

        donecek = "<a href='" + url + "' class='btn " + renk + "'>" + _
        "<i class='" + icon + "'></i> " + label + _
        "</a>"

        Return donecek

    End Function


    Function menuaktiflestir() As String

        Dim menu As New CLASSMENU
        Dim menu_erisim As New CLASSMENU_ERISIM


        Dim idbaba, id As String
        Dim sayfaad As String
        Dim sys_erisim As New CLASSSYS_ERISIM

        sayfaad = sys_erisim.GetCurrentPageName()
        menu = menu_erisim.bulsayfaadagore(sayfaad)

        If Len(menu.idismi) = 3 Then
            idbaba = Mid(menu.idismi, 1, 2)
        Else
            idbaba = Mid(menu.idismi, 1, 1)
        End If
        id = menu.idismi


        Dim donecek As String

        donecek = "<script>" + _
        "jQuery(document).ready(function() {" + _
            "$('#" + idbaba + "').addClass('active');" + _
            "$('#" + id + "').addClass('active');" + _
        "});" + _
        "</script>"


        Return donecek

    End Function

    Public Function GetCurrentPageName()

        Dim stpath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As System.IO.FileInfo
        oInfo = New System.IO.FileInfo(stpath)
        Dim sRet As String = oInfo.Name
        Return sRet

    End Function


End Class
