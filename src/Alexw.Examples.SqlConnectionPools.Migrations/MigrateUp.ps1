# Run this from the bin directory (or change values for Alexw.Examples.SqlConnectionPools.Migrations.dll below)

$migrateExePath = Get-ChildItem -Filter Migrate.exe -Recurse -Path ((Get-Item (pwd).Path).Parent.Parent.Parent.Parent).FullName | Select-Object -First 1 | select -ExpandProperty FullName;
$connectionString = "Data Source=localhost;Initial Catalog=Test;Integrated Security=True";
$migrationsDllPath = ".\Alexw.Examples.SqlConnectionPools.Migrations.dll";
& $migrateExePath --connectionString "Data Source=db\db.sqlite;Version=3;" -target assembly $migrationsDllPath /verbose