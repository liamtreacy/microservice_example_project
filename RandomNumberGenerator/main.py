import sys
import time

import pika

from rng import generate_random_number

if __name__ == '__main__':
    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()

    channel.queue_declare(queue='test_rng')

    lower = int(sys.argv[1])
    upper = int(sys.argv[2])
    loop_interval_secs = int(sys.argv[3])

    while True:
        rnd = generate_random_number(lower, upper)
        rnd = str(rnd)

        channel.basic_publish(exchange='',
                          routing_key='test_rng',
                          body=rnd)
        print(" [x] Sent " + rnd)
        time.sleep(loop_interval_secs)

    connection.close()

