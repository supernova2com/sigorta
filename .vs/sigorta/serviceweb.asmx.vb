Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Xml
Imports System.Xml.Serialization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://kksbm.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class serviceweb
    Inherits System.Web.Services.WebService


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function TotalPolicyNumber(ByVal UserName As String, _
    ByVal Password As String) As String

        Dim donecek As String = ""
        Dim PolicyInfoServiceWeb_erisim As New PolicyInfoServiceWeb_Erisim
        donecek = PolicyInfoServiceWeb_erisim.TotalPolicyNumber(UserName, Password)
        Return donecek

    End Function


    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function TotalPolicyNumberDate(ByVal UserName As String, _
    ByVal Password As String, ByVal StartDate As String, ByVal EndDate As String) As String

        Dim donecek As String = ""
        Dim PolicyInfoServiceWeb_erisim As New PolicyInfoServiceWeb_Erisim
        donecek = PolicyInfoServiceWeb_erisim.TotalPolicyNumberDate(UserName, Password, StartDate, EndDate)
        Return donecek

    End Function

    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(root))> _
    Public Function TodayPolicyNumber(ByVal UserName As String, _
    ByVal Password As String, ByVal ArrangeDate As String) As String

        Dim donecek As String = ""
        Dim PolicyInfoServiceWeb_erisim As New PolicyInfoServiceWeb_Erisim
        donecek = PolicyInfoServiceWeb_erisim.TodayPolicyNumber(UserName, Password, ArrangeDate)
        Return donecek

    End Function



    <WebMethod()> _
    <System.Xml.Serialization.XmlInclude(GetType(PolicyInfo))> _
    Public Function PolicySearch(ByVal UserName As String, _
    ByVal Password As String, ByVal PlateNumber As String, _
    ByVal IdentityNo As String) As List(Of PolicyInfo)

        Dim bulunanpoliceler As New List(Of PolicyInfo)
        Dim PolicyInfoServiceWeb_erisim As New PolicyInfoServiceWeb_Erisim

        bulunanpoliceler = PolicyInfoServiceWeb_erisim.PolicySearch(UserName, Password, PlateNumber, IdentityNo)
        Return bulunanpoliceler

    End Function

End Class