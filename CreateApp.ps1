$app = "WebAPIClient"
dotnet new console --name $app
cd $app

#For JSON Processing
dotnet add package System.Text.Json
dotnet add package MySql.Data
dotnet add package ApiController
