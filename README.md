# Alexw.Examples.SqlConnectionPools
Taking a look at ADO.NET SQL Connections and Connection Pooling

# Technologies
* JMeter for load testing
* Microsoft SQL Server
* .NET C# Application and in Microsoft.OwinSelfHost

# Getting started
* Ensure MSSQL is installed somewhere
* Create a test database
* Migrate the database using the commands found in [src/Alexw.Examples.SqlConnectionPools.Migrations/MigrateUp.ps1](src/Alexw.Examples.SqlConnectionPools.Migrations/MigrateUp.ps1)
* Rebuild the solution to restore the Nuget Packages
* Start the web application, it should run at `http://localhost:9000`
* Download JMeter and run `jmeter.bat`, execute [src/Alexw.Examples.SqlConnectionPools.JMeter/loadtest.jmx](src/Alexw.Examples.SqlConnectionPools.JMeter/loadtest.jmx)
* Run the jmeter tests, the app should be hit

# Performance Counters
* Open `perfmon` (Microsoft Performance Counters)
* Find .NET Data Provider for SQL Server and chose the app you wish to profile.

# Troubleshooting
* Make sure the connection strings are correct and working
* Can't see your app in perfmon? Restart perfmon.
