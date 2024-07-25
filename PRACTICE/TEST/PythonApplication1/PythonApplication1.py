class Persona:
    def __init__(self, name, age) -> None:
        self.name = name
        self.age = age
        
    def __repr__(self) -> str:
        return f"Persona({self.name},{self.age})"


print("Ingrese el nombre: ", end="")
nombre = input()

print("Ingrese la edad: ", end="")
edad = int(input())

persona = Persona(nombre, edad)

print(persona)

