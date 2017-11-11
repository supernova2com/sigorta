Imports System.Net

Public Class CLASSIP_ERISIM

    Public Function ipadresibul() As String

        Dim visitoripaddress As String
        If HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR") <> Nothing Then
            visitoripaddress = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString()
            Return visitoripaddress
        Else
            If (HttpContext.Current.Request.UserHostAddress.Length <> 0) Then
                visitoripaddress = HttpContext.Current.Request.UserHostAddress
                Return visitoripaddress
            End If
        End If

    End Function


    Public Function balangicbitisvemaskbul(ByVal cidrnotation As Integer, ByVal checkip As IPAddress) As Hashtable

        Dim ht As New Hashtable

        Dim ip As IPAddress = checkip
        Dim bits As Integer = cidrnotation
        Dim mask As UInteger = Not (UInteger.MaxValue >> bits)
        Dim ipBytes() As Byte = ip.GetAddressBytes()
        Dim maskBytes() As Byte = BitConverter.GetBytes(mask).Reverse().ToArray()
        Dim startIPBytes(ipBytes.Length - 1) As Byte
        Dim endIPBytes(ipBytes.Length - 1) As Byte

        For i As Integer = 0 To ipBytes.Length - 1
            startIPBytes(i) = CByte(ipBytes(i) And maskBytes(i))
            endIPBytes(i) = CByte(ipBytes(i) Or (Not maskBytes(i)))
        Next i

        ' You can remove first and last (Network and Broadcast) here if desired
        Dim startIP As New IPAddress(startIPBytes)
        Dim endIP As New IPAddress(endIPBytes)
        Dim maskx As String
        maskx = maskBytes(0).ToString & "." & maskBytes(1).ToString & "." & maskBytes(2).ToString & "." & maskBytes(3).ToString

        If bits = 32 Then
            startIP = ip
            endIP = ip
            maskx = "255.255.255.255"
        End If

        ht.Add(1, startIP.ToString)
        ht.Add(2, endIP.ToString)
        ht.Add(3, maskx)
        Return ht

    End Function





    Public Function range(ByVal cidrnotation As Integer, ByVal ip As IPAddress, _
        ByVal checkip As IPAddress) As String

        Dim donecek As String

        If HttpContext.Current.Request.IsLocal Then
            Return "Evet"
        End If

        Dim ipler As New List(Of IPAddress)

        Dim ht As New Hashtable

        Dim bits As Integer = cidrnotation
        Dim mask As UInteger = Not (UInteger.MaxValue >> bits)
        Dim ipBytes() As Byte = ip.GetAddressBytes()
        Dim maskBytes() As Byte = BitConverter.GetBytes(mask).Reverse().ToArray()
        Dim startIPBytes(ipBytes.Length - 1) As Byte
        Dim endIPBytes(ipBytes.Length - 1) As Byte

        For i As Integer = 0 To ipBytes.Length - 1
            startIPBytes(i) = CByte(ipBytes(i) And maskBytes(i))
            endIPBytes(i) = CByte(ipBytes(i) Or (Not maskBytes(i)))
        Next i

        ' You can remove first and last (Network and Broadcast) here if desired
        Dim startIP As New IPAddress(startIPBytes)
        Dim endIP As New IPAddress(endIPBytes)

        If bits = 32 Then
            startIP = ip
            endIP = ip
        End If

        Dim rangeStart As Net.IPAddress = startIP
        Dim rangeEnd As Net.IPAddress = endIP
        Dim check As Net.IPAddress = checkip

        'get the bytes of the address
        Dim rbs() As Byte = rangeStart.GetAddressBytes
        Dim rbe() As Byte = rangeEnd.GetAddressBytes
        Dim cb() As Byte = check.GetAddressBytes

        'reverse them for conversion
        Array.Reverse(rbs)
        Array.Reverse(rbe)
        Array.Reverse(cb)

        'convert them
        Dim rs As UInt32 = BitConverter.ToUInt32(rbs, 0)
        Dim re As UInt32 = BitConverter.ToUInt32(rbe, 0)
        Dim chk As UInt32 = BitConverter.ToUInt32(cb, 0)

        'check
        If chk >= rs AndAlso chk <= re Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If


        Return donecek

    End Function




End Class
