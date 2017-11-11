Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports System.Globalization.CultureInfo
Imports System.Globalization
Imports System.Xml
Imports System.Text


Public Class PolicyInfoPolis_Erisim

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim resultset As New CLADBOPRESULT
    Dim x As System.DBNull


    '--- GetInfoInsuredPeople -------------------------------------------------------
    Function GetInfoInsuredPeople(ByVal UserName As String, _
    ByVal Password As String, ByVal VehiclePlate As String) As root

        Dim root As New root
        Dim yetkiresult As New CLADBOPRESULT
        Dim site_erisim As New CLASSSITE_ERISIM

        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        Dim errorinfo As New ErrorInfo
        errorinfo.Code = 0
        errorinfo.Message = ""

        root.ResultCode = 1
        root.ErrorInfo = errorinfo

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim donecekPolicyInfoPolis As New PolicyInfoPolis

        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        'en son poliçeye bak iptali olmayan ve sorgulama tarihi poliçenin 
        'başlangıç ve bitiş tarihleri arasında olsun ve bu poliçe iptal zeyilli olmasın.

        sqlstr = "select PlateNumber,PolicyOwnerName,PolicyOwnerSurname," + _
        "PolicyOwnerIdentityCode,PolicyOwnerIdentityNo,AddressLine1," + _
        "AddressLine2, AddressLine3,StartDate,ZeylCode,EndDate, ArrangeDate = max(ArrangeDate) " + _
        " from PolicyInfo " + _
        " group by PlateNumber,PolicyOwnerName,PolicyOwnerSurname," + _
        " PolicyOwnerIdentityCode,PolicyOwnerIdentityNo,AddressLine1," + _
        " AddressLine2, AddressLine3,StartDate,EndDate,ZeylCode" + _
        " having PlateNumber=@PlateNumber and " + _
        "Convert(DATE,StartDate)<=@sorgulamatarih and " + _
        "Convert(DATE,EndDate)>=@sorgulamatarih and " + _
        "ZeylCode<>'X'"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlateNumber", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = VehiclePlate
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sorgulamatarih", SqlDbType.DateTime)
        param2.Direction = ParameterDirection.Input
        param2.Value = DateTime.Now
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.PlateNumber = veri.Item("PlateNumber")
                End If

                If Not veri.Item("PolicyOwnerName") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.Name = veri.Item("PolicyOwnerName")
                End If

                If Not veri.Item("PolicyOwnerSurname") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.Surname = veri.Item("PolicyOwnerSurname")
                End If

                If Not veri.Item("PolicyOwnerIdentityCode") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.IdentityCode = veri.Item("PolicyOwnerIdentityCode")
                End If

                If Not veri.Item("PolicyOwnerIdentityNo") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.IdentityNo = veri.Item("PolicyOwnerIdentityNo")
                End If

                If Not veri.Item("AddressLine1") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.Address1 = veri.Item("AddressLine1")
                End If

                If Not veri.Item("AddressLine2") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.Address2 = veri.Item("AddressLine2")
                End If

                If Not veri.Item("AddressLine3") Is System.DBNull.Value Then
                    donecekPolicyInfoPolis.Address3 = veri.Item("AddressLine3")
                End If

            End While

        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        root.PolicyInfo = donecekPolicyInfoPolis

        Return root

    End Function
End Class
