﻿Public Class CLASSBAZFIYAT

    Private pkey_v As Integer
    Private sirketpkey_v As Integer
    Private baslangictarih_v As DateTime
    Private kayittarih_v As DateTime
    Private kayitno_v As Integer
    Private policetip_v As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal sirketpkey As Integer, ByVal baslangictarih As DateTime, _
    ByVal kayittarih As DateTime, ByVal kayitno As Integer, ByVal policetip As Integer)


        Me.pkey = pkey
        Me.sirketpkey = sirketpkey
        Me.baslangictarih = baslangictarih
        Me.kayittarih = kayittarih
        Me.kayitno = kayitno
        Me.policetip = policetip

    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property sirketpkey() As Integer
        Get
            Return sirketpkey_v
        End Get
        Set(ByVal value As Integer)
            sirketpkey_v = value
        End Set
    End Property


    Public Property baslangictarih() As Nullable(Of DateTime)
        Get
            Return baslangictarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            baslangictarih_v = value
        End Set
    End Property


    Public Property kayittarih() As Nullable(Of DateTime)
        Get
            Return kayittarih_v
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            kayittarih_v = value
        End Set
    End Property


    Public Property kayitno() As Integer
        Get
            Return kayitno_v
        End Get
        Set(ByVal value As Integer)
            kayitno_v = value
        End Set
    End Property


    Public Property policetip() As Integer
        Get
            Return policetip_v
        End Get
        Set(ByVal value As Integer)
            policetip_v = value
        End Set
    End Property



End Class
