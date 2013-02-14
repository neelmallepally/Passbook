Imports Newtonsoft.Json
Public Class JsonHelper

  Public Shared Function CreatePassJson(ByVal input As Object) As String
    If (input IsNot Nothing) Then
      Return JsonConvert.SerializeObject(input)
    End If
    Return Nothing
  End Function

End Class
