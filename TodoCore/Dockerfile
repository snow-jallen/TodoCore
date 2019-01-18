FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TodoCore/TodoCore.csproj", "TodoCore/"]
RUN dotnet restore "TodoCore/TodoCore.csproj"
COPY . .
WORKDIR "/src/TodoCore"
RUN dotnet build "TodoCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TodoCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TodoCore.dll"]