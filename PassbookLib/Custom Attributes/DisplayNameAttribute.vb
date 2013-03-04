<AttributeUsage(AttributeTargets.Class)>
Public Class DisplayNameAttribute
  Inherits Attribute

  Private _name As String
  Public Sub New(name As String)
    Me._name = name
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return Me._name
        End Get
    End Property

End Class
