# Income Tax Calculator
### Application was made with ability to scale and easy-to-maintain as a whole solution. 
#### Note: Models can be easily extended. Infrastructure layer dependency is used only for dependency registration
### Angular client for used to create a UI from scratch. 
### Added client-side and backend-side validation.
![tax_calculator](https://github.com/YuraSoroka/tax_calculator/assets/72869941/2c4f47eb-f30d-47c5-9951-f76477fbee5d)

### Was added an ability to connect to a relational DB MSSQL Server - a history of calculated tax will be written in DB:
<img width="640" alt="image" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/b185a9a6-daa9-41dc-9c8d-551bb2310eee">


## Architecture: Clean Architecture.
### Solution Structure:  
<img width="400" alt="image" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/da7550a8-e3b4-443b-acba-31dca0a3e6a7">


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
<img width="450" alt="image" src="https://github.com/YuraSoroka/tax_calculator/assets/72869941/79658aad-1810-48ab-a347-83a90a58e309">
