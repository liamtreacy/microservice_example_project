# microservice_example_project

This project will serve to help me learn docker, microservices etc.


Need:

RNG
RabbitMq docker


DB Service
MySQL docker


Display Service


Frontend


Docker compose to handle it all


=================================
Progress:

Have a python RNG.
Need to get it to produce rabbit messages

To run rabbit

(must have docker desktop running beforehand)
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management

After starting it up, go to http://localhost:15672/
login details are guest / guest
you can see the traffic

Next:
Get python to send rabbit messages

https://www.rabbitmq.com/tutorials/tutorial-one-python.html

Have got:
RabbitMq running
The python program reading command line args to generate a random number in a range and send that as a rabbit message.