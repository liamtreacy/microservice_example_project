import sys
import pika

from rng import generate_random_number

if __name__ == '__main__':
    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()

    channel.queue_declare(queue='test_rng')

    lower = sys.argv[1]
    upper = sys.argv[2]
    rnd = generate_random_number(int(lower), int(upper))

    channel.basic_publish(exchange='',
                          routing_key='test_rng',
                          body=str(rnd))
    print(" [x] Sent " + str(rnd))

    connection.close()

