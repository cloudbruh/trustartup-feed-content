FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CloudBruh.Trustartup.FeedContent/CloudBruh.Trustartup.FeedContent.csproj", "CloudBruh.Trustartup.FeedContent/"]
RUN dotnet restore "CloudBruh.Trustartup.FeedContent/CloudBruh.Trustartup.FeedContent.csproj"
COPY . .
WORKDIR "/src/CloudBruh.Trustartup.FeedContent"
RUN dotnet build "CloudBruh.Trustartup.FeedContent.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudBruh.Trustartup.FeedContent.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudBruh.Trustartup.FeedContent.dll"]
