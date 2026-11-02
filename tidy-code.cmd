@echo off
dotnet format --verbosity:detailed || exit /b
dotnet run tools/normalize-line-endings.cs
