Progress (DBS):

Need
- program to read rabbitmq messages - done
- dockerise it - done
- mysql db in docker - done
- mongo in docker - done
- program to connect to it - done
- docker the program to connect to it - done
- merge the two programs

        - an asp net project - done
        - docker that - done ( docker build -t dbservice .     and then docker run -ti --rm -p 8080:80 dbservice)
        - can Get the latest number from it - done
        - add rabbitreader as a service - done
        - add mongo connector to update the db with it
        - check works running in docker


Have mongo running. Once compose is up
Go to http://localhost:8081/
admin pass

Don't know why the credentials don't work? According to the mongo-express documentation, the default username and password for the web-based admin interface are admin and pass, respectively 1. It’s possible that these are the credentials you need to use to log in.


Decided to go against mysql, just use mongo for now


Ran
docker run --name some-mysql -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:8 

Then
docker exec -it some-mysql bash

https://learn.microsoft.com/en-us/visualstudio/docker/tutorials/tutorial-multi-container-app-mysql

Got the mysql running from docker-compose

Logged into it (through exec on docker desktop)
mysql -p
mysql> SHOW DATABASES;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| number_info        |
| performance_schema |
| sys                |
+--------------------+
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