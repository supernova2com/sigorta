﻿Public Class CLASSTARIFESINIRKAPIBAG

    Private pkey_v As Integer
    Private aractarifepkey_v As Integer
    Private sinirkapiaractippkey_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal aractarifepkey As Integer, ByVal sinirkapiaractippkey As Integer)


        Me.pkey = pkey
        Me.aractarifepkey = aractarifepkey
        Me.sinirkapiaractippkey = sinirkapiaractippkey

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property aractarifepkey() As Integer
        Get
            Return aractarifepkey_v
        End Get
        Set(ByVal value As Integer)
            aractarifepkey_v = value
        End Set
    End Property


    Public Property sinirkapiaractippkey() As Integer
        Get
            Return sinirkapiaractippkey_v
        End Get
        Set(ByVal value As Integer)
            sinirkapiaractippkey_v = value
        End Set
    End Property



End Class
