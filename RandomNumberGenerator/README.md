# Random Number Generator

This project sends a rabbitmq message containing a random number at regaular intervals.

The interval currently is 5 seconds. And the random number is in a range between 1 and 100.

## Requirements

- Docker
- Python (to run tests locally)

## Usage

To run tests

`./build.sh`

To bring up the system

`docker-compose up`

## Known issues

The rng container will need to restarted a few seconds after the rabbitmq container comes online.

## TODO

- Move the interval period, upper and lower bounds, exchange names etc to be docker supplied and configurable

  
