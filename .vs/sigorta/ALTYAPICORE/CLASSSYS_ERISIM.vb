Imports System
Imports System.Management

Public Class CLASSSYS_ERISIM

    Public Function GetCurrentPageName()

        Dim stpath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As System.IO.FileInfo
        oInfo = New System.IO.FileInfo(stpath)
        Dim sRet As String = oInfo.Name
        Return sRet

    End Function

    Public Function SistemBilgi() As String

        Dim donecek As String

        ' Build an options object for the remote connection 
        ' if you plan to connect to the remote 
        ' computer with a different user name 
        ' and password than the one you are currently using 
        Dim options As ConnectionOptions
        options = New ConnectionOptions

        ' Make a connection to a remote computer. 
        ' Replace the "FullComputerName" section of the 
        ' string "\\FullComputerName\root\cimv2" with 
        ' the full computer name or IP address of the 
        ' remote computer. 
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\server2008\root\cimv2", options)
        scope.Connect()

        ' Query system for Operating System information 
        Dim query1 As ObjectQuery
        query1 = New ObjectQuery("SELECT * FROM Win32_OperatingSystem")
        Dim searcher1 As ManagementObjectSearcher
        searcher1 = New ManagementObjectSearcher(scope, query1)
        Dim queryCollection1 As ManagementObjectCollection
        queryCollection1 = searcher1.Get()

        For Each m In queryCollection1
            ' Display the remote computer information
            donecek = "Bilgisayar Adı: " + "<b>" + m("csname") + "</b><br/>" + _
            "Windows Directory: " + "<b>" + m("WindowsDirectory") + "</b><br/>" + _
            "İşletim Sistemi: " + "<b>" + m("Caption") + "</b><br/>" + _
            "Versiyon: " + "<b>" + m("Version") + "</b><br/>" + _
            "Üretici: " + "<b>" + m("Manufacturer") + "</b><br/>" + _
            "--------------------------------------------------<br/>"
        Next

        Return donecek

    End Function


    Public Function DiskBilgi(ByVal Name As String) As String

        Dim donecek As String

        ' Build an options object for the remote connection 
        ' if you plan to connect to the remote 
        ' computer with a different user name 
        ' and password than the one you are currently using 
        Dim options As ConnectionOptions
        options = New ConnectionOptions

        ' Make a connection to a remote computer. 
        ' Replace the "FullComputerName" section of the 
        ' string "\\FullComputerName\root\cimv2" with 
        ' the full computer name or IP address of the 
        ' remote computer. 
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\server2008\root\cimv2", options)
        scope.Connect()


        ' Query for Disk Information
        Dim query2 As ObjectQuery
        query2 = New ObjectQuery("Select * from Win32_LogicalDisk")
        Dim searcher2 As ManagementObjectSearcher
        searcher2 = New ManagementObjectSearcher(scope, query2)
        Dim queryCollection2 As ManagementObjectCollection
        queryCollection2 = searcher2.Get()

        For Each mo In queryCollection2
            ' Display Logical Disks information

            If mo("Name") = Name Then

                donecek = donecek + _
                "Disk Sürücü: " + "<b>" + mo("Name") + "</b><br/>" + _
                "Disk Boyutu: " + "<b>" + Format(gbcevir(mo("Size")), "0.00") + " GB" + "</b><br/>" + _
                "Kullanılan: " + "<b>" + Format(gbcevir(mo("Size")) - gbcevir(mo("FreeSpace")), "0.00") + " GB" + "</b><br/>" + _
                "Kalan Disk: " + "<b>" + Format(gbcevir(mo("FreeSpace")), "0.00") + " GB" + "</b><br/>" + _
                "Disk Adı: " + "<b>" + mo("VolumeName") + "</b><br/>"

            End If
        Next

        Return donecek

    End Function


    Public Function sistemdiskdoldur() As List(Of CLASSDISK)

        Dim diskler As New List(Of CLASSDISK)

        Dim options As ConnectionOptions
        options = New ConnectionOptions
        ' remote computer. 
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\server2008\root\cimv2", options)
        scope.Connect()


        ' Query for Disk Information
        Dim query2 As ObjectQuery
        query2 = New ObjectQuery("Select * from Win32_LogicalDisk")
        Dim searcher2 As ManagementObjectSearcher
        searcher2 = New ManagementObjectSearcher(scope, query2)
        Dim queryCollection2 As ManagementObjectCollection
        queryCollection2 = searcher2.Get()

        For Each mo In queryCollection2

            Dim disk As New CLASSDISK
            disk.diskad = mo("Name")
            disk.kapasite = mo("Size")
            disk.kullanilan = mo("Size") - mo("FreeSpace")
            disk.kalan = mo("FreeSpace")
            disk.surucu = mo("VolumeName")

            diskler.Add(New CLASSDISK(disk.surucu, disk.kapasite, disk.kullanilan, disk.kalan, _
            disk.diskad))

        Next

        Return diskler

    End Function


    Public Function ilgilidiskbilgilerinigetir(ByVal Name As String) As CLASSDISK

        Dim disk As New CLASSDISK

        Dim options As ConnectionOptions
        options = New ConnectionOptions
        ' remote computer. 
        Dim scope As ManagementScope
        scope = New ManagementScope( _
            "\\server2008\root\cimv2", options)
        scope.Connect()


        ' Query for Disk Information
        Dim query2 As ObjectQuery
        query2 = New ObjectQuery("Select * from Win32_LogicalDisk")
        Dim searcher2 As ManagementObjectSearcher
        searcher2 = New ManagementObjectSearcher(scope, query2)
        Dim queryCollection2 As ManagementObjectCollection
        queryCollection2 = searcher2.Get()

        For Each mo In queryCollection2

            If mo("Name") = Name Then
                disk.diskad = mo("Name")
                disk.kapasite = mo("Size")
                disk.kullanilan = mo("Size") - mo("FreeSpace")
                disk.kalan = mo("FreeSpace")
                disk.surucu = mo("VolumeName")
            End If

        Next

        Return disk

    End Function



    Public Function gbcevir(ByVal deger As Decimal) As Decimal

        Return deger / 1000000000

    End Function


    Public Function grafikdata(ByVal surucu As String) As List(Of CLASSGRAFIKBILGIDECIMAL)

        Dim disk As New CLASSDISK
        disk = ilgilidiskbilgilerinigetir(surucu)

        Dim donecekgrafikbilgi As New CLASSGRAFIKBILGIDECIMAL
        Dim donecekgrafikbilgiler As New List(Of CLASSGRAFIKBILGIDECIMAL)

        'KULLANILAN EKLE
        donecekgrafikbilgi.seriad = "Kullanılan"
        donecekgrafikbilgi.sayi = Math.Round(gbcevir(disk.kullanilan), 2)
        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGIDECIMAL(donecekgrafikbilgi.seriad, _
        donecekgrafikbilgi.sayi))

        'KALAN EKLE
        donecekgrafikbilgi.seriad = "Kalan"
        donecekgrafikbilgi.sayi = Math.Round(gbcevir(disk.kalan), 2)
        donecekgrafikbilgiler.Add(New CLASSGRAFIKBILGIDECIMAL(donecekgrafikbilgi.seriad, _
        donecekgrafikbilgi.sayi))


        Return donecekgrafikbilgiler

    End Function


End Class
