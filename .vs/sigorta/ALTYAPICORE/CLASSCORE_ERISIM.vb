Public Class CLASSCORE_ERISIM

    Public Function sifirlariat_kullanilmiyor(ByVal str As String) As String

        Dim sifirsiz As String = str
        Dim uzunluk As Integer
        uzunluk = str.Length

        For i = 1 To uzunluk
            If Mid(str, i, 1) = "0" Then
                sifirsiz = Mid(str, i + 1)
            Else
                Exit For
            End If
        Next

        Return sifirsiz

    End Function

End Class
