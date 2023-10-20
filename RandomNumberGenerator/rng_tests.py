import unittest

from rng import generate_random_number, generate_lottery_result


class MyTestCase(unittest.TestCase):
    def test_returns_if_lower_equals_upper(self):
        self.assertEqual(5, generate_random_number(5, 5))

    def test_returns_number_in_range(self):
        l = 1
        u = 100
        ret = generate_random_number(l, u)
        self.assertTrue(l < ret < u)

    def test_lottery_result_generated(self):
        ret = generate_lottery_result(1, 10)
        self.assertTrue(len(ret) > 6)


if __name__ == '__main__':
    unittest.main()
