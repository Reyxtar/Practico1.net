using DataAccessLayer.DAL;
using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mi primera app");

        List<Persona> list = new List<Persona>();
        IDAL_Persona dalPersona = new DAL_Persona();

        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Nueva Persona");
                Persona per = new Persona();
                Console.Write("Nombre: ");
                per.nombre = Console.ReadLine();
                Console.Write("Apellido: ");
                per.apellido = Console.ReadLine();
                Console.Write("Documento: ");
                per.Documento = Console.ReadLine();
                Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
                per.fechaNac = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);

                dalPersona.Insert(per); // Agregar persona a la lista

                Console.WriteLine("Persona");
                Console.WriteLine("      Documento: " + per.Documento);
                Console.WriteLine("      Nombre: " + per.nombre);
                Console.WriteLine("      Apellido: " + per.apellido);
                Console.WriteLine("      Fecha de Nacimiento: " + per.fechaNac.ToString("yyyy-MM-dd"));
                Console.WriteLine("Presione ENTER para continuar o escriba 'EXIT' para terminar de agregar personas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        } while (!Console.ReadLine().Equals("EXIT"));

        // Obtener personas ordenadas por fecha de nacimiento y mostrarlas
        List<Persona> personasOrdenadas = dalPersona.GetPersonas().OrderBy(p => p.fechaNac).ToList();
        Console.Clear();
        Console.WriteLine("Personas Ordenadas por Fecha de Nacimiento:");
        foreach (var persona in personasOrdenadas)
        {
            Console.WriteLine($"Nombre: {persona.nombre}, Apellido: {persona.apellido}, Documento: {persona.Documento}, Fecha de Nacimiento: {persona.fechaNac.ToString("yyyy-MM-dd")}");
        }
    }
}
