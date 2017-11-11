Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel


<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class genericservice
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function genericservis(ByVal username As String, ByVal password As String, _
    ByVal servicecode As String, ByVal xmlparams As String) As String


        Dim genericservis_erisim As New CLASSGENERICSERVIS_ERISIM
        Return genericservis_erisim.calistir(username, password, servicecode, xmlparams)

    End Function

End Class