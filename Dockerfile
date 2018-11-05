FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 6502
#EXPOSE 44359
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WhisperLeaderboard.csproj", "WhisperLeaderboard/"]
RUN dotnet restore "WhisperLeaderboard/WhisperLeaderboard.csproj"
WORKDIR "/src/WhisperLeaderboard"
COPY . .
RUN dotnet build "WhisperLeaderboard.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WhisperLeaderboard.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WhisperLeaderboard.dll"]
