class Employee:
    def __init__(self, emp_id: int, name: str, position: str):
        self.emp_id = emp_id
        self.name = name
        self.position = position
        self.tasks = []

    def assign_task(self, task):
        self.tasks.append(task)
        task.assigned_to = self

    def __repr__(self):
        return f"{self.name} ({self.position})"


class Task:
    def __init__(self, description: str, due_date: str):
        self.description = description
        self.due_date = due_date
        self.status = "Не начата"
        self.assigned_to = None

    def assign_employee(self, employee: Employee):
        if not isinstance(employee, Employee):
            raise TypeError("Должен быть объект Employee")
        self.assigned_to = employee
        employee.assign_task(self)

    def update_status(self, new_status: str):
        valid_statuses = ["Не начата", "В процессе", "Завершена"]
        if new_status not in valid_statuses:
            raise ValueError(f"Недопустимый статус. Допустимые: {valid_statuses}")
        self.status = new_status

    def __repr__(self):
        return f"Задача: {self.description}"


class Project:
    def __init__(self, name: str):
        self.name = name
        self.tasks = []
        self.employees = []

    def add_task(self, task: Task):
        self.tasks.append(task)

    def add_employee(self, employee: Employee):
        self.employees.append(employee)

    def assign_task(self, task: Task, employee: Employee):
        if employee not in self.employees:
            raise ValueError("Сотрудник не участвует в проекте")
        if task not in self.tasks:
            raise ValueError("Задача не принадлежит проекту")
        employee.assign_task(task)
        task.assign_employee(employee)

    def calculate_progress(self) -> float:
        completed = sum(1 for task in self.tasks if task.status == "Завершена")
        return (completed / len(self.tasks)) * 100 if self.tasks else 0.0

    def __repr__(self):
        return f"Проект '{self.name}'"


dev = Employee(1, "Витя", "Разработчик")
qa = Employee(2, "Иван", "Тестировщик")

task1 = Task("Создать API", "2024-01-15")
task2 = Task("Написать тесты", "2024-01-20")

project = Project("Платформа аналитики")

project.add_employee(dev)
project.add_employee(qa)
project.add_task(task1)
project.add_task(task2)


project.assign_task(task1, dev)
project.assign_task(task2, qa)

task1.update_status("В процессе")
task2.update_status("Завершена")

# Отчетность
print(f"Прогресс: {project.calculate_progress():.1f}%")
print(f"Задачи Анны: {dev.tasks}")