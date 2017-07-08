echo off

cls

echo -------------------------------------------------

echo.
echo   [ Drop database ]

echo.
echo   EF Core Feedback:
echo.

cd ../Sollicitatiebeheer.Data.EFCore.Migrations 
dotnet run drop
cd ../Sollicitatiebeheer.Data.EFCore

echo.
echo -------------------------------------------------
echo.