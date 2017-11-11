Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs


        Dim errorlog As New CLASSERRORLOG
        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM
        Dim kullanicipkey As Integer

        Try
            If Not HttpContext.Current.Session("kullanici_pkey") Is Nothing Then
                kullanicipkey = HttpContext.Current.Session("kullanici_pkey")
            Else
                kullanicipkey = 0
            End If
        Catch ex As Exception
            kullanicipkey = 0
        End Try


        errorlog.kullanicipkey = kullanicipkey
        errorlog.tarih = DateTime.Now

        Dim uri As String = ""
        If (Not HttpContext.Current Is Nothing) Then
            uri = HttpContext.Current.Request.Url.ToString
        End If

        ' Get the exception object.
        Dim exc As Exception = Server.GetLastError
        Dim exp_msg As String
        Dim exp_source As String
        Dim exp_stacktrace As String

        Try
            exp_msg = exc.InnerException.Message
            exp_source = exc.InnerException.Source
            exp_stacktrace = exc.InnerException.StackTrace
        Catch ex As Exception
            exp_msg = ""
            exp_source = ""
            exp_stacktrace = ""
        End Try

        errorlog.exp_msg = exp_msg
        errorlog.exp_source = exp_source
        errorlog.exp_stacktrace = exp_stacktrace
        errorlog.exp_url = uri
        errorlog.emailgonderilmismi = "Hayır"
        errorlog.okunmusmu = "Hayır"

        errorlog_erisim.Ekle(errorlog)

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class