import sys
import time
import os

import pika

from rng import generate_random_number


if __name__ == '__main__':

    lower = int(os.environ['LOWER_BOUND'])
    upper = int(os.environ['UPPER_BOUND'])
    loop_interval_secs = int(os.environ['DELAY_LOOP_SECONDS'])

    connection = pika.BlockingConnection(pika.ConnectionParameters('rabbitmq'))
    channel = connection.channel()

    channel.queue_declare(queue='test_rng')

    while True:
        rnd = generate_random_number(lower, upper)
        rnd = str(rnd)

        channel.basic_publish(exchange='',
                          routing_key='test_rng',
                          body=rnd)
        print(" [x] Sent " + rnd)
        time.sleep(loop_interval_secs)

    connection.close()

