/// <summary>
/// TAREA: Clase No.5 Archivos Secuenciales Ejemplo Aplicación
/// AUTOR: Mario Joel Monroy Canizales
/// CARNET: 0900 16 3378
/// </summary>

namespace ProgramaArchivos
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo op;
            Program lObjProceso = new Program();

            do
            {
                lObjProceso.SubMenuPrincipal();

                op = Console.ReadKey(true); // Que no muestre la tecla señalada
                Console.WriteLine(op.Key);
                //métodos son acciones, las propiedades son valores

                switch (op.Key)
                {
                    case ConsoleKey.NumPad1 or ConsoleKey.D1:
                        lObjProceso.SubAgregarPuesto();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad2 or ConsoleKey.D2:
                        lObjProceso.SubAgregarEmpleado();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad3 or ConsoleKey.D3:
                        lObjProceso.SubListarInformacionArchivo();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad4 or ConsoleKey.D4:
                        lObjProceso.SubProcesoAumentoSalario();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad5 or ConsoleKey.D5:
                        lObjProceso.SubModificarEmpleado();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad6 or ConsoleKey.D6:
                        lObjProceso.SubEliminarEmpleado();
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.NumPad7 or ConsoleKey.D7:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("SALIENDO DEL SISTEMA.");
                        break;

                }
            } while ((op.Key != ConsoleKey.Escape));
        }

        public struct PuestoTrabajo
        {
            public int lIntPuesto;
            public string lStrNombrePUesto;
            public double lDblSueldo;
        }

        static List<PuestoTrabajo> FncObtienePuesto()
        {
            String lstrCadena = string.Empty;
            var lObjResultado = new List<PuestoTrabajo>();
            PuestoTrabajo lObjPuesto;

            if (File.Exists("d:/puestos.txt"))
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream fs = new FileStream("d:/puestos.txt", FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        while ((lstrCadena = sr.ReadLine()) != null)
                        {
                            String[] lStrConjuntoDatos = lstrCadena.Split('|');

                            lObjPuesto.lIntPuesto = int.Parse(lStrConjuntoDatos[0]);
                            lObjPuesto.lStrNombrePUesto = Convert.ToString(lStrConjuntoDatos[1]);
                            lObjPuesto.lDblSueldo = double.Parse(lStrConjuntoDatos[2]);

                            lObjResultado.Add(lObjPuesto);
                        }

                    }
                }
            }

            return lObjResultado;
        }

        public void SubMenuPrincipal()
        {
            Console.Clear(); //Limpiar la pantalla
            Console.Title = "CLASE NO.6 EJERCICIO DE MENUS Y ARCHIVOS"; // Titulo de la pantalla.
            string StrTitulo = "CLASE NO.6 EJERCICIO DE MENUS Y ARCHIVOS";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 3); Console.WriteLine("CURSO: PROGRAMACIÓN 1 ");
            Console.SetCursorPosition(30, 4); Console.WriteLine("NOMBRE: MARIO JOEL MONROY CANIZALES");
            Console.SetCursorPosition(30, 5); Console.WriteLine("CARNET: 0900-16-3378");
            Console.SetCursorPosition(30, 6); Console.WriteLine("SECCION: B \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));

            StrTitulo = "MENU PRINCIPAL - EJERCICIO #2";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(30, 12); Console.WriteLine("    1. ALTA PUESTO");
            Console.SetCursorPosition(30, 13); Console.WriteLine("    2. ALTA EMPLEADO");
            Console.SetCursorPosition(30, 14); Console.WriteLine("    3. VER PLANILLA SUELDO");
            Console.SetCursorPosition(30, 15); Console.WriteLine("    4. INCREMENTO 5% SUELDO");
            Console.SetCursorPosition(30, 16); Console.WriteLine("    5. MODIFICAR DATOS EMPLEADO");
            Console.SetCursorPosition(30, 17); Console.WriteLine("    6. ELIMINAR EMPLEADO");
            Console.SetCursorPosition(30, 18); Console.WriteLine("    7. SALIR [Esc] \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));
            Console.SetCursorPosition(30, 20); Console.WriteLine("   ELIJA EL NÚMERO DE OPCIÓN [ _ ]          ");
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 115)));
            Console.SetCursorPosition(61, 20);
        }

        public void SubAgregarPuesto()
        {
            string lStrInformacion = string.Empty;
            string lstrCadena = string.Empty;
            int lintIdPuesto = 0;
            Boolean lblnContinuaIngresando = true;
            string lStrDeseaContinuar = string.Empty;
            string lStrNombre = string.Empty;
            double lDblSueldo = 0;
            string lStrSeparador = "|";
            Console.Clear();

            try
            {
                if (File.Exists("d:/puestos.txt"))
                {
                    using (Stream ms = new MemoryStream())
                    {
                        using (Stream fs = new FileStream("d:/puestos.txt", FileMode.Open, FileAccess.Read))
                        {
                            fs.CopyTo(ms);
                        }

                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            while ((lstrCadena = sr.ReadLine()) != null)
                            {
                                string[] lStrConjuntoDatos = lstrCadena.Split('|');
                                lintIdPuesto = int.Parse(lStrConjuntoDatos[0]);
                            }
                            lintIdPuesto++;
                        }
                    }
                }
                else
                {
                    lintIdPuesto = 1;
                }

                if (lintIdPuesto != 0)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream("d:/puestos.txt", FileMode.Append)))
                    {
                        while (lblnContinuaIngresando == true)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 3);
                            string StrTitulo = "INFORMACION A COMPLETAR DEL PUESTO";
                            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop);
                            Console.WriteLine(StrTitulo);

                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("Datos Generales");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 8); Console.WriteLine("ID PUESTO:            ");
                            Console.SetCursorPosition(35, 9); Console.WriteLine("NOMBRE PUESTO:        ");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 13); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 15); Console.WriteLine("SALARIO:             ");
                            Console.SetCursorPosition(25, 17); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lintIdPuesto).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 15); lDblSueldo = double.Parse(Console.ReadLine());

                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO DATOS [S/N]:      ");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                            sw.Write(Convert.ToString(lintIdPuesto).PadRight(4, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrNombre.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.WriteLine(Convert.ToString(lDblSueldo).PadLeft(10, '0'));

                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lblnContinuaIngresando = false;
                            }
                            lintIdPuesto += 1;
                        }
                        sw.Close();
                        Console.Write("Presione una tecla para continuar");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en interaccion con archivo" + e.Message);
            }

        }

        public static bool FncValidaPuesto(int pIntPuesto)
        {
            bool lBlnResultado = false;
            string lstrCadena = string.Empty;
            int lintPuestoRevision = 0;

            if (File.Exists("d:/puestos.txt"))
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream fs = new FileStream("d:/puestos.txt", FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        bool lBlnSeguir = false;
                        while((lstrCadena = sr.ReadLine()) != null && (lBlnSeguir == false))
                        {
                            String[] lStrConjuntoDatos = lstrCadena.Split('|');
                            lintPuestoRevision = int.Parse(lStrConjuntoDatos[0]);
                            if (lintPuestoRevision == pIntPuesto)
                            {
                                lBlnResultado = true;
                                lBlnSeguir = true;
                            }

                        }
                    }
                }
            } else
            {
                lBlnResultado = false;
            }
            return lBlnResultado;
        }

        public void SubAgregarEmpleado()
        {
            string lStrInformacion = string.Empty;
            String lstrCadena = string.Empty;
            int lintIdEmpleado = 0;
            int lintIdPuesto = 0;
            Boolean lblnContinuarIngresando = true;
            String lStrDeseaContinuar = string.Empty;
            string lStrNombre = string.Empty;
            string lStrDireccion = string.Empty;
            string lStrTelefono = string.Empty;
            string lStrSeparador = "|";
            Console.Clear();

            try
            {
                if (File.Exists("d:/empleado.txt"))
                {
                    using (Stream ms = new MemoryStream())
                    {
                        using (Stream fs = new FileStream("d:/empleado.txt", FileMode.Open, FileAccess.Read))
                        {
                            fs.CopyTo(ms);
                        }

                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            while((lstrCadena = sr.ReadLine()) != null)
                            {
                                String[] lStrConjuntoDatos = lstrCadena.Split('|');
                                lintIdEmpleado = int.Parse(lStrConjuntoDatos[0]);
                            }
                            lintIdEmpleado += 1;
                        }
                    }
                } else
                {
                    lintIdEmpleado = 1;
                }

                if (lintIdEmpleado != 0)
                {
                    using(StreamWriter sw = new StreamWriter(new FileStream("d:/empleado.txt", FileMode.Append)))
                    {
                        while(lblnContinuarIngresando == true)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 3);
                            string StrTitulo = "INFORMACION A COMPLETAR DEL EMPLEADO";
                            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop);
                            Console.WriteLine(StrTitulo);

                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 8); Console.WriteLine("ID EMPLEADO:  ");
                            Console.SetCursorPosition(35, 9); Console.WriteLine("NOMBRE EMPLEADO:  ");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION:   ");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO:   ");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 13); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 15); Console.WriteLine("ID PUESTO");
                            Console.SetCursorPosition(25, 17); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 10); lStrDireccion = Console.ReadLine();
                            Console.SetCursorPosition(70, 11); lStrTelefono = Console.ReadLine();
                            Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());

                            bool blnValidar = false;
                            blnValidar = FncValidaPuesto(lintIdPuesto);

                            while(blnValidar == false)
                            {
                                Console.SetCursorPosition(35, 22); Console.WriteLine("EL ID NO EXISTE");
                                Console.SetCursorPosition(70, 15); Console.WriteLine("      ");
                                Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                                blnValidar = FncValidaPuesto(lintIdPuesto);
                            }

                            sw.Write(Convert.ToString(lintIdEmpleado).PadRight(4, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrNombre.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrDireccion.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrTelefono.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.WriteLine(Convert.ToString(lintIdPuesto).PadRight(4, ' '));

                            lintIdEmpleado += 1;
                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS [S/N]:  ");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lblnContinuarIngresando = false;
                            }
                        }
                        sw.Close();
                        Console.Write("PRESIONE UNA TECLA PARA CONTINUAR");
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("ERROR INTERACCION CON ARCHIVO" + e.Message);
            }
        }

        public void SubListarInformacionArchivo()
        {
            Console.Clear(); //Limpiar la pantalla

            try
            {
                // ABRIENDO EL ARCHIVO
                using (var sr = new StreamReader("d:/empleado.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "PLANILLA LABORAL";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "DETALLE DE INFORMACION";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine("DETALLE DE INFORMACION");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(5, 8); Console.WriteLine("NOMBRE EMPLEADO                NOMBRE PUESTO       SUELDO       CUOTA PATRONAL   SUELDO LIQUIDO");

                    List<PuestoTrabajo> lobjPuestos = FncObtienePuesto();

                    while ((lstrCadena = sr.ReadLine()) != null)
                    {

                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        String lStrPuesto = string.Empty;

                        double lDblCuotaPatronal = 0.00;
                        double lDblSalarioLiquido = 0.00;
                        Console.SetCursorPosition(5, lIntLinea); Console.Write(lStrConjuntoDatos[1]);

                        foreach (PuestoTrabajo lObjPuesto in lobjPuestos)
                        {
                            if (lObjPuesto.lIntPuesto == int.Parse(lStrConjuntoDatos[4]))
                            {
                                Console.SetCursorPosition(37, lIntLinea); Console.Write(lObjPuesto.lStrNombrePUesto);
                                Console.SetCursorPosition(57, lIntLinea); Console.Write(lObjPuesto.lDblSueldo.ToString("N2"));
                                lDblCuotaPatronal = lObjPuesto.lDblSueldo * 0.0483;
                                lDblSalarioLiquido = lObjPuesto.lDblSueldo - lDblCuotaPatronal;
                                Console.SetCursorPosition(70, lIntLinea); Console.Write(lDblCuotaPatronal.ToString("N2"));
                                Console.SetCursorPosition(90, lIntLinea); Console.Write(lDblSalarioLiquido.ToString("N2"));
                                lIntLinea += 1;
                                break;
                            }
                        }
                    }
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }

                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");

            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }

        public void SubProcesoAumentoSalario()
        {
            Console.Clear(); //Limpiar la pantalla

            try
            {
                // ABRIENDO EL ARCHIVO
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                using (var sr = new StreamReader("d:/puestos.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    lObjArchivoFinal = File.CreateText("d:/temp.txt");
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "PLANILLA LABORAL";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "AUMENTO SALARIO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine("DETALLE DE INFORMACION");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(5, 8); Console.WriteLine(" ID        NOMBRE PUESTO       SUELDO ACTUAL    AUMENTO   SALARIO NUEVO");

                    while ((lstrCadena = sr.ReadLine()) != null)
                    {

                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        double lDblAumento;
                        double lDblSalarioNuevo;
                        Console.SetCursorPosition(5, lIntLinea); Console.Write(lStrConjuntoDatos[0]);
                        Console.SetCursorPosition(15, lIntLinea); Console.Write(lStrConjuntoDatos[1]);
                        lDblAumento = double.Parse(lStrConjuntoDatos[2]) * 0.05;
                        lDblSalarioNuevo = double.Parse(lStrConjuntoDatos[2]) + lDblAumento;
                        Console.SetCursorPosition(38, lIntLinea); Console.Write(double.Parse(lStrConjuntoDatos[2]).ToString("N2"));
                        Console.SetCursorPosition(56, lIntLinea); Console.Write(lDblAumento.ToString("N2"));
                        Console.SetCursorPosition(67, lIntLinea); Console.Write(lDblSalarioNuevo.ToString("N2"));
                        lObjArchivoFinal.Write(Convert.ToString(lStrConjuntoDatos[0]).PadRight(4, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.Write(lStrConjuntoDatos[1].PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.WriteLine(Convert.ToString(lDblSalarioNuevo).PadLeft(10, '0'));
                        lIntLinea += 1;

                    }
                    sr.Close();
                    lObjArchivoFinal.Close();
                    File.Delete("d:/puestos.txt");
                    File.Move("d:/temp.txt", "d:/puestos.txt");
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }

                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");
            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }

        public void SubModificarEmpleado()
        {
            Console.Clear(); //Limpiar la pantalla

            try
            {
                // ABRIENDO EL ARCHIVO
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                int lIntCodigoEmpleado = 0;
                using (var sr = new StreamReader("d:/empleado.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    lObjArchivoFinal = File.CreateText("d:/tempemp.txt");
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "MANTENIMIENTOS DE DATOS DEL EMPLEADO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "INGRESAR DATO A MODIFICAR";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.SetCursorPosition(7, 6); Console.WriteLine("INGRESE EL NUMERO EMPLEADO A MODIFICAR:                        [             ]");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(75, 6); lIntCodigoEmpleado = int.Parse(Console.ReadLine());


                    while ((lstrCadena = sr.ReadLine()) != null)
                    {

                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        if (int.Parse(lStrConjuntoDatos[0]) == lIntCodigoEmpleado)
                        {
                            string lStrNombre = string.Empty;
                            string lStrDireccion = string.Empty;
                            string lStrTelefono = string.Empty;

                            Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO    :            [                                          ]");
                            Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO:            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntCodigoEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); Console.WriteLine(lStrConjuntoDatos[1]);
                            Console.SetCursorPosition(70, 10); Console.WriteLine(lStrConjuntoDatos[2]);
                            Console.SetCursorPosition(70, 11); Console.WriteLine(lStrConjuntoDatos[3]);

                            Console.SetCursorPosition(5, 13); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 14); Console.WriteLine("MODIFICACION DE DATOS");
                            Console.SetCursorPosition(5, 15); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 17); Console.WriteLine("NOMBRE EMPLEADO :           [                                          ]");
                            Console.SetCursorPosition(35, 18); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 19); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 20); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));

                            Console.SetCursorPosition(70, 17); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 18); lStrDireccion = Console.ReadLine();
                            Console.SetCursorPosition(70, 19); lStrTelefono = Console.ReadLine();

                            lObjArchivoFinal.Write(Convert.ToString(lIntCodigoEmpleado).PadRight(4, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrNombre.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrDireccion.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrTelefono.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.WriteLine(Convert.ToString(lStrConjuntoDatos[4]).PadRight(4, ' '));
                        }
                        else
                        {
                            lObjArchivoFinal.WriteLine(lstrCadena);
                        }
                    }
                    sr.Close();
                    lObjArchivoFinal.Close();
                    File.Delete("d:/empleado.txt");
                    File.Move("d:/tempemp.txt", "d:/empleado.txt");
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }

                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");
            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }

        public void SubEliminarEmpleado()
        {
            Console.Clear(); //Limpiar la pantalla

            try
            {
                // ABRIENDO EL ARCHIVO
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                int lIntCodigoEmpleado = 0;
                using (var sr = new StreamReader("d:/empleado.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    lObjArchivoFinal = File.CreateText("d:/tempemp.txt");
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "ELIMINACION DE DATOS DEL EMPLEADO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "INGRESAR DATO A ELIMINAR";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.SetCursorPosition(7, 6); Console.WriteLine("INGRESE EL NUMERO EMPLEADO A ELIMINAR:                        [             ]");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(75, 6); lIntCodigoEmpleado = int.Parse(Console.ReadLine());

                    string lStrDeseaEliminar = string.Empty;
                    while ((lstrCadena = sr.ReadLine()) != null)
                    {
                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        if (int.Parse(lStrConjuntoDatos[0]) == lIntCodigoEmpleado)
                        {
                            Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO    :            [                                          ]");
                            Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO:            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntCodigoEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); Console.WriteLine(lStrConjuntoDatos[1]);
                            Console.SetCursorPosition(70, 10); Console.WriteLine(lStrConjuntoDatos[2]);
                            Console.SetCursorPosition(70, 11); Console.WriteLine(lStrConjuntoDatos[3]);

                            Console.SetCursorPosition(25, 13); Console.WriteLine("DESEA CONTINUAR CON LA ELIMINACION DEL  REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(88, 13); lStrDeseaEliminar = Console.ReadLine();
                            if (lStrDeseaEliminar.ToUpper() == "S")
                            {
                                Console.SetCursorPosition(40, 13); Console.WriteLine("                                                                                 ");
                                Console.SetCursorPosition(40, 13); Console.WriteLine("EL REGISTRO FUE ELIMINADO.");
                            }
                            else
                            {
                                lObjArchivoFinal.WriteLine(lstrCadena);
                            }
                        }
                        else
                        {
                            lObjArchivoFinal.WriteLine(lstrCadena);
                        }
                    }
                    sr.Close();
                    lObjArchivoFinal.Close();
                    File.Delete("d:/empleado.txt");
                    File.Move("d:/tempemp.txt", "d:/empleado.txt");
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }

                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");
            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }
    }
}
