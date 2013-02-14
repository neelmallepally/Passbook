Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class Coupon

  Private _AuthenticationToken As String
  Private _BackgroundColor As String
  Private _Barcode As Barcode
  Private _Description As String
  Private _Fields As Dictionary(Of String, Dictionary(Of String, String))
  Private _ForegroundColor As String
  Private _FormatVersion As String
  Private _Images As List(Of Image)
  Private _Locations As List(Of Location)
  Private _LogoText As String
  Private _OrganizationName As String
  Private _PassTypeIdentifier As String
  Private _SerialNumber As String
  Private _TeamIdentifier As String
  Private _WebServiceURL As String

  Public Property AuthenticationToken As String
    Get
      Return _AuthenticationToken
    End Get
    Set(value As String)
      _AuthenticationToken = value
    End Set
  End Property

  Public Property BackgroundColor As String
    Get
      Return _BackgroundColor
    End Get
    Set(value As String)
      _BackgroundColor = value
    End Set
  End Property

  Public Property ForegroundColor As String
    Get
      Return _ForegroundColor
    End Get
    Set(value As String)
      _ForegroundColor = value
    End Set
  End Property

  Public Property Barcode As Barcode
    Get
      Return _Barcode
    End Get
    Set(value As Barcode)
      _Barcode = value
    End Set
  End Property

  Public Property Description As String
    Get
      Return _Description
    End Get
    Set(value As String)
      _Description = value
    End Set
  End Property

  Public Property Fields As Dictionary(Of String, Dictionary(Of String, String))
    Get
      Return _Fields
    End Get
    Set(value As Dictionary(Of String, Dictionary(Of String, String)))
      _Fields = value
    End Set
  End Property

  Public Property FormatVersion As String
    Get
      Return _FormatVersion
    End Get
    Set(value As String)
      _FormatVersion = value
    End Set
  End Property

  Public Property Images As List(Of Image)
    Get
      Return _Images
    End Get
    Set(value As List(Of Image))
      _Images = value
    End Set
  End Property

  Public Property Locations As System.Collections.Generic.List(Of Location)
    Get
      Return _Locations
    End Get
    Set(value As System.Collections.Generic.List(Of Location))
      _Locations = value
    End Set
  End Property

  Public Property LogoText As String
    Get
      Return _LogoText
    End Get
    Set(value As String)
      _LogoText = value
    End Set
  End Property

  Public Property OrganizationName As String
    Get
      Return _OrganizationName
    End Get
    Set(value As String)
      _OrganizationName = value
    End Set
  End Property

  Public Property PassTypeIdentifier As String
    Get
      Return _PassTypeIdentifier
    End Get
    Set(value As String)
      _PassTypeIdentifier = value
    End Set
  End Property

  Public Property SerialNumber As String
    Get
      Return _SerialNumber
    End Get
    Set(value As String)
      _SerialNumber = value
    End Set
  End Property

  Public Property TeamIdentifier As String
    Get
      Return _TeamIdentifier
    End Get
    Set(value As String)
      _TeamIdentifier = value
    End Set
  End Property

  Public Property WebServiceURL As String
    Get
      Return _WebServiceURL
    End Get
    Set(value As String)
      _WebServiceURL = value
    End Set
  End Property


  Public ReadOnly Property PassJson() As String
    Get

      Using sw As StringWriter = New StringWriter(New StringBuilder())
        Using jsonWriter As JsonWriter = New JsonTextWriter(sw)
          jsonWriter.Formatting = Formatting.Indented
          jsonWriter.WriteStartObject()

          Return sw.ToString()
        End Using
      End Using
    End Get
  End Property



  Private Sub CreatePassFolder(ByVal path As String, ByVal DirName As String)

    Dim lsDirPath As String = System.IO.Path.Combine(path, DirName)
    Directory.CreateDirectory(lsDirPath)

    ''''Add Files to folder

    'Create pass.json file and data
    Dim lsPassFileName As String = "pass.json"
    Dim lsPassFilePath As String = System.IO.Path.Combine(lsDirPath, lsPassFileName)

    Using fs As FileStream = File.Create(lsPassFilePath)

      Dim fields = GetType(Coupon).GetFields

    End Using
    'add images to folder


  End Sub


End Class
