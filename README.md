# Hotel Booking API

Demo API to test Hotel Booking implementation
API documentation can be found at ~/swagger
### Notes

To run, please create a database using the included *CreateDatabase.sql* there are API end points that will seed the data.

The connection string should be added to the *asppsettings.Development.json*

Once running the API documentation can be found at:
- Swagger: ~/swagger
- OpenAPI: ~/openapi/v1.json

There are no included unit tests but the system has been designed using SOLID principles to allow easy injection of mock objects should it be required.

A "Test Hotel" is included to allow later functionality to pass an automation flag through HTTP headers (not implemented) for testing against production without harming customer data.

#### Database Information

Please create a new database in MS SQL Server (System was built against v 16.0.1160.1) and run the database create script against that in order to run the API and seed the data through code.