echo off

cls

echo -------------------------------------------------

echo.
echo   [ Remove previous migration ]

echo.
echo   EF Core Feedback:
echo.

dotnet ef migrations remove --startup-project ../Sollicitatiebeheer.Data.EFCore.Migrations

echo.
echo -------------------------------------------------
echo.