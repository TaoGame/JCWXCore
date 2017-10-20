#FROM microsoft/aspnetcore:2.0
#ARG source
#WORKDIR /app
#EXPOSE 80
#COPY ${source:-obj/Docker/publish} .
#ENTRYPOINT ["dotnet", "PassivityRequestMessageDemo.dll"]
FROM centos:7
COPY Startup.cs .

CMD ["bash"]
