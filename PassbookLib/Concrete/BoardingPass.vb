Imports Newtonsoft.Json
Imports System.Dynamic

<DisplayName("boardingPass")>
Public Class BoardingPass
    Implements IPassStyle

    Private _transitType As String
    <JsonProperty("transitType", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property TransitType() As String
        Get
            Return _transitType
        End Get
        Set(ByVal value As String)
            _transitType = value
        End Set
    End Property

    Private _auxiliaryFields As IList(Of ExpandoObject)
    Public Property AuxiliaryFields As System.Collections.Generic.IList(Of ExpandoObject) Implements IPassStyle.AuxiliaryFields
        Get
            Return _auxiliaryFields
        End Get
        Set(value As System.Collections.Generic.IList(Of ExpandoObject))
            _auxiliaryFields = value
        End Set
    End Property

    Private _backFields As IList(Of ExpandoObject)
    Public Property BackFields As System.Collections.Generic.IList(Of ExpandoObject) Implements IPassStyle.BackFields
        Get
            Return _backFields
        End Get
        Set(value As System.Collections.Generic.IList(Of ExpandoObject))
            _backFields = value
        End Set
    End Property

    Private _headerFields As IList(Of ExpandoObject)
    Public Property HeaderFields As System.Collections.Generic.IList(Of ExpandoObject) Implements IPassStyle.HeaderFields
        Get
            Return _headerFields
        End Get
        Set(value As System.Collections.Generic.IList(Of ExpandoObject))
            _headerFields = value
        End Set
    End Property

    Private _primaryFields As IList(Of ExpandoObject)
    Public Property PrimaryFields As System.Collections.Generic.IList(Of ExpandoObject) Implements IPassStyle.PrimaryFields
        Get
            Return _primaryFields
        End Get
        Set(value As System.Collections.Generic.IList(Of ExpandoObject))
            _primaryFields = value
        End Set
    End Property

    Private _secondaryFields As IList(Of ExpandoObject)
    Public Property SecondaryFields As System.Collections.Generic.IList(Of ExpandoObject) Implements IPassStyle.SecondaryFields
        Get
            Return _secondaryFields
        End Get
        Set(value As System.Collections.Generic.IList(Of ExpandoObject))
            _secondaryFields = value
        End Set
    End Property
End Class
