echo off

cls

echo -------------------------------------------------

echo.
echo   [ Seed database ]

echo.
echo   EF Core Feedback:
echo.

cd ../Sollicitatiebeheer.Data.EFCore.Migrations 
dotnet run seed
cd ../Sollicitatiebeheer.Data.EFCore

echo.
echo -------------------------------------------------
echo.