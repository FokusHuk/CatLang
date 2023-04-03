FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /solution
COPY ./*.sln ./*/*.csproj ./*.props ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
COPY ./*/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p Tools/${file%.*}/ && mv $file Tools/${file%.*}/; done
RUN dotnet restore "EnglishTrainer.sln"
COPY . .
RUN dotnet build "EnglishTrainer.sln" -c Release --no-restore /warnaserror

FROM mcr.microsoft.com/dotnet/sdk:7.0 as tests
WORKDIR /tests
COPY --from=build /solution .
ENTRYPOINT ["dotnet", "test", "-c", "Release", "--no-build"]

FROM build as publish
RUN dotnet publish "./EnglishTrainer.API/EnglishTrainer.API.csproj" -c Release --output /publishes/api --no-restore
RUN dotnet publish "./Tools/Migrator/Migrator.csproj" -c Release --output /publishes/migrator --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS migrator
COPY --from=publish /publishes/migrator /app/
WORKDIR /app
ENTRYPOINT ["dotnet", "Migrator.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS api
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
COPY --from=publish /publishes/api .
ENTRYPOINT ["dotnet", "EnglishTrainer.API.dll"]