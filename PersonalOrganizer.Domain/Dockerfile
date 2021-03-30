FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /src
# Copy everything and build
COPY . ./
RUN dotnet restore "PersonalOrganizer.WebApi/PersonalOrganizer.WebApi.csproj"
RUN dotnet publish "PersonalOrganizer.WebApi/PersonalOrganizer.WebApi.csproj" -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as PersonalOrganizer
WORKDIR /app
COPY --from=build-env src/publish .
ENTRYPOINT ["dotnet", "PersonalOrganizer.WebApi.dll"]
EXPOSE 80
EXPOSE 5000
EXPOSE 5001