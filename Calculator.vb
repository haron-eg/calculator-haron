Imports System.Windows.Forms

Public Class Calculator
    Dim currentInput As String = ""
    Dim operation As String = ""
    Dim result As Double = 0

    ' Initialize the form and its components
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NumberButton_Click(sender As Object, e As EventArgs)
        Dim button = CType(sender, Button)
        currentInput &= button.Text
        UpdateDisplay()
    End Sub

    Private Sub OperationButton_Click(sender As Object, e As EventArgs)
        Dim button = CType(sender, Button)
        If currentInput <> "" Then
            result = Convert.ToDouble(currentInput)
            operation = button.Text
            currentInput = ""
        End If
    End Sub

    Private Sub EqualsButton_Click(sender As Object, e As EventArgs)
        Try
            Dim secondOperand As Double = Convert.ToDouble(currentInput)
            Select Case operation
                Case "+"
                    result += secondOperand
                Case "-"
                    result -= secondOperand
                Case "*"
                    result *= secondOperand
                Case "/"
                    If secondOperand = 0 Then
                        MessageBox.Show("Cannot divide by zero.")
                        ClearAll()
                        Return
                    End If
                    result /= secondOperand
            End Select
            currentInput = result.ToString()
            UpdateDisplay()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            ClearAll()
        End Try
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs)
        ClearAll()
    End Sub

    Private Sub ClearAll()
        currentInput = ""
        result = 0
        operation = ""
        UpdateDisplay()
    End Sub

    Private Sub UpdateDisplay()
        ' Update your display label/UI element here
        DisplayLabel.Text = currentInput
    End Sub

    ' Other methods for InitializeComponent() to setup the UI with buttons and event handlers...

End Class
