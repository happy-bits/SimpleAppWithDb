# Generera migrations SQL
dotnet ef migrations script --no-build | Out-File -Encoding utf8 temp.sql

# Läs innehållet och ta bort BOM
$content = [System.IO.File]::ReadAllText("temp.sql").TrimStart([char]0xFEFF)

# Skriv tillbaka utan BOM
[System.IO.File]::WriteAllText("migrations.sql", $content, [System.Text.UTF8Encoding]::new($false))

# Ta bort temporär fil
Remove-Item temp.sql