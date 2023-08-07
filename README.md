# Income Tax Calculator
### Application was made with ability to scale and easy-to-maintain as a whole solution. 
#### Note: Models can be easily extended. Infrastructure layer dependency is used only for dependency registration
### Angular client for used to create a UI from scratch. 
### Added client-side and backend-side validation.
![258649111-2c4f47eb-f30d-47c5-9951-f76477fbee5d](https://github.com/YuraSoroka/tax_calculator/assets/72869941/f650a2e0-66d5-4c73-b0bd-f85a6e508c26)

### Was added an ability to connect to a relational DB MSSQL Server - a history of calculated tax will be written in DB:
<img width="640" alt="sql" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/60c2e728-b110-4179-b528-0a9e13af660d">


## Architecture: Clean Architecture.
### Solution Structure:  
<img width="153" alt="solution" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/31e0a5c4-8e8e-48c1-a807-a4a9f416f244">


## Design patterns were used:
* Chain of responsibility
* Facade
* Template method
* Mediator (as an MediatR library implementation )
* Visitor (as an extension method realization)

## Libraries were used:
* MediatR
* FluentValidations
* FluentAssertions
* Moq
* Entity Framework
* Swagger

## Testing Framework used: 
* xUnit
<img width="348" alt="tests" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/36d5bd15-2bcf-41a1-ad08-bf3127471de8">
