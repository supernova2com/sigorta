Public Class CLASSREMINDERSETTING

    Private pkey_v As Integer
    Private reminder_name_v As String
    Private reminder_schedule_minute_v As String
    Private reminder_schedule_hour_v As String
    Private reminder_schedule_day_of_month_v As String
    Private reminder_schedule_month_v As String
    Private reminder_schedule_weekday_v As String
    Private reminder_schedule_end_date_v As DateTime
    Private reminder_status_v As String
    Private reminder_date_added_v As DateTime
    Private ayinsongunucalissinmi_v As String


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal reminder_name As String, ByVal reminder_schedule_minute As String, _
    ByVal reminder_schedule_hour As String, ByVal reminder_schedule_day_of_month As String, ByVal reminder_schedule_month As String, _
    ByVal reminder_schedule_weekday As String, ByVal reminder_schedule_end_date As DateTime, ByVal reminder_status As String, _
    ByVal reminder_date_added As DateTime, ByVal ayinsongunucalissinmi As String)


        Me.pkey = pkey
        Me.reminder_name = reminder_name
        Me.reminder_schedule_minute = reminder_schedule_minute
        Me.reminder_schedule_hour = reminder_schedule_hour
        Me.reminder_schedule_day_of_month = reminder_schedule_day_of_month
        Me.reminder_schedule_month = reminder_schedule_month
        Me.reminder_schedule_weekday = reminder_schedule_weekday
        Me.reminder_schedule_end_date = reminder_schedule_end_date
        Me.reminder_status = reminder_status
        Me.reminder_date_added = reminder_date_added
        Me.ayinsongunucalissinmi = ayinsongunucalissinmi

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property reminder_name() As String
        Get
            Return reminder_name_v
        End Get
        Set(ByVal value As String)
            reminder_name_v = value
        End Set
    End Property


    Public Property reminder_schedule_minute() As String
        Get
            Return reminder_schedule_minute_v
        End Get
        Set(ByVal value As String)
            reminder_schedule_minute_v = value
        End Set
    End Property


    Public Property reminder_schedule_hour() As String
        Get
            Return reminder_schedule_hour_v
        End Get
        Set(ByVal value As String)
            reminder_schedule_hour_v = value
        End Set
    End Property


    Public Property reminder_schedule_day_of_month() As String
        Get
            Return reminder_schedule_day_of_month_v
        End Get
        Set(ByVal value As String)
            reminder_schedule_day_of_month_v = value
        End Set
    End Property


    Public Property reminder_schedule_month() As String
        Get
            Return reminder_schedule_month_v
        End Get
        Set(ByVal value As String)
            reminder_schedule_month_v = value
        End Set
    End Property


    Public Property reminder_schedule_weekday() As String
        Get
            Return reminder_schedule_weekday_v
        End Get
        Set(ByVal value As String)
            reminder_schedule_weekday_v = value
        End Set
    End Property


    Public Property reminder_schedule_end_date() As Nullable(Of DateTime)
        Get
            Return reminder_schedule_end_date_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            reminder_schedule_end_date_v = value
        End Set
    End Property


    Public Property reminder_status() As String
        Get
            Return reminder_status_v
        End Get
        Set(ByVal value As String)
            reminder_status_v = value
        End Set
    End Property


    Public Property reminder_date_added() As Nullable(Of DateTime)
        Get
            Return reminder_date_added_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            reminder_date_added_v = value
        End Set
    End Property


    Public Property ayinsongunucalissinmi() As String
        Get
            Return ayinsongunucalissinmi_v
        End Get
        Set(ByVal value As String)
            ayinsongunucalissinmi_v = value
        End Set
    End Property

End Class


