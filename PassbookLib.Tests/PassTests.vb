Imports System.Text
Imports Newtonsoft.Json

<TestClass()>
Public Class PassTests

  <TestMethod()>
  Public Sub JsonWillHaveKeyValueFromJsonPropertyNameOfProperty()
    'arrange
        Dim input As Pass = New Pass(Nothing)
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
    Public Sub PassJsonWillReplaceBoardingPassPropertyKeyForPassStyleProperty()
        ''arrange
        Dim passStyle As IPassStyle = New BoardingPass With {.TransitType = "TransitType"}
        Dim input As Pass = New Pass(passStyle)

        'action
        Dim output As String = input.PassJson()
        ''assert
        Dim expectedOutput As String = "{""formatVersion"":1,""supressStripShine"":false,""boardingPass"":{""transitType"":""TransitType""}}"

        Assert.AreEqual(expectedOutput, output)
    End Sub

End Class
