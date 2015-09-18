cd <Folder with FLS.nuspec>
<Downloads>\nuget pack "FLS\FLS.csproj" -Prop Configuration=Release
pause
<Downloads>\nuget push FLS.1.1.5.0.nupkg