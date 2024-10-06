# Use uma imagem do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos e faz o build da aplicação
COPY . .
RUN dotnet publish -c Release -o /out

# Use a imagem do runtime do .NET para rodar o app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Exponha a porta da API
EXPOSE 80

# Defina o ponto de entrada para o container
ENTRYPOINT ["dotnet", "dg-studio-api.dll"]
