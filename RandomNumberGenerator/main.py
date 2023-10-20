import sys
import time
import os

import pika

from rng import generate_random_number, generate_lottery_result

if __name__ == '__main__':

    lower = int(os.environ['LOWER_BOUND'])
    upper = int(os.environ['UPPER_BOUND'])
    loop_interval_secs = int(os.environ['DELAY_LOOP_SECONDS'])
    publish_queue = os.environ['PUBLISH_QUEUE']

    # Sleep until the rabbitmq is up and running
    #TODO replace this with a proper callback guard
    time.sleep(15)

    connection = pika.BlockingConnection(pika.ConnectionParameters('rabbitmq'))
    channel = connection.channel()

    channel.queue_declare(queue=publish_queue)

    while True:
        result = generate_lottery_result(lower, upper)

        channel.basic_publish(exchange='',
                          routing_key=publish_queue,
                          body=result)
        print("RNG Sending:: " + result)
        time.sleep(loop_interval_secs)

    connection.close()

