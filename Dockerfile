FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WhisperLeaderboard.csproj", "WhisperLeaderboard/"]
RUN dotnet restore "WhisperLeaderboard/WhisperLeaderboard.csproj"
WORKDIR "/src/WhisperLeaderboard"
COPY . .
RUN dotnet publish "WhisperLeaderboard.csproj" -c Release -o /app

from node as uibuild
WORKDIR /app
COPY ./WhisperUI ./
RUN npm install
RUN npm uninstall -g angular-cli @angular/cli
RUN npm install -g @angular/cli@latest
RUN mkdir semantic && cp -r node_modules/semantic-ui/dist ./semantic/dist
RUN cd semantic
RUN ng build -c agent --output-path=dist/agent --base-href "/whisperui/agent/"
RUN ng build -c user --output-path=dist/user --base-href "/whisperui/user/"

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app .
RUN rm -r WhisperUI
COPY --from=uibuild /app/dist ./WhisperUI/dist
EXPOSE 80
ENTRYPOINT ["dotnet", "WhisperLeaderboard.dll"]