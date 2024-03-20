namespace edu.Ejercicio5._1903
{
    internal class Program
    {
        static string rutaArchivo = "C:\\Users\\Carlos\\Desktop\\Cs1\\PROGRAMACION\\ficheroParaActividades\\archivoEjercicio5.txt";

        static void Main(string[] args)
        {
            

            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                sw.WriteLine("Un libro (del latín liber, libri) es una obra impresa, manuscrita o pintada en una serie de hojas de papel, pergamino,");
                sw.WriteLine("vitela u otro material, unidas por un lado (es decir, encuadernadas) y protegidas con tapas, también llamadas cubiertas.");
                sw.WriteLine("Un libro puede tratar sobre cualquier tema. Según la definición de la Unesco,1​2​ un libro debe poseer veinticinco hojas");
                sw.WriteLine("mínimo (49 páginas), pues de veinticuatro hojas o menos sería un folleto; y de una hasta cuatro páginas se consideran");
                sw.WriteLine("hojas sueltas (en una o dos hojas).");

            }
            using (StreamReader sr = new StreamReader(rutaArchivo))
            {
                string contenido = sr.ReadToEnd();
                Console.WriteLine("Contenido del archivo:\n" + contenido);
            }


            Console.WriteLine("-----------------------------------------------------------------------");


            bool cerrarMenu = false;
            int opcionUsuario;

            do
            {
                opcionUsuario = menuYSeleccion();
                switch(opcionUsuario) {
                    case 0:
                        Console.WriteLine("Has seleccionado cerrar menu");
                        cerrarMenu = true;
                        break;
                    case 1:
                        Console.WriteLine("Has seleccionado modificar línea especifica");
                        modificarLinea();
                        break;

                    case 2:
                        Console.WriteLine("Has seleccionado insertar texto en posición especifica");
                        textoPosicion();
                        break ;

                    default:
                        Console.WriteLine("La opción seleccionada no corresponde con niguna");
                        break;
                }

            } while (!cerrarMenu);


        }
        static private int menuYSeleccion()
        {
            int opcionUsuario;
            Console.WriteLine("0.Cerrar Menu");
            Console.WriteLine("1.Modificar línea especifica");
            Console.WriteLine("2.Insertar texto en posición especifica");
            opcionUsuario = Convert.ToInt32(Console.ReadLine());
            return opcionUsuario;
        }

        static private void modificarLinea() 
        {
            Console.WriteLine("Introduce la línea que quieres modificar");
            int numLinea = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce el texto");
            string textoUsuario = Console.ReadLine();

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (numLinea >= 1 && numLinea <= lineas.Length)
                {
                    lineas[numLinea - 1] = textoUsuario;

                    File.WriteAllLines(rutaArchivo, lineas);

                    Console.WriteLine("El texto se ha introducido correctamente");
                }
                else
                {
                    Console.WriteLine("El numero de la línea introducido no corresponde con el texto");

                }
            }catch(IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }

        }
        static private void textoPosicion()
        {
            Console.WriteLine("Introduce la línea donde quieres introducir el texto");
            int numLinea = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce la posición donde quieres introducir el texto");
            int posicion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce el texto");
            string textoUsuario = Console.ReadLine();

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (numLinea >= 1 && numLinea <= lineas.Length)
                {
                    string linea = lineas[numLinea - 1];

                    if(posicion >= 0 && posicion <= linea.Length)
                    {
                        string nuevaLinea = linea.Insert(posicion, textoUsuario);

                        lineas[numLinea - 1] = nuevaLinea;

                        File.WriteAllLines(rutaArchivo, lineas);

                        Console.WriteLine("El texto se ha introducido correctamente");
                    }
                    else
                    {
                        Console.WriteLine("La posicion indicada no corresponde con la línea indicada");
                    }
                                       
                }
                else
                {
                    Console.WriteLine("El numero de la línea introducido no corresponde con el texto");

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }

        }
    }
}
