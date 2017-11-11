Public Partial Class coreservis
    Inherits System.Web.UI.Page


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function diskgrafikdata(ByVal surucu As String) As List(Of CLASSGRAFIKBILGIDECIMAL)

        Dim sys_erisim As New CLASSSYS_ERISIM
        Return sys_erisim.grafikdata(surucu)

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function diskbilgi(ByVal surucu As String) As String

        Dim sys_erisim As New CLASSSYS_ERISIM
        Return sys_erisim.DiskBilgi(surucu)


    End Function




End Class