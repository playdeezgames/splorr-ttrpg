Module Program
    Sub Main(args As String())
        Dim prompt As New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoice("Another")
        prompt.AddChoices("Fight!")
        prompt.AddChoice("Done")
        Dim done As Boolean = False
        Do
            AnsiConsole.Clear()
            Dim character As New PlayerCharacter

            For Each entry In character.AbilityScores
                AnsiConsole.MarkupLine($"{entry.Key.Name}: {entry.Value}")
            Next

            Select Case AnsiConsole.Prompt(prompt)
                Case "Fight!"
                    ChooseOpponents(character)
                Case "Done"
                    done = True
            End Select
        Loop Until done
    End Sub

    Private Sub ChooseOpponents(character As Character)
        Dim done As Boolean = False
        Dim opponentCount As Long = 0
        While Not done
            AnsiConsole.WriteLine($"{character.Name} has faced {opponentCount} enemies so far.")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "Choose Opponent:"}
            prompt.AddChoice("Goblin")
            Select Case AnsiConsole.Prompt(prompt)
                Case "Goblin"
                    Fight(character, New GoblinNPC)
                    done = character.IsDead
                    If done Then
                        AnsiConsole.WriteLine($"{character.Name} defeated {opponentCount} enemies.")
                        OkPrompt()
                    End If
                    opponentCount += 1
            End Select
        End While
    End Sub

    Private Sub Fight(character As Character, opponent As Character)
        While Not character.IsDead AndAlso Not opponent.IsDead
            character.Attack(opponent)
            If Not opponent.IsDead Then
                opponent.Attack(character)
            End If
        End While
        If character.IsDead Then
            AnsiConsole.MarkupLine($"{character.Name} is dead!")
        End If
        If opponent.IsDead Then
            AnsiConsole.MarkupLine($"{character.Name} wins!")
        End If
    End Sub
End Module
