### Current state of the project:

`docker-compose up` will bring up the rng, rabbitmq, mongo and dbpopulator.
The lottery results will be sent as rabbit messages, and consumed by the dbpopulator which will put these in the database.

### TODO

- Remove the startup sleep from the DbPopulator and RNG and back off attempting to connect until rabbitmq broker is up and running

- Code tidy up of DbPopulator

- Front-end to show results (connect to Mongo)

- Rename RNG