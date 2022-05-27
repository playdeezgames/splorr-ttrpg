Public Class Character
    Public AbilityScores As Dictionary(Of AbilityScore, Long)
    Public HP As Long
    Public MaximumHP As Long
    Public MP As Long
    Public MaximumMP As Long
    Public Weapon As Weapon
    Sub New()
        AbilityScores = New Dictionary(Of AbilityScore, Long)
    End Sub
End Class
