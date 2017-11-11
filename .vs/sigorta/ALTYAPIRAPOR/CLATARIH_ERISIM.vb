Public Class CLATARIH_ERISIM



    Function bul(ByVal tarihtip As String) As CLATARIH

        Dim tarihdon As New CLATARIH


        If tarihtip = "Halihazırda" Then

            Dim dbaslangic As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.hour, DateTime.Now.Minute, 0)
            Dim dbaslangicr As New DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 0, 0)
            Dim dbitisr As New DateTime
            dbitisr = dbaslangicr.AddHours(24)

            tarihdon.baslangic = dbaslangicr
            tarihdon.bitis = dbitisr

        End If

        If tarihtip = "Bugün" Then

            Dim dbaslangic As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
            Dim dbaslangicr As New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0)
            Dim dbitisr As New DateTime
            dbitisr = dbaslangicr.AddHours(24)

            tarihdon.baslangic = dbaslangicr
            tarihdon.bitis = DateTime.Now

        End If

        If tarihtip = "Dün" Then

            Dim ikigunonce As New DateTime
            Dim birgunonce As New DateTime
            birgunonce = Now.AddDays(-1)
            Dim dbitisr As New DateTime(birgunonce.Year, birgunonce.Month, birgunonce.Day, 0, 0, 0, 0)

            ikigunonce = Now.AddDays(-2)
            Dim dbaslangicr As New DateTime
            dbaslangicr = ikigunonce

            tarihdon.baslangic = ikigunonce
            tarihdon.bitis = dbitisr

        End If


        If tarihtip = "Son 3 gün" Then

            Dim dbaslangic As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
            Dim dbaslangicr As New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0)
            Dim dbitisr As New DateTime
            dbitisr = dbaslangicr.AddDays(-3)

            tarihdon.baslangic = dbitisr
            tarihdon.bitis = DateTime.Now

        End If

        If tarihtip = "Son 1 hafta" Then

            Dim dbaslangic As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
            Dim dbaslangicr As New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0)
            Dim dbitisr As New DateTime
            dbitisr = dbaslangicr.AddDays(-7)

            tarihdon.baslangic = dbitisr
            tarihdon.bitis = DateTime.Now

        End If

        If tarihtip = "Son 1 ay" Then

            Dim dbaslangic As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)
            Dim dbaslangicr As New DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0)
            Dim dbitisr As New DateTime
            dbitisr = dbaslangicr.AddDays(-31)

            tarihdon.baslangic = dbitisr
            tarihdon.bitis = DateTime.Now

        End If


        Return tarihdon

    End Function
End Class
