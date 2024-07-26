FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

COPY . .
RUN dotnet publish "src/VolunteerVision.Api/VolunteerVision.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "app/publish/VolunteerVision.Api.dll"]
