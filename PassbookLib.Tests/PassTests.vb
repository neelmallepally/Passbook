Imports System.Text
Imports Newtonsoft.Json

<TestClass()>
Public Class PassTests

  <TestMethod()>
  Public Sub JsonWillHaveKeyValueFromJsonPropertyNameOfProperty()
    'arrange
    Dim input As Pass = New Pass()
    input.PassTypeIdentifier = "test"
    input.SupressStripShine = True

    'action
    Dim output As String = JsonConvert.SerializeObject(input, Formatting.None, New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore})

    'assert
    Dim expectedOutPut1 As String = "{""formatVersion"":1,""passTypeIdentifier"":""test"",""supressStripShine"":false}"
    Dim expectedOutPut2 As String = "{""formatVersion"":1,""passTypeIdentifier"":""test"",""supressStripShine"":true}"

    Assert.AreNotEqual(expectedOutPut1, output)
    Assert.AreEqual(expectedOutPut2, output)

  End Sub

  <TestMethod()>
  Public Sub JsonWillIgnorePropertyKeyForPassStyleProperty()

    ''arrange
    Dim input As Pass = New Pass()

    input.PassStyle = New BoardingPass With {.TransitType = "TransitType"}


    'action
    Dim output As String = JsonConvert.SerializeObject(input, Formatting.None, New Converters.KeyValuePairConverter())

    ''assert
    Dim expectedOutput As String = "{""formatVersion"":1, ""supressStripShine"":false}"

  End Sub

End Class
