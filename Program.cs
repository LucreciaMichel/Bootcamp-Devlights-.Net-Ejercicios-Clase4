


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Ejercicios Clase 4 - Colecciones ===");
            Console.WriteLine("1  - Promedio de últimas 10 notas (List)");
            Console.WriteLine("2  - Contar mayores y menores (List de 20 edades)");
            Console.WriteLine("3  - Nombre mayor y menor longitud (List de nombres)");
            Console.WriteLine("4  - Lista de supermercado (agregar/quitar, 'fin' para salir)");
            Console.WriteLine("5  - Matriz 5x5: 'I' en impares, 'P' en pares");
            Console.WriteLine("6  - Matriz temperaturas 5x7 (mes de mayo) - análisis semanal/mensual");
            Console.WriteLine("7  - Matriz tablas del 0 al 9 (10x10)");
            Console.WriteLine("8  - Juego: esconder 'X' en 10x10 y adivinar");
            Console.WriteLine("9  - Diccionario de calificaciones (Dictionary<string,double>)");
            Console.WriteLine("10 - Simulador de atención en ventanilla (Queue)");
            Console.WriteLine("11 - (Opcional) Inventario con List, Dictionary y Stack");
            Console.WriteLine("0  - Salir");
            Console.Write("Elige una opción: ");
            var opt = Console.ReadLine();

            if (opt == "0") break;

            switch (opt)
            {
                case "1": Ejercicio1(); break;
                case "2": Ejercicio2(); break;
                case "3": Ejercicio3(); break;
                case "4": Ejercicio4(); break;
                case "5": Ejercicio5(); break;
                case "6": Ejercicio6(); break;
                case "7": Ejercicio7(); break;
                case "8": Ejercicio8(); break;
                case "9": Ejercicio9(); break;
                case "10": Ejercicio10(); break;
                case "11": Ejercicio11(); break;
                default:
                    Console.WriteLine("Opción no válida. Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // 1.
    static void Ejercicio1()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 1 - Promedio de últimas 10 notas");
        List<double> notas = new List<double>();
        // Para facilitar la demo, pedimos las 10 notas al usuario:
        for (int i = 0; i < 10; i++)
        {
            double n;
            while (true)
            {
                Console.Write($"Ingrese nota {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out n)) break;
                Console.WriteLine("Valor inválido. Ingrese un número.");
            }
            notas.Add(n);
        }
        Console.WriteLine("\nLas 10 notas ingresadas:");
        for (int i = 0; i < notas.Count; i++)
            Console.WriteLine($"Examen {i + 1}: {notas[i]:0.##}");

        double promedio = notas.Average();
        Console.WriteLine($"\nPromedio: {promedio:0.##}");
        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 2.
    static void Ejercicio2()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 2 - Contar mayores y menores (20 edades)");
        List<int> edades = new List<int>();
        Console.WriteLine("Ingrese 20 edades:");
        for (int i = 0; i < 20; i++)
        {
            int e;
            while (true)
            {
                Console.Write($"Edad {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out e) && e >= 0) break;
                Console.WriteLine("Edad inválida.");
            }
            edades.Add(e);
        }

        int mayores = edades.Count(x => x >= 18);
        int menores = edades.Count - mayores;
        Console.WriteLine($"\nMayores de edad: {mayores}");
        Console.WriteLine($"Menores de edad: {menores}");
        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 3.
    static void Ejercicio3()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 3 - Nombre más largo y más corto");
        Console.WriteLine("Ingresa nombres (escribe 'fin' para terminar):");
        List<string> nombres = new List<string>();
        while (true)
        {
            Console.Write("Nombre: ");
            string s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) continue;
            if (s.Trim().ToLower() == "fin") break;
            nombres.Add(s.Trim());
        }

        if (nombres.Count == 0)
        {
            Console.WriteLine("No se ingresaron nombres.");
        }
        else
        {
            string masLargo = nombres.OrderByDescending(n => n.Length).First();
            string masCorto = nombres.OrderBy(n => n.Length).First();
            Console.WriteLine($"\nNombre más largo: {masLargo} ({masLargo.Length} caracteres)");
            Console.WriteLine($"Nombre más corto: {masCorto} ({masCorto.Length} caracteres)");
        }
        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 4.
    static void Ejercicio4()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 4 - Lista de supermercado");
        // Lista inicial de supermercado (ejemplo)
        List<string> listaSuper = new List<string> { "leche", "pan", "huevos", "azúcar", "sal", "arroz", "fideo", "manteca" };
        List<string> compradosNoEstaban = new List<string>();
        List<string> compradosSiEstaban = new List<string>();

        Console.WriteLine("Lista inicial: " + string.Join(", ", listaSuper));
        Console.WriteLine("Ingrese elementos que va a comprar. Escriba 'fin' para terminar.");

        while (true)
        {
            Console.Write("Elemento: ");
            string entrada = Console.ReadLine().Trim().ToLower();
            if (entrada == "fin") break;
            if (entrada == "") continue;

            if (listaSuper.Contains(entrada))
            {
                listaSuper.Remove(entrada);
                compradosSiEstaban.Add(entrada);
                Console.WriteLine($"'{entrada}' estaba en la lista. Se marcó como comprado y se sacó de la lista.");
            }
            else
            {
                // No estaba en la lista: lo agregamos a la lista de comprados no previstos
                compradosNoEstaban.Add(entrada);
                Console.WriteLine($"'{entrada}' NO estaba en la lista. Se agregó a 'comprados pero no estaban'.");
            }
        }

        Console.WriteLine("\n--- Resultado ---");
        Console.WriteLine("Elementos que NO compró (quedaron en la lista): " + (listaSuper.Count > 0 ? string.Join(", ", listaSuper) : "(ninguno)"));
        Console.WriteLine("Elementos que compró y NO estaban en la lista: " + (compradosNoEstaban.Count > 0 ? string.Join(", ", compradosNoEstaban) : "(ninguno)"));
        Console.WriteLine("Elementos que compró y estaban en la lista: " + (compradosSiEstaban.Count > 0 ? string.Join(", ", compradosSiEstaban) : "(ninguno)"));

        Console.WriteLine("Si deseas, también podrías ver todas las compras juntas:");
        var todas = compradosSiEstaban.Concat(compradosNoEstaban).ToList();
        Console.WriteLine("Todas las compras: " + (todas.Any() ? string.Join(", ", todas) : "(ninguna)"));

        Console.WriteLine("\nPresiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 5.
    static void Ejercicio5()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 5 - Matriz 5x5: 'I' en impares, 'P' en pares (posiciones contadas desde 1)");
        char[,] mat = new char[5, 5];
        int pos = 1;
        for (int r = 0; r < 5; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                if (pos % 2 == 1) mat[r, c] = 'I';
                else mat[r, c] = 'P';
                pos++;
            }
        }

        for (int r = 0; r < 5; r++)
        {
            for (int c = 0; c < 5; c++)
                Console.Write($"{mat[r, c]} ");
            Console.WriteLine();
        }
        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 6.
    static void Ejercicio6()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 6 - Matriz de temperaturas 5x7 (mayo). Lunes=1, hasta 31 (miércoles).");

        int filas = 5, cols = 7;
        int[,] temps = new int[filas, cols];
        Random rnd = new Random();
        // llenamos los primeros 31 días (fila0-col0 = lunes día 1) y dejamos el resto (días >31) con un valor especial (0).
        int dia = 1;
        for (int r = 0; r < filas; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (dia <= 31)
                {
                    temps[r, c] = rnd.Next(7, 39); // 7..38 inclusive
                    dia++;
                }
                else
                    temps[r, c] = int.MinValue; // celda no usada
            }
        }

        string[] nombresDias = new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        // a) Para cada semana (fila) obtener temp más alta y más baja y que día se produjo
        for (int r = 0; r < filas; r++)
        {
            // recolectar solo días válidos de la semana (podría ser que última semana tenga celdas inválidas)
            List<(int temp, int diaIdx)> diasSemana = new List<(int, int)>();
            for (int c = 0; c < cols; c++)
            {
                if (temps[r, c] != int.MinValue)
                    diasSemana.Add((temps[r, c], c));
            }
            if (diasSemana.Count == 0) continue;
            var max = diasSemana.OrderByDescending(x => x.temp).First();
            var min = diasSemana.OrderBy(x => x.temp).First();
            double avg = diasSemana.Average(x => x.temp);

            Console.WriteLine($"\nSemana {r + 1}:");
            Console.WriteLine($"  Temperatura máxima: {max.temp} ({nombresDias[max.diaIdx]})");
            Console.WriteLine($"  Temperatura mínima: {min.temp} ({nombresDias[min.diaIdx]})");
            Console.WriteLine($"  Promedio de la semana: {avg:0.##}");
        }

        // c) Temperatura más alta del mes y su día (fecha y día de la semana)
        int maxTemp = int.MinValue;
        int maxDiaNumero = -1;
        int maxDiaSemanaIdx = -1;
        dia = 1;
        for (int r = 0; r < filas; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (dia <= 31)
                {
                    int t = temps[r, c];
                    if (t > maxTemp)
                    {
                        maxTemp = t;
                        maxDiaNumero = dia;
                        maxDiaSemanaIdx = c;
                    }
                    dia++;
                }
            }
        }

        Console.WriteLine($"\nMáxima del mes: {maxTemp}° el día {maxDiaNumero} ({nombresDias[maxDiaSemanaIdx]})");

        // Mostrar matriz con fechas y temperaturas para visualizar
        Console.WriteLine("\nMatriz (días con temperatura). '-' indica celda fuera de mes:");
        dia = 1;
        for (int r = 0; r < filas; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (dia <= 31)
                {
                    Console.Write($"{temps[r, c],3} ");
                    dia++;
                }
                else
                    Console.Write("  - ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nPresiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 7.
    static void Ejercicio7()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 7 - Matriz tablas del 0 al 9 (10x10) con fila y columna 0..9");

        int[,] tabla = new int[10, 10];
        // primera fila y primera columna con los números 0..9
        for (int i = 0; i <= 9; i++)
        {
            tabla[0, i] = i; // fila 0
            tabla[i, 0] = i; // columna 0
        }
        // calcular el resto usando posiciones disponibles
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                tabla[i, j] = tabla[i, 0] * tabla[0, j]; // i * j
            }
        }

        // Mostrar matriz
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 10; c++)
                Console.Write($"{tabla[r, c],3} ");
            Console.WriteLine();
        }
        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 8.
    static void Ejercicio8()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 8 - Buscar X en matriz 10x10");

        int n = 10;
        char[,] tablero = new char[n, n];
        for (int r = 0; r < n; r++)
            for (int c = 0; c < n; c++)
                tablero[r, c] = '*'; // por defecto no hay X

        Random rnd = new Random();
        int maxX = 30; // cantidad elegida por programador (no más de la mitad -> 100/2=50). Elegí 30.
        int colocadas = 0;
        HashSet<(int, int)> posicionesX = new HashSet<(int, int)>();
        while (colocadas < maxX)
        {
            int r = rnd.Next(0, n);
            int c = rnd.Next(0, n);
            if (!posicionesX.Contains((r, c)))
            {
                posicionesX.Add((r, c));
                // no las mostramos (seguirá siendo '*'), solo guardamos dónde están
                colocadas++;
            }
        }

        Console.WriteLine($"Se ocultaron {colocadas} 'X' en la matriz. Debes adivinarlas.");
        Console.WriteLine("Tenés 3 intentos para fallar (es decir, 3 errores).");

        int errores = 0;
        int acertadas = 0;
        HashSet<(int, int)> acertadasSet = new HashSet<(int, int)>();

        while (errores < 3 && acertadas < colocadas)
        {
            Console.Write($"Ingresá fila (1-{n}): ");
            if (!int.TryParse(Console.ReadLine(), out int fila) || fila < 1 || fila > n)
            {
                Console.WriteLine("Fila inválida.");
                continue;
            }
            Console.Write($"Ingresá columna (1-{n}): ");
            if (!int.TryParse(Console.ReadLine(), out int col) || col < 1 || col > n)
            {
                Console.WriteLine("Columna inválida.");
                continue;
            }
            var guess = (fila - 1, col - 1);
            if (acertadasSet.Contains(guess))
            {
                Console.WriteLine("Ya habías acertado esa posición antes.");
                continue;
            }

            if (posicionesX.Contains(guess))
            {
                acertadas++;
                acertadasSet.Add(guess);
                Console.WriteLine("¡Acierto!");
            }
            else
            {
                errores++;
                Console.WriteLine($"Fallo. Errores: {errores}/3");
            }
            Console.WriteLine($"Acertadas: {acertadas}/{colocadas}. Quedan intentos de fallo: {3 - errores}");
        }

        Console.WriteLine("\nJuego finalizado.");
        // Revelar matriz: mostrar 'X' donde estaban, '*' donde no
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (posicionesX.Contains((r, c))) Console.Write(" X ");
                else Console.Write(" * ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 9.
    static void Ejercicio9()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 9 - Diccionario de calificaciones");
        Dictionary<string, double> notas = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

        while (true)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1 - Agregar alumno y nota");
            Console.WriteLine("2 - Mostrar promedio general del curso");
            Console.WriteLine("3 - Alumno con mejor y peor nota");
            Console.WriteLine("4 - Mostrar todos los alumnos y notas");
            Console.WriteLine("0 - Volver al menú principal");
            Console.Write("Elige: ");
            string o = Console.ReadLine();
            if (o == "0") break;
            if (o == "1")
            {
                Console.Write("Nombre alumno: ");
                string nombre = Console.ReadLine().Trim();
                double nota;
                while (true)
                {
                    Console.Write("Nota (número): ");
                    if (double.TryParse(Console.ReadLine(), out nota)) break;
                    Console.WriteLine("Nota inválida.");
                }
                notas[nombre] = nota;
                Console.WriteLine("Alumno agregado/actualizado.");
            }
            else if (o == "2")
            {
                if (notas.Count == 0) Console.WriteLine("No hay alumnos.");
                else
                {
                    double prom = notas.Values.Average();
                    Console.WriteLine($"Promedio general: {prom:0.##}");
                }
            }
            else if (o == "3")
            {
                if (notas.Count == 0) Console.WriteLine("No hay alumnos.");
                else
                {
                    var mejor = notas.Aggregate((l, r) => l.Value > r.Value ? l : r);
                    var peor = notas.Aggregate((l, r) => l.Value < r.Value ? l : r);
                    Console.WriteLine($"Mejor nota: {mejor.Key} - {mejor.Value:0.##}");
                    Console.WriteLine($"Peor nota: {peor.Key} - {peor.Value:0.##}");
                }
            }
            else if (o == "4")
            {
                if (notas.Count == 0) Console.WriteLine("No hay alumnos.");
                else
                    foreach (var kv in notas)
                        Console.WriteLine($"{kv.Key} -> {kv.Value:0.##}");
            }
            else Console.WriteLine("Opción inválida.");
        }
    }

    // 10.
    static void Ejercicio10()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 10 - Simulador de atención en ventanilla (Queue)");
        Queue<string> fila = new Queue<string>();
        Console.WriteLine("Ingrese nombres de clientes a encolar (dejar vacío para terminar):");
        while (true)
        {
            Console.Write("Nombre cliente: ");
            string s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) break;
            fila.Enqueue(s.Trim());
        }

        Console.WriteLine($"\nHay {fila.Count} clientes en la fila. Comenzando atención...");
        while (fila.Count > 0)
        {
            var atendido = fila.Dequeue();
            Console.WriteLine($"Atendiendo a: {atendido}. Quedan {fila.Count} en la fila.");
            Console.WriteLine("Presiona Enter para atender al siguiente...");
            Console.ReadLine();
        }
        Console.WriteLine("No quedan más clientes. Presiona Enter para volver al menú...");
        Console.ReadLine();
    }

    // 11. Opcional: inventario con List, Dictionary, Stack
    static void Ejercicio11()
    {
        Console.Clear();
        Console.WriteLine("Ejercicio 11 - Inventario básico (List, Dictionary, Stack)");
        List<string> productos = new List<string>();
        Dictionary<string, int> stock = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        Stack<string> historial = new Stack<string>();

        while (true)
        {
            Console.WriteLine("\nOpciones inventario:");
            Console.WriteLine("1 - Agregar producto y cantidad");
            Console.WriteLine("2 - Vender producto (restar stock)");
            Console.WriteLine("3 - Mostrar inventario actual");
            Console.WriteLine("4 - Mostrar últimas 3 acciones");
            Console.WriteLine("0 - Volver al menú principal");
            Console.Write("Elige: ");
            string op = Console.ReadLine();
            if (op == "0") break;

            if (op == "1")
            {
                Console.Write("Nombre producto: ");
                string p = Console.ReadLine().Trim();
                int q;
                while (true)
                {
                    Console.Write("Cantidad a agregar: ");
                    if (int.TryParse(Console.ReadLine(), out q) && q > 0) break;
                    Console.WriteLine("Cantidad inválida.");
                }
                if (!productos.Contains(p, StringComparer.OrdinalIgnoreCase))
                    productos.Add(p);
                if (stock.ContainsKey(p)) stock[p] += q;
                else stock[p] = q;
                historial.Push($"Agregar {q} x {p} ({DateTime.Now})");
                Console.WriteLine("Producto agregado.");
            }
            else if (op == "2")
            {
                Console.Write("Producto a vender: ");
                string p = Console.ReadLine().Trim();
                if (!stock.ContainsKey(p) || stock[p] <= 0)
                {
                    Console.WriteLine("Producto no disponible o sin stock.");
                }
                else
                {
                    int q;
                    while (true)
                    {
                        Console.Write("Cantidad a vender: ");
                        if (int.TryParse(Console.ReadLine(), out q) && q > 0) break;
                        Console.WriteLine("Cantidad inválida.");
                    }
                    if (q > stock[p])
                    {
                        Console.WriteLine($"Stock insuficiente. Hay {stock[p]} disponible.");
                    }
                    else
                    {
                        stock[p] -= q;
                        historial.Push($"Vender {q} x {p} ({DateTime.Now})");
                        Console.WriteLine("Venta realizada.");
                    }
                }
            }
            else if (op == "3")
            {
                Console.WriteLine("\nInventario actual:");
                foreach (var prod in productos)
                {
                    int s = stock.ContainsKey(prod) ? stock[prod] : 0;
                    Console.WriteLine($"- {prod}: {s}");
                }
            }
            else if (op == "4")
            {
                Console.WriteLine("\nÚltimas 3 acciones:");
                var last3 = historial.Take(3).ToList();
                if (!last3.Any()) Console.WriteLine("(No hay acciones registradas)");
                else
                {
                    foreach (var a in last3) Console.WriteLine($"- {a}");
                }
            }
            else Console.WriteLine("Opción inválida.");
        }
    }
}
