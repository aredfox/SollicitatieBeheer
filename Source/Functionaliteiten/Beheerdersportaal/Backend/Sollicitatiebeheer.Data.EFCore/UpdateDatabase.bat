echo off

cls

echo -------------------------------------------------

echo.
echo   [ Update Database ]

echo.
echo   EF Core Feedback:
echo.

dotnet ef database update --startup-project ../Sollicitatiebeheer.Data.EFCore.MigrationsHelpApp

echo.
echo -------------------------------------------------
echo.