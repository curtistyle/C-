// *****************************************
// COLA DE PRIORIDAD
// *****************************************

Queue<string> cola = new Queue<string>();

cola.Enqueue("Lunes");       // 1
cola.Enqueue("Martes");      // 2
cola.Enqueue("Miercoles");   // 3
cola.Enqueue("Juves");       // 4
cola.Enqueue("Viernes");     // 5


Console.WriteLine(cola.Peek());