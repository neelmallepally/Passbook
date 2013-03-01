Imports Newtonsoft.Json
Public Class PassStyleJsonConverter
  Inherits JsonConverter

  Public Overrides Function CanConvert(objectType As System.Type) As Boolean
    Return True
  End Function

  Public Overrides Function ReadJson(reader As Newtonsoft.Json.JsonReader, objectType As System.Type, existingValue As Object, serializer As Newtonsoft.Json.JsonSerializer) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub WriteJson(writer As Newtonsoft.Json.JsonWriter, value As Object, serializer As Newtonsoft.Json.JsonSerializer)


  End Sub

End Class
