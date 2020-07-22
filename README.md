## Introduction

This is a .Net Core 2.2 solution to presents microservice concepts

## Database Model

To be easy to test, this example does not use a database. Data is persisting in Json files (the code ist here https://github.com/fernandoprass/myBank/blob/master/src/API/DBContexts/DBContext.cs).

## NuGet Packages
Two external packages were added to the project
1. **Newtonsoft.Json** => Serialize/Deserialize Json files (https://www.newtonsoft.com/json)
2. **FluentAssertions** => Used in Unit Test (https://fluentassertions.com/)

## How to test the API

To test the API you can use the Postman (https://www.postman.com)

1. Create an new account (POST method **Add**) => [http://localhost:55355/api/Account/Add?customerId=USER_ID&initialCredit=VALUE]. Where **USER_ID** is a integer number between 1 and 8 (the list of user is fixed) and **VALUE** is a double number the represents the initial balance.
  
2. Get the account Statement (GET method **GetStatement**) =>: [http://localhost:55355/api/Account/GetStatement?accountId=ACCOUNT_ID]. Where **ACCOUNT_ID** is a guid genereted when the account is created.
