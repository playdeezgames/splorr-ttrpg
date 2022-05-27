Imports System

Module Program
    Sub Main(args As String())
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("Another")
        prompt.AddChoice("Done")
        Do
            AnsiConsole.Clear()
            Dim characterSheet As New PlayerCharacterSheet

            For Each entry In characterSheet.AbilityScores
                AnsiConsole.MarkupLine($"{entry.Key.Name}: {entry.Value}")
            Next
        Loop Until AnsiConsole.Prompt(prompt) = "Done"
    End Sub
End Module
