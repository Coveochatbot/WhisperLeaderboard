FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WhisperLeaderboard.csproj", "WhisperLeaderboard/"]
RUN dotnet restore "WhisperLeaderboard/WhisperLeaderboard.csproj"
WORKDIR "/src/WhisperLeaderboard"
COPY . .
RUN dotnet publish "WhisperLeaderboard.csproj" -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app .
COPY ./WhisperUI ./WhisperUI
EXPOSE 80
ENTRYPOINT ["dotnet", "WhisperLeaderboard.dll"]