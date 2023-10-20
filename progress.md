### Current state of the project:

`docker-compose up` will bring up the rng, rabbitmq, mongo and dbpopulator.
The generated numbers will be sent as rabbit messages, and consumed by the dbpopulator which will put these in the database.

### TODO

- Remove the sleep from the DbPopulator and back off attempting to connect until rabbitmq broker is up and running

- Code tidy up of DbPopulator

- Change the message to be a lottery result, and the db entry to reflect that.

- Front-end to show results (connect to Mongo)