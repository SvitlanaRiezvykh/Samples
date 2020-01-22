# WcfService
Creation of a RESTful service using WCF

## Prerequisites
*	Microsoft Visual Studio 2019 or higher
* Postman to test our API: https://www.getpostman.com/apps

## How to run application

1. Open Visual studio with Administrator access rights. 
2. Open "~\Samples\EmployeeManagament\EmployeeManagament.sln" solution in visual studio.
3. Set up EmployeeManagamentHost as StartUp project.
4. Run application.

## Postman test

Start the application then test your methods.
Application would run at http://localhost:8080/EmployeeManagament

| Action        | HTTP method   |URI Part| Body Example
| ------------- |:-------------:|:--------:| ----------|
| Get employees  | GET | /employees | - | 
| Get employee by Id  | GET | /employees/id/{id} | - |
| Get employees by Specialization   | GET | /employees/specialization /{specialization } | - |
| Create Employee    | POST      | /add  | {"Experience": 3,"Name": "Inna","Position": "Junior","Salary": 70,"Specialization": "Manager","TeamMembers":"12"} |
| Update Employee    | POST      | /update/id/{id}  | {"Experience": "2","Name": "Vills","Salary": "5"} |