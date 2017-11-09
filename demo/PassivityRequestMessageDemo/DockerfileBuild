#Demo for weichat mp
FROM microsoft/aspnetcore-build AS builder
WORKDIR /source

#restore and copying csproj
COPY *.csproj .
RUN dotnet restore

#coping code and publish to app
COPY . .
#RUN dotnet restore
RUN dotnet publish --output /app/ --configuration Release
#RUN ls /source

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "PassivityRequestMessageDemo.dll"]

