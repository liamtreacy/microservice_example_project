import random

import operator as op


def generate_random_number(lower, upper):
    return random.randint(lower, upper)


def get_unique_number_in_range(l, u, result_list):
    n = generate_random_number(l, u)
    while (op.countOf(result_list, n) != 0):
        n = generate_random_number(l, u)

    return n


def generate_lottery_result(lower, upper):
    result = []

    for i in range(6):
        num = get_unique_number_in_range(lower, upper, result)
        result.append(num)

    result.sort()
    formatted_result = ' '.join(map(str, result))
    return formatted_result
