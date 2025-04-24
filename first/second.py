import random


secret_number = random.randint(1, 10)
user_guess = int(input("Угадайте число от 1 до 10: "))

if user_guess == secret_number:
    print("Угадал!")
else:
    print(f"Не угадал! Загаданное число: {secret_number}")