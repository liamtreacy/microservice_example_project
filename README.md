# microservice_example_project

This project comprises the following:

- RabbitMq

- MongoDB

- DbPopulator: A C#.NET project which listens for RabbitMq messages, and populates a MongoDb collection with what's received.

- RandomNumberGenerator: A Python project which generates a random lottery result and sends it as a RabbitMq message.

- LatestResult: A go project which implements a very simple web server. It retrieves and returns the latest lottery result from MongoDb.

### Usage

`docker-compose up` will bring everything up. After 15 seconds, the results will start to be sent as messages and the system will run until stopped.

