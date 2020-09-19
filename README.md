## Introduction

This is a .Net Coresolution to presents microservice concepts

This is the first version, there some improveds to be done:
- NET core 2.2 is not the best choice, I used it because I couldn't install different versions on the PC used to write this example
- ~~The Account service depends on User service, the question IsCustomerValid should be moved to the BankOrchestrator~~
- Use asynchronous and tasks methods
- Add a unit test to MyBankOrchestrator

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
