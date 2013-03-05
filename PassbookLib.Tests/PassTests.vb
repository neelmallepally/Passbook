Imports System.Text
Imports Newtonsoft.Json
Imports System.Dynamic

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

    <TestMethod()>
    Public Sub PassJsonWillReturnWithHeaderFieldsForBoardingPass()
        ''arrange
        Dim passStyle As IPassStyle = New BoardingPass()
        Dim headerFields As Object = New ExpandoObject()
        Dim auxiliaryFields As Object = New ExpandoObject()
        Dim backFields As Object = New ExpandoObject()

        headerFields.key = "offer"
        headerFields.label = "Any premium dog food"
        headerFields.value = "20% off"

        auxiliaryFields.key = "expires"
        auxiliaryFields.label = "EXPIRES"
        auxiliaryFields.value = "2 Weeks"

        backFields.key = "temrs"
        backFields.label = "TERMS AND CONDITIONS"
        backFields.value = "Generic offers this pass, including all information"

        passStyle.HeaderFields = New List(Of ExpandoObject) From {headerFields}
        passStyle.AuxiliaryFields = New List(Of ExpandoObject) From {auxiliaryFields}
        passStyle.BackFields = New List(Of ExpandoObject) From {backFields}

        Dim input As Pass = New Pass(passStyle)

        ''action
        Dim output As String = input.PassJson()

        ''assert
        Dim expectedOutput As String = "{""formatVersion"":1,""supressStripShine"":false,""boardingPass"":{""transitType"":""TransitType""}}"

    End Sub
End Class
