Public Class CLASSKAZATARIH_ERISIM


    'KAZA TARİHİ VAR MI?
    Function butarihvarmi(ByVal kazalar As List(Of CLASSKAZATARIH), ByVal kazatarih As Date) As String

        Dim varmi As String = "Hayır"

        For Each item In kazalar
            If item.kazatarih = kazatarih Then
                varmi = "Evet"
            End If
        Next

        Return varmi

    End Function

End Class
