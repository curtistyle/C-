# Delegados

## Desglose del codigo

### Declaracion de delegados

- `DiscountRule` : Este delegado representa un método que no toma paramentros y devuelve un `double`. Se utiliza para representar las **reglas de descuento**.
- `MessageFormat`: Este delegado representa un método que no tema parámetros y devuelve un `string`. Se utiliza para representar los formatos de los mensajes.

### Clases `Message` y `Discount`

- **Clase** `Message`:
	- `Instance()` : Método de instancia que devuelve un `string` de formato.
	- `Class()` : Método de formato que tambien devuelve un `string` de formato.
	- `Out(MessageFormat format, double d)` : Método que toma un delegado `MessageFormat` y un `double`, Imprime en la consola el resultado del método delegado formateado con el número decimal proporcionado.

- **Clase** `Discount`:
	- `Aplly(DiscountRule rule, double amount)` : Método que toma un delegado `DiscountRule` y un `double` (el monto comprar). Aplica la regla de descuento la monto y devuelve el monto con el descuento aplicado.
	- **Metodos estáticos** : (`Maximun`, `Average`, `Minimun`, `None`) : Cada uno de estos métodos representa una regla de descuento especifica y devuelve un valor de descuento.

#### 1. Instanciación de Reglas de Descuento

```C#
DiscountRule[] rules = {
    new DiscountRule(Discount.None),
    new DiscountRule(Discount.Minimum),
    new DiscountRule(Discount.Average),
    new DiscountRule(Discount.Maximun),
};
```
Aque se crean instancias del delegado `DiscountRule` para cada método de descuento en la clase `Discount`. Estos delegados apuntan a los métodos `None`, `Minumun`, `Average` y `Maximun`.

#### 2. Instanciacion del Formato de Mensaje

```C#
	MessageFormat format = new MessageFormat(Message.Class);
```
Se crea una instancia del delegado `MensaggeFormat` utilizando el método estatico `Class` de la clase `Message`. Este metodo se utilizará para formatear mensajes que muestran el monto de compra.

#### 3. Configuracion de la Compra y Salida Incial

```C#
double buy = 100.00;
Message msg = new Message();
msg.Out(format, buy);
```

- Se define un monto de compra de `100.00`
- Se crea una instancia de la clase `Message`
- Se llama al método `Out` de la instancia `msg` usando el formato de mensaje definido y el monto de compra, mostrando "You are buying for $100.00"

#### 4. Cambio de Formato de Mensaje

```C#
format = new MessageFormat(msg.Instance);
```

- Se reasigna el delegedo `format` para que apunte al método `Instance` de la instancia de `Message`. Este metodo formateará mensajes para mostrar el ahorro obtenido.

#### 5. Aplicacion de Reglas de Descuento.

```C#
foreach (DiscountRule r in rules)  
{
	double saving = Discount.Apply(r, buy);
	msg.Out(format, saving);
}
```

- Se itera a través de cada regla de descuento en `rules`.
- Para cada regla, se llama al método `Apply` de la clase `Discount`, aplicando el descuento al monto de compra.
- Luego, se llama al metodo `Out` con el formato actualizado y el ahorro calculado, imprimiendo mensajes como "You Save $100.00", "You Save $20.00" y así sucesivamente.


### Resumen del Comportamiento
- Instancia y ejecución de delegados: El código muestra cómo instanciar delegados y utilizarlos para encapsular lógica de negocio, como aplicar diferentes descuentos y formatear mensajes de salida.

- Salida formateada: Inicialmente, se muestra el monto de compra. Luego, se aplican y se muestran los diferentes descuentos posibles.

- Uso de foreach y delegados en métodos: La lógica de descuentos se aplica mediante un bucle foreach y los resultados se imprimen dinámicamente usando los delegados.