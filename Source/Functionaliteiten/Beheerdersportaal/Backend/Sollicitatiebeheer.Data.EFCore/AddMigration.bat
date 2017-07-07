echo off

cls

echo -------------------------------------------------

echo.
echo   [ Adding migration with name '%1' ]

echo.
echo   EF Core Feedback:
echo.

dotnet ef migrations add %1 --startup-project ../Sollicitatiebeheer.Data.EFCore.Migrations

echo.
echo -------------------------------------------------
echo.