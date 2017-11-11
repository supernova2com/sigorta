Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class dinamikraporservis1
    Inherits System.Web.Services.WebService



    <WebMethod(EnableSession:=True)> _
    Public Function raporla() As String


        Dim backservislog_erisim As New CLASSBACKSERVISLOG_ERISIM
        backservislog_erisim.raporla()

        Dim manuelrapor_erisim As New CLASSMANUELRAPOR_ERISIM
        manuelrapor_erisim.calistir()



    End Function

End Class