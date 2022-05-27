Imports System

Module Program
    Sub Main(args As String())
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("Another")
        prompt.AddChoice("Done")
        Dim characterSheet As New CharacterSheet
        Do
            AnsiConsole.Clear()
            characterSheet.Generate()

            'always put wild card points into Power
            characterSheet.AbilityScores(AbilityScore.Power) += characterSheet.AbilityScores(AbilityScore.None)
            characterSheet.AbilityScores(AbilityScore.None) = 0

            For Each entry In characterSheet.AbilityScores
                AnsiConsole.MarkupLine($"{entry.Key.Name}: {entry.Value}")
            Next
        Loop Until AnsiConsole.Prompt(prompt) = "Done"
    End Sub
End Module
