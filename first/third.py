s = input("Введите строку: ")
count = 0
for char in s:
    if char == 'a':
        count += 1
print(f"Символ 'a' встречается {count} раз(а)")