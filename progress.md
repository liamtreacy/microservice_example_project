Progress (DBS):

Need
- program to read rabbitmq messages - done
- dockerise it
- mysql db in docker
- program to connect to it
- docker the program to connect to it
- merge the two programs






=================================
Progress (RNG):

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

Now need:
To loop the python rng, sending messages each loop

To dockerise the python program - done
Someway to run test then build image - done
Have that image run and see output on rabbit - done




Problem is that the rng docker container cannot connect to the rabbitmq container... think I need docker compose?

Tried to copy this, but it fails. Due to a heartbeat issue maybe? https://github.com/dmaze/docker-rabbitmq-example/tree/master


OK! Lots of problem BUT

- docker-compose brings up the two containers.
- the rng one fails
- if wait a bit and manually restart, it's all good!
- have seen random number messages appear in the ui
- woohoo!

"The host parameter is set to 'rabbitmq', which is the name of the RabbitMQ container. This name is used because Docker automatically creates a DNS entry for each container that matches its name."


TODO::

1 - Investigate the start-up issue of the docker containers. Can RNG hold off until its properly connected?
2 - Tidy up of the python/Move args to be docker environment supplied.
3 - Do up proper progress notes
4 - Docker compose up and del commands/helpers/a proper readme instructions
5 - Longer term things (e.g. a proper build chain)

docker rmi -f $(docker images -aq)

===
Maybe it should be a lottery system? Could generate six number, puts the message out with them and the time?