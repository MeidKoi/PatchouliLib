FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-end

WORKDIR /app

COPY . ./
RUN dotnet publish ./PatchouliLib.csproj -c Release -o output

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build-end /app/output/wwwroot .

COPY nginx.conf /etc/nginx.conf

EXPOSE 80
